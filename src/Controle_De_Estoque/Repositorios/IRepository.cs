using ControleDeEstoque.Dominio;

namespace ControleDeEstoque.Repositorios

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
