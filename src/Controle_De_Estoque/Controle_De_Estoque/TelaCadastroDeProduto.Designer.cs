﻿using System;

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
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePickerDataEntrada = new System.Windows.Forms.DateTimePicker();
            this.textBoxArea = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // botaoCancelar
            // 
            this.botaoCancelar.Location = new System.Drawing.Point(12, 289);
            this.botaoCancelar.Name = "botaoCancelar";
            this.botaoCancelar.Size = new System.Drawing.Size(75, 23);
            this.botaoCancelar.TabIndex = 0;
            this.botaoCancelar.Text = "button1";
            this.botaoCancelar.UseVisualStyleBackColor = true;
            // 
            // botaoSalvar
            // 
            this.botaoSalvar.Location = new System.Drawing.Point(198, 289);
            this.botaoSalvar.Name = "botaoSalvar";
            this.botaoSalvar.Size = new System.Drawing.Size(75, 23);
            this.botaoSalvar.TabIndex = 1;
            this.botaoSalvar.Text = "Salvar";
            this.botaoSalvar.UseVisualStyleBackColor = true;
            this.botaoSalvar.Click += new System.EventHandler(this.aoClicarEmSalvar);
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
            this.labelDataEntrada.AutoSize = true;
            this.labelDataEntrada.Location = new System.Drawing.Point(173, 26);
            this.labelDataEntrada.Name = "labelDataEntrada";
            this.labelDataEntrada.Size = new System.Drawing.Size(87, 13);
            this.labelDataEntrada.TabIndex = 4;
            this.labelDataEntrada.Text = "Data de entrada:";
            // 
            // labelArea
            // 
            this.labelArea.AutoSize = true;
            this.labelArea.Location = new System.Drawing.Point(125, 103);
            this.labelArea.Name = "labelArea";
            this.labelArea.Size = new System.Drawing.Size(55, 13);
            this.labelArea.TabIndex = 5;
            this.labelArea.Text = "Tamanho:";
            // 
            // labelPrecoMetroQuadrado
            // 
            this.labelPrecoMetroQuadrado.AutoSize = true;
            this.labelPrecoMetroQuadrado.Location = new System.Drawing.Point(12, 103);
            this.labelPrecoMetroQuadrado.Name = "labelPrecoMetroQuadrado";
            this.labelPrecoMetroQuadrado.Size = new System.Drawing.Size(38, 13);
            this.labelPrecoMetroQuadrado.TabIndex = 6;
            this.labelPrecoMetroQuadrado.Text = "Preço:";
            // 
            // labelDetalhes
            // 
            this.labelDetalhes.AutoSize = true;
            this.labelDetalhes.Location = new System.Drawing.Point(9, 183);
            this.labelDetalhes.Name = "labelDetalhes";
            this.labelDetalhes.Size = new System.Drawing.Size(52, 13);
            this.labelDetalhes.TabIndex = 7;
            this.labelDetalhes.Text = "Detalhes:";
            // 
            // textBoxPrecoMetroQuadrado
            // 
            this.textBoxPrecoMetroQuadrado.Location = new System.Drawing.Point(33, 119);
            this.textBoxPrecoMetroQuadrado.Name = "textBoxPrecoMetroQuadrado";
            this.textBoxPrecoMetroQuadrado.Size = new System.Drawing.Size(39, 20);
            this.textBoxPrecoMetroQuadrado.TabIndex = 9;
            // 
            // comboBoxTipo
            // 
            this.comboBoxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipo.FormattingEnabled = true;
            this.comboBoxTipo.Items.AddRange(Enum.GetNames(typeof(TipoTapecaria)));
            this.comboBoxTipo.Location = new System.Drawing.Point(15, 41);
            this.comboBoxTipo.Name = "comboBoxTipo";
            this.comboBoxTipo.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTipo.TabIndex = 10;
            // 
            // checkBoxEntregarAposServico
            // 
            this.checkBoxEntregarAposServico.AutoSize = true;
            this.checkBoxEntregarAposServico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBoxEntregarAposServico.Location = new System.Drawing.Point(204, 125);
            this.checkBoxEntregarAposServico.Name = "checkBoxEntregarAposServico";
            this.checkBoxEntregarAposServico.Size = new System.Drawing.Size(66, 17);
            this.checkBoxEntregarAposServico.TabIndex = 13;
            this.checkBoxEntregarAposServico.Text = "Entregar";
            this.checkBoxEntregarAposServico.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.checkBoxEntregarAposServico.UseVisualStyleBackColor = true;
            // 
            // textBoxDetalhes
            // 
            this.textBoxDetalhes.Location = new System.Drawing.Point(12, 199);
            this.textBoxDetalhes.Multiline = true;
            this.textBoxDetalhes.Name = "textBoxDetalhes";
            this.textBoxDetalhes.Size = new System.Drawing.Size(261, 71);
            this.textBoxDetalhes.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(168, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "m²";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(72, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "/m²";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "R$";
            // 
            // dateTimePickerDataEntrada
            // 
            this.dateTimePickerDataEntrada.CustomFormat = "";
            this.dateTimePickerDataEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDataEntrada.Location = new System.Drawing.Point(176, 42);
            this.dateTimePickerDataEntrada.Name = "dateTimePickerDataEntrada";
            this.dateTimePickerDataEntrada.Size = new System.Drawing.Size(99, 20);
            this.dateTimePickerDataEntrada.TabIndex = 18;
            this.dateTimePickerDataEntrada.Value = DateTime.Today;
            // 
            // textBoxArea
            // 
            this.textBoxArea.Location = new System.Drawing.Point(128, 119);
            this.textBoxArea.Name = "textBoxArea";
            this.textBoxArea.Size = new System.Drawing.Size(39, 20);
            this.textBoxArea.TabIndex = 19;
            // 
            // TelaCadastroDeProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 323);
            this.Controls.Add(this.textBoxArea);
            this.Controls.Add(this.dateTimePickerDataEntrada);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
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
            this.Load += new System.EventHandler(this.TelaCadastroDeProduto_Load);
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
        private System.Windows.Forms.TextBox textBoxPrecoMetroQuadrado;
        private System.Windows.Forms.ComboBox comboBoxTipo;
        private System.Windows.Forms.CheckBox checkBoxEntregarAposServico;
        private System.Windows.Forms.TextBox textBoxDetalhes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataEntrada;
        private System.Windows.Forms.TextBox textBoxArea;
    }
}