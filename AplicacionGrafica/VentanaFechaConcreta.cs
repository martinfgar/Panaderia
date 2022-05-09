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
    public partial class VentanaFechaConcreta : Form
    {
        public VentanaFechaConcreta()
        {
            InitializeComponent();
            dateTimePicker1.MinDate = DateTime.Today.AddDays(2);
        }
    }
}
