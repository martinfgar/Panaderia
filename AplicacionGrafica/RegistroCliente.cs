using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace AplicacionGrafica
{
    public partial class RegistroCliente : Form
    {
        public RegistroCliente()
        {
            InitializeComponent();
        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            if ((new Regex(@"^[0-9]{8}[A-Za-z]$")).IsMatch(txtDNI.Text))
            {
                txtDNI.ForeColor = Color.Black;
            }
            else
            {
                txtDNI.ForeColor = Color.Red;
            }
        }
    }
}
