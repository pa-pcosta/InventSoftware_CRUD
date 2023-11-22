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
            InicializaCampos();
        }

        private void InicializaCampos()
        {
            dataGridViewListaProdutoTapecaria.MultiSelect = false;
            dataGridViewListaProdutoTapecaria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void AoClicarEmCadastrar(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void atualizaDataGridView()
        {
            dataGridViewListaProdutoTapecaria.DataSource = null;
            dataGridViewListaProdutoTapecaria.DataSource = listaProdutoTapecaria;
        }

    }
}
