using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Controle_De_Estoque
{
    public class ListaTapecaria : List<ProdutoTapecaria>
    {
        private static readonly Lazy<ListaTapecaria> _instancia = new Lazy<ListaTapecaria> (() => new ListaTapecaria());

        private ListaTapecaria() { }
        
        public static ListaTapecaria  Instancia => _instancia.Value;

        private static int _ultimoIdUtilizado = 0;
        public static int ObterProximoId()
        {
            return ++_ultimoIdUtilizado;
        }
    }
}
