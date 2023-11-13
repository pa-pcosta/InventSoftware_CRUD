using System;

namespace Controle_De_Estoque
{
    partial class TelaCadastroDeProduto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.botaoCancelar = new System.Windows.Forms.Button();
            this.botaoSalvar = new System.Windows.Forms.Button();
            this.labelTipo = new System.Windows.Forms.Label();
            this.labelDataEntrada = new System.Windows.Forms.Label();
            this.labelArea = new System.Windows.Forms.Label();
            this.labelPrecoMetroQuadrado = new System.Windows.Forms.Label();
            this.labelDetalhes = new System.Windows.Forms.Label();
            this.textBoxPrecoMetroQuadrado = new System.Windows.Forms.TextBox();
            this.comboBoxTipo = new System.Windows.Forms.ComboBox();
            this.checkBoxEntregarAposServico = new System.Windows.Forms.CheckBox();
            this.textBoxDetalhes = new System.Windows.Forms.TextBox();
            this.dateTimePickerDataEntrada = new System.Windows.Forms.DateTimePicker();
            this.textBoxArea = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // botaoCancelar
            // 
            this.botaoCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.botaoCancelar.Location = new System.Drawing.Point(116, 289);
            this.botaoCancelar.Name = "botaoCancelar";
            this.botaoCancelar.Size = new System.Drawing.Size(75, 23);
            this.botaoCancelar.TabIndex = 0;
            this.botaoCancelar.Text = "Cancelar";
            this.botaoCancelar.UseVisualStyleBackColor = true;
            this.botaoCancelar.Click += new System.EventHandler(this.AoClicarEmCancelar);
            // 
            // botaoSalvar
            // 
            this.botaoSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.botaoSalvar.Location = new System.Drawing.Point(198, 289);
            this.botaoSalvar.Name = "botaoSalvar";
            this.botaoSalvar.Size = new System.Drawing.Size(75, 23);
            this.botaoSalvar.TabIndex = 1;
            this.botaoSalvar.Text = "Salvar";
            this.botaoSalvar.UseVisualStyleBackColor = true;
            this.botaoSalvar.Click += new System.EventHandler(this.AoClicarEmSalvar);
            // 
            // labelTipo
            // 
            this.labelTipo.AutoSize = true;
            this.labelTipo.Location = new System.Drawing.Point(12, 24);
            this.labelTipo.Name = "labelTipo";
            this.labelTipo.Size = new System.Drawing.Size(31, 13);
            this.labelTipo.TabIndex = 3;
            this.labelTipo.Text = "Tipo:";
            // 
            // labelDataEntrada
            // 
            this.labelDataEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDataEntrada.AutoSize = true;
            this.labelDataEntrada.Location = new System.Drawing.Point(173, 26);
            this.labelDataEntrada.Name = "labelDataEntrada";
            this.labelDataEntrada.Size = new System.Drawing.Size(87, 13);
            this.labelDataEntrada.TabIndex = 4;
            this.labelDataEntrada.Text = "Data de entrada:";
            // 
            // labelArea
            // 
            this.labelArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelArea.AutoSize = true;
            this.labelArea.Location = new System.Drawing.Point(113, 103);
            this.labelArea.Name = "labelArea";
            this.labelArea.Size = new System.Drawing.Size(69, 13);
            this.labelArea.TabIndex = 5;
            this.labelArea.Text = "Tamanho m²:";
            // 
            // labelPrecoMetroQuadrado
            // 
            this.labelPrecoMetroQuadrado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPrecoMetroQuadrado.AutoSize = true;
            this.labelPrecoMetroQuadrado.Location = new System.Drawing.Point(12, 103);
            this.labelPrecoMetroQuadrado.Name = "labelPrecoMetroQuadrado";
            this.labelPrecoMetroQuadrado.Size = new System.Drawing.Size(55, 13);
            this.labelPrecoMetroQuadrado.TabIndex = 6;
            this.labelPrecoMetroQuadrado.Text = "Preço R$:";
            // 
            // labelDetalhes
            // 
            this.labelDetalhes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDetalhes.AutoSize = true;
            this.labelDetalhes.Location = new System.Drawing.Point(9, 183);
            this.labelDetalhes.Name = "labelDetalhes";
            this.labelDetalhes.Size = new System.Drawing.Size(52, 13);
            this.labelDetalhes.TabIndex = 7;
            this.labelDetalhes.Text = "Detalhes:";
            // 
            // textBoxPrecoMetroQuadrado
            // 
            this.textBoxPrecoMetroQuadrado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxPrecoMetroQuadrado.Location = new System.Drawing.Point(15, 119);
            this.textBoxPrecoMetroQuadrado.Name = "textBoxPrecoMetroQuadrado";
            this.textBoxPrecoMetroQuadrado.Size = new System.Drawing.Size(66, 20);
            this.textBoxPrecoMetroQuadrado.TabIndex = 9;
            // 
            // comboBoxTipo
            // 
            this.comboBoxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipo.FormattingEnabled = true;
            this.comboBoxTipo.Location = new System.Drawing.Point(15, 41);
            this.comboBoxTipo.Name = "comboBoxTipo";
            this.comboBoxTipo.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTipo.TabIndex = 10;
            // 
            // checkBoxEntregarAposServico
            // 
            this.checkBoxEntregarAposServico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxEntregarAposServico.AutoSize = true;
            this.checkBoxEntregarAposServico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBoxEntregarAposServico.Location = new System.Drawing.Point(207, 122);
            this.checkBoxEntregarAposServico.Name = "checkBoxEntregarAposServico";
            this.checkBoxEntregarAposServico.Size = new System.Drawing.Size(66, 17);
            this.checkBoxEntregarAposServico.TabIndex = 13;
            this.checkBoxEntregarAposServico.Text = "Entregar";
            this.checkBoxEntregarAposServico.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.checkBoxEntregarAposServico.UseVisualStyleBackColor = true;
            // 
            // textBoxDetalhes
            // 
            this.textBoxDetalhes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDetalhes.Location = new System.Drawing.Point(12, 199);
            this.textBoxDetalhes.Multiline = true;
            this.textBoxDetalhes.Name = "textBoxDetalhes";
            this.textBoxDetalhes.Size = new System.Drawing.Size(261, 71);
            this.textBoxDetalhes.TabIndex = 14;
            // 
            // dateTimePickerDataEntrada
            // 
            this.dateTimePickerDataEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerDataEntrada.CustomFormat = "";
            this.dateTimePickerDataEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDataEntrada.Location = new System.Drawing.Point(176, 42);
            this.dateTimePickerDataEntrada.Name = "dateTimePickerDataEntrada";
            this.dateTimePickerDataEntrada.Size = new System.Drawing.Size(99, 20);
            this.dateTimePickerDataEntrada.TabIndex = 18;
            this.dateTimePickerDataEntrada.Value = new System.DateTime(2023, 11, 6, 0, 0, 0, 0);
            // 
            // textBoxArea
            // 
            this.textBoxArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.textBoxArea.Location = new System.Drawing.Point(116, 119);
            this.textBoxArea.Name = "textBoxArea";
            this.textBoxArea.Size = new System.Drawing.Size(66, 20);
            this.textBoxArea.TabIndex = 19;
            // 
            // TelaCadastroDeProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 323);
            this.Controls.Add(this.textBoxArea);
            this.Controls.Add(this.dateTimePickerDataEntrada);
            this.Controls.Add(this.textBoxDetalhes);
            this.Controls.Add(this.checkBoxEntregarAposServico);
            this.Controls.Add(this.comboBoxTipo);
            this.Controls.Add(this.textBoxPrecoMetroQuadrado);
            this.Controls.Add(this.labelDetalhes);
            this.Controls.Add(this.labelPrecoMetroQuadrado);
            this.Controls.Add(this.labelArea);
            this.Controls.Add(this.labelDataEntrada);
            this.Controls.Add(this.labelTipo);
            this.Controls.Add(this.botaoSalvar);
            this.Controls.Add(this.botaoCancelar);
            this.Name = "TelaCadastroDeProduto";
            this.Text = "Cadastro - Produto Tapeçaria";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botaoCancelar;
        private System.Windows.Forms.Button botaoSalvar;
        private System.Windows.Forms.Label labelTipo;
        private System.Windows.Forms.Label labelDataEntrada;
        private System.Windows.Forms.Label labelArea;
        private System.Windows.Forms.Label labelPrecoMetroQuadrado;
        private System.Windows.Forms.Label labelDetalhes;
        public System.Windows.Forms.TextBox textBoxPrecoMetroQuadrado;
        public System.Windows.Forms.ComboBox comboBoxTipo;
        private System.Windows.Forms.CheckBox checkBoxEntregarAposServico;
        private System.Windows.Forms.TextBox textBoxDetalhes;
        public System.Windows.Forms.DateTimePicker dateTimePickerDataEntrada;
        public System.Windows.Forms.TextBox textBoxArea;
    }
}