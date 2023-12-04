namespace Controle_De_Estoque.Repositorio
{
    public interface IRepository
    {
        public List<ProdutoTapecaria> ObterTodos();

        public ProdutoTapecaria ObterPorId(int id);

        public void Criar(ProdutoTapecaria produtoTapecaria);

        public void Atualizar(int idProdutoASerEditado, ProdutoTapecaria novoProdutoTapecaria);

        public void Remover(int id);
    }
}
