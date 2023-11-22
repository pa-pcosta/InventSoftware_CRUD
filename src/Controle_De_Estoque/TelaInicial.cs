using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Controle_De_Estoque
{
    public partial class TelaInicial : Form
    {
        public List<ProdutoTapecaria> _listaProdutoTapecaria = new List<ProdutoTapecaria>();

        public TelaInicial()
        {
            InitializeComponent();
            InicializaCampos();
        }

        private void InicializaCampos()
        {
            //dataGridViewListaProdutoTapecaria.MultiSelect = false;
            dataGridViewListaProdutoTapecaria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //Teste
            _listaProdutoTapecaria.Add(new ProdutoTapecaria() { Tipo = (TipoTapecaria)1, DataEntrada = new DateTime(2000,01,19), Area = 23.00, PrecoMetroQuadrado = 20, Detalhes = "TESTE"});
            _listaProdutoTapecaria.Add(new ProdutoTapecaria() { });
            _listaProdutoTapecaria.Add(new ProdutoTapecaria() { });
            atualizaDataGridView();
        }

        private void AoClicarEmCadastrar(object sender, EventArgs e)
        {
            try
            {
                ProdutoTapecaria novoProdutoTapecaria = new ProdutoTapecaria();
                TelaCadastroDeProduto infoProdutoTapecaria = new TelaCadastroDeProduto(novoProdutoTapecaria);
                infoProdutoTapecaria.ShowDialog();

                if(infoProdutoTapecaria.DialogResult.Equals(DialogResult.OK))
                {
                    _listaProdutoTapecaria.Add(novoProdutoTapecaria);
                    atualizaDataGridView();
                    MessageBox.Show("Novo produto cadastrado com sucesso");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void atualizaDataGridView()
        {
            dataGridViewListaProdutoTapecaria.DataSource = null;
            dataGridViewListaProdutoTapecaria.DataSource = _listaProdutoTapecaria;
        }

        private void AoClicarEmEditar(object sender, EventArgs e)
        {
            try
            {
                var qtdLinhasSelecionadas = dataGridViewListaProdutoTapecaria.SelectedRows.Count;

                if (qtdLinhasSelecionadas == 1)
                {
                    var linhaSelecionada = dataGridViewListaProdutoTapecaria.CurrentRow;

                    ProdutoTapecaria produtoEditado = (ProdutoTapecaria)linhaSelecionada.DataBoundItem;
                    
                    TelaCadastroDeProduto infoProdutoTapecaria = new TelaCadastroDeProduto(produtoEditado);
                    infoProdutoTapecaria.ShowDialog();
                    
                }
                else
                {
                    MessageBox.Show("Selecione apenas 1 linha", "Erro inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
