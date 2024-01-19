using Dominio;
using InfraestruturaDeDados;

namespace InfraestruturaDeDados.Repositorios
{
    public class RepositorioSingleton : IRepositorio
    {
        public int Criar(ProdutoTapecaria produtoTapecaria)
        {
            produtoTapecaria.Id = ListaTapecariaSingleton.ObterProximoId();
            _listaTapecaria.Add(produtoTapecaria);

            return produtoTapecaria.Id;
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


        public int Atualizar(ProdutoTapecaria novoProdutoTapecaria)
        {
            var produtoASerEditado = ObterPorId(novoProdutoTapecaria.Id);
            var indexProdutoASerEditado = _listaTapecaria.IndexOf(produtoASerEditado);

            _listaTapecaria[indexProdutoASerEditado] = novoProdutoTapecaria;

            return novoProdutoTapecaria.Id;
        }

        public void Remover(int id)
        {
            var produtoASerRemovido = ObterPorId(id);

            if (produtoASerRemovido is not null)
                _listaTapecaria.Remove(produtoASerRemovido);
        }
    }
}