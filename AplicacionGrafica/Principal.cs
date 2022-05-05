using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionGrafica
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void ingresos_Click(object sender, EventArgs e)
        {
            VentanaFechas f = new VentanaFechas();

            var result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
              
                //get selected date
            }
        }

        private void gastos_Click(object sender, EventArgs e)
        {
            VentanaFechas f = new VentanaFechas();

            var result = f.ShowDialog();
            if (result == DialogResult.OK)
            {

                //get selected date
            }
        }

        private void balance_Click(object sender, EventArgs e)
        {
            VentanaFechas f = new VentanaFechas();

            var result = f.ShowDialog();
            if (result == DialogResult.OK)
            {

                //get selected date
            }
        }
    }
}
