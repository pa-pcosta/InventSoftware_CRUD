using ControleDeEstoque.Dominio;

namespace ControleDeEstoque.InfraestruturaDeDados
{
    public class ListaTapecariaSingleton
    {
        public static List<ProdutoTapecaria> _produtos;

        private static int _ultimoIdUtilizado = 0;

        private static readonly object _lock = new object();

        public static List<ProdutoTapecaria> ObterInstancia()
        {
            lock (_lock)
            {
                if (_produtos == null)
                    _produtos = new List<ProdutoTapecaria>();
            }

            return _produtos;
        }

        public static int ObterProximoId()
        {
            return ++_ultimoIdUtilizado;
        }
    }
}