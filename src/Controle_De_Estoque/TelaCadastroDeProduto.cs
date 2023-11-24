﻿using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Controle_De_Estoque.ValidacaoProdutoTapecaria;

namespace Controle_De_Estoque
{
    public partial class TelaCadastroDeProduto : Form
    {
        public ProdutoTapecaria _novoProdutoTapecaria;

        private static int _ultimoIdUtilizado = 0;

        public TelaCadastroDeProduto(ProdutoTapecaria produtoTapecaria)
        {
            InitializeComponent();
            InicializaCampos();

            if (produtoTapecaria != null)
            {
                comboBoxTipo.SelectedIndex = Convert.ToInt32(produtoTapecaria.Tipo);
                dateTimePickerDataEntrada.Value = produtoTapecaria.DataEntrada;
                textBoxArea.Text = produtoTapecaria.Area.ToString();
                textBoxPrecoMetroQuadrado.Text = produtoTapecaria.PrecoMetroQuadrado.ToString();
                checkBoxEntregarAposServico.Checked = produtoTapecaria.EhEntrega;
                textBoxDetalhes.Text = produtoTapecaria.Detalhes;

                _novoProdutoTapecaria = produtoTapecaria;
            }
            else
            {
                _novoProdutoTapecaria = new ProdutoTapecaria();
            }
        }

        private void InicializaCampos()
        {
            comboBoxTipo.Items.AddRange(Enum.GetNames(typeof(TipoTapecaria)));
            dateTimePickerDataEntrada.Value = DateTime.Today;
        }

        public void AoClicarEmSalvar(object sender, EventArgs e)
        {
            try
            {
                var produtoAValidar = ObterProdutoaValidar();
                var validador = new ValidadorProdutoTapecaria();

                var listaDeErros = validador.ValidarProduto(produtoAValidar);

                if (!listaDeErros.Any())
                {
                    if (_novoProdutoTapecaria.Id == 0)
                        _novoProdutoTapecaria.Id = ObterProximoId();

                    AtribuiAoProdutoTapecaria();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(string.Join("\r", listaDeErros), "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AoClicarEmCancelar(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Ao cancelar a operação os dados que já preencheu serão perdidos.\nDeseja continuar?", "Cancelar cadastro", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro inesperado", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private ProdutoAValidar ObterProdutoaValidar()
        {
            ProdutoAValidar produtoAValidar = new ProdutoAValidar()
            {
                Tipo = comboBoxTipo.SelectedIndex.ToString(),
                DataEntrada = dateTimePickerDataEntrada.Value.ToString(),
                Area = textBoxArea.Text,
                PrecoMetroQuadrado = textBoxPrecoMetroQuadrado.Text
            };

            return produtoAValidar;
        }

        private void AtribuiAoProdutoTapecaria()
        {
            _novoProdutoTapecaria.Tipo = (TipoTapecaria)comboBoxTipo.SelectedIndex;
            _novoProdutoTapecaria.DataEntrada = dateTimePickerDataEntrada.Value;
            _novoProdutoTapecaria.Area = Convert.ToDouble(textBoxArea.Text);
            _novoProdutoTapecaria.PrecoMetroQuadrado = Convert.ToDecimal(textBoxPrecoMetroQuadrado.Text);
            _novoProdutoTapecaria.EhEntrega = checkBoxEntregarAposServico.Checked;
            _novoProdutoTapecaria.Detalhes = textBoxDetalhes.Text;
        }

        private int ObterProximoId()
        {
            return ++_ultimoIdUtilizado;
        }

        private void textBoxPrecoMetroQuadrado_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxPrecoMetroQuadrado.Leave += AplicarMascaraPontoFlutuante;
            
            string tecla = e.KeyChar.ToString();
            var ehValido = Regex.IsMatch(tecla, "[0-9]|[\b]|[,]");
            var ehVirgula = Regex.IsMatch(tecla, ",");
            var posicaoDaVirgula = textBoxPrecoMetroQuadrado.Text.IndexOf(',');
            var naoExisteOcorrencia = -1;


            if (!ehValido || (ehVirgula && posicaoDaVirgula != naoExisteOcorrencia))
            {
                e.Handled = true;
            }
        }

        private void textBoxArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxArea.Leave += AplicarMascaraPontoFlutuante;

            string tecla = e.KeyChar.ToString();
            var ehValido = Regex.IsMatch(tecla, "[0-9]|[\b]|[,]");
            var ehVirgula = Regex.IsMatch(tecla, ",");
            var posicaoDaVirgula = textBoxArea.Text.IndexOf(',');
            var naoExisteOcorrencia = -1;

            if (!ehValido || (ehVirgula && posicaoDaVirgula != naoExisteOcorrencia))
            {
                e.Handled = true;
            }
        }

        private void AplicarMascaraPontoFlutuante(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;

            if (!String.IsNullOrEmpty(txt.Text))
            {
                txt.Text = decimal.Parse(txt.Text).ToString("N2");
            }
        }
    }
}
