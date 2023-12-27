namespace ControleDeEstoque.Dominio
{
    public interface IRepositorio
    {
        public void Criar(ProdutoTapecaria produtoTapecaria);

        public List<ProdutoTapecaria> ObterTodos();

        public ProdutoTapecaria? ObterPorId(int id);

        public void Atualizar(ProdutoTapecaria novoProdutoTapecaria);

        public void Remover(int id);
    }
}
