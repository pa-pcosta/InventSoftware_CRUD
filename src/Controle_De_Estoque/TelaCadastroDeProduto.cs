using System;
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
        }

        public void AoClicarEmSalvar(object sender, EventArgs e)
        {
            try
            {
                ValidacaoProdutoTapecaria validacaoProdutoTapecaria = new ValidacaoProdutoTapecaria(this);
                var mensagemErro = validacaoProdutoTapecaria.ValidarProduto();

                if (mensagemErro == string.Empty)
                {
                    AtribuiAoProdutoTapecaria();

                    DialogResult = DialogResult.OK;

                    Close();
                }
                else
                {
                    MessageBox.Show(mensagemErro, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var ehValido = Regex.IsMatch(tecla, "[0-9]|[\b]|[.,]");
            var ehPontoOuVirgula = Regex.IsMatch(tecla, "[.,]");
            var posicaoDoPonto = textBoxPrecoMetroQuadrado.Text.IndexOf('.');
            var posicaoDaVirgula = textBoxPrecoMetroQuadrado.Text.IndexOf(',');
            var naoExisteOcorrencia = -1;

            if (!ehValido)
            {
                e.Handled = true;
            }

            if (ehPontoOuVirgula && (posicaoDoPonto != naoExisteOcorrencia || posicaoDaVirgula != naoExisteOcorrencia))
            {
                e.Handled = true;
            }
        }

        private void textBoxArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            string tecla = e.KeyChar.ToString();
            var ehValido = Regex.IsMatch(tecla, "[0-9]|[\b]|[.,]");
            var ehPontoOuVirgula = Regex.IsMatch(tecla, "[.,]");
            var posicaoDoPonto = textBoxPrecoMetroQuadrado.Text.IndexOf('.');
            var posicaoDaVirgula = textBoxPrecoMetroQuadrado.Text.IndexOf(',');
            var naoExisteOcorrencia = -1;

            if (!ehValido)
            {
                e.Handled = true;
            }

            if (ehPontoOuVirgula && (posicaoDoPonto != naoExisteOcorrencia || posicaoDaVirgula != naoExisteOcorrencia))
            {
                e.Handled = true;
            }
        }
    }
}
