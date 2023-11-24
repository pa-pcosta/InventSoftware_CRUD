﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Controle_De_Estoque
{
    public partial class TelaInicial : Form
    {
        public List<ProdutoTapecaria> _listaProdutoTapecaria = new List<ProdutoTapecaria>();

        public TelaInicial()
        {
            InitializeComponent();
        }

        private void AoClicarEmCadastrar(object sender, EventArgs e)
        {
            try
            {
                TelaCadastroDeProduto infoProdutoTapecaria = new TelaCadastroDeProduto(null);
                infoProdutoTapecaria.ShowDialog();

                if(infoProdutoTapecaria.DialogResult == DialogResult.OK)
                {
                    _listaProdutoTapecaria.Add(infoProdutoTapecaria._novoProdutoTapecaria);
                    AtualizaDataGridView();
                    MessageBox.Show("Novo produto cadastrado com sucesso");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                    ProdutoTapecaria produtoASerEditado = ObterObjetoPorId(idObjetoSelecionado);
                    
                    TelaCadastroDeProduto infoProdutoTapecaria = new TelaCadastroDeProduto(produtoASerEditado);
                    infoProdutoTapecaria.ShowDialog();
                    
                    if (infoProdutoTapecaria.DialogResult == DialogResult.OK)
                    {
                        SubstituiObjetoNaLista(produtoASerEditado, infoProdutoTapecaria);
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

        private void SubstituiObjetoNaLista(ProdutoTapecaria produtoASerEditado, TelaCadastroDeProduto infoProdutoTapecaria)
        {
            var indexProdutoEditado = _listaProdutoTapecaria.IndexOf(produtoASerEditado);

            if (indexProdutoEditado != -1)
            {
                _listaProdutoTapecaria[indexProdutoEditado] = infoProdutoTapecaria._novoProdutoTapecaria;
            }
        }

        public void AtualizaDataGridView()
        {
            dataGridViewListaProdutoTapecaria.DataSource = null;
            dataGridViewListaProdutoTapecaria.DataSource = _listaProdutoTapecaria;
        }
    }
}
