using System.Windows.Forms.DataVisualization.Charting;
namespace WinForms
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
           
        }

        private void registrarCliente_Click(object sender, EventArgs e)
        {
            
            


        }

        private void ingresosGen_Click(object sender, EventArgs e)
        {
            VentanaFechasSinLim f = new VentanaFechasSinLim();

            var result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                DateTime fecha1 = f.fecha_inicio.Value;
                DateTime fecha2 = f.fecha_final.Value;
                
               
                //get selected date
            }
        }
    }
}