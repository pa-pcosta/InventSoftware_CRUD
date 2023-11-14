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
                validacaoProdutoTapecaria.ValidarProduto();

                if (validacaoProdutoTapecaria.RetornaListaDeErros() == string.Empty)
                {
                    AtribuiAoProdutoTapecaria();

                    DialogResult = DialogResult.OK;

                    Close();
                }
                else
                {
                    MessageBox.Show(validacaoProdutoTapecaria.RetornaListaDeErros(), "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                //mostrarmodalde mensagem de erro
                throw;
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
                throw;
            }
        }

        private void textBoxPrecoMetroQuadrado_KeyPress(object sender, KeyPressEventArgs e)
        {
            char tecla = e.KeyChar;
            
            if (tecla == 46 && textBoxPrecoMetroQuadrado.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
            }

            if (tecla == 46 && textBoxPrecoMetroQuadrado.Text.IndexOf(',') != -1)
            {
                e.Handled = true;
            }

            if (!Char.IsDigit(tecla) && tecla != 8 && tecla != 46 && tecla != 44)
            {
                e.Handled = true;
            }
        }

        private void textBoxArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            char tecla = e.KeyChar;

            if (tecla == 46 && textBoxPrecoMetroQuadrado.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
            }

            if (tecla == 46 && textBoxPrecoMetroQuadrado.Text.IndexOf(',') != -1)
            {
                e.Handled = true;
            }

            if (!Char.IsDigit(tecla) && tecla != 8 && tecla != 46 && tecla != 44)
            {
                e.Handled = true;
            }
        }
    }
}
