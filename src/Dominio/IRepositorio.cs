namespace Dominio
{
    public interface IRepositorio
    {
        public int Criar(ProdutoTapecaria produtoTapecaria);

        public List<ProdutoTapecaria> ObterTodos();

        public ProdutoTapecaria? ObterPorId(int id);

        public int Atualizar(ProdutoTapecaria novoProdutoTapecaria);

        public void Remover(int id);
    }
}
