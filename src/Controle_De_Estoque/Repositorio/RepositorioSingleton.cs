
namespace Controle_De_Estoque.Repositorio
{
    internal class RepositorioSingleton : IRepository
    {
        static readonly List<ProdutoTapecaria> _listaTapecaria = ListaTapecaria.ObterInstancia();

        public ProdutoTapecaria ObterPorId(int id)
        {
            return _listaTapecaria.FirstOrDefault(item => item.Id == id);
        }

        public List<ProdutoTapecaria> ObterTodos()
        {
            return _listaTapecaria;
        }

        public void Criar(ProdutoTapecaria produtoTapecaria)
        {
            _listaTapecaria.Add(produtoTapecaria);
        }

        public void Atualizar(int idProdutoASerEditado, ProdutoTapecaria novoProdutoTapecaria)
        {
            var produtoASerEditado = ObterPorId(idProdutoASerEditado);
            var indexProdutoASerEditado = _listaTapecaria.IndexOf(produtoASerEditado);
            const int itemNaoEncontrado = -1;

            if (indexProdutoASerEditado != itemNaoEncontrado)
            {
                _listaTapecaria[indexProdutoASerEditado] = novoProdutoTapecaria;
            }
        }

        public void Remover(ProdutoTapecaria produtoASerRemovido)
        {
            _listaTapecaria.Remove(produtoASerRemovido);
        }
    }
}