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
        ProdutoTapecaria _produtoTapecaria;

        public List<string> _listaDeErros = new List<string>();
        
        public ValidacaoProdutoTapecaria(ProdutoTapecaria produtoTapecaria) 
        {
            _produtoTapecaria = produtoTapecaria;
        }

        public List<string> ValidarProduto()
        {
            var tipoSelecionado = Convert.ToInt32(_produtoTapecaria.Tipo);
            var tamanhoEnum = Enum.GetValues(typeof(TipoTapecaria)).Length;
            var ehTipoValido = (tipoSelecionado >= 0) && (tipoSelecionado < tamanhoEnum);
            
            if (!ehTipoValido)
            {
                var erro = "TIPO inválido.";
                _listaDeErros.Add(erro);
            }

            var dataEntrada = _produtoTapecaria.DataEntrada;
            var ehDataValida = dataEntrada <= DateTime.Now;

            if (!ehDataValida)
            {
                var erro = "DATA DE ENTRADA não pode ser maior que a data atual.";
                _listaDeErros.Add(erro);
            }

            var precoMetroQuadrado = _produtoTapecaria.PrecoMetroQuadrado.ToString();
            var precoEhNumero = Regex.IsMatch(precoMetroQuadrado, "^[0-9]+([,.][0-9]+)?$");

            if (!precoEhNumero)
            {
                var erro = "PREÇO deve ser um número.";
                _listaDeErros.Add(erro);
            }
            else
            {
                var ehPrecoValido =  _produtoTapecaria.PrecoMetroQuadrado >= 0;

                if (!ehPrecoValido)
                {
                    var erro = "PREÇO inválido.";
                    _listaDeErros.Add(erro);
                }
            }

            var  area = _produtoTapecaria.PrecoMetroQuadrado.ToString();
            var areaEhNumero = Regex.IsMatch(area, "^[0-9]+([,.][0-9]+)?$");

            if (!areaEhNumero)
            {
                var erro = "TAMANHO deve ser um número.";
                _listaDeErros.Add(erro);
            }
            else
            {
                var ehAreaValida = _produtoTapecaria.Area > 0.0;

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