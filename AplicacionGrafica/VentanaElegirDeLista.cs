using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using modelos;
namespace AplicacionGrafica
{
    public partial class VentanaElegirDeLista<T> : Form
    {
       
        public VentanaElegirDeLista(List<T> lista)
        {
            
            InitializeComponent();
            listBox1.DataSource = lista;
        }
    }
}
