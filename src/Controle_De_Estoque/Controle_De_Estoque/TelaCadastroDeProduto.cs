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
            InitializeTextBoxPrecoMetroQuadrado();
        }

        private void InitializeTextBoxPrecoMetroQuadrado()
        {
            textBoxPrecoMetroQuadrado.Text = string.Empty;
        }

        private void InitializeComboBoxTipo()
        {
            comboBoxTipo.Items.AddRange(Enum.GetNames(typeof(TipoTapecaria)));
        }

        private void TelaCadastroDeProduto_Load(object sender, EventArgs e)
        {

        }

    }
}
