using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema;
namespace AplicacionGrafica
{
    public partial class VentanaProduccion : Form
    {
        GestorPanaderia gestor;
        public VentanaProduccion(GestorPanaderia gestor)
        {

            InitializeComponent();
            this.gestor = gestor;
            listBox1.DataSource = gestor.listaProductos;
        }
    }
}
