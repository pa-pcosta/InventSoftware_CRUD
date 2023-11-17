using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Controle_De_Estoque
{
    public partial class TelaCadastroDeProduto : Form
    {
        public readonly ProdutoTapecaria _novoProdutoTapecaria;

        private static int _ultimoIdUtilizado = 0;

        public TelaCadastroDeProduto(ProdutoTapecaria novoProdutoTapecaria)
        {
            InitializeComponent();
            InicializarCampos();

            _novoProdutoTapecaria = novoProdutoTapecaria;
        }

        private void InicializarCampos()
        {
            dateTimePickerDataEntrada.Value = DateTime.Today;
            comboBoxTipo.Items.AddRange(Enum.GetNames(typeof(TipoTapecaria)));
        }

        public void AoClicarEmSalvar(object sender, EventArgs e)
        {
            try
            {
                var valoresParaValidar = ObterValoresDosCampos();

                ValidacaoProdutoTapecaria validacaoProdutoTapecaria = new ValidacaoProdutoTapecaria();
                var listaErros = validacaoProdutoTapecaria.ValidarProduto(valoresParaValidar);

                if (!listaErros.Any())
                {
                    ConstruirObjetoTapecaria();
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(string.Join("\r", listaErros), "Houve erros no formulário!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO inesperado!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConstruirObjetoTapecaria()
        {
            _novoProdutoTapecaria.Id = ObterProximoId();
            _novoProdutoTapecaria.Tipo = (TipoTapecaria)comboBoxTipo.SelectedIndex; ;
            _novoProdutoTapecaria.DataEntrada = dateTimePickerDataEntrada.Value;
            _novoProdutoTapecaria.Area = Convert.ToDouble(textBoxArea.Text);
            _novoProdutoTapecaria.PrecoMetroQuadrado = Convert.ToDecimal(textBoxPrecoMetroQuadrado.Text);
            _novoProdutoTapecaria.EhEntrega = checkBoxEntregarAposServico.Checked;
            _novoProdutoTapecaria.Detalhes = textBoxDetalhes.Text;
        }

        private Dictionary<string, string> ObterValoresDosCampos()
        {
            Dictionary<string, string> camposParaValidar = new Dictionary<string, string>()
            {
                { comboBoxTipo.Name, comboBoxTipo.SelectedIndex.ToString() },
                { dateTimePickerDataEntrada.Name, dateTimePickerDataEntrada.Value.ToString() },
                { textBoxArea.Name, textBoxArea.Text },
                { textBoxPrecoMetroQuadrado.Name, textBoxPrecoMetroQuadrado.Text },
                { checkBoxEntregarAposServico.Name, checkBoxEntregarAposServico.Checked.ToString() },
                { textBoxDetalhes.Name, textBoxDetalhes.Text }
            };

            return camposParaValidar;
        }

        private int ObterProximoId()
        {
            return ++_ultimoIdUtilizado;
        }

        private void AoClicarEmCancelar(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void textBoxPrecoMetroQuadrado_KeyPress(object sender, KeyPressEventArgs e)
        {
            string tecla = e.KeyChar.ToString();
            var ehValido = Regex.IsMatch(tecla, "[0-9]|[\b]");
            //var ehPontoOuVirgula = Regex.IsMatch(tecla, "[.,]");
            //var posicaoDoPonto = textBoxPrecoMetroQuadrado.Text.IndexOf('.');
            //var posicaoDaVirgula = textBoxPrecoMetroQuadrado.Text.IndexOf(',');
            //var naoExisteOcorrencia = -1;


            if (!ehValido)
            {
                e.Handled = true;
            }
            else
            {
                string valor = textBoxPrecoMetroQuadrado.Text;
                var tamanhoString = textBoxPrecoMetroQuadrado.TextLength;
                
                if (tamanhoString == 2)
                {
                    valor.Insert(tamanhoString, ",");
                }
                
                
            }

            //if (ehPontoOuVirgula && (posicaoDoPonto != naoExisteOcorrencia || posicaoDaVirgula != naoExisteOcorrencia))
            //{
            //    e.Handled = true;
            //}
        }

        private void textBoxArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            string tecla = e.KeyChar.ToString();
            var ehValido = Regex.IsMatch(tecla, "[0-9]|[\b]|[.,]");
            var ehPontoOuVirgula = Regex.IsMatch(tecla, "[.,]");
            var posicaoDoPonto = textBoxArea.Text.IndexOf('.');
            var posicaoDaVirgula = textBoxArea.Text.IndexOf(',');
            var naoExisteOcorrencia = -1;

            if (!ehValido)
            {
                e.Handled = true;
            }

            if (ehPontoOuVirgula && (posicaoDoPonto != naoExisteOcorrencia || posicaoDaVirgula != naoExisteOcorrencia))
            {
                e.Handled = true;
            }
        }
    }
}
