namespace AplicacionGrafica
{
    partial class Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.menuPedidos = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoPedido = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarPedido = new System.Windows.Forms.ToolStripMenuItem();
            this.entregarPedido = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoPedHab = new System.Windows.Forms.ToolStripMenuItem();
            this.elimPedidoHab = new System.Windows.Forms.ToolStripMenuItem();
            this.excPedidoHab = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFinanzas = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresos = new System.Windows.Forms.ToolStripMenuItem();
            this.gastos = new System.Windows.Forms.ToolStripMenuItem();
            this.balance = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.deudasClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.pagarDeuda = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProduccion = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grupoFinanzas = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grupoPedidos = new System.Windows.Forms.GroupBox();
            this.grupoTienda = new System.Windows.Forms.GroupBox();
            this.menuPrincipal.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grupoFinanzas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPedidos,
            this.menuFinanzas,
            this.menuClientes,
            this.menuProduccion});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(1584, 24);
            this.menuPrincipal.TabIndex = 0;
            this.menuPrincipal.Text = "menuPrincipal";
            // 
            // menuPedidos
            // 
            this.menuPedidos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoPedido,
            this.cancelarPedido,
            this.entregarPedido,
            this.nuevoPedHab,
            this.elimPedidoHab,
            this.excPedidoHab});
            this.menuPedidos.Name = "menuPedidos";
            this.menuPedidos.Size = new System.Drawing.Size(61, 20);
            this.menuPedidos.Text = "Pedidos";
            // 
            // nuevoPedido
            // 
            this.nuevoPedido.Name = "nuevoPedido";
            this.nuevoPedido.Size = new System.Drawing.Size(216, 22);
            this.nuevoPedido.Text = "Nuevo";
            // 
            // cancelarPedido
            // 
            this.cancelarPedido.Name = "cancelarPedido";
            this.cancelarPedido.Size = new System.Drawing.Size(216, 22);
            this.cancelarPedido.Text = "Cancelar";
            // 
            // entregarPedido
            // 
            this.entregarPedido.Name = "entregarPedido";
            this.entregarPedido.Size = new System.Drawing.Size(216, 22);
            this.entregarPedido.Text = "Entregar";
            // 
            // nuevoPedHab
            // 
            this.nuevoPedHab.Name = "nuevoPedHab";
            this.nuevoPedHab.Size = new System.Drawing.Size(216, 22);
            this.nuevoPedHab.Text = "Nuevo Pedido Habitual";
            // 
            // elimPedidoHab
            // 
            this.elimPedidoHab.Name = "elimPedidoHab";
            this.elimPedidoHab.Size = new System.Drawing.Size(216, 22);
            this.elimPedidoHab.Text = "Eliminar Pedido Habitual";
            // 
            // excPedidoHab
            // 
            this.excPedidoHab.Name = "excPedidoHab";
            this.excPedidoHab.Size = new System.Drawing.Size(216, 22);
            this.excPedidoHab.Text = "Excepción Pedido Habitual";
            // 
            // menuFinanzas
            // 
            this.menuFinanzas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresos,
            this.gastos,
            this.balance});
            this.menuFinanzas.Name = "menuFinanzas";
            this.menuFinanzas.Size = new System.Drawing.Size(64, 20);
            this.menuFinanzas.Text = "Finanzas";
            // 
            // ingresos
            // 
            this.ingresos.Name = "ingresos";
            this.ingresos.Size = new System.Drawing.Size(118, 22);
            this.ingresos.Text = "Ingresos";
            this.ingresos.Click += new System.EventHandler(this.ingresos_Click);
            // 
            // gastos
            // 
            this.gastos.Name = "gastos";
            this.gastos.Size = new System.Drawing.Size(118, 22);
            this.gastos.Text = "Gastos";
            this.gastos.Click += new System.EventHandler(this.gastos_Click);
            // 
            // balance
            // 
            this.balance.Name = "balance";
            this.balance.Size = new System.Drawing.Size(118, 22);
            this.balance.Text = "Balance";
            this.balance.Click += new System.EventHandler(this.balance_Click);
            // 
            // menuClientes
            // 
            this.menuClientes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarCliente,
            this.deudasClientes,
            this.pagarDeuda});
            this.menuClientes.Name = "menuClientes";
            this.menuClientes.Size = new System.Drawing.Size(61, 20);
            this.menuClientes.Text = "Clientes";
            // 
            // registrarCliente
            // 
            this.registrarCliente.Name = "registrarCliente";
            this.registrarCliente.Size = new System.Drawing.Size(153, 22);
            this.registrarCliente.Text = "Nuevo";
            // 
            // deudasClientes
            // 
            this.deudasClientes.Name = "deudasClientes";
            this.deudasClientes.Size = new System.Drawing.Size(153, 22);
            this.deudasClientes.Text = "Ver Deudas";
            // 
            // pagarDeuda
            // 
            this.pagarDeuda.Name = "pagarDeuda";
            this.pagarDeuda.Size = new System.Drawing.Size(153, 22);
            this.pagarDeuda.Text = "Pago de deuda";
            // 
            // menuProduccion
            // 
            this.menuProduccion.Name = "menuProduccion";
            this.menuProduccion.Size = new System.Drawing.Size(80, 20);
            this.menuProduccion.Text = "Produccion";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.grupoFinanzas, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.grupoPedidos, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.grupoTienda, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1584, 786);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // grupoFinanzas
            // 
            this.grupoFinanzas.Controls.Add(this.chart1);
            this.grupoFinanzas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grupoFinanzas.Location = new System.Drawing.Point(478, 3);
            this.grupoFinanzas.Name = "grupoFinanzas";
            this.grupoFinanzas.Size = new System.Drawing.Size(1103, 387);
            this.grupoFinanzas.TabIndex = 0;
            this.grupoFinanzas.TabStop = false;
            this.grupoFinanzas.Text = "Finanzas";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 16);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1097, 368);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // grupoPedidos
            // 
            this.grupoPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grupoPedidos.Location = new System.Drawing.Point(478, 396);
            this.grupoPedidos.Name = "grupoPedidos";
            this.grupoPedidos.Size = new System.Drawing.Size(1103, 387);
            this.grupoPedidos.TabIndex = 1;
            this.grupoPedidos.TabStop = false;
            this.grupoPedidos.Text = "Pedidos";
            // 
            // grupoTienda
            // 
            this.grupoTienda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grupoTienda.Location = new System.Drawing.Point(3, 3);
            this.grupoTienda.Name = "grupoTienda";
            this.tableLayoutPanel1.SetRowSpan(this.grupoTienda, 2);
            this.grupoTienda.Size = new System.Drawing.Size(469, 780);
            this.grupoTienda.TabIndex = 2;
            this.grupoTienda.TabStop = false;
            this.grupoTienda.Text = "Tienda";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 810);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuPrincipal);
            this.MainMenuStrip = this.menuPrincipal;
            this.Name = "Principal";
            this.Text = "Principal";
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grupoFinanzas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem menuPedidos;
        private System.Windows.Forms.ToolStripMenuItem nuevoPedido;
        private System.Windows.Forms.ToolStripMenuItem cancelarPedido;
        private System.Windows.Forms.ToolStripMenuItem entregarPedido;
        private System.Windows.Forms.ToolStripMenuItem nuevoPedHab;
        private System.Windows.Forms.ToolStripMenuItem elimPedidoHab;
        private System.Windows.Forms.ToolStripMenuItem excPedidoHab;
        private System.Windows.Forms.ToolStripMenuItem menuFinanzas;
        private System.Windows.Forms.ToolStripMenuItem ingresos;
        private System.Windows.Forms.ToolStripMenuItem gastos;
        private System.Windows.Forms.ToolStripMenuItem balance;
        private System.Windows.Forms.ToolStripMenuItem menuClientes;
        private System.Windows.Forms.ToolStripMenuItem registrarCliente;
        private System.Windows.Forms.ToolStripMenuItem deudasClientes;
        private System.Windows.Forms.ToolStripMenuItem pagarDeuda;
        private System.Windows.Forms.ToolStripMenuItem menuProduccion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox grupoFinanzas;
        private System.Windows.Forms.GroupBox grupoPedidos;
        private System.Windows.Forms.GroupBox grupoTienda;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}