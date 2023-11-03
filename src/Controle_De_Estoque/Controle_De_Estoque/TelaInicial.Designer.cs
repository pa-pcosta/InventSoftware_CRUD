namespace Controle_De_Estoque
{
    partial class TelaInicial
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BotaoCadastrarProdutoTapecaria = new System.Windows.Forms.Button();
            this.BotaoRemoverProdutoTapecaria = new System.Windows.Forms.Button();
            this.BotaoEditarProdutoTapecaria = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(734, 406);
            this.dataGridView1.TabIndex = 0;
            // 
            // BotaoCadastrarProdutoTapecaria
            // 
            this.BotaoCadastrarProdutoTapecaria.Location = new System.Drawing.Point(671, 424);
            this.BotaoCadastrarProdutoTapecaria.Name = "BotaoCadastrarProdutoTapecaria";
            this.BotaoCadastrarProdutoTapecaria.Size = new System.Drawing.Size(75, 23);
            this.BotaoCadastrarProdutoTapecaria.TabIndex = 1;
            this.BotaoCadastrarProdutoTapecaria.Text = "Cadastrar";
            this.BotaoCadastrarProdutoTapecaria.UseVisualStyleBackColor = true;
            this.BotaoCadastrarProdutoTapecaria.Click += new System.EventHandler(this.aoClicarEmCadastar);
            // 
            // BotaoRemoverProdutoTapecaria
            // 
            this.BotaoRemoverProdutoTapecaria.Location = new System.Drawing.Point(12, 424);
            this.BotaoRemoverProdutoTapecaria.Name = "BotaoRemoverProdutoTapecaria";
            this.BotaoRemoverProdutoTapecaria.Size = new System.Drawing.Size(75, 23);
            this.BotaoRemoverProdutoTapecaria.TabIndex = 2;
            this.BotaoRemoverProdutoTapecaria.Text = "Remover";
            this.BotaoRemoverProdutoTapecaria.UseVisualStyleBackColor = true;
            // 
            // BotaoEditarProdutoTapecaria
            // 
            this.BotaoEditarProdutoTapecaria.Location = new System.Drawing.Point(93, 424);
            this.BotaoEditarProdutoTapecaria.Name = "BotaoEditarProdutoTapecaria";
            this.BotaoEditarProdutoTapecaria.Size = new System.Drawing.Size(75, 23);
            this.BotaoEditarProdutoTapecaria.TabIndex = 3;
            this.BotaoEditarProdutoTapecaria.Text = "Editar";
            this.BotaoEditarProdutoTapecaria.UseVisualStyleBackColor = true;
            // 
            // TelaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 450);
            this.Controls.Add(this.BotaoEditarProdutoTapecaria);
            this.Controls.Add(this.BotaoRemoverProdutoTapecaria);
            this.Controls.Add(this.BotaoCadastrarProdutoTapecaria);
            this.Controls.Add(this.dataGridView1);
            this.Name = "TelaInicial";
            this.Text = "Produtos de Tapeçaria";
            this.Load += new System.EventHandler(this.TelaInicial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BotaoCadastrarProdutoTapecaria;
        private System.Windows.Forms.Button BotaoRemoverProdutoTapecaria;
        private System.Windows.Forms.Button BotaoEditarProdutoTapecaria;
    }
}

