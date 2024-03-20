using Dominio;
using InfraestruturaDeDados;

namespace InfraestruturaDeDados.Repositorios
{
    public class RepositorioSingleton : IRepositorio
    {
        static readonly List<ProdutoTapecaria> _listaTapecaria = ListaTapecariaSingleton.ObterInstancia();

        public void Criar(ProdutoTapecaria produtoTapecaria)
        {
            produtoTapecaria.Id = ListaTapecariaSingleton.ObterProximoId();
            _listaTapecaria.Add(produtoTapecaria);
        }

        public List<ProdutoTapecaria> ObterTodos(string? tipo, string? detalhes)
        {
            var listaProdutosTapecaria = _listaTapecaria;

            if (tipo is not null)
            {
                listaProdutosTapecaria = listaProdutosTapecaria
                                            .Where(x => Convert.ToInt32(x.Tipo) == Convert.ToInt32(tipo))
                                            .ToList();
            }

            if (detalhes is not null)
            {
                listaProdutosTapecaria = listaProdutosTapecaria
                                            .Where(x => x.Detalhes.ToLower().Contains(detalhes.ToLower()))
                                            .ToList();
            }

            return listaProdutosTapecaria;
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