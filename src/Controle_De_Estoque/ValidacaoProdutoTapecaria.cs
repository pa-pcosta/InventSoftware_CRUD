using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Controle_De_Estoque
{
    public class ValidacaoProdutoTapecaria
    {
        public List<string> ValidarProduto(Dictionary<string, string> produtoTapecaria)
        {
            List<string> listaDeErros = new List<string>();

            foreach (var item in produtoTapecaria)
            {
                if (item.Key == "comboBoxTipo")
                {
                    var valorInvalido = -1;
                    var ehValido = item.Value != valorInvalido.ToString();

                    if (!ehValido)
                        listaDeErros.Add("TIPO inválido.");
                }

                if(item.Key == "dateTimePickerDataEntrada")
                {
                    var ehVazio = string.IsNullOrWhiteSpace(item.Value);
                    var ehValorValido = DateTime.TryParse(item.Value, out var dataSaida);
                    var ehDataValida = dataSaida <= DateTime.Now;
                    
                    if (ehVazio || !ehValorValido || !ehDataValida)
                        listaDeErros.Add("DATA DE ENTRADA não pode ser maior que a data atual.");
                }

                if(item.Key == "textBoxPrecoMetroQuadrado")
                {

                    var precoMetroQuadrado = item.Value.ToString().Replace(".", ",");
                    decimal.TryParse(precoMetroQuadrado, out decimal teste);
                    var precoEhNumero = Regex.IsMatch(teste.ToString(), @"^\d");
                    
                    if (!precoEhNumero)
                    {
                        listaDeErros.Add("PREÇO deve ser um número.");
                    }
                    else
                    {
                        var valorMetroQuadrado = int.Parse(precoMetroQuadrado);
                        const int valorInvalido = 0;
                        if (valorMetroQuadrado <= valorInvalido)
                            listaDeErros.Add("PREÇO deve ser maior que zero.");
                    }
                }


                if(item.Key == "textBoxArea")
                {
                    var valorArea = item.Value;
                    var metroArea = Regex.IsMatch(valorArea, @"^\d");

                    if (!metroArea)
                    {
                        listaDeErros.Add("TAMANHO deve ser um número.");
                    }
                    else
                    {
                        var valorMetroQuadrado = int.Parse(valorArea);
                        const int valorInvalido = 0;
                        if (valorMetroQuadrado <= valorInvalido)
                            listaDeErros.Add("TAMANHO do produto deve ser maior que zero.");
                    }
                }
            }

            return listaDeErros;
        }
    }
}