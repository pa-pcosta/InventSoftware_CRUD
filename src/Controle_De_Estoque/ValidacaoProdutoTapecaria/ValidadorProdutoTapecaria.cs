using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Controle_De_Estoque.ValidacaoProdutoTapecaria;

namespace Controle_De_Estoque
{
    public class ValidadorProdutoTapecaria
    {
        public List<string> _listaDeErros = new List<string>();

        public List<string> ValidarProduto(ProdutoAValidar produtoAValidar)
        {
            var valorTipoInvalido = -1;
            var ehTipoValido = produtoAValidar.Tipo != valorTipoInvalido.ToString();
            
            if (!ehTipoValido)
            {
                var erro = "TIPO inválido.";
                _listaDeErros.Add(erro);
            }

            DateTime.TryParse(produtoAValidar.DataEntrada, out var dataEntrada);
            var ehDataValida = dataEntrada <= DateTime.Now;

            if (!ehDataValida)
            {
                var erro = "DATA DE ENTRADA não pode ser maior que a data atual.";
                _listaDeErros.Add(erro);
            }

            var precoEhNumero = Regex.IsMatch(produtoAValidar.PrecoMetroQuadrado, "^[0-9]+([,][0-9]+)?$");

            if (!precoEhNumero)
            {
                var erro = "PREÇO deve ser um número.";
                _listaDeErros.Add(erro);
            }
            else
            {
                var precoMetroQuadrado = Decimal.Parse(produtoAValidar.PrecoMetroQuadrado);
                var ehPrecoValido =  precoMetroQuadrado >= 0;

                if (!ehPrecoValido)
                {
                    var erro = "PREÇO inválido.";
                    _listaDeErros.Add(erro);
                }
            }

            var areaEhNumero = Regex.IsMatch(produtoAValidar.Area, "^[0-9]+([,][0-9]+)?$");

            if (!areaEhNumero)
            {
                var erro = "TAMANHO deve ser um número.";
                _listaDeErros.Add(erro);
            }
            else
            {
                var area = Double.Parse(produtoAValidar.Area);
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