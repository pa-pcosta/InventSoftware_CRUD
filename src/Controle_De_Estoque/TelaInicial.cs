namespace Controle_De_Estoque
{
    public partial class TelaInicial : Form
    {
        private readonly ListaTapecaria singleton;
        private readonly ListaTapecaria singleton2;

        private List<ProdutoTapecaria> _listaTapecaria;
        private List<ProdutoTapecaria> teste;

        public TelaInicial()
        {
            InitializeComponent();
            singleton = ListaTapecaria.ObterInstancia();
            _listaTapecaria = singleton._produtos;

            singleton2 = ListaTapecaria.ObterInstancia();
            teste = singleton2._produtos;
        }

        private void AoClicarEmCadastrar(object sender, EventArgs e)
        {
            try
            {
                TelaCadastroDeProduto formCadastroProduto = new TelaCadastroDeProduto(null);
                formCadastroProduto.ShowDialog();

                if (formCadastroProduto.DialogResult == DialogResult.OK)
                {
                    _listaTapecaria.Add(formCadastroProduto._novoProdutoTapecaria);
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
                    ProdutoTapecaria produtoASerEditado = ObterPorId(idItemSelecionado);

                    if (produtoASerEditado != null)
                    {
                        TelaCadastroDeProduto formCadastroProduto = new TelaCadastroDeProduto(produtoASerEditado);
                        formCadastroProduto.ShowDialog();

                        if (formCadastroProduto.DialogResult == DialogResult.OK)
                        {
                            SubstituiObjetoNaLista(produtoASerEditado, formCadastroProduto);
                            AtualizaDataGridView();
                            MessageBox.Show("Registro editado com sucesso", "SUCESSSO!");
                        }
                    }
                    else
                    {
                        throw new Exception("Registro n�o encontrado na base de dados");
                    }
                }
                else if (qtdLinhasSelecionadas < limiteLinhasSelecionadas)
                {
                    MessageBox.Show("Selecione um registro", "N�o h� linha selecionada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Selecione apenas 1 linha", "OPERA��O INV�LIDA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    ProdutoTapecaria produtoASerRemovido = ObterPorId(idItemSelecionado);

                    if (produtoASerRemovido != null)
                    {
                        string msgCorfirmaExclusao = $"Ao remover, o seguinte registro ser� deletado e n�o poder� ser recuperado:\n\n" +
                            $"Id: {produtoASerRemovido.Id}\n" +
                            $"Tipo: {produtoASerRemovido.Tipo}\n" +
                            $"Data de entrada: {produtoASerRemovido.DataEntrada}\n" +
                            $"Tamanho: {produtoASerRemovido.Area} m�\n" +
                            $"Pre�o: {produtoASerRemovido.PrecoMetroQuadrado}\n" +
                            $"Entrega: {produtoASerRemovido.EhEntrega}\n" +
                            $"Detalhes: {produtoASerRemovido.Detalhes}\n\n" +
                            $"Deseja continuar?";

                        var confirmaExclusao = MessageBox.Show(msgCorfirmaExclusao, "REMOVER CADASTRO", MessageBoxButtons.YesNo);

                        if (confirmaExclusao == DialogResult.Yes)
                        {
                            _listaTapecaria.Remove(produtoASerRemovido);
                            AtualizaDataGridView();
                            MessageBox.Show("Registro exclu�do com sucesso.", "REGISTRO REMOVIDO");
                        }
                    }
                    else
                    {
                        throw new Exception("Registro n�o encontrado na base de dados");
                    }
                }
                else if (qtdLinhasSelecionadas < limiteLinhasSelecionadas)
                {
                    MessageBox.Show("Selecione um registro", "N�o h� linha selecionada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Selecione apenas 1 linha", "OPERA��O INV�LIDA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private ProdutoTapecaria ObterPorId(int Id)
        {
            return _listaTapecaria.FirstOrDefault(item => item.Id == Id);
        }

        private void SubstituiObjetoNaLista(ProdutoTapecaria produtoASerEditado, TelaCadastroDeProduto formCadastroProduto)
        {
            var indexProdutoASerEditado = _listaTapecaria.IndexOf(produtoASerEditado);
            const int itemNaoEncontrado = -1;

            if (indexProdutoASerEditado != itemNaoEncontrado)
            {
                _listaTapecaria[indexProdutoASerEditado] = formCadastroProduto._novoProdutoTapecaria;
            }
        }

        public void AtualizaDataGridView()
        {
            dataGridViewListaProdutoTapecaria.DataSource = new List<ProdutoTapecaria>();
            var valorMinimo = 1;

            if (_listaTapecaria.Count >= valorMinimo)
                dataGridViewListaProdutoTapecaria.DataSource = teste;
        }
    }
}
