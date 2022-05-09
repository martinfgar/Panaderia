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
using modelos;
using System.Data.SQLite;
namespace AplicacionGrafica
{
    public partial class VentanaProduccion : Form
    {
        GestorPanaderia gestor;
        Dictionary<Producto, int> listaProduccion = new Dictionary<Producto, int>();
        public VentanaProduccion(GestorPanaderia gestor)
        {

            InitializeComponent();
            this.gestor = gestor;
            listBox1.DataSource = gestor.listaProductos;
            listaVistaProd.Columns.Add("Producto");
            listaVistaProd.Columns.Add("Cantidad");
        }

        private void cantidadHoras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void anadirProducto_Click(object sender, EventArgs e)
        {
            Producto prod = (Producto)listBox1.SelectedItem;
            int cantidad = (int)cantidadProducto.Value;

            listaProduccion[prod] = cantidad;
            foreach (ListViewItem item in listaVistaProd.Items)
            {
                if (item.SubItems[0].Text.Equals(prod.ToString()))
                {
                    item.SubItems[1].Text = cantidad.ToString();
                    return; 
                }
            }
            listaVistaProd.Items.Add(new ListViewItem(new string[] { prod.ToString(), cantidad.ToString() }));

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (listaProduccion.Count == 0) {
                MessageBox.Show("Añade al menos un producto","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            try
            {
                float horas_horno = float.Parse(cantidadHoras.Text);
                List<(Producto, int)> productos = new List<(Producto, int)>();
                foreach (KeyValuePair<Producto, int> kvp in listaProduccion) { productos.Add((kvp.Key, kvp.Value)); }
                gestor.registrarProduccion(productos, horas_horno);
                MessageBox.Show("Producción confirmada", "Producción confirmada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("La producción de hoy ya ha sido especificada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) {
                MessageBox.Show($"Error:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
