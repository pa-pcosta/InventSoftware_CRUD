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
            ProdutoTapecaria novoProdutoTapecaria = new ProdutoTapecaria();
            TelaCadastroDeProduto newForm = new TelaCadastroDeProduto(novoProdutoTapecaria);
            newForm.ShowDialog();

            if(newForm.DialogResult.Equals(DialogResult.OK))
            {
                listaProdutoTapecaria.Add(novoProdutoTapecaria);
                atualizaDataGridView();
                MessageBox.Show("Novo produto cadastrado com sucesso");
            }
        }

        public void atualizaDataGridView()
        {
            dataGridViewListaProdutoTapecaria.DataSource = null;
            dataGridViewListaProdutoTapecaria.DataSource = listaProdutoTapecaria;
        }

    }
}
