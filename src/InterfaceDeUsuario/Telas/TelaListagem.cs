using Dominio;

namespace ControleDeEstoque.InterfaceDeUsuario
{
    public partial class TelaListagem : Form
    {
        private readonly IRepositorio _repositorio;

        public TelaListagem(IRepositorio repositorio)
        {
            _repositorio = repositorio;

            InitializeComponent();
            AtualizaDataGridView();
        }

        private void AoClicarEmCadastrar(object sender, EventArgs e)
        {
            try
            {
                TelaInfoTapecaria formCadastroProduto = new TelaInfoTapecaria(null);
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
                MessageBox.Show(ex.Message, "Erro inesperado \n[Ao Clicar Em Cadastrar]", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        TelaInfoTapecaria formInfoTapecaria = new TelaInfoTapecaria(produtoASerEditado);
                        formInfoTapecaria.ShowDialog();

                        if (formInfoTapecaria.DialogResult == DialogResult.OK)
                        {
                            _repositorio.Atualizar(formInfoTapecaria._novoProdutoTapecaria);
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
                MessageBox.Show(ex.Message, "Erro inesperado\n[Ao Clicar Em Editar]", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, "Erro inesperado\n[Ao Clicar Em Remover]", MessageBoxButtons.OK, MessageBoxIcon.Error);
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