using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controle_De_Estoque
{
    public partial class TelaCadastroDeProduto : Form
    {
        TelaInicial telaInicial;

        static int ultimoIdUtilizado = 0;

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

        private void aoClicarEmSalvar(object sender, EventArgs e)
        {
            ProdutoTapecaria novoProdutoTapecaria = new ProdutoTapecaria()
            {
                Id = geraId(),
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

        private int geraId()
        {
            ++ultimoIdUtilizado;

            return ultimoIdUtilizado;
        }

        private void aoClicarEmCancelar(object sender, EventArgs e)
        {
            Close();
        }
    }
}
