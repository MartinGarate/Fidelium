namespace Desktop.Views
{
    partial class ComprasView
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
            label5 = new Label();
            label1 = new Label();
            dataGridViewCompras = new DataGridView();
            BtnAgregar = new FontAwesome.Sharp.IconButton();
            tabControl = new TabControl();
            Lista_TabPage = new TabPage();
            BtnRestaurar = new FontAwesome.Sharp.IconButton();
            BtnEliminar = new FontAwesome.Sharp.IconButton();
            BtnEditar = new FontAwesome.Sharp.IconButton();
            checkBoxEliminados = new CheckBox();
            BtnBuscar = new FontAwesome.Sharp.IconButton();
            textBoxBuscar = new TextBox();
            AgregarEditar_TabPage = new TabPage();
            label3 = new Label();
            panel1 = new Panel();
            dateTime_FechaCompra = new DateTimePicker();
            textBoxEmpleado = new TextBox();
            textBoxProductoServicio = new TextBox();
            textBoxCliente = new TextBox();
            label8 = new Label();
            label2 = new Label();
            label6 = new Label();
            label4 = new Label();
            labelAccion = new Label();
            SeleccionarClienteResponsable_TabPage = new TabPage();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            textBoxBuscarUsuario = new TextBox();
            label10 = new Label();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            label11 = new Label();
            dataGridViewUsuarios = new DataGridView();
            txtDescripcion = new TextBox();
            label12 = new Label();
            dateTime_FechaRecordatorio = new DateTimePicker();
            label7 = new Label();
            txtNotasVentaInternas = new TextBox();
            label13 = new Label();
            label14 = new Label();
            checkBox1 = new CheckBox();
            txtFeedbackCliente = new TextBox();
            label9 = new Label();
            BtnCancelar = new FontAwesome.Sharp.IconButton();
            BtnGuardar = new FontAwesome.Sharp.IconButton();
            iconButton3 = new FontAwesome.Sharp.IconButton();
            iconButton4 = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCompras).BeginInit();
            tabControl.SuspendLayout();
            Lista_TabPage.SuspendLayout();
            AgregarEditar_TabPage.SuspendLayout();
            panel1.SuspendLayout();
            SeleccionarClienteResponsable_TabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Semibold", 30F, FontStyle.Bold);
            label5.Location = new Point(48, 71);
            label5.Name = "label5";
            label5.Size = new Size(764, 54);
            label5.TabIndex = 15;
            label5.Text = "Administrá todas las compras de tu Local";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 14.25F);
            label1.Location = new Point(52, 117);
            label1.Name = "label1";
            label1.Size = new Size(693, 25);
            label1.TabIndex = 16;
            label1.Text = "Visualizá, gestioná y controlá cada compra realizada de manera rápida y sencilla.";
            // 
            // dataGridViewCompras
            // 
            dataGridViewCompras.BackgroundColor = Color.White;
            dataGridViewCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCompras.Location = new Point(52, 260);
            dataGridViewCompras.Name = "dataGridViewCompras";
            dataGridViewCompras.Size = new Size(1415, 649);
            dataGridViewCompras.TabIndex = 17;
            // 
            // BtnAgregar
            // 
            BtnAgregar.BackColor = Color.FromArgb(88, 1, 180);
            BtnAgregar.FlatAppearance.BorderSize = 0;
            BtnAgregar.FlatStyle = FlatStyle.Flat;
            BtnAgregar.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            BtnAgregar.ForeColor = Color.White;
            BtnAgregar.IconChar = FontAwesome.Sharp.IconChar.CirclePlus;
            BtnAgregar.IconColor = Color.White;
            BtnAgregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnAgregar.IconSize = 33;
            BtnAgregar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnAgregar.Location = new Point(1285, 87);
            BtnAgregar.Name = "BtnAgregar";
            BtnAgregar.Padding = new Padding(12, 6, 12, 6);
            BtnAgregar.Size = new Size(182, 52);
            BtnAgregar.TabIndex = 18;
            BtnAgregar.Text = "Agregar";
            BtnAgregar.TextAlign = ContentAlignment.MiddleRight;
            BtnAgregar.UseVisualStyleBackColor = false;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(Lista_TabPage);
            tabControl.Controls.Add(AgregarEditar_TabPage);
            tabControl.Controls.Add(SeleccionarClienteResponsable_TabPage);
            tabControl.Location = new Point(1, -8);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1528, 1048);
            tabControl.TabIndex = 19;
            // 
            // Lista_TabPage
            // 
            Lista_TabPage.BackColor = Color.FromArgb(244, 246, 248);
            Lista_TabPage.Controls.Add(label1);
            Lista_TabPage.Controls.Add(BtnRestaurar);
            Lista_TabPage.Controls.Add(BtnEliminar);
            Lista_TabPage.Controls.Add(BtnEditar);
            Lista_TabPage.Controls.Add(checkBoxEliminados);
            Lista_TabPage.Controls.Add(BtnBuscar);
            Lista_TabPage.Controls.Add(textBoxBuscar);
            Lista_TabPage.Controls.Add(label5);
            Lista_TabPage.Controls.Add(BtnAgregar);
            Lista_TabPage.Controls.Add(dataGridViewCompras);
            Lista_TabPage.Location = new Point(4, 24);
            Lista_TabPage.Name = "Lista_TabPage";
            Lista_TabPage.Padding = new Padding(3);
            Lista_TabPage.Size = new Size(1520, 1020);
            Lista_TabPage.TabIndex = 0;
            Lista_TabPage.Text = "Lista";
            // 
            // BtnRestaurar
            // 
            BtnRestaurar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnRestaurar.BackColor = Color.Transparent;
            BtnRestaurar.FlatAppearance.BorderColor = Color.FromArgb(115, 108, 122);
            BtnRestaurar.FlatStyle = FlatStyle.Flat;
            BtnRestaurar.Font = new Font("Microsoft Sans Serif", 12F);
            BtnRestaurar.ForeColor = Color.FromArgb(19, 10, 29);
            BtnRestaurar.IconChar = FontAwesome.Sharp.IconChar.ChevronCircleLeft;
            BtnRestaurar.IconColor = Color.FromArgb(19, 10, 29);
            BtnRestaurar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnRestaurar.IconSize = 24;
            BtnRestaurar.ImageAlign = ContentAlignment.MiddleRight;
            BtnRestaurar.Location = new Point(181, 915);
            BtnRestaurar.Name = "BtnRestaurar";
            BtnRestaurar.Size = new Size(123, 28);
            BtnRestaurar.TabIndex = 24;
            BtnRestaurar.Text = "Restaurar";
            BtnRestaurar.TextAlign = ContentAlignment.MiddleLeft;
            BtnRestaurar.UseVisualStyleBackColor = false;
            BtnRestaurar.Visible = false;
            // 
            // BtnEliminar
            // 
            BtnEliminar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnEliminar.BackColor = Color.Transparent;
            BtnEliminar.FlatAppearance.BorderSize = 0;
            BtnEliminar.FlatStyle = FlatStyle.Flat;
            BtnEliminar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnEliminar.ForeColor = Color.FromArgb(19, 10, 29);
            BtnEliminar.IconChar = FontAwesome.Sharp.IconChar.CartArrowDown;
            BtnEliminar.IconColor = Color.FromArgb(19, 10, 29);
            BtnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnEliminar.IconSize = 24;
            BtnEliminar.ImageAlign = ContentAlignment.MiddleRight;
            BtnEliminar.Location = new Point(1377, 915);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(90, 28);
            BtnEliminar.TabIndex = 23;
            BtnEliminar.Text = "Eliminar";
            BtnEliminar.TextAlign = ContentAlignment.MiddleLeft;
            BtnEliminar.UseVisualStyleBackColor = false;
            // 
            // BtnEditar
            // 
            BtnEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnEditar.BackColor = Color.Transparent;
            BtnEditar.FlatAppearance.BorderColor = Color.FromArgb(115, 108, 122);
            BtnEditar.FlatStyle = FlatStyle.Flat;
            BtnEditar.Font = new Font("Microsoft Sans Serif", 12F);
            BtnEditar.ForeColor = Color.FromArgb(19, 10, 29);
            BtnEditar.IconChar = FontAwesome.Sharp.IconChar.Pen;
            BtnEditar.IconColor = Color.FromArgb(19, 10, 29);
            BtnEditar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnEditar.IconSize = 24;
            BtnEditar.ImageAlign = ContentAlignment.MiddleRight;
            BtnEditar.Location = new Point(52, 915);
            BtnEditar.Name = "BtnEditar";
            BtnEditar.Size = new Size(123, 28);
            BtnEditar.TabIndex = 22;
            BtnEditar.Text = "Editar";
            BtnEditar.TextAlign = ContentAlignment.MiddleLeft;
            BtnEditar.UseVisualStyleBackColor = false;
            // 
            // checkBoxEliminados
            // 
            checkBoxEliminados.AutoSize = true;
            checkBoxEliminados.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Italic);
            checkBoxEliminados.Location = new Point(1230, 920);
            checkBoxEliminados.Name = "checkBoxEliminados";
            checkBoxEliminados.Size = new Size(120, 21);
            checkBoxEliminados.TabIndex = 21;
            checkBoxEliminados.Text = "Ver eliminados";
            checkBoxEliminados.UseVisualStyleBackColor = true;
            checkBoxEliminados.CheckedChanged += checkBoxEliminados_CheckedChanged;
            // 
            // BtnBuscar
            // 
            BtnBuscar.BackColor = Color.FromArgb(11, 0, 25);
            BtnBuscar.FlatAppearance.BorderSize = 0;
            BtnBuscar.FlatStyle = FlatStyle.Flat;
            BtnBuscar.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnBuscar.ForeColor = Color.White;
            BtnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            BtnBuscar.IconColor = Color.White;
            BtnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnBuscar.IconSize = 28;
            BtnBuscar.Location = new Point(1420, 221);
            BtnBuscar.Name = "BtnBuscar";
            BtnBuscar.Size = new Size(47, 33);
            BtnBuscar.TabIndex = 20;
            BtnBuscar.TextAlign = ContentAlignment.MiddleRight;
            BtnBuscar.UseVisualStyleBackColor = false;
            BtnBuscar.Click += BtnBuscar_Click;
            // 
            // textBoxBuscar
            // 
            textBoxBuscar.Font = new Font("Segoe UI", 14F);
            textBoxBuscar.Location = new Point(52, 221);
            textBoxBuscar.Name = "textBoxBuscar";
            textBoxBuscar.PlaceholderText = " ¿Qué estás buscando?…";
            textBoxBuscar.Size = new Size(1368, 32);
            textBoxBuscar.TabIndex = 19;
            textBoxBuscar.TextChanged += textBoxBuscar_TextChanged;
            // 
            // AgregarEditar_TabPage
            // 
            AgregarEditar_TabPage.BackColor = Color.FromArgb(244, 246, 248);
            AgregarEditar_TabPage.Controls.Add(BtnCancelar);
            AgregarEditar_TabPage.Controls.Add(label3);
            AgregarEditar_TabPage.Controls.Add(BtnGuardar);
            AgregarEditar_TabPage.Controls.Add(panel1);
            AgregarEditar_TabPage.Controls.Add(labelAccion);
            AgregarEditar_TabPage.Location = new Point(4, 24);
            AgregarEditar_TabPage.Name = "AgregarEditar_TabPage";
            AgregarEditar_TabPage.Padding = new Padding(3);
            AgregarEditar_TabPage.Size = new Size(1520, 1020);
            AgregarEditar_TabPage.TabIndex = 1;
            AgregarEditar_TabPage.Text = "Agregar/Editar";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 14.25F);
            label3.Location = new Point(164, 132);
            label3.Name = "label3";
            label3.Size = new Size(610, 25);
            label3.TabIndex = 18;
            label3.Text = "Completá los datos de la compra para mantener tu control actualizado.";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(iconButton4);
            panel1.Controls.Add(iconButton3);
            panel1.Controls.Add(txtFeedbackCliente);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(txtNotasVentaInternas);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(dateTime_FechaRecordatorio);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtDescripcion);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(dateTime_FechaCompra);
            panel1.Controls.Add(textBoxEmpleado);
            panel1.Controls.Add(textBoxProductoServicio);
            panel1.Controls.Add(textBoxCliente);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            panel1.Location = new Point(164, 185);
            panel1.Name = "panel1";
            panel1.Size = new Size(1180, 661);
            panel1.TabIndex = 19;
            // 
            // dateTime_FechaCompra
            // 
            dateTime_FechaCompra.Font = new Font("Segoe UI", 12F);
            dateTime_FechaCompra.Format = DateTimePickerFormat.Custom;
            dateTime_FechaCompra.Location = new Point(590, 150);
            dateTime_FechaCompra.Name = "dateTime_FechaCompra";
            dateTime_FechaCompra.Size = new Size(490, 29);
            dateTime_FechaCompra.TabIndex = 34;
            // 
            // textBoxEmpleado
            // 
            textBoxEmpleado.BackColor = Color.FromArgb(244, 246, 248);
            textBoxEmpleado.Font = new Font("Segoe UI", 12F);
            textBoxEmpleado.Location = new Point(590, 70);
            textBoxEmpleado.Name = "textBoxEmpleado";
            textBoxEmpleado.PlaceholderText = "Ejemplo: Martin Garate";
            textBoxEmpleado.Size = new Size(453, 29);
            textBoxEmpleado.TabIndex = 32;
            // 
            // textBoxProductoServicio
            // 
            textBoxProductoServicio.BackColor = Color.FromArgb(244, 246, 248);
            textBoxProductoServicio.Font = new Font("Segoe UI", 12F);
            textBoxProductoServicio.Location = new Point(76, 150);
            textBoxProductoServicio.Name = "textBoxProductoServicio";
            textBoxProductoServicio.PlaceholderText = "Ejemplo: Auriculares ASTROS A10";
            textBoxProductoServicio.Size = new Size(489, 29);
            textBoxProductoServicio.TabIndex = 20;
            // 
            // textBoxCliente
            // 
            textBoxCliente.BackColor = Color.FromArgb(244, 246, 248);
            textBoxCliente.Font = new Font("Segoe UI", 12F);
            textBoxCliente.Location = new Point(75, 70);
            textBoxCliente.Name = "textBoxCliente";
            textBoxCliente.PlaceholderText = "Ejemplo: Martin Garate";
            textBoxCliente.Size = new Size(464, 29);
            textBoxCliente.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            label8.Location = new Point(590, 115);
            label8.Name = "label8";
            label8.Size = new Size(204, 32);
            label8.TabIndex = 35;
            label8.Text = "Fecha de Compra";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            label2.Location = new Point(590, 35);
            label2.Name = "label2";
            label2.Size = new Size(257, 32);
            label2.TabIndex = 33;
            label2.Text = "Nombre del Empleado";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            label6.Location = new Point(75, 115);
            label6.Name = "label6";
            label6.Size = new Size(358, 32);
            label6.TabIndex = 21;
            label6.Text = "Nombre del Producto / Servicio";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(76, 35);
            label4.Name = "label4";
            label4.Size = new Size(226, 32);
            label4.TabIndex = 19;
            label4.Text = "Nombre del Cliente";
            // 
            // labelAccion
            // 
            labelAccion.AutoSize = true;
            labelAccion.BackColor = Color.Transparent;
            labelAccion.Font = new Font("Segoe UI Semibold", 30F, FontStyle.Bold);
            labelAccion.Location = new Point(158, 78);
            labelAccion.Name = "labelAccion";
            labelAccion.Size = new Size(757, 54);
            labelAccion.TabIndex = 17;
            labelAccion.Text = "Registrá una nueva compra en el sistema";
            // 
            // SeleccionarClienteResponsable_TabPage
            // 
            SeleccionarClienteResponsable_TabPage.Controls.Add(iconButton1);
            SeleccionarClienteResponsable_TabPage.Controls.Add(textBoxBuscarUsuario);
            SeleccionarClienteResponsable_TabPage.Controls.Add(label10);
            SeleccionarClienteResponsable_TabPage.Controls.Add(iconButton2);
            SeleccionarClienteResponsable_TabPage.Controls.Add(label11);
            SeleccionarClienteResponsable_TabPage.Controls.Add(dataGridViewUsuarios);
            SeleccionarClienteResponsable_TabPage.Location = new Point(4, 24);
            SeleccionarClienteResponsable_TabPage.Name = "SeleccionarClienteResponsable_TabPage";
            SeleccionarClienteResponsable_TabPage.Padding = new Padding(3);
            SeleccionarClienteResponsable_TabPage.Size = new Size(1520, 1020);
            SeleccionarClienteResponsable_TabPage.TabIndex = 2;
            SeleccionarClienteResponsable_TabPage.Text = "Seleccionar Usuario";
            SeleccionarClienteResponsable_TabPage.UseVisualStyleBackColor = true;
            // 
            // iconButton1
            // 
            iconButton1.BackColor = Color.FromArgb(11, 0, 25);
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            iconButton1.ForeColor = Color.White;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.Search;
            iconButton1.IconColor = Color.White;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 28;
            iconButton1.Location = new Point(1424, 224);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(47, 33);
            iconButton1.TabIndex = 26;
            iconButton1.TextAlign = ContentAlignment.MiddleRight;
            iconButton1.UseVisualStyleBackColor = false;
            // 
            // textBoxBuscarUsuario
            // 
            textBoxBuscarUsuario.Font = new Font("Segoe UI", 14F);
            textBoxBuscarUsuario.Location = new Point(56, 224);
            textBoxBuscarUsuario.Name = "textBoxBuscarUsuario";
            textBoxBuscarUsuario.PlaceholderText = " ¿Qué estás buscando?…";
            textBoxBuscarUsuario.Size = new Size(1368, 32);
            textBoxBuscarUsuario.TabIndex = 25;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Microsoft Sans Serif", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(56, 74);
            label10.Name = "label10";
            label10.Size = new Size(791, 46);
            label10.TabIndex = 21;
            label10.Text = "Administrá todas las compras de tu Local";
            // 
            // iconButton2
            // 
            iconButton2.BackColor = Color.FromArgb(88, 1, 180);
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.FlatStyle = FlatStyle.Flat;
            iconButton2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            iconButton2.ForeColor = Color.White;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.CirclePlus;
            iconButton2.IconColor = Color.White;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.IconSize = 33;
            iconButton2.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton2.Location = new Point(1266, 90);
            iconButton2.Name = "iconButton2";
            iconButton2.Padding = new Padding(12, 6, 12, 6);
            iconButton2.Size = new Size(205, 52);
            iconButton2.TabIndex = 24;
            iconButton2.Text = "Seleccionar";
            iconButton2.TextAlign = ContentAlignment.MiddleRight;
            iconButton2.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label11.Location = new Point(56, 120);
            label11.Name = "label11";
            label11.Size = new Size(686, 24);
            label11.TabIndex = 22;
            label11.Text = "Visualizá, gestioná y controlá cada compra realizada de manera rápida y sencilla.";
            // 
            // dataGridViewUsuarios
            // 
            dataGridViewUsuarios.BackgroundColor = Color.White;
            dataGridViewUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsuarios.Location = new Point(56, 263);
            dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            dataGridViewUsuarios.Size = new Size(1415, 649);
            dataGridViewUsuarios.TabIndex = 23;
            // 
            // txtDescripcion
            // 
            txtDescripcion.BackColor = Color.FromArgb(244, 246, 248);
            txtDescripcion.Font = new Font("Segoe UI", 12F);
            txtDescripcion.Location = new Point(75, 241);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.PlaceholderText = "Detalles de uso y cualquier información relevante para el comprador";
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Size = new Size(491, 64);
            txtDescripcion.TabIndex = 38;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            label12.Location = new Point(76, 206);
            label12.Name = "label12";
            label12.Size = new Size(394, 32);
            label12.TabIndex = 39;
            label12.Text = "Descripción del Producto / Servicio";
            // 
            // dateTime_FechaRecordatorio
            // 
            dateTime_FechaRecordatorio.Font = new Font("Segoe UI", 12F);
            dateTime_FechaRecordatorio.Format = DateTimePickerFormat.Custom;
            dateTime_FechaRecordatorio.Location = new Point(591, 241);
            dateTime_FechaRecordatorio.Name = "dateTime_FechaRecordatorio";
            dateTime_FechaRecordatorio.Size = new Size(490, 29);
            dateTime_FechaRecordatorio.TabIndex = 40;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            label7.Location = new Point(591, 206);
            label7.Name = "label7";
            label7.Size = new Size(258, 32);
            label7.TabIndex = 41;
            label7.Text = "Fecha de Recordatorio";
            // 
            // txtNotasVentaInternas
            // 
            txtNotasVentaInternas.BackColor = Color.FromArgb(244, 246, 248);
            txtNotasVentaInternas.Font = new Font("Segoe UI", 12F);
            txtNotasVentaInternas.Location = new Point(75, 365);
            txtNotasVentaInternas.Multiline = true;
            txtNotasVentaInternas.Name = "txtNotasVentaInternas";
            txtNotasVentaInternas.PlaceholderText = "Ej: \"Buscaba mouse para CS:GO, ver si el peso del G203 le resultó cómodo\"";
            txtNotasVentaInternas.ScrollBars = ScrollBars.Vertical;
            txtNotasVentaInternas.Size = new Size(1004, 64);
            txtNotasVentaInternas.TabIndex = 42;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.FlatStyle = FlatStyle.Popup;
            label13.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            label13.Location = new Point(75, 330);
            label13.Name = "label13";
            label13.Size = new Size(470, 32);
            label13.TabIndex = 43;
            label13.Text = "Notas Internas para Feedback (Empleado)";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            label14.Location = new Point(75, 448);
            label14.Name = "label14";
            label14.Size = new Size(243, 32);
            label14.TabIndex = 44;
            label14.Text = "Estado del Feedback:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            checkBox1.Location = new Point(324, 455);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(94, 25);
            checkBox1.TabIndex = 45;
            checkBox1.Text = "Recibido";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtFeedbackCliente
            // 
            txtFeedbackCliente.BackColor = Color.FromArgb(244, 246, 248);
            txtFeedbackCliente.Font = new Font("Segoe UI", 12F);
            txtFeedbackCliente.Location = new Point(75, 529);
            txtFeedbackCliente.Multiline = true;
            txtFeedbackCliente.Name = "txtFeedbackCliente";
            txtFeedbackCliente.PlaceholderText = "Ej: \"Me encantó el sensor, pero el cable es algo rígido\"";
            txtFeedbackCliente.ScrollBars = ScrollBars.Vertical;
            txtFeedbackCliente.Size = new Size(1004, 99);
            txtFeedbackCliente.TabIndex = 46;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.FlatStyle = FlatStyle.Popup;
            label9.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            label9.Location = new Point(75, 494);
            label9.Name = "label9";
            label9.Size = new Size(298, 32);
            label9.TabIndex = 47;
            label9.Text = "Feedback Final del Cliente";
            // 
            // BtnCancelar
            // 
            BtnCancelar.BackColor = Color.Transparent;
            BtnCancelar.FlatAppearance.BorderSize = 0;
            BtnCancelar.FlatStyle = FlatStyle.Flat;
            BtnCancelar.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            BtnCancelar.ForeColor = Color.FromArgb(11, 0, 25);
            BtnCancelar.IconChar = FontAwesome.Sharp.IconChar.None;
            BtnCancelar.IconColor = Color.FromArgb(11, 0, 25);
            BtnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnCancelar.Location = new Point(1120, 852);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(92, 34);
            BtnCancelar.TabIndex = 23;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.UseVisualStyleBackColor = false;
            // 
            // BtnGuardar
            // 
            BtnGuardar.BackColor = Color.FromArgb(68, 0, 154);
            BtnGuardar.FlatStyle = FlatStyle.Flat;
            BtnGuardar.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            BtnGuardar.ForeColor = SystemColors.Control;
            BtnGuardar.IconChar = FontAwesome.Sharp.IconChar.ArrowRight;
            BtnGuardar.IconColor = Color.White;
            BtnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnGuardar.IconSize = 24;
            BtnGuardar.ImageAlign = ContentAlignment.MiddleRight;
            BtnGuardar.Location = new Point(1234, 852);
            BtnGuardar.Name = "BtnGuardar";
            BtnGuardar.Padding = new Padding(3);
            BtnGuardar.Size = new Size(110, 34);
            BtnGuardar.TabIndex = 22;
            BtnGuardar.Text = "Guardar";
            BtnGuardar.TextAlign = ContentAlignment.TopLeft;
            BtnGuardar.UseVisualStyleBackColor = false;
            // 
            // iconButton3
            // 
            iconButton3.BackColor = Color.FromArgb(68, 0, 154);
            iconButton3.FlatStyle = FlatStyle.Flat;
            iconButton3.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            iconButton3.ForeColor = SystemColors.Control;
            iconButton3.IconChar = FontAwesome.Sharp.IconChar.UniversalAccess;
            iconButton3.IconColor = Color.White;
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton3.IconSize = 24;
            iconButton3.Location = new Point(539, 69);
            iconButton3.Name = "iconButton3";
            iconButton3.Padding = new Padding(3);
            iconButton3.Size = new Size(36, 30);
            iconButton3.TabIndex = 24;
            iconButton3.TextAlign = ContentAlignment.TopLeft;
            iconButton3.UseVisualStyleBackColor = false;
            // 
            // iconButton4
            // 
            iconButton4.BackColor = Color.FromArgb(68, 0, 154);
            iconButton4.FlatStyle = FlatStyle.Flat;
            iconButton4.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            iconButton4.ForeColor = SystemColors.Control;
            iconButton4.IconChar = FontAwesome.Sharp.IconChar.UniversalAccess;
            iconButton4.IconColor = Color.White;
            iconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton4.IconSize = 24;
            iconButton4.Location = new Point(1043, 68);
            iconButton4.Name = "iconButton4";
            iconButton4.Padding = new Padding(3);
            iconButton4.Size = new Size(36, 31);
            iconButton4.TabIndex = 48;
            iconButton4.TextAlign = ContentAlignment.TopLeft;
            iconButton4.UseVisualStyleBackColor = false;
            // 
            // ComprasView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 248);
            ClientSize = new Size(1534, 1041);
            ControlBox = false;
            Controls.Add(tabControl);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ComprasView";
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dataGridViewCompras).EndInit();
            tabControl.ResumeLayout(false);
            Lista_TabPage.ResumeLayout(false);
            Lista_TabPage.PerformLayout();
            AgregarEditar_TabPage.ResumeLayout(false);
            AgregarEditar_TabPage.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            SeleccionarClienteResponsable_TabPage.ResumeLayout(false);
            SeleccionarClienteResponsable_TabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label5;
        private Label label1;
        private DataGridView dataGridViewCompras;
        private FontAwesome.Sharp.IconButton BtnAgregar;
        private TabControl tabControl;
        private TabPage AgregarEditar_TabPage;
        private TabPage Lista_TabPage;
        private Label labelAccion;
        private Label label3;
        private TextBox textBoxBuscar;
        private FontAwesome.Sharp.IconButton BtnBuscar;
        private Panel panel1;
        private Label label4;
        private TextBox textBoxCliente;
        private Label label6;
        private TextBox textBoxProductoServicio;
        private CheckBox checkBoxEliminados;
        private FontAwesome.Sharp.IconButton BtnRestaurar;
        private FontAwesome.Sharp.IconButton BtnEliminar;
        private FontAwesome.Sharp.IconButton BtnEditar;
        private Label label2;
        private TextBox textBoxEmpleado;
        private DateTimePicker dateTimeSolicitudFeedback;
        private Label label8;
        private DateTimePicker dateTime_FechaCompra;
        private TabPage SeleccionarClienteResponsable_TabPage;
        private FontAwesome.Sharp.IconButton iconButton1;
        private TextBox textBoxBuscarUsuario;
        private Label label10;
        private FontAwesome.Sharp.IconButton iconButton2;
        private Label label11;
        private DataGridView dataGridViewUsuarios;
        private Label label7;
        private TextBox textBox1;
        private Label label12;
        private Label label14;
        private TextBox txtNotasVentaInternas;
        private Label label13;
        private CheckBox checkBox1;
        private TextBox txtFeedbackCliente;
        private Label label9;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton BtnCancelar;
        private FontAwesome.Sharp.IconButton BtnGuardar;
        private FontAwesome.Sharp.IconButton iconButton4;
        private TextBox txtDescripcion;
        private DateTimePicker dateTime_FechaRecordatorio;
    }
}