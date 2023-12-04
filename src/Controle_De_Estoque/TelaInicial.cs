using Controle_De_Estoque.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Controle_De_Estoque
{
    public partial class TelaInicial : Form
    {
        private RepositorioSingleton _repositorio = new RepositorioSingleton();
        //private readonly List<ProdutoTapecaria> _listaTapecaria = ListaTapecaria.ObterInstancia();

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

                if (formCadastroProduto.DialogResult == DialogResult.OK)
                {
                    _repositorio.Criar(formCadastroProduto._novoProdutoTapecaria);
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
                    var idItemSelecionado = ObterIdItemSelecionado();
                    ProdutoTapecaria produtoASerEditado = _repositorio.ObterPorId(idItemSelecionado);

                    if (produtoASerEditado != null)
                    {
                        TelaCadastroDeProduto formCadastroProduto = new TelaCadastroDeProduto(produtoASerEditado);
                        formCadastroProduto.ShowDialog();

                        if (formCadastroProduto.DialogResult == DialogResult.OK)
                        {
                            _repositorio.Atualizar(idItemSelecionado, formCadastroProduto._novoProdutoTapecaria);
                            AtualizaDataGridView();
                            MessageBox.Show("Registro editado com sucesso", "SUCESSSO!");
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
                    var idItemSelecionado = ObterIdItemSelecionado();
                    ProdutoTapecaria produtoASerRemovido = _repositorio.ObterPorId(idItemSelecionado);

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

                        var confirmaExclusao = MessageBox.Show(msgCorfirmaExclusao, "REMOVER CADASTRO", MessageBoxButtons.YesNo);

                        if (confirmaExclusao == DialogResult.Yes)
                        {
                            _repositorio.Remover(idItemSelecionado);
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

        private int ObterIdItemSelecionado()
        {
            return Convert.ToInt32(dataGridViewListaProdutoTapecaria.CurrentRow.Cells["Id"].Value);
        }

        public void AtualizaDataGridView()
        {
            List<ProdutoTapecaria> listaTapecaria = _repositorio.ObterTodos();

            dataGridViewListaProdutoTapecaria.DataSource = new List<ProdutoTapecaria>();
            var valorMinimo = 1;

            if (listaTapecaria.Count >= valorMinimo)
                dataGridViewListaProdutoTapecaria.DataSource = listaTapecaria;
        }
    }
}