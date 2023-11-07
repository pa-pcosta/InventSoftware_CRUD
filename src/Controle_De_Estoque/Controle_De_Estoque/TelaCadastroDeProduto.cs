using System;

using System.Windows.Forms;

namespace Controle_De_Estoque
{
    public partial class TelaCadastroDeProduto : Form
    {
        TelaInicial telaInicial;

        private static int _ultimoIdUtilizado = 0;

        public TelaCadastroDeProduto(TelaInicial telaInicial)
        {
            InitializeComponent();
            InitializeComboBox(comboBoxTipo);
            
            this.telaInicial = telaInicial;
        }

        private void InitializeComboBox(ComboBox comboBox)
        {
            comboBox.Items.AddRange(Enum.GetNames(typeof(TipoTapecaria)));
        }

        private void AoClicarEmSalvar(object sender, EventArgs e)
        {
            ProdutoTapecaria novoProdutoTapecaria = new ProdutoTapecaria()
            {
                Id = GeraId(),
                Tipo = (TipoTapecaria)comboBoxTipo.SelectedIndex,
                DataEntrada = dateTimePickerDataEntrada.Value,
                Area = Convert.ToDouble(textBoxArea.Text),
                PrecoMetroQuadrado = Convert.ToDecimal(textBoxPrecoMetroQuadrado.Text),
                EhEntrega = checkBoxEntregarAposServico.Checked,
                Detalhes = textBoxDetalhes.Text
            };

            telaInicial.listaProdutoTapecaria.Add(novoProdutoTapecaria);

            telaInicial.atualizaDataGridView();
            
            Close();
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
