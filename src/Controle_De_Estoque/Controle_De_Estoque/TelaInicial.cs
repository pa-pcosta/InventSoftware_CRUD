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
    public partial class TelaInicial : Form
    {
        public List<ProdutoTapecaria> listaProdutoTapecaria = new List<ProdutoTapecaria>();

        public TelaInicial()
        {
            InitializeComponent();

            
        }

        private void aoClicarEmCadastar(object sender, EventArgs e)
        {
            TelaCadastroDeProduto newForm = new TelaCadastroDeProduto(this);
            newForm.ShowDialog();
        }

        private void TelaInicial_Load(object sender, EventArgs e)
        {
            
        }

        public void atualizaDataGridView()
        {
            dataGridViewListaProdutoTapecaria.DataSource = null;
            dataGridViewListaProdutoTapecaria.DataSource = listaProdutoTapecaria;
        }

    }
}
