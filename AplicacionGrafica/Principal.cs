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
using Sistema;
namespace AplicacionGrafica
{
    public partial class Principal : Form
    {
        GestorPanaderia gestor;
        System.Windows.Forms.DataVisualization.Charting.Series series1;
        public Principal(GestorPanaderia gestor)
        {
            InitializeComponent();
            this.gestor = gestor;

            
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
                graficoBarrasDineroTiempo();
                chart1.Legends.Add("Ingresos");
                
                while ((fecha_1-fecha_2).TotalDays<1) {
                    double benef = gestor.dineroPedidosRangoFechas(fecha_1, fecha_1) + gestor.dineroVentasRangoFechas(fecha_1, fecha_1);
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
                graficoBarrasDineroTiempo();
                chart1.Legends.Add("Gastos");
                int i = 0;
                while ((fecha_1 - fecha_2).TotalDays < 1)
                {
                    double gasto = gestor.gastoEnHarinaEstimadoRangoFechas(fecha_1, fecha_1) + gestor.gastoEnLuzRangoFechas(fecha_1, fecha_1);
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
                System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
                series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
                series1.Points.AddXY(3, 4);
                series1.Points.AddXY(5, 6);
                chart1.Series.Add(series1);
                //get selected date
            }
        }
    }
}
