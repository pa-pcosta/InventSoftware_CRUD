using Dominio;
using InfraestruturaDeDados;

namespace InfraestruturaDeDados.Repositorios
{
    public class RepositorioSingleton : IRepositorio
    {
        public void Criar(ProdutoTapecaria produtoTapecaria)
        {
            _listaTapecaria.Add(produtoTapecaria);
        }
        static readonly List<ProdutoTapecaria> _listaTapecaria = ListaTapecariaSingleton.ObterInstancia();

        public List<ProdutoTapecaria> ObterTodos()
        {
            return _listaTapecaria;
        }

        public ProdutoTapecaria? ObterPorId(int id)
        {
            return _listaTapecaria.FirstOrDefault(item => item.Id == id);
        }


        public void Atualizar(ProdutoTapecaria novoProdutoTapecaria)
        {
            var produtoASerEditado = ObterPorId(novoProdutoTapecaria.Id);
            var indexProdutoASerEditado = _listaTapecaria.IndexOf(produtoASerEditado);

            _listaTapecaria[indexProdutoASerEditado] = novoProdutoTapecaria;
        }

        public void Remover(int id)
        {
            var produtoASerRemovido = ObterPorId(id);

            if (produtoASerRemovido is not null)
                _listaTapecaria.Remove(produtoASerRemovido);
        }
    }
}