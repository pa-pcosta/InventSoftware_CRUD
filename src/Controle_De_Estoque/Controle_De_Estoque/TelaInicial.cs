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
    public partial class TelaInicial : Form
    {
        public TelaInicial()
        {
            InitializeComponent();

            List<ProdutoTapecaria> listaProdutoTapecaria = new List<ProdutoTapecaria>();

            listaProdutoTapecaria.Add(new ProdutoTapecaria() {Tipo = TipoTapecaria.tapete, DataEntrada = new DateTime()});
            listaProdutoTapecaria.Add(new ProdutoTapecaria() {Tipo = TipoTapecaria.cortina, DataEntrada = new DateTime() });
            listaProdutoTapecaria.Add(new ProdutoTapecaria() {Tipo = TipoTapecaria.estofado, DataEntrada = new DateTime() });

            for (var i = 0; i < listaProdutoTapecaria.Count; i++)
            {
                listaProdutoTapecaria[i].Id = i+1;
            }

            dataGridView1.DataSource = listaProdutoTapecaria;
        }

    }
}
