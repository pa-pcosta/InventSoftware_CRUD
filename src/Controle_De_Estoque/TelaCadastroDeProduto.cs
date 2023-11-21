using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Controle_De_Estoque
{
    public partial class TelaCadastroDeProduto : Form
    {
        ProdutoTapecaria _novoProdutoTapecaria;

        private static int _ultimoIdUtilizado = 0;

        public TelaCadastroDeProduto(ProdutoTapecaria novoProdutoTapecaria)
        {
            InitializeComponent();
            InicializaCampos();

            _novoProdutoTapecaria = novoProdutoTapecaria;
        }

        private void InicializaCampos()
        {
            dateTimePickerDataEntrada.Value = DateTime.Today;

            comboBoxTipo.Items.AddRange(Enum.GetNames(typeof(TipoTapecaria)));

            AplicarEventos(textBoxPrecoMetroQuadrado);
            AplicarEventos(textBoxArea);
        }

        public void AoClicarEmSalvar(object sender, EventArgs e)
        {
            try
            {
                ValidacaoProdutoTapecaria produtoAValidar = new ValidacaoProdutoTapecaria()
                {
                    Tipo = comboBoxTipo.SelectedIndex.ToString(),
                    DataEntrada = dateTimePickerDataEntrada.Value.ToString(),
                    Area = textBoxArea.Text,
                    PrecoMetroQuadrado = textBoxPrecoMetroQuadrado.Text
                };

                var listaDeErros = produtoAValidar.ValidarProduto();

                if (!listaDeErros.Any())
                {
                    AtribuiAoProdutoTapecaria();

                    DialogResult = DialogResult.OK;

                    Close();
                }
                else
                {
                    MessageBox.Show(string.Join("\r", listaDeErros), "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtribuiAoProdutoTapecaria()
        { 
            _novoProdutoTapecaria.Id = ObterProximoId();
            _novoProdutoTapecaria.Tipo = (TipoTapecaria)comboBoxTipo.SelectedIndex; ;
            _novoProdutoTapecaria.DataEntrada = dateTimePickerDataEntrada.Value;
            _novoProdutoTapecaria.Area = Convert.ToDouble(textBoxArea.Text);
            _novoProdutoTapecaria.PrecoMetroQuadrado = Convert.ToDecimal(textBoxPrecoMetroQuadrado.Text);
            _novoProdutoTapecaria.EhEntrega = checkBoxEntregarAposServico.Checked;
            _novoProdutoTapecaria.Detalhes = textBoxDetalhes.Text;
        }

        private int ObterProximoId()
        {
            return ++_ultimoIdUtilizado;
        }

        private void AoClicarEmCancelar(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void textBoxPrecoMetroQuadrado_KeyPress(object sender, KeyPressEventArgs e)
        {
            string tecla = e.KeyChar.ToString();
            var ehValido = Regex.IsMatch(tecla, "[0-9]|[\b]|[,]");
            var ehVirgula = Regex.IsMatch(tecla, ",");
            var posicaoDaVirgula = textBoxPrecoMetroQuadrado.Text.IndexOf(',');
            var naoExisteOcorrencia = -1;

            if (!ehValido)
            {
                e.Handled = true;
            }

            if (ehVirgula && posicaoDaVirgula != naoExisteOcorrencia)
            {
                e.Handled = true;
            }
        }

        private void textBoxArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            string tecla = e.KeyChar.ToString();
            var ehValido = Regex.IsMatch(tecla, "[0-9]|[\b]|[,]");
            var ehVirgula = Regex.IsMatch(tecla, ",");
            var posicaoDaVirgula = textBoxArea.Text.IndexOf(',');
            var naoExisteOcorrencia = -1;

            if (!ehValido)
            {
                e.Handled = true;
            }

            if (ehVirgula && posicaoDaVirgula != naoExisteOcorrencia)
            {
                e.Handled = true;
            }
        }

        private void RetornarMascara(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox txt = (System.Windows.Forms.TextBox)sender;
            if (!String.IsNullOrEmpty(txt.Text))
            {
                txt.Text = decimal.Parse(txt.Text).ToString("N2");
            }
        }

        private void TirarMascara(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox txt = (System.Windows.Forms.TextBox)sender;
            txt.Text = txt.Text.Trim();
        }

        private void AplicarEventos(System.Windows.Forms.TextBox txt)
        {
            txt.Enter += TirarMascara;
            txt.Leave += RetornarMascara;
            //txt.KeyPress += ApenasValorNumerico;
        }
    }
}
