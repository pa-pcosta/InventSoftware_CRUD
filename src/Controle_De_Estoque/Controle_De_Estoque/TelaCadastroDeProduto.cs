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

            this.telaInicial = telaInicial;
        }

        private void TelaCadastroDeProduto_Load(object sender, EventArgs e)
        {


        }

        private void aoClicarEmSalvar(object sender, EventArgs e)
        {
            //Constroi objeto do tipo ProdutoTapecaria com base nos valores passados no formulario
            ProdutoTapecaria novoProdutoTapecaria = new ProdutoTapecaria()
            {
                Id = ++TelaCadastroDeProduto.ultimoIdUtilizado,
                Tipo = (TipoTapecaria)comboBoxTipo.SelectedIndex,
                DataEntrada = dateTimePickerDataEntrada.Value,
                Area = Convert.ToDouble(textBoxArea.Text),
                PrecoMetroQuadrado = Convert.ToDecimal(textBoxPrecoMetroQuadrado.Text),
                EntregarAposServico = checkBoxEntregarAposServico.Checked,
                Detalhes = textBoxDetalhes.Text
            };

            //Adiciona objeto criado a Lista de Produtos definida na TelaInicial
            telaInicial.listaProdutoTapecaria.Add(novoProdutoTapecaria);

            //Chama a função que atualiza a tabela da TelaInicial
            telaInicial.atualizaDataGridView();
            
            //Fecha a janela do formúlario
            Close();
        }

        private void aoClicarEmCancelar(object sender, EventArgs e)
        {
            Close();
        }
    }
}
