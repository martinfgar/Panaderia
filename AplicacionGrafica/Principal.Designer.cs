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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.grupoNuevoPedido = new System.Windows.Forms.GroupBox();
            this.panelNuevoPedido = new System.Windows.Forms.TableLayoutPanel();
            this.listaClientes = new System.Windows.Forms.ListBox();
            this.listaProductos = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.cantidadProducto = new System.Windows.Forms.NumericUpDown();
            this.anadirProducto = new System.Windows.Forms.Button();
            this.listaCompra = new System.Windows.Forms.ListView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnCrearPedido = new System.Windows.Forms.Button();
            this.grupoTienda = new System.Windows.Forms.GroupBox();
            this.anadirProductoVenta = new System.Windows.Forms.Button();
            this.cantidadProductoVenta = new System.Windows.Forms.NumericUpDown();
            this.btnVender = new System.Windows.Forms.Button();
            this.listaCompraLocal = new System.Windows.Forms.ListView();
            this.listaProductosVenta = new System.Windows.Forms.ListBox();
            this.clienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gestorPanaderiaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gestorPanaderiaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.menuPrincipal.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grupoFinanzas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.grupoNuevoPedido.SuspendLayout();
            this.panelNuevoPedido.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadProducto)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.grupoTienda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadProductoVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestorPanaderiaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestorPanaderiaBindingSource1)).BeginInit();
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
            this.nuevoPedido.Click += new System.EventHandler(this.nuevoPedido_Click);
            // 
            // cancelarPedido
            // 
            this.cancelarPedido.Name = "cancelarPedido";
            this.cancelarPedido.Size = new System.Drawing.Size(216, 22);
            this.cancelarPedido.Text = "Cancelar";
            this.cancelarPedido.Click += new System.EventHandler(this.cancelarPedido_Click);
            // 
            // entregarPedido
            // 
            this.entregarPedido.Name = "entregarPedido";
            this.entregarPedido.Size = new System.Drawing.Size(216, 22);
            this.entregarPedido.Text = "Entregar";
            this.entregarPedido.Click += new System.EventHandler(this.entregarPedido_Click);
            // 
            // nuevoPedHab
            // 
            this.nuevoPedHab.Name = "nuevoPedHab";
            this.nuevoPedHab.Size = new System.Drawing.Size(216, 22);
            this.nuevoPedHab.Text = "Nuevo Pedido Habitual";
            this.nuevoPedHab.Click += new System.EventHandler(this.nuevoPedHab_Click);
            // 
            // elimPedidoHab
            // 
            this.elimPedidoHab.Name = "elimPedidoHab";
            this.elimPedidoHab.Size = new System.Drawing.Size(216, 22);
            this.elimPedidoHab.Text = "Eliminar Pedido Habitual";
            this.elimPedidoHab.Click += new System.EventHandler(this.elimPedidoHab_Click);
            // 
            // excPedidoHab
            // 
            this.excPedidoHab.Name = "excPedidoHab";
            this.excPedidoHab.Size = new System.Drawing.Size(216, 22);
            this.excPedidoHab.Text = "Excepción Pedido Habitual";
            this.excPedidoHab.Click += new System.EventHandler(this.excPedidoHab_Click);
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
            this.tableLayoutPanel1.Controls.Add(this.grupoNuevoPedido, 1, 1);
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
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Name = "Legend1";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(3, 16);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(1097, 368);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // grupoNuevoPedido
            // 
            this.grupoNuevoPedido.Controls.Add(this.panelNuevoPedido);
            this.grupoNuevoPedido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grupoNuevoPedido.Location = new System.Drawing.Point(478, 396);
            this.grupoNuevoPedido.Name = "grupoNuevoPedido";
            this.grupoNuevoPedido.Size = new System.Drawing.Size(1103, 387);
            this.grupoNuevoPedido.TabIndex = 1;
            this.grupoNuevoPedido.TabStop = false;
            this.grupoNuevoPedido.Text = "Nuevo Pedido";
            // 
            // panelNuevoPedido
            // 
            this.panelNuevoPedido.ColumnCount = 3;
            this.panelNuevoPedido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelNuevoPedido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelNuevoPedido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelNuevoPedido.Controls.Add(this.listaClientes, 0, 0);
            this.panelNuevoPedido.Controls.Add(this.listaProductos, 1, 0);
            this.panelNuevoPedido.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.panelNuevoPedido.Controls.Add(this.listaCompra, 2, 0);
            this.panelNuevoPedido.Controls.Add(this.tableLayoutPanel3, 2, 1);
            this.panelNuevoPedido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNuevoPedido.Location = new System.Drawing.Point(3, 16);
            this.panelNuevoPedido.Name = "panelNuevoPedido";
            this.panelNuevoPedido.RowCount = 2;
            this.panelNuevoPedido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelNuevoPedido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelNuevoPedido.Size = new System.Drawing.Size(1097, 368);
            this.panelNuevoPedido.TabIndex = 0;
            // 
            // listaClientes
            // 
            this.listaClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listaClientes.FormattingEnabled = true;
            this.listaClientes.Location = new System.Drawing.Point(3, 3);
            this.listaClientes.Name = "listaClientes";
            this.panelNuevoPedido.SetRowSpan(this.listaClientes, 2);
            this.listaClientes.ScrollAlwaysVisible = true;
            this.listaClientes.Size = new System.Drawing.Size(359, 362);
            this.listaClientes.TabIndex = 0;
            // 
            // listaProductos
            // 
            this.listaProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listaProductos.FormattingEnabled = true;
            this.listaProductos.Location = new System.Drawing.Point(368, 3);
            this.listaProductos.Name = "listaProductos";
            this.listaProductos.Size = new System.Drawing.Size(359, 178);
            this.listaProductos.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lblCantidad, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cantidadProducto, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.anadirProducto, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(368, 187);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(359, 178);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // lblCantidad
            // 
            this.lblCantidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(65, 38);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(49, 13);
            this.lblCantidad.TabIndex = 0;
            this.lblCantidad.Text = "Cantidad";
            // 
            // cantidadProducto
            // 
            this.cantidadProducto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cantidadProducto.Location = new System.Drawing.Point(29, 123);
            this.cantidadProducto.Name = "cantidadProducto";
            this.cantidadProducto.Size = new System.Drawing.Size(120, 20);
            this.cantidadProducto.TabIndex = 1;
            // 
            // anadirProducto
            // 
            this.anadirProducto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.anadirProducto.Location = new System.Drawing.Point(231, 122);
            this.anadirProducto.Name = "anadirProducto";
            this.anadirProducto.Size = new System.Drawing.Size(75, 23);
            this.anadirProducto.TabIndex = 2;
            this.anadirProducto.Text = "Añadir";
            this.anadirProducto.UseVisualStyleBackColor = true;
            this.anadirProducto.Click += new System.EventHandler(this.anadirProducto_Click);
            // 
            // listaCompra
            // 
            this.listaCompra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listaCompra.GridLines = true;
            this.listaCompra.HideSelection = false;
            this.listaCompra.Location = new System.Drawing.Point(733, 3);
            this.listaCompra.Name = "listaCompra";
            this.listaCompra.Size = new System.Drawing.Size(361, 178);
            this.listaCompra.TabIndex = 3;
            this.listaCompra.UseCompatibleStateImageBehavior = false;
            this.listaCompra.View = System.Windows.Forms.View.Details;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.lblFecha, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.dateTimePicker1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnCrearPedido, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(733, 187);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(361, 178);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // lblFecha
            // 
            this.lblFecha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(70, 38);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePicker1.Location = new System.Drawing.Point(183, 34);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(175, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // btnCrearPedido
            // 
            this.btnCrearPedido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCrearPedido.AutoSize = true;
            this.btnCrearPedido.Location = new System.Drawing.Point(231, 122);
            this.btnCrearPedido.Name = "btnCrearPedido";
            this.btnCrearPedido.Size = new System.Drawing.Size(78, 23);
            this.btnCrearPedido.TabIndex = 2;
            this.btnCrearPedido.Text = "Crear Pedido";
            this.btnCrearPedido.UseVisualStyleBackColor = true;
            this.btnCrearPedido.Click += new System.EventHandler(this.btnCrearPedido_Click);
            // 
            // grupoTienda
            // 
            this.grupoTienda.Controls.Add(this.anadirProductoVenta);
            this.grupoTienda.Controls.Add(this.cantidadProductoVenta);
            this.grupoTienda.Controls.Add(this.btnVender);
            this.grupoTienda.Controls.Add(this.listaCompraLocal);
            this.grupoTienda.Controls.Add(this.listaProductosVenta);
            this.grupoTienda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grupoTienda.Location = new System.Drawing.Point(3, 3);
            this.grupoTienda.Name = "grupoTienda";
            this.tableLayoutPanel1.SetRowSpan(this.grupoTienda, 2);
            this.grupoTienda.Size = new System.Drawing.Size(469, 780);
            this.grupoTienda.TabIndex = 2;
            this.grupoTienda.TabStop = false;
            this.grupoTienda.Text = "Tienda";
            // 
            // anadirProductoVenta
            // 
            this.anadirProductoVenta.Dock = System.Windows.Forms.DockStyle.Top;
            this.anadirProductoVenta.Location = new System.Drawing.Point(3, 196);
            this.anadirProductoVenta.Name = "anadirProductoVenta";
            this.anadirProductoVenta.Size = new System.Drawing.Size(463, 51);
            this.anadirProductoVenta.TabIndex = 4;
            this.anadirProductoVenta.Text = "Añadir Producto";
            this.anadirProductoVenta.UseVisualStyleBackColor = true;
            this.anadirProductoVenta.Click += new System.EventHandler(this.anadirProductoVenta_Click);
            // 
            // cantidadProductoVenta
            // 
            this.cantidadProductoVenta.Dock = System.Windows.Forms.DockStyle.Top;
            this.cantidadProductoVenta.Location = new System.Drawing.Point(3, 176);
            this.cantidadProductoVenta.Name = "cantidadProductoVenta";
            this.cantidadProductoVenta.Size = new System.Drawing.Size(463, 20);
            this.cantidadProductoVenta.TabIndex = 3;
            // 
            // btnVender
            // 
            this.btnVender.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnVender.Location = new System.Drawing.Point(3, 462);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(463, 58);
            this.btnVender.TabIndex = 2;
            this.btnVender.Text = "Confirmar Venta";
            this.btnVender.UseVisualStyleBackColor = true;
            this.btnVender.Click += new System.EventHandler(this.btnVender_Click);
            // 
            // listaCompraLocal
            // 
            this.listaCompraLocal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listaCompraLocal.GridLines = true;
            this.listaCompraLocal.HideSelection = false;
            this.listaCompraLocal.Location = new System.Drawing.Point(3, 520);
            this.listaCompraLocal.Name = "listaCompraLocal";
            this.listaCompraLocal.Size = new System.Drawing.Size(463, 257);
            this.listaCompraLocal.TabIndex = 1;
            this.listaCompraLocal.UseCompatibleStateImageBehavior = false;
            this.listaCompraLocal.View = System.Windows.Forms.View.Details;
            // 
            // listaProductosVenta
            // 
            this.listaProductosVenta.Dock = System.Windows.Forms.DockStyle.Top;
            this.listaProductosVenta.FormattingEnabled = true;
            this.listaProductosVenta.Location = new System.Drawing.Point(3, 16);
            this.listaProductosVenta.Name = "listaProductosVenta";
            this.listaProductosVenta.Size = new System.Drawing.Size(463, 160);
            this.listaProductosVenta.TabIndex = 0;
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
            this.grupoNuevoPedido.ResumeLayout(false);
            this.panelNuevoPedido.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadProducto)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.grupoTienda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cantidadProductoVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestorPanaderiaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestorPanaderiaBindingSource1)).EndInit();
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
        private System.Windows.Forms.GroupBox grupoNuevoPedido;
        private System.Windows.Forms.GroupBox grupoTienda;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TableLayoutPanel panelNuevoPedido;
        private System.Windows.Forms.ListBox listaClientes;
        private System.Windows.Forms.ListBox listaProductos;
        private System.Windows.Forms.BindingSource gestorPanaderiaBindingSource1;
        private System.Windows.Forms.BindingSource clienteBindingSource;
        private System.Windows.Forms.BindingSource gestorPanaderiaBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown cantidadProducto;
        private System.Windows.Forms.Button anadirProducto;
        private System.Windows.Forms.ListView listaCompra;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnCrearPedido;
        private System.Windows.Forms.Button btnVender;
        private System.Windows.Forms.ListView listaCompraLocal;
        private System.Windows.Forms.ListBox listaProductosVenta;
        private System.Windows.Forms.Button anadirProductoVenta;
        private System.Windows.Forms.NumericUpDown cantidadProductoVenta;
    }
}