using System;

using System.Windows.Forms;

namespace Controle_De_Estoque
{
    public partial class TelaCadastroDeProduto : Form
    {
        ProdutoTapecaria _novoProdutoTapecaria;

        private static int _ultimoIdUtilizado = 0;

        public TelaCadastroDeProduto(ProdutoTapecaria novoProdutoTapecaria)
        {
            InitializeComponent();
            InitializeComboBox(comboBoxTipo);
            InitializeDateTimePicker();
            _novoProdutoTapecaria = novoProdutoTapecaria;
        }

        public void AoClicarEmSalvar(object sender, EventArgs e)
        {
            ValidacaoProdutoTapecaria validacaoProdutoTapecaria = new ValidacaoProdutoTapecaria(this);

            validacaoProdutoTapecaria.ValidaProduto();

            if (validacaoProdutoTapecaria.RetornaListaDeErros() == string.Empty)
            {
                _novoProdutoTapecaria.Id = GeraId();
                _novoProdutoTapecaria.Tipo = (TipoTapecaria)comboBoxTipo.SelectedIndex;
                _novoProdutoTapecaria.DataEntrada = dateTimePickerDataEntrada.Value;
                _novoProdutoTapecaria.PrecoMetroQuadrado = Convert.ToDecimal(textBoxPrecoMetroQuadrado.Text);
                _novoProdutoTapecaria.Area = Convert.ToDouble(textBoxArea.Text);
                _novoProdutoTapecaria.EhEntrega = checkBoxEntregarAposServico.Checked;
                _novoProdutoTapecaria.Detalhes = textBoxDetalhes.Text;

                DialogResult = DialogResult.OK;

                Close();
            }
            else
            {
                MessageBox.Show(validacaoProdutoTapecaria.RetornaListaDeErros(),"ERRO!", MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
        }

        private int GeraId()
        {
            return ++_ultimoIdUtilizado;
        }

        private void AoClicarEmCancelar(object sender, EventArgs e)
        {
            Close();
        }

        private void InitializeDateTimePicker()
        {
            dateTimePickerDataEntrada.Value = DateTime.Today;
        }

        private void InitializeComboBox(ComboBox comboBox)
        {
            comboBox.Items.AddRange(Enum.GetNames(typeof(TipoTapecaria)));
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
