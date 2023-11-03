using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controle_De_Estoque
{
    public partial class TelaCadastroDeProduto : Form
    {
        public TelaCadastroDeProduto()
        {
            InitializeComponent();
            InitializeComboBoxTipo();
        }

        private void InitializeComboBoxTipo()
        {
            comboBoxTipo.Items.AddRange(Enum.GetNames(typeof(TipoTapecaria)));
        }

        private void TelaCadastroDeProduto_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

      

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxTipo.Items.AddRange(Enum.GetNames(typeof(TipoTapecaria)));
        }

    }
}
