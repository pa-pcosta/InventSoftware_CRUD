namespace Dominio
{
    public interface IRepositorio
    {
        public int Criar(ProdutoTapecaria produtoTapecaria);

        public List<ProdutoTapecaria> ObterTodos(int? id);

        public ProdutoTapecaria? ObterPorId(int id);

        public int Atualizar(ProdutoTapecaria novoProdutoTapecaria);

        public void Remover(int id);
    }
}
