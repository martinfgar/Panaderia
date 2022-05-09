using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using modelos;
using Sistema;
namespace AplicacionGrafica
{
    public partial class Principal : Form
    {
        GestorPanaderia gestor;
        System.Windows.Forms.DataVisualization.Charting.Series series1;
        Dictionary<Producto, int> listaCompra_pedido = new Dictionary<Producto, int>();
        Dictionary<Producto, int> listaCompra_local = new Dictionary<Producto, int>();
        public Principal(GestorPanaderia gestor)
        {
            
            this.gestor = gestor;
          
          
            InitializeComponent();
            listaClientes.DataSource = gestor.listaDeClientes();
            listaProductos.DataSource = gestor.listaProductos;
            listaProductosVenta.DataSource = gestor.listaProductos;
            listaCompra.Columns.Add("Producto");
            listaCompra.Columns.Add("Cantidad");
            listaCompraLocal.Columns.Add("Producto");
            listaCompraLocal.Columns.Add("Cantidad");
            dateTimePicker1.MinDate = DateTime.Today.AddDays(2);

        }

        private void graficoBarrasDineroTiempo() {
            // Graficos de finanzas.
            chart1.ChartAreas[0].AxisX.Title = "Fecha";
            chart1.ChartAreas[0].AxisY.Title = "€";
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
        }

        private void ingresos_Click(object sender, EventArgs e)
        {
            VentanaFechas f = new VentanaFechas();           
            var result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                chart1.Series.Clear();
                System.DateTime fecha_1 = f.fecha_inicio.Value;
                System.DateTime fecha_2 = f.fecha_final.Value;
                series1 = new System.Windows.Forms.DataVisualization.Charting.Series($"Ingresos Periodo: {fecha_1.ToString("d")} - {fecha_2.ToString("d")}");
                series1.IsValueShownAsLabel = true;
                graficoBarrasDineroTiempo();
                
                while ((fecha_1-fecha_2).TotalDays<1) {
                    double benef = Math.Round((gestor.dineroPedidosRangoFechas(fecha_1, fecha_1) + gestor.dineroVentasRangoFechas(fecha_1, fecha_1)),2);
                    series1.Points.AddXY(fecha_1,benef);
                    
                    fecha_1 = fecha_1.AddDays(1);
                    
                }
                
                chart1.Series.Add(series1);
                
            }
        }

        

