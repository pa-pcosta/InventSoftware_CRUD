using System;
using System.Collections.Generic;
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

        private void aoClicarEmCadastrar(object sender, EventArgs e)
        {
            TelaCadastroDeProduto newForm = new TelaCadastroDeProduto(this);
            newForm.ShowDialog();
        }

        public void atualizaDataGridView()
        {
            dataGridViewListaProdutoTapecaria.DataSource = null;
            dataGridViewListaProdutoTapecaria.DataSource = listaProdutoTapecaria;
        }

    }
}
