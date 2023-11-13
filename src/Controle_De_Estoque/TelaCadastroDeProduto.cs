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
            _novoProdutoTapecaria = novoProdutoTapecaria;
        }

        private void InitializeComboBox(ComboBox comboBox)
        {
            comboBox.Items.AddRange(Enum.GetNames(typeof(TipoTapecaria)));
            comboBox.SelectedIndex = (Enum.GetValues(typeof(TipoTapecaria)).Length)-1;
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
                MessageBox.Show(validacaoProdutoTapecaria.RetornaListaDeErros());
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
    }
}
