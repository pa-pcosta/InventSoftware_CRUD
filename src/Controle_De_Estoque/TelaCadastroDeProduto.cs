using System;

using System.Windows.Forms;

namespace Controle_De_Estoque
{
    public partial class TelaCadastroDeProduto : Form
    {
        TelaInicial _telaInicial;

        private static int _ultimoIdUtilizado = 0;

        public TelaCadastroDeProduto(TelaInicial telaInicial)
        {
            InitializeComponent();
            InitializeComboBox(comboBoxTipo);
            _telaInicial = telaInicial; 
        }

        private void InitializeComboBox(ComboBox comboBox)
        {
            comboBox.Items.AddRange(Enum.GetNames(typeof(TipoTapecaria)));
            comboBox.SelectedIndex = (Enum.GetValues(typeof(TipoTapecaria)).Length)-1;
        }

        public void AoClicarEmSalvar(object sender, EventArgs e)
        {
            ProdutoTapecaria novoProdutoTapecaria = new ProdutoTapecaria();

            ValidacaoProdutoTapecaria validacaoProdutoTapecaria = new ValidacaoProdutoTapecaria();

            try
            {
                novoProdutoTapecaria.Tipo = (TipoTapecaria)comboBoxTipo.SelectedIndex;
                novoProdutoTapecaria.DataEntrada = dateTimePickerDataEntrada.Value;
                novoProdutoTapecaria.Area = Convert.ToDouble(textBoxArea.Text);
                novoProdutoTapecaria.PrecoMetroQuadrado = Convert.ToDecimal(textBoxPrecoMetroQuadrado.Text);
                novoProdutoTapecaria.EhEntrega = checkBoxEntregarAposServico.Checked;
                novoProdutoTapecaria.Detalhes = textBoxDetalhes.Text;
            
                validacaoProdutoTapecaria.ValidaProduto(novoProdutoTapecaria);
            }
            catch 
            {             
                MessageBox.Show(validacaoProdutoTapecaria.RetornaListaDeErros());
            }

            if (validacaoProdutoTapecaria.RetornaListaDeErros() != string.Empty)
            {
                novoProdutoTapecaria.Id = GeraId();

                _telaInicial.listaProdutoTapecaria.Add(novoProdutoTapecaria);

                _telaInicial.atualizaDataGridView();


                Close();
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
