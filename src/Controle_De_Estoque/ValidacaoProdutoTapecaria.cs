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

        List<string> _listaDeErros = new List<string>();

        ValidacaoProdutoTapecaria (ProdutoTapecaria produtoTapecaria)
        {
            _produtoTapecaria = produtoTapecaria;
        }

        void ValidaProduto()
        {
            //Valida campo comboBoxTipo
            try
            {
                if(!(Convert.ToInt32(_produtoTapecaria.Tipo) >= 0) && (Convert.ToInt32(_produtoTapecaria.Tipo) < Enum.GetValues(typeof(TipoTapecaria)).Length))
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
                if (!(_produtoTapecaria.DataEntrada < DateTime.Now))
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
                if (!(_produtoTapecaria.Area < 0))
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
                if (!(_produtoTapecaria.PrecoMetroQuadrado < 0))
                {
                    throw new Exception("Preço do produto inválido");
                }
            }
            catch (Exception exception)
            {
                _listaDeErros.Add(exception.Message);
            }
        }

        string RetornaListaDeErros ()
        {
            return String.Join(Environment.NewLine, _listaDeErros);
        }
    }
}
