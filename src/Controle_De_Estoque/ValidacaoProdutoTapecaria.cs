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
        TelaCadastroDeProduto _telaCadastroDeProduto;

        public List<string> _listaDeErros = new List<string>();
        
        public ValidacaoProdutoTapecaria(TelaCadastroDeProduto telaCadastroDeProduto) 
        {
            _telaCadastroDeProduto = telaCadastroDeProduto;
        }

        public string ValidarProduto()
        {
            //Valida combobox tipoTapecaria
            var tipoTapecaria = _telaCadastroDeProduto.comboBoxTipo.SelectedIndex;
            var ehTipoValido = (tipoTapecaria >= 0) && (tipoTapecaria < Enum.GetValues(typeof(TipoTapecaria)).Length);
            
            if (!ehTipoValido)
            {
                var erro = "TIPO inválido.";
                _listaDeErros.Add(erro);
            }

            //Valida campo dateTimePickerDataEntrada
            var dataEntrada = _telaCadastroDeProduto.dateTimePickerDataEntrada.Value;
            var ehDataValida = dataEntrada <= DateTime.Now;

            if (!ehDataValida)
            {
                var erro = "DATA DE ENTRADA não pode ser maior que a data atual.";
                _listaDeErros.Add(erro);
            }

            //Valida campo textBoxPrecoMetroQuadrado
            var precoEhNumero = Regex.IsMatch(_telaCadastroDeProduto.textBoxPrecoMetroQuadrado.Text, "^[0-9]+([,.][0-9]{1,2})?$");

            if (!precoEhNumero)
            {
                var erro = "PREÇO deve ser um número.";
                _listaDeErros.Add(erro);
            }
            else
            {
                var precoMetroQuadrado = Convert.ToDecimal(_telaCadastroDeProduto.textBoxPrecoMetroQuadrado.Text);
                var ehPrecoValido = precoMetroQuadrado >= 0;

                if (!ehPrecoValido)
                {
                    var erro = "PREÇO inválido.";
                    _listaDeErros.Add(erro);
                }

            }
            

            //Valida campo textBoxArea
            var areaEhNumero = Regex.IsMatch(_telaCadastroDeProduto.textBoxArea.Text, "^[0-9]+([,.][0-9]{1,2})?$");

            if (!areaEhNumero)
            {
                var erro = "TAMANHO deve ser um número.";
                _listaDeErros.Add(erro);
            }
            else
                {
                var area = Convert.ToDouble(_telaCadastroDeProduto.textBoxArea.Text);
                var ehAreaValida = area > 0.0;

                if (!ehAreaValida)
                {
                    var erro = "TAMANHO do produto inválido.";
                    _listaDeErros.Add(erro);
                }
            }

            return String.Join(Environment.NewLine, _listaDeErros);
        }
    }
}