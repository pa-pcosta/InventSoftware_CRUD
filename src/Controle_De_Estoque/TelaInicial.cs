using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Controle_De_Estoque
{
    public partial class TelaInicial : Form
    {
        public List<ProdutoTapecaria> _listaProdutoTapecaria = new List<ProdutoTapecaria>();

        public TelaInicial()
        {
            InitializeComponent();
        }

        private void AoClicarEmCadastrar(object sender, EventArgs e)
        {
            try
            {
                TelaCadastroDeProduto formCadastroProduto = new TelaCadastroDeProduto(null);
                formCadastroProduto.ShowDialog();

                if(formCadastroProduto.DialogResult == DialogResult.OK)
                {
                    _listaProdutoTapecaria.Add(formCadastroProduto._novoProdutoTapecaria);
                    AtualizaDataGridView();
                    MessageBox.Show("Novo produto cadastrado com sucesso", "SUCESSO!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AoClicarEmEditar(object sender, EventArgs e)
        {
            try
            {
                var limiteLinhasSelecionadas = 1;
                var qtdLinhasSelecionadas = dataGridViewListaProdutoTapecaria.SelectedRows.Count;

                if (qtdLinhasSelecionadas == limiteLinhasSelecionadas)
                {
                    var idObjetoSelecionado = ObterIdObjetoSelecionadoNaDataGrid();
                    ProdutoTapecaria produtoASerEditado = ObterObjetoPorId(idObjetoSelecionado);

                    if (produtoASerEditado != null)
                    {
                        TelaCadastroDeProduto formCadastroProduto = new TelaCadastroDeProduto(produtoASerEditado);
                        formCadastroProduto.ShowDialog();
                    
                        if (formCadastroProduto.DialogResult == DialogResult.OK)
                        {
                            SubstituiObjetoNaLista(produtoASerEditado, formCadastroProduto);
                            AtualizaDataGridView();
                            MessageBox.Show("Registro editado com sucesso","SUCESSSO!");
                        }
                    }
                    else
                    {
                        throw new Exception("Registro não encontrado na base de dados");
                    }
                }
                else if (qtdLinhasSelecionadas < limiteLinhasSelecionadas)
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

        private void AoClicarEmRemover(object sender, EventArgs e)
        {
            try
            {
                var limiteLinhasSelecionadas = 1;
                var qtdLinhasSelecionadas = dataGridViewListaProdutoTapecaria.SelectedRows.Count;

                if (qtdLinhasSelecionadas == limiteLinhasSelecionadas)
                {
                    var idObjetoSelecionado = ObterIdObjetoSelecionadoNaDataGrid();
                    ProdutoTapecaria produtoASerRemovido = ObterObjetoPorId(idObjetoSelecionado);

                    if (produtoASerRemovido != null)
                    {
                        string msgCorfirmaExclusao = $"Ao remover, o seguinte registro será deletado e não poderá ser recuperado:\n\n" +
                            $"Id: {produtoASerRemovido.Id}\n" +
                            $"Tipo: {produtoASerRemovido.Tipo}\n" +
                            $"Data de entrada: {produtoASerRemovido.DataEntrada}\n" +
                            $"Tamanho: {produtoASerRemovido.Area} m²\n" +
                            $"Preço: {produtoASerRemovido.PrecoMetroQuadrado}\n" +
                            $"Entrega: {produtoASerRemovido.EhEntrega}\n" +
                            $"Detalhes: {produtoASerRemovido.Detalhes}\n\n" +
                            $"Deseja continuar?";

                        DialogResult confirmaExclusao = MessageBox.Show(msgCorfirmaExclusao, "REMOVER CADASTRO", MessageBoxButtons.YesNo);

                        if (confirmaExclusao == DialogResult.Yes)
                        {
                            _listaProdutoTapecaria.Remove(produtoASerRemovido);
                            AtualizaDataGridView();
                            MessageBox.Show("Registro excluído com sucesso.", "REGISTRO REMOVIDO");
                        }
                    }
                    else
                    {
                        throw new Exception("Registro não encontrado na base de dados");
                    }
                }
                else if (qtdLinhasSelecionadas < limiteLinhasSelecionadas)
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

        private int ObterIdObjetoSelecionadoNaDataGrid()
        {
            return Convert.ToInt32(dataGridViewListaProdutoTapecaria.CurrentRow.Cells["Id"].Value);
        }

        private ProdutoTapecaria ObterObjetoPorId(int Id)
        {
            return _listaProdutoTapecaria.FirstOrDefault(item => item.Id == Id);
        }

        private void SubstituiObjetoNaLista(ProdutoTapecaria produtoASerEditado, TelaCadastroDeProduto formCadastroProduto)
        {
            var indexProdutoASerEditado = _listaProdutoTapecaria.IndexOf(produtoASerEditado);

            if (indexProdutoASerEditado != -1)
            {
                _listaProdutoTapecaria[indexProdutoASerEditado] = formCadastroProduto._novoProdutoTapecaria;
            }
        }

        public void AtualizaDataGridView()
        {
            dataGridViewListaProdutoTapecaria.DataSource = null;
            dataGridViewListaProdutoTapecaria.DataSource = _listaProdutoTapecaria;
        }

    }
}
