using ControleDeEstoque.Dominio;

namespace ControleDeEstoque.Repositorio
{
    internal class RepositorioSingleton : IRepository
    {
        static readonly List<ProdutoTapecaria> _listaTapecaria = ListaTapecariaSingleton.ObterInstancia();

        public List<ProdutoTapecaria> ObterTodos()
        {
            return _listaTapecaria;
        }

        public ProdutoTapecaria? ObterPorId(int id)
        {
            return _listaTapecaria.FirstOrDefault(item => item.Id == id);
        }

        public void Criar(ProdutoTapecaria produtoTapecaria)
        {
            _listaTapecaria.Add(produtoTapecaria);
        }

        public void Atualizar(int idProdutoASerEditado, ProdutoTapecaria novoProdutoTapecaria)
        {
            var produtoASerEditado = ObterPorId(idProdutoASerEditado);
            var indexProdutoASerEditado = _listaTapecaria.IndexOf(produtoASerEditado);
            _listaTapecaria[indexProdutoASerEditado] = novoProdutoTapecaria;
        }

        public void Remover(int id)
        {
            var produtoASerRemovido = ObterPorId(id);
            _listaTapecaria.Remove(produtoASerRemovido);
        }
    }
}