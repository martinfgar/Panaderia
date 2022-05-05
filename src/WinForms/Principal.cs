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
            var fecha1 = new System.Windows.Forms.DateTimePicker();
            var fecha2 = new System.Windows.Forms.DateTimePicker();
            VentanaFechas f = new VentanaFechas(fecha1, fecha2);

            var result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                label1.Text = fecha1.Value.ToString("yyyy-MM-dd");
                //get selected date
            }


        }

       
    }
}