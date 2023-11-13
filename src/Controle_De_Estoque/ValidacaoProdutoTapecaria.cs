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

        public void ValidaProduto()
        {
            ProdutoTapecaria testeProdutoTapecaria = new ProdutoTapecaria();

            //Valida campo comboBoxTipo
            try
            {
                testeProdutoTapecaria.Tipo = (TipoTapecaria)_telaCadastroDeProduto.comboBoxTipo.SelectedIndex;

                if (((int)testeProdutoTapecaria.Tipo < 0) || ((int)testeProdutoTapecaria.Tipo >= Enum.GetValues(typeof(TipoTapecaria)).Length))
                {
                    throw new Exception("TIPO inválido.");
                }
            }
            catch (Exception exception)
            {
                _listaDeErros.Add(exception.Message);
            }

            //Valida campo dateTimePickerDataEntrada
            try
            {
                testeProdutoTapecaria.DataEntrada = _telaCadastroDeProduto.dateTimePickerDataEntrada.Value;

                if (_telaCadastroDeProduto.dateTimePickerDataEntrada.Value > DateTime.Now)
                {
                    throw new Exception("DATA DE ENTRADA não pode ser maior que a data atual.");
                }
            }
            catch (Exception exception)
            {
                _listaDeErros.Add(exception.Message);
            }

            //Valida campo textBoxPrecoMetroQuadrado
            try
            {
                testeProdutoTapecaria.PrecoMetroQuadrado = Convert.ToDecimal(_telaCadastroDeProduto.textBoxPrecoMetroQuadrado.Text);

                if ((testeProdutoTapecaria.PrecoMetroQuadrado) < 0)
                {
                    _listaDeErros.Add("Menor que 0");
                }
            }
            catch (FormatException)
            {
                _listaDeErros.Add("PREÇO deve ser um número.");
            }

            //Valida campo textBoxArea
            try
            {
                testeProdutoTapecaria.Area = Convert.ToDouble(_telaCadastroDeProduto.textBoxArea.Text);

                if (testeProdutoTapecaria.Area <= 0)
                {
                    throw new Exception("TAMANHO do produto inválido");
                }
            }
            catch(FormatException)
            {
                _listaDeErros.Add("TAMANHO deve ser um número");
            }
            catch (Exception exception)
            {
                _listaDeErros.Add(exception.Message);
            }
        }

        public string RetornaListaDeErros ()
        {
            return String.Join(Environment.NewLine, _listaDeErros);
        }
    }
}
