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
            BtnCancelar = new FontAwesome.Sharp.IconButton();
            labelSubtituloAgregarEditar = new Label();
            BtnGuardar = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            BtnSeleccionarVendedor = new FontAwesome.Sharp.IconButton();
            BtnSeleccionarCliente = new FontAwesome.Sharp.IconButton();
            textBoxFeedbackCliente = new TextBox();
            label9 = new Label();
            checkBoxFeedbackRecibido = new CheckBox();
            label14 = new Label();
            textBoxNotasVentaInternas = new TextBox();
            label13 = new Label();
            dateTime_FechaRecordatorio = new DateTimePicker();
            label7 = new Label();
            textBoxDescripcion = new TextBox();
            label12 = new Label();
            dateTime_FechaCompra = new DateTimePicker();
            textBoxEmpleado = new TextBox();
            textBoxProductoServicio = new TextBox();
            textBoxCliente = new TextBox();
            label8 = new Label();
            label2 = new Label();
            label6 = new Label();
            label4 = new Label();
            labelAccion = new Label();
            SeleccionarUsuario_TabPage = new TabPage();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            textBoxBuscarUsuario = new TextBox();
            lblSeleccionUsuarioCliente_Titulo = new Label();
            BtnSeleccionarUsuario = new FontAwesome.Sharp.IconButton();
            lblSeleccionUsuarioCliente_SubTitulo = new Label();
            dataGridViewUsuarios = new DataGridView();
            BtnCancelarSeleccion = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCompras).BeginInit();
            tabControl.SuspendLayout();
            Lista_TabPage.SuspendLayout();
            AgregarEditar_TabPage.SuspendLayout();
            panel1.SuspendLayout();
            SeleccionarUsuario_TabPage.SuspendLayout();
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
            BtnAgregar.Location = new Point(1297, 87);
            BtnAgregar.Name = "BtnAgregar";
            BtnAgregar.Padding = new Padding(12, 6, 12, 6);
            BtnAgregar.Size = new Size(170, 52);
            BtnAgregar.TabIndex = 18;
            BtnAgregar.Text = "Agregar";
            BtnAgregar.TextAlign = ContentAlignment.MiddleRight;
            BtnAgregar.UseVisualStyleBackColor = false;
            BtnAgregar.Click += BtnAgregar_Click;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(Lista_TabPage);
            tabControl.Controls.Add(AgregarEditar_TabPage);
            tabControl.Controls.Add(SeleccionarUsuario_TabPage);
            tabControl.Location = new Point(1, -8);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1528, 1048);
            tabControl.TabIndex = 19;
            // 
            // Lista_TabPage
            // 
            Lista_TabPage.BackColor = Color.FromArgb(244, 246, 248);
            Lista_TabPage.Controls.Add(BtnRestaurar);
            Lista_TabPage.Controls.Add(BtnEliminar);
            Lista_TabPage.Controls.Add(BtnEditar);
            Lista_TabPage.Controls.Add(checkBoxEliminados);
            Lista_TabPage.Controls.Add(label1);
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
            BtnRestaurar.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            BtnRestaurar.ForeColor = Color.FromArgb(19, 10, 29);
            BtnRestaurar.IconChar = FontAwesome.Sharp.IconChar.ChevronCircleLeft;
            BtnRestaurar.IconColor = Color.FromArgb(19, 10, 29);
            BtnRestaurar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnRestaurar.IconSize = 24;
            BtnRestaurar.ImageAlign = ContentAlignment.MiddleRight;
            BtnRestaurar.Location = new Point(192, 915);
            BtnRestaurar.Name = "BtnRestaurar";
            BtnRestaurar.Size = new Size(123, 28);
            BtnRestaurar.TabIndex = 28;
            BtnRestaurar.Text = "Restaurar";
            BtnRestaurar.TextAlign = ContentAlignment.MiddleLeft;
            BtnRestaurar.UseVisualStyleBackColor = false;
            BtnRestaurar.Visible = false;
            BtnRestaurar.Click += BtnRestaurar_Click;
            // 
            // BtnEliminar
            // 
            BtnEliminar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnEliminar.BackColor = Color.Transparent;
            BtnEliminar.FlatAppearance.BorderSize = 0;
            BtnEliminar.FlatStyle = FlatStyle.Flat;
            BtnEliminar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnEliminar.ForeColor = Color.FromArgb(19, 10, 29);
            BtnEliminar.IconChar = FontAwesome.Sharp.IconChar.UserMinus;
            BtnEliminar.IconColor = Color.FromArgb(19, 10, 29);
            BtnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnEliminar.IconSize = 24;
            BtnEliminar.ImageAlign = ContentAlignment.MiddleRight;
            BtnEliminar.Location = new Point(1377, 915);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(90, 28);
            BtnEliminar.TabIndex = 27;
            BtnEliminar.Text = "Eliminar";
            BtnEliminar.TextAlign = ContentAlignment.MiddleLeft;
            BtnEliminar.UseVisualStyleBackColor = false;
            BtnEliminar.Click += BtnEliminar_Click;
            // 
            // BtnEditar
            // 
            BtnEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnEditar.BackColor = Color.Transparent;
            BtnEditar.FlatAppearance.BorderColor = Color.FromArgb(115, 108, 122);
            BtnEditar.FlatStyle = FlatStyle.Flat;
            BtnEditar.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            BtnEditar.ForeColor = Color.FromArgb(19, 10, 29);
            BtnEditar.IconChar = FontAwesome.Sharp.IconChar.UserPen;
            BtnEditar.IconColor = Color.FromArgb(19, 10, 29);
            BtnEditar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnEditar.IconSize = 24;
            BtnEditar.ImageAlign = ContentAlignment.MiddleRight;
            BtnEditar.Location = new Point(52, 915);
            BtnEditar.Name = "BtnEditar";
            BtnEditar.Size = new Size(123, 28);
            BtnEditar.TabIndex = 26;
            BtnEditar.Text = "Editar";
            BtnEditar.TextAlign = ContentAlignment.MiddleLeft;
            BtnEditar.UseVisualStyleBackColor = false;
            BtnEditar.Click += BtnEditar_Click;
            // 
            // checkBoxEliminados
            // 
            checkBoxEliminados.AutoSize = true;
            checkBoxEliminados.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            checkBoxEliminados.Location = new Point(1244, 918);
            checkBoxEliminados.Name = "checkBoxEliminados";
            checkBoxEliminados.Size = new Size(120, 23);
            checkBoxEliminados.TabIndex = 25;
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
            AgregarEditar_TabPage.Controls.Add(labelSubtituloAgregarEditar);
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
            BtnCancelar.Click += BtnCancelar_Click;
            // 
            // labelSubtituloAgregarEditar
            // 
            labelSubtituloAgregarEditar.AutoSize = true;
            labelSubtituloAgregarEditar.BackColor = Color.Transparent;
            labelSubtituloAgregarEditar.Font = new Font("Segoe UI", 14.25F);
            labelSubtituloAgregarEditar.Location = new Point(164, 132);
            labelSubtituloAgregarEditar.Name = "labelSubtituloAgregarEditar";
            labelSubtituloAgregarEditar.Size = new Size(610, 25);
            labelSubtituloAgregarEditar.TabIndex = 18;
            labelSubtituloAgregarEditar.Text = "Completá los datos de la compra para mantener tu control actualizado.";
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
            BtnGuardar.Click += BtnGuardar_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(BtnSeleccionarVendedor);
            panel1.Controls.Add(BtnSeleccionarCliente);
            panel1.Controls.Add(textBoxFeedbackCliente);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(checkBoxFeedbackRecibido);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(textBoxNotasVentaInternas);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(dateTime_FechaRecordatorio);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(textBoxDescripcion);
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
            // BtnSeleccionarVendedor
            // 
            BtnSeleccionarVendedor.BackColor = Color.FromArgb(68, 0, 154);
            BtnSeleccionarVendedor.FlatStyle = FlatStyle.Flat;
            BtnSeleccionarVendedor.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            BtnSeleccionarVendedor.ForeColor = SystemColors.Control;
            BtnSeleccionarVendedor.IconChar = FontAwesome.Sharp.IconChar.UniversalAccess;
            BtnSeleccionarVendedor.IconColor = Color.White;
            BtnSeleccionarVendedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnSeleccionarVendedor.IconSize = 24;
            BtnSeleccionarVendedor.Location = new Point(1043, 68);
            BtnSeleccionarVendedor.Name = "BtnSeleccionarVendedor";
            BtnSeleccionarVendedor.Padding = new Padding(3);
            BtnSeleccionarVendedor.Size = new Size(36, 31);
            BtnSeleccionarVendedor.TabIndex = 48;
            BtnSeleccionarVendedor.TextAlign = ContentAlignment.TopLeft;
            BtnSeleccionarVendedor.UseVisualStyleBackColor = false;
            BtnSeleccionarVendedor.Click += BtnSeleccionarVendedor_Click;
            // 
            // BtnSeleccionarCliente
            // 
            BtnSeleccionarCliente.BackColor = Color.FromArgb(68, 0, 154);
            BtnSeleccionarCliente.FlatStyle = FlatStyle.Flat;
            BtnSeleccionarCliente.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            BtnSeleccionarCliente.ForeColor = SystemColors.Control;
            BtnSeleccionarCliente.IconChar = FontAwesome.Sharp.IconChar.UniversalAccess;
            BtnSeleccionarCliente.IconColor = Color.White;
            BtnSeleccionarCliente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnSeleccionarCliente.IconSize = 24;
            BtnSeleccionarCliente.Location = new Point(539, 69);
            BtnSeleccionarCliente.Name = "BtnSeleccionarCliente";
            BtnSeleccionarCliente.Padding = new Padding(3);
            BtnSeleccionarCliente.Size = new Size(36, 30);
            BtnSeleccionarCliente.TabIndex = 24;
            BtnSeleccionarCliente.TextAlign = ContentAlignment.TopLeft;
            BtnSeleccionarCliente.UseVisualStyleBackColor = false;
            BtnSeleccionarCliente.Click += BtnSeleccionarCliente_Click;
            // 
            // textBoxFeedbackCliente
            // 
            textBoxFeedbackCliente.BackColor = Color.FromArgb(244, 246, 248);
            textBoxFeedbackCliente.Font = new Font("Segoe UI", 12F);
            textBoxFeedbackCliente.Location = new Point(75, 529);
            textBoxFeedbackCliente.Multiline = true;
            textBoxFeedbackCliente.Name = "textBoxFeedbackCliente";
            textBoxFeedbackCliente.PlaceholderText = "Ej: \"Me encantó el sensor, pero el cable es algo rígido\"";
            textBoxFeedbackCliente.ScrollBars = ScrollBars.Vertical;
            textBoxFeedbackCliente.Size = new Size(1004, 99);
            textBoxFeedbackCliente.TabIndex = 46;
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
            // checkBoxFeedbackRecibido
            // 
            checkBoxFeedbackRecibido.AutoSize = true;
            checkBoxFeedbackRecibido.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            checkBoxFeedbackRecibido.Location = new Point(324, 455);
            checkBoxFeedbackRecibido.Name = "checkBoxFeedbackRecibido";
            checkBoxFeedbackRecibido.Size = new Size(94, 25);
            checkBoxFeedbackRecibido.TabIndex = 45;
            checkBoxFeedbackRecibido.Text = "Recibido";
            checkBoxFeedbackRecibido.UseVisualStyleBackColor = true;
            checkBoxFeedbackRecibido.CheckedChanged += checkBoxFeedbackRecibido_CheckedChanged;
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
            // textBoxNotasVentaInternas
            // 
            textBoxNotasVentaInternas.BackColor = Color.FromArgb(244, 246, 248);
            textBoxNotasVentaInternas.Font = new Font("Segoe UI", 12F);
            textBoxNotasVentaInternas.Location = new Point(75, 365);
            textBoxNotasVentaInternas.Multiline = true;
            textBoxNotasVentaInternas.Name = "textBoxNotasVentaInternas";
            textBoxNotasVentaInternas.PlaceholderText = "Ej: \"Buscaba mouse para CS:GO, ver si el peso del G203 le resultó cómodo\"";
            textBoxNotasVentaInternas.ScrollBars = ScrollBars.Vertical;
            textBoxNotasVentaInternas.Size = new Size(1004, 64);
            textBoxNotasVentaInternas.TabIndex = 42;
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
            // textBoxDescripcion
            // 
            textBoxDescripcion.BackColor = Color.FromArgb(244, 246, 248);
            textBoxDescripcion.Font = new Font("Segoe UI", 12F);
            textBoxDescripcion.Location = new Point(75, 241);
            textBoxDescripcion.Multiline = true;
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.PlaceholderText = "Detalles de uso y cualquier información relevante para el comprador";
            textBoxDescripcion.ScrollBars = ScrollBars.Vertical;
            textBoxDescripcion.Size = new Size(491, 64);
            textBoxDescripcion.TabIndex = 38;
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
            // dateTime_FechaCompra
            // 
            dateTime_FechaCompra.Font = new Font("Segoe UI", 12F);
            dateTime_FechaCompra.Format = DateTimePickerFormat.Custom;
            dateTime_FechaCompra.Location = new Point(590, 150);
            dateTime_FechaCompra.Name = "dateTime_FechaCompra";
            dateTime_FechaCompra.Size = new Size(490, 29);
            dateTime_FechaCompra.TabIndex = 34;
            dateTime_FechaCompra.ValueChanged += dateTime_FechaCompra_ValueChanged;
            // 
            // textBoxEmpleado
            // 
            textBoxEmpleado.BackColor = Color.FromArgb(244, 246, 248);
            textBoxEmpleado.Font = new Font("Segoe UI", 12F);
            textBoxEmpleado.Location = new Point(590, 70);
            textBoxEmpleado.Name = "textBoxEmpleado";
            textBoxEmpleado.PlaceholderText = "Ejemplo: Fulanito Vendedor";
            textBoxEmpleado.ReadOnly = true;
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
            textBoxCliente.PlaceholderText = "Ejemplo: Fulanito Cliente";
            textBoxCliente.ReadOnly = true;
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
            // SeleccionarUsuario_TabPage
            // 
            SeleccionarUsuario_TabPage.Controls.Add(BtnCancelarSeleccion);
            SeleccionarUsuario_TabPage.Controls.Add(iconButton1);
            SeleccionarUsuario_TabPage.Controls.Add(textBoxBuscarUsuario);
            SeleccionarUsuario_TabPage.Controls.Add(lblSeleccionUsuarioCliente_Titulo);
            SeleccionarUsuario_TabPage.Controls.Add(BtnSeleccionarUsuario);
            SeleccionarUsuario_TabPage.Controls.Add(lblSeleccionUsuarioCliente_SubTitulo);
            SeleccionarUsuario_TabPage.Controls.Add(dataGridViewUsuarios);
            SeleccionarUsuario_TabPage.Location = new Point(4, 24);
            SeleccionarUsuario_TabPage.Name = "SeleccionarUsuario_TabPage";
            SeleccionarUsuario_TabPage.Padding = new Padding(3);
            SeleccionarUsuario_TabPage.Size = new Size(1520, 1020);
            SeleccionarUsuario_TabPage.TabIndex = 2;
            SeleccionarUsuario_TabPage.Text = "Seleccionar Usuario";
            SeleccionarUsuario_TabPage.UseVisualStyleBackColor = true;
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
            // lblSeleccionUsuarioCliente_Titulo
            // 
            lblSeleccionUsuarioCliente_Titulo.AutoSize = true;
            lblSeleccionUsuarioCliente_Titulo.BackColor = Color.Transparent;
            lblSeleccionUsuarioCliente_Titulo.Font = new Font("Segoe UI Semibold", 30F, FontStyle.Bold);
            lblSeleccionUsuarioCliente_Titulo.Location = new Point(51, 68);
            lblSeleccionUsuarioCliente_Titulo.Name = "lblSeleccionUsuarioCliente_Titulo";
            lblSeleccionUsuarioCliente_Titulo.Size = new Size(764, 54);
            lblSeleccionUsuarioCliente_Titulo.TabIndex = 21;
            lblSeleccionUsuarioCliente_Titulo.Text = "Administrá todas las compras de tu Local";
            // 
            // BtnSeleccionarUsuario
            // 
            BtnSeleccionarUsuario.BackColor = Color.FromArgb(88, 1, 180);
            BtnSeleccionarUsuario.FlatAppearance.BorderSize = 0;
            BtnSeleccionarUsuario.FlatStyle = FlatStyle.Flat;
            BtnSeleccionarUsuario.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            BtnSeleccionarUsuario.ForeColor = Color.White;
            BtnSeleccionarUsuario.IconChar = FontAwesome.Sharp.IconChar.CirclePlus;
            BtnSeleccionarUsuario.IconColor = Color.White;
            BtnSeleccionarUsuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnSeleccionarUsuario.IconSize = 33;
            BtnSeleccionarUsuario.ImageAlign = ContentAlignment.MiddleLeft;
            BtnSeleccionarUsuario.Location = new Point(1266, 90);
            BtnSeleccionarUsuario.Name = "BtnSeleccionarUsuario";
            BtnSeleccionarUsuario.Padding = new Padding(12, 6, 12, 6);
            BtnSeleccionarUsuario.Size = new Size(205, 52);
            BtnSeleccionarUsuario.TabIndex = 24;
            BtnSeleccionarUsuario.Text = "Seleccionar";
            BtnSeleccionarUsuario.TextAlign = ContentAlignment.MiddleRight;
            BtnSeleccionarUsuario.UseVisualStyleBackColor = false;
            BtnSeleccionarUsuario.Click += BtnSeleccionarUsuario_Click;
            // 
            // lblSeleccionUsuarioCliente_SubTitulo
            // 
            lblSeleccionUsuarioCliente_SubTitulo.AutoSize = true;
            lblSeleccionUsuarioCliente_SubTitulo.BackColor = Color.Transparent;
            lblSeleccionUsuarioCliente_SubTitulo.Font = new Font("Segoe UI", 14.25F);
            lblSeleccionUsuarioCliente_SubTitulo.Location = new Point(56, 120);
            lblSeleccionUsuarioCliente_SubTitulo.Name = "lblSeleccionUsuarioCliente_SubTitulo";
            lblSeleccionUsuarioCliente_SubTitulo.Size = new Size(693, 25);
            lblSeleccionUsuarioCliente_SubTitulo.TabIndex = 22;
            lblSeleccionUsuarioCliente_SubTitulo.Text = "Visualizá, gestioná y controlá cada compra realizada de manera rápida y sencilla.";
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
            // BtnCancelarSeleccion
            // 
            BtnCancelarSeleccion.BackColor = Color.Transparent;
            BtnCancelarSeleccion.FlatStyle = FlatStyle.Flat;
            BtnCancelarSeleccion.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            BtnCancelarSeleccion.ForeColor = Color.FromArgb(11, 0, 25);
            BtnCancelarSeleccion.IconChar = FontAwesome.Sharp.IconChar.None;
            BtnCancelarSeleccion.IconColor = Color.FromArgb(11, 0, 25);
            BtnCancelarSeleccion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnCancelarSeleccion.Location = new Point(1044, 90);
            BtnCancelarSeleccion.Name = "BtnCancelarSeleccion";
            BtnCancelarSeleccion.Size = new Size(205, 52);
            BtnCancelarSeleccion.TabIndex = 27;
            BtnCancelarSeleccion.Text = "Cancelar";
            BtnCancelarSeleccion.UseVisualStyleBackColor = false;
            BtnCancelarSeleccion.Click += BtnCancelarSeleccion_Click;
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
            Load += ComprasView_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewCompras).EndInit();
            tabControl.ResumeLayout(false);
            Lista_TabPage.ResumeLayout(false);
            Lista_TabPage.PerformLayout();
            AgregarEditar_TabPage.ResumeLayout(false);
            AgregarEditar_TabPage.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            SeleccionarUsuario_TabPage.ResumeLayout(false);
            SeleccionarUsuario_TabPage.PerformLayout();
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
        private Label labelSubtituloAgregarEditar;
        private TextBox textBoxBuscar;
        private FontAwesome.Sharp.IconButton BtnBuscar;
        private Panel panel1;
        private Label label4;
        private TextBox textBoxCliente;
        private Label label6;
        private TextBox textBoxProductoServicio;
        private Label label2;
        private TextBox textBoxEmpleado;
        private DateTimePicker dateTimeSolicitudFeedback;
        private Label label8;
        private DateTimePicker dateTime_FechaCompra;
        private TabPage SeleccionarUsuario_TabPage;
        private FontAwesome.Sharp.IconButton iconButton1;
        private TextBox textBoxBuscarUsuario;
        private Label lblSeleccionUsuarioCliente_Titulo;
        private FontAwesome.Sharp.IconButton BtnSeleccionarUsuario;
        private Label lblSeleccionUsuarioCliente_SubTitulo;
        private DataGridView dataGridViewUsuarios;
        private Label label7;
        private TextBox textBox1;
        private Label label12;
        private Label label14;
        private TextBox textBoxNotasVentaInternas;
        private Label label13;
        private CheckBox checkBoxFeedbackRecibido;
        private TextBox textBoxFeedbackCliente;
        private Label label9;
        private FontAwesome.Sharp.IconButton BtnSeleccionarCliente;
        private FontAwesome.Sharp.IconButton BtnCancelar;
        private FontAwesome.Sharp.IconButton BtnGuardar;
        private FontAwesome.Sharp.IconButton BtnSeleccionarVendedor;
        private TextBox textBoxDescripcion;
        private DateTimePicker dateTime_FechaRecordatorio;
        private FontAwesome.Sharp.IconButton BtnRestaurar;
        private FontAwesome.Sharp.IconButton BtnEliminar;
        private FontAwesome.Sharp.IconButton BtnEditar;
        private CheckBox checkBoxEliminados;
        private FontAwesome.Sharp.IconButton BtnCancelarSeleccion;
    }
}