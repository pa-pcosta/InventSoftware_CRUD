using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Controle_De_Estoque
{
    public partial class TelaInicial : Form
    {
        public List<ProdutoTapecaria> _listaProdutoTapecaria = new List<ProdutoTapecaria>();

        private readonly bool _ehNovoProduto = true;

        public TelaInicial()
        {
            InitializeComponent();
        }

        private void AoClicarEmCadastrar(object sender, EventArgs e)
        {
            try
            {
                ProdutoTapecaria novoProdutoTapecaria = new ProdutoTapecaria();
                TelaCadastroDeProduto infoProdutoTapecaria = new TelaCadastroDeProduto(novoProdutoTapecaria, _ehNovoProduto);
                infoProdutoTapecaria.ShowDialog();

                if(infoProdutoTapecaria.DialogResult.Equals(DialogResult.OK))
                {
                    _listaProdutoTapecaria.Add(novoProdutoTapecaria);
                    AtualizaDataGridView();
                    MessageBox.Show("Novo produto cadastrado com sucesso");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AtualizaDataGridView()
        {
            dataGridViewListaProdutoTapecaria.DataSource = null;
            dataGridViewListaProdutoTapecaria.DataSource = _listaProdutoTapecaria;
        }

        private void AoClicarEmEditar(object sender, EventArgs e)
        {
            try
            {
                var limiteLinhasSelecionadas = 1;
                var qtdLinhasSelecionadas = dataGridViewListaProdutoTapecaria.SelectedRows.Count;

                if (qtdLinhasSelecionadas == limiteLinhasSelecionadas)
                {
                    var idObjetoSelecionado = Convert.ToInt32(dataGridViewListaProdutoTapecaria.CurrentRow.Cells["Id"].Value);

                    ProdutoTapecaria produtoEditado = ObterObjetoPorId(idObjetoSelecionado);
                    
                    TelaCadastroDeProduto infoProdutoTapecaria = new TelaCadastroDeProduto(produtoEditado, !_ehNovoProduto);
                    infoProdutoTapecaria.ShowDialog();
                    
                    if (infoProdutoTapecaria.DialogResult.Equals(DialogResult.OK))
                    {
                        AtualizaDataGridView();
                        MessageBox.Show("Registro editado com sucesso","SUCESSSO!");
                    }
                }
                else if (qtdLinhasSelecionadas < limiteLinhasSelecionadas)
                {
                    MessageBox.Show("Selecione um registro", "Não há linha selecionada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Selecione apenas 1 linha", "OPERAÇÃO INVÁLIDA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ProdutoTapecaria ObterObjetoPorId(int Id)
        {
            return _listaProdutoTapecaria.FirstOrDefault(item => item.Id == Id);
        }
    }
}
