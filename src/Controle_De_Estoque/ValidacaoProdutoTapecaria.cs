using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controle_De_Estoque
{
    public class ValidacaoProdutoTapecaria
    {
        public string Tipo { get; set; }
        public string DataEntrada { get; set; }
        public string Area { get; set; }
        public string PrecoMetroQuadrado { get; set; }

        public List<string> _listaDeErros = new List<string>();

        public List<string> ValidarProduto()
        {
            var valorTipoInvalido = -1;
            var ehTipoValido = Tipo != valorTipoInvalido.ToString();
            
            if (!ehTipoValido)
            {
                var erro = "TIPO inválido.";
                _listaDeErros.Add(erro);
            }

            DateTime.TryParse(DataEntrada, out var dataEntrada);
            var ehDataValida = dataEntrada <= DateTime.Now;

            if (!ehDataValida)
            {
                var erro = "DATA DE ENTRADA não pode ser maior que a data atual.";
                _listaDeErros.Add(erro);
            }

            var precoEhNumero = Regex.IsMatch(PrecoMetroQuadrado, "^[0-9]+([,][0-9]+)?$");

            if (!precoEhNumero)
            {
                var erro = "PREÇO deve ser um número.";
                _listaDeErros.Add(erro);
            }
            else
            {
                var precoMetroQuadrado = Decimal.Parse(PrecoMetroQuadrado);
                var ehPrecoValido =  precoMetroQuadrado >= 0;

                if (!ehPrecoValido)
                {
                    var erro = "PREÇO inválido.";
                    _listaDeErros.Add(erro);
                }
            }

            var areaEhNumero = Regex.IsMatch(Area, "^[0-9]+([,][0-9]+)?$");

            if (!areaEhNumero)
            {
                var erro = "TAMANHO deve ser um número.";
                _listaDeErros.Add(erro);
            }
            else
            {
                var area = Double.Parse(Area);
                var ehAreaValida = area > 0;

                if (!ehAreaValida)
                {
                    var erro = "TAMANHO do produto inválido.";
                    _listaDeErros.Add(erro);
                }
            }

            return _listaDeErros;
        }
    }
}