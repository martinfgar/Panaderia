namespace WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void registrarCliente_Click(object sender, EventArgs e)
        {
            var picker = new DateTimePicker();
            
            this.Controls.Add(picker);

            
        }
    }
}