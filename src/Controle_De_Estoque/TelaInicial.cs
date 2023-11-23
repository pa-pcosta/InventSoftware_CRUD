using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Controle_De_Estoque
{
    public partial class TelaInicial : Form
    {
        public List<ProdutoTapecaria> _listaProdutoTapecaria = new List<ProdutoTapecaria>();

        const int ehNovoProduto = -1;

        public TelaInicial()
        {
            InitializeComponent();
        }

        private void AoClicarEmCadastrar(object sender, EventArgs e)
        {
            try
            {
                ProdutoTapecaria novoProdutoTapecaria = new ProdutoTapecaria() { Id = ehNovoProduto};
                TelaCadastroDeProduto infoProdutoTapecaria = new TelaCadastroDeProduto(novoProdutoTapecaria);
                infoProdutoTapecaria.ShowDialog();

                if(infoProdutoTapecaria.DialogResult.Equals(DialogResult.OK))
                {
                    _listaProdutoTapecaria.Add(novoProdutoTapecaria);
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
            dataGridViewListaProdutoTapecaria.DataSource = _listaProdutoTapecaria;
        }

        private void AoClicarEmEditar(object sender, EventArgs e)
        {
            try
            {
                var qtdLinhasSelecionadas = dataGridViewListaProdutoTapecaria.SelectedRows.Count;

                if (qtdLinhasSelecionadas == 1)
                {
                    var idObjetoSelecionado = Convert.ToInt32(dataGridViewListaProdutoTapecaria.CurrentRow.Cells["Id"].Value);

                    ProdutoTapecaria produtoEditado = ObterObjetoPorId(idObjetoSelecionado);
                    
                    TelaCadastroDeProduto infoProdutoTapecaria = new TelaCadastroDeProduto(produtoEditado);
                    infoProdutoTapecaria.ShowDialog();
                    
                    if (infoProdutoTapecaria.DialogResult.Equals(DialogResult.OK))
                    {
                        atualizaDataGridView();
                    }
                }
                else if (qtdLinhasSelecionadas == 0)
                {
                    MessageBox.Show("Selecione um registro", "Não há linha selecionada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Selecione apenas 1 linha", "OPERAÇÃO INVÁLIDA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ProdutoTapecaria ObterObjetoPorId(int Id)
        {
            return _listaProdutoTapecaria.Find(x => x.Id == Id);
        }
    }
}
