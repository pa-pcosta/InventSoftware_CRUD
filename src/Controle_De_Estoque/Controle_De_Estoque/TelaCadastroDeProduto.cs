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

        public static ProdutoTapecaria novoProdutoTapecaria = new ProdutoTapecaria() { Detalhes = "Veio da TelaDeCadastro"};

        public TelaCadastroDeProduto(TelaInicial telaInicial)
        {
            InitializeComponent();
            InitializeTextBoxPrecoMetroQuadrado();

            this.telaInicial = telaInicial;
        }

        private void InitializeTextBoxPrecoMetroQuadrado()
        {
            textBoxPrecoMetroQuadrado.Text = string.Empty;
        }

        private void TelaCadastroDeProduto_Load(object sender, EventArgs e)
        {


        }

        private void aoClicarEmSalvar(object sender, EventArgs e)
        {
            ProdutoTapecaria novoProdutoTapecaria = new ProdutoTapecaria()
            {
                Tipo = (TipoTapecaria)comboBoxTipo.SelectedIndex,
                DataEntrada = dateTimePickerDataEntrada.Value,
                Area = Convert.ToDouble(textBoxArea.Text),
                //PrecoMetroQuadrado = Convert.ToDecimal(textBoxPrecoMetroQuadrado),
                EntregarAposServico = checkBoxEntregarAposServico.Checked,
                Detalhes = textBoxDetalhes.Text
            };

            telaInicial.listaProdutoTapecaria.Add(novoProdutoTapecaria);

            telaInicial.atualizaDataGridView();

        }
    }
}
