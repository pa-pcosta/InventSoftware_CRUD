using System.Text.RegularExpressions;

namespace Dominio.ValidacaoProdutoTapecaria
{
    public class ValidadorProdutoTapecaria
    {
        public List<string> ValidarProduto(ProdutoAValidar produtoAValidar)
        {
            List<string> listaDeErros = new List<string>();

            ValidarTipo();
            ValidarDataEntrada();
            ValidarPrecoMetroQuadrado();
            ValidarArea();

            return listaDeErros;

            void ValidarTipo()
            {
                var valorTipoInvalido = -1;
                var ehTipoValido = produtoAValidar.Tipo != valorTipoInvalido.ToString();

                if (!ehTipoValido)
                {
                    var erro = "TIPO inválido.";
                    listaDeErros.Add(erro);
                }
            }

            void ValidarDataEntrada()
            {
                DateTime.TryParse(produtoAValidar.DataEntrada, out var dataEntrada);
                var ehDataValida = dataEntrada <= DateTime.Now;

                if (!ehDataValida)
                {
                    var erro = "DATA DE ENTRADA não pode ser maior que a data atual.";
                    listaDeErros.Add(erro);
                }
            }

            void ValidarPrecoMetroQuadrado()
            {
                var precoEhNumero = Regex.IsMatch(produtoAValidar.PrecoMetroQuadrado, "^[0-9]+([,][0-9]+)?$");

                if (!precoEhNumero)
                {
                    var erro = "PREÇO deve ser um número.";
                    listaDeErros.Add(erro);
                }
                else
                {
                    var precoMetroQuadrado = decimal.Parse(produtoAValidar.PrecoMetroQuadrado);
                    var ehPrecoValido = precoMetroQuadrado >= 0;

                    if (!ehPrecoValido)
                    {
                        var erro = "PREÇO inválido.";
                        listaDeErros.Add(erro);
                    }
                }
            }

            void ValidarArea()
            {
                var areaEhNumero = Regex.IsMatch(produtoAValidar.Area, "^[0-9]+([,][0-9]+)?$");

                if (!areaEhNumero)
                {
                    var erro = "TAMANHO deve ser um número.";
                    listaDeErros.Add(erro);
                }
                else
                {
                    var area = double.Parse(produtoAValidar.Area);
                    var ehAreaValida = area > 0;

                    if (!ehAreaValida)
                    {
                        var erro = "TAMANHO do produto inválido.";
                        listaDeErros.Add(erro);
                    }
                }
            }
        }

        public void ValidarProduto(ProdutoTapecaria produtoAValidar)
        {
            List<string> listaDeErros = new List<string>();

            ValidarTipo();
            ValidarDataEntrada();
            ValidarPrecoMetroQuadrado();
            ValidarArea();

            void ValidarTipo()
             {
                var valorTipoInvalido = -1;
                var ehTipoValido = Convert.ToInt32(produtoAValidar.Tipo) != valorTipoInvalido;

                if (!ehTipoValido)
                {
                    var erro = "TIPO inválido.";
                    listaDeErros.Add(erro);
                }
            }

            void ValidarDataEntrada()
            {
                var ehDataValida = produtoAValidar.DataEntrada <= DateTime.Now;

                if (!ehDataValida)
                {
                    var erro = "DATA DE ENTRADA não pode ser maior que a data atual.";
                    listaDeErros.Add(erro);
                }
            }

            void ValidarPrecoMetroQuadrado()
            {
                var ehPrecoValido = produtoAValidar.PrecoMetroQuadrado >= 0;

                if (!ehPrecoValido)
                {
                    var erro = "PREÇO inválido.";
                    listaDeErros.Add(erro);
                }
            }

            void ValidarArea()
            {
                var ehAreaValida = produtoAValidar.Area > 0;

                if (!ehAreaValida)
                {
                    var erro = "TAMANHO do produto inválido.";
                    listaDeErros.Add(erro);
                }

            }

            if (listaDeErros.Any())
                throw new Exception("Alguns campos não atendem os critérios de validação");
        }
    }
}