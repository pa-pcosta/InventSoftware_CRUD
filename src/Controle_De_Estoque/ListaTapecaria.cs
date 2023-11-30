using System.Collections.Generic;

namespace Controle_De_Estoque
{
    public class ListaTapecaria
    {
        private ListaTapecaria() { }

        private static ListaTapecaria _instancia;

        public List<ProdutoTapecaria> _produtos = new List<ProdutoTapecaria>();

        private static int _ultimoIdUtilizado = 0;

        private static readonly object _lock = new object();

        public static ListaTapecaria ObterInstancia()
        {
            lock (_lock)
            {
                if (_instancia == null)
                    _instancia = new ListaTapecaria();
            }

            return _instancia;
        }

        public static int ObterProximoId()
        {
            return ++_ultimoIdUtilizado;
        }
    }
}
