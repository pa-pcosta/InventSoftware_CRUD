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
        public List<string> _listaDeErros = new List<string>();

        public void ValidaProduto(ProdutoTapecaria produtoTapecaria)
        {
            //Valida campo comboBoxTipo
            try
            {
                if (!(Convert.ToInt32(produtoTapecaria.Tipo) >= 0) && (Convert.ToInt32(produtoTapecaria.Tipo) < Enum.GetValues(typeof(TipoTapecaria)).Length))
                {
                    throw new Exception("O tipo do produto não pode ser vazio.");
                }
            }
            catch (Exception exception)
            {
                _listaDeErros.Add(exception.Message);
            }

            //Valida campo dateTimePickerDataEntrada
            try
            {
                if (!(produtoTapecaria.DataEntrada < DateTime.Now))
                {
                    throw new Exception("Data de Entrada do produto inválida.");
                }
            }
            catch (Exception exception)
            {
                _listaDeErros.Add(exception.Message);
            }

            //Valida campo textBoxArea
            try
            {
                if (!(produtoTapecaria.Area < 0))
                {
                    throw new Exception("Tamanho do produto inválido");
                }
            }
            catch (Exception exception)
            {
                _listaDeErros.Add(exception.Message);
            }

            //Valida campo textBoxPrecoMetroQuadrado
            try
            {
                if (!(produtoTapecaria.PrecoMetroQuadrado < 0))
                {
                    throw new Exception("Preço do produto inválido");
                }
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