        private void gastos_Click(object sender, EventArgs e)
        {
            VentanaFechas f = new VentanaFechas();

            var result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                chart1.Series.Clear();
                System.DateTime fecha_1 = f.fecha_inicio.Value;
                System.DateTime fecha_2 = f.fecha_final.Value;
                series1 = new System.Windows.Forms.DataVisualization.Charting.Series($"Gastos Periodo: {fecha_1.ToString("d")} - {fecha_2.ToString("d")}");
                series1.IsValueShownAsLabel = true;
                graficoBarrasDineroTiempo();
                int i = 0;
                while ((fecha_1 - fecha_2).TotalDays < 1)
                {
                    double gasto = Math.Round(gestor.gastoEnHarinaEstimadoRangoFechas(fecha_1, fecha_1) + gestor.gastoEnLuzRangoFechas(fecha_1, fecha_1),2);
                    series1.Points.AddXY(fecha_1, gasto);
                    series1.Points[i].Color = Color.Red;
                    fecha_1 = fecha_1.AddDays(1);
                    i++;
                }
                chart1.Series.Add(series1);
            }
        }

        private void balance_Click(object sender, EventArgs e)
        {
            VentanaFechas f = new VentanaFechas();

            var result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                chart1.Series.Clear();
                System.DateTime fecha_1 = f.fecha_inicio.Value;
                System.DateTime fecha_2 = f.fecha_final.Value;
                series1 = new System.Windows.Forms.DataVisualization.Charting.Series($"Balance Periodo: {fecha_1.ToString("d")} - {fecha_2.ToString("d")}");
                series1.IsValueShownAsLabel = true;
                series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
                series1.Points.AddXY("Ingresos Pedidos", Math.Round(gestor.dineroPedidosRangoFechas(fecha_1,fecha_2),2));
                series1.Points.AddXY("Ingresos Ventas", Math.Round(gestor.dineroVentasRangoFechas(fecha_1,fecha_2),2));
                series1.Points.AddXY("Gastos Harina", Math.Round(gestor.gastoEnHarinaEstimadoRangoFechas(fecha_1,fecha_2),2));
                series1.Points.AddXY("Gastos horno", Math.Round(gestor.gastoEnLuzRangoFechas(fecha_1,fecha_2),2));
                chart1.Series.Add(series1);
            }
        }

        private void anadirProducto_Click(object sender, EventArgs e)
        {
            Producto prod = (Producto)listaProductos.SelectedItem;
            int cantidad = (int)cantidadProducto.Value;
            
            if (!listaCompra_pedido.ContainsKey(prod))
            {
                listaCompra_pedido.Add(prod, cantidad);
                listaCompra.Items.Add(new ListViewItem(new string[] { prod.ToString(), cantidad.ToString() }));
            }
            else {
                foreach (ListViewItem item in listaCompra.Items) {
                    if (item.SubItems[0].Text.Equals(prod.ToString())) {
                        item.SubItems[1].Text = cantidad.ToString();
                    }
                }
                listaCompra_pedido[(Producto)listaProductos.SelectedItem] = (int)cantidadProducto.Value;
            }
           
    
        }

        private void btnCrearPedido_Click(object sender, EventArgs e)
        {
                if (listaCompra_pedido.Count == 0)
                {
                    MessageBox.Show("Añada algún producto para realizar un pedido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        List<(Producto, int)> listaProd = new List<(Producto, int)>();
                        foreach (KeyValuePair<Producto, int> kvp in listaCompra_pedido)
                        {
                            listaProd.Add((kvp.Key, kvp.Value));
                        }
                        gestor.registrarPedido(new Pedido
                        {
                            fecha = dateTimePicker1.Value,
                            dni = ((Cliente)listaClientes.SelectedItem).dni,
                            entregado = false,
                            pagado = false,
                            productos = listaProd
                        });
                        MessageBox.Show("Pedido realizado con exito.\nEn caso de ser un cliente con un pedido habitual ese día no se entregará.", "Pedido completado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show("Este cliente ya tiene un pedido para esa fecha.\nCancelelo o haga una excepción en caso de ser un pedido habitual.", "Error al registrar el pedido", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error:\n{ex.Message}", "Error al registrar el pedido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    listaCompra.Items.Clear();
                    listaCompra_pedido.Clear();

                }                      
        }

        private void anadirProductoVenta_Click(object sender, EventArgs e)
        {
            Producto prod = (Producto)listaProductosVenta.SelectedItem;
            int cantidad = (int)cantidadProductoVenta.Value;

            if (!listaCompra_local.ContainsKey(prod))
            {
                listaCompra_local.Add(prod, cantidad);
                listaCompraLocal.Items.Add(new ListViewItem(new string[] { prod.ToString(), cantidad.ToString() }));
                
            }
            else
            {
                foreach (ListViewItem item in listaCompra.Items)
                {
                    if (item.SubItems[0].Text.Equals(prod.ToString()))
                    {
                        item.SubItems[1].Text = cantidad.ToString();
                    }
                }
                listaCompra_local[(Producto)listaProductosVenta.SelectedItem] = (int)cantidadProductoVenta.Value;
            }
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            if (listaCompra_local.Count == 0)
            {
                MessageBox.Show("Añada algún producto para realizar una venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    List<(Producto, int)> listaProd = new List<(Producto, int)>();
                    foreach (KeyValuePair<Producto, int> kvp in listaCompra_local)
                    {
                        listaProd.Add((kvp.Key, kvp.Value));
                    }
                    gestor.venderProductos(new Venta
                    {
                        productos = listaProd,
                    }) ;
                    MessageBox.Show("Venta realizada con exito.", "Venta completada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error:\n{ex.Message}", "Error al registrar la venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                listaCompraLocal.Items.Clear();
                listaCompra_local.Clear();

            }
        }

        private void nuevoPedido_Click(object sender, EventArgs e)
        {
            listaCompra_pedido.Clear();
            listaCompra.Items.Clear();
            this.grupoNuevoPedido.Text = "Nuevo Pedido";
            this.lblFecha.Visible = true;
            this.dateTimePicker1.Enabled = true;
            this.dateTimePicker1.Visible = true;
            this.btnCrearPedido.Click -= this.btnCrearPedidoHabitual_Click ;
            this.btnCrearPedido.Click += new System.EventHandler(this.btnCrearPedido_Click);
        }

        private void nuevoPedHab_Click(object sender, EventArgs e)
        {
            listaCompra_pedido.Clear();
            listaCompra.Items.Clear();
            this.grupoNuevoPedido.Text = "Nuevo Pedido Habitual";
            this.lblFecha.Visible = false;
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Visible = false;
            this.btnCrearPedido.Click -= this.btnCrearPedido_Click;
            this.btnCrearPedido.Click += new System.EventHandler(this.btnCrearPedidoHabitual_Click);
        }

        private void btnCrearPedidoHabitual_Click(object sender, EventArgs e)
        {
            if (listaCompra_pedido.Count == 0)
            {
                MessageBox.Show("Añada algún producto para realizar un pedido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    List<(Producto, int)> listaProd = new List<(Producto, int)>();
                    foreach (KeyValuePair<Producto, int> kvp in listaCompra_pedido)
                    {
                        listaProd.Add((kvp.Key, kvp.Value));
                    }
                    gestor.registrarPedidoHabitual(new PedidoHabitual {
                        dni = ((Cliente)listaClientes.SelectedItem).dni,
                        productos = listaProd

                    });
                    MessageBox.Show("Pedido habitual guardado con exito.", "Rutina registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Este cliente ya tiene un pedido habitual.\nEliminelo antes de registrar uno nuevo.", "Error al registrar el pedido", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error:\n{ex.Message}", "Error al registrar el pedido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                listaCompra.Items.Clear();
                listaCompra_pedido.Clear();

            }
        }

        private void elimPedidoHab_Click(object sender, EventArgs e)
        {
            VentanaElegirDeLista<PedidoHabitual> ventana = new VentanaElegirDeLista<PedidoHabitual>(gestor.listaPedidosHabituales());
            var result = ventana.ShowDialog();
            if (result == DialogResult.OK) {
                gestor.eliminarPedidoHabitual((PedidoHabitual)ventana.listBox1.SelectedItem);
                MessageBox.Show("Pedido habitual eliminado correctamente.", "Pedido eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cancelarPedido_Click(object sender, EventArgs e)
        {
            VentanaFechaConcreta f = new VentanaFechaConcreta();
            var result = f.ShowDialog();
            if (result == DialogResult.OK) {
                DateTime fecha = f.dateTimePicker1.Value;
                VentanaElegirDeLista<Pedido> elegirPedido = new VentanaElegirDeLista<Pedido>(gestor.pedidosDeFecha(fecha));
                var resultado = elegirPedido.ShowDialog();
                if (resultado == DialogResult.OK) {
                    gestor.eliminarPedido((Pedido)elegirPedido.listBox1.SelectedItem);
                    MessageBox.Show("Pedido eliminado correctamente.", "Pedido eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void entregarPedido_Click(object sender, EventArgs e)
        {
            VentanaElegirDeLista<Pedido> ventana = new VentanaElegirDeLista<Pedido>(gestor.pedidosPorEntregarHoy());
            var resultado = ventana.ShowDialog();
            if (resultado == DialogResult.OK) {
                gestor.entregarPedido((Pedido)ventana.listBox1.SelectedItem);
                MessageBox.Show("Pedido entregado", "Proceso correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void excPedidoHab_Click(object sender, EventArgs e)
        {
            VentanaElegirDeLista<PedidoHabitual> ventana = new VentanaElegirDeLista<PedidoHabitual>(gestor.listaPedidosHabituales());
            var result = ventana.ShowDialog();
            if (result == DialogResult.OK)
            {
                VentanaFechaConcreta f = new VentanaFechaConcreta();
                var resultado = f.ShowDialog();
                int id_ped = ((PedidoHabitual)ventana.listBox1.SelectedItem).id_pedido_habitual;
                if (resultado == DialogResult.OK)
                {
                    DateTime fecha = f.dateTimePicker1.Value;
                    try
                    {
                        gestor.registrarExcepcion(id_ped, fecha);
                        MessageBox.Show("Excepción añadida correctamente.", "No se entregará", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show("Este usuario ya tiene una excepción para esa fecha", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex) {
                        MessageBox.Show($"Error:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    
                }
            }
        }
    }
}
