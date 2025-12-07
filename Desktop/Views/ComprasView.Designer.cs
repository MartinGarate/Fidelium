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
            BtnGuardar = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            label9 = new Label();
            dateTimeSolicitudFeedback = new DateTimePicker();
            label8 = new Label();
            dateTimeFechaCompra = new DateTimePicker();
            label2 = new Label();
            textBoxResponsable = new TextBox();
            label7 = new Label();
            textBoxDescripcion = new TextBox();
            label6 = new Label();
            textBoxProductoServicio = new TextBox();
            label4 = new Label();
            textBoxCliente = new TextBox();
            labelAccion = new Label();
            label3 = new Label();
            SeleccionarClienteResponsable_TabPage = new TabPage();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            textBoxBuscarUsuario = new TextBox();
            label10 = new Label();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            label11 = new Label();
            dataGridViewUsuarios = new DataGridView();
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
            AgregarEditar_TabPage.Controls.Add(label3);
            AgregarEditar_TabPage.Controls.Add(BtnCancelar);
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
            BtnCancelar.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            BtnCancelar.ForeColor = Color.FromArgb(11, 0, 25);
            BtnCancelar.IconChar = FontAwesome.Sharp.IconChar.None;
            BtnCancelar.IconColor = Color.FromArgb(11, 0, 25);
            BtnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnCancelar.Location = new Point(1128, 852);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(75, 31);
            BtnCancelar.TabIndex = 21;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.UseVisualStyleBackColor = false;
            // 
            // BtnGuardar
            // 
            BtnGuardar.BackColor = Color.FromArgb(68, 0, 154);
            BtnGuardar.FlatStyle = FlatStyle.Flat;
            BtnGuardar.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            BtnGuardar.ForeColor = SystemColors.Control;
            BtnGuardar.IconChar = FontAwesome.Sharp.IconChar.ArrowRight;
            BtnGuardar.IconColor = Color.White;
            BtnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnGuardar.IconSize = 20;
            BtnGuardar.ImageAlign = ContentAlignment.MiddleRight;
            BtnGuardar.Location = new Point(1234, 852);
            BtnGuardar.Name = "BtnGuardar";
            BtnGuardar.Padding = new Padding(3);
            BtnGuardar.Size = new Size(110, 31);
            BtnGuardar.TabIndex = 20;
            BtnGuardar.Text = "Guardar";
            BtnGuardar.TextAlign = ContentAlignment.MiddleLeft;
            BtnGuardar.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(dateTimeSolicitudFeedback);
            panel1.Controls.Add(dateTimeFechaCompra);
            panel1.Controls.Add(textBoxResponsable);
            panel1.Controls.Add(textBoxDescripcion);
            panel1.Controls.Add(textBoxProductoServicio);
            panel1.Controls.Add(textBoxCliente);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            panel1.Location = new Point(164, 185);
            panel1.Name = "panel1";
            panel1.Size = new Size(1180, 661);
            panel1.TabIndex = 19;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            label9.Location = new Point(586, 294);
            label9.Name = "label9";
            label9.Size = new Size(355, 32);
            label9.TabIndex = 37;
            label9.Text = "Fecha de Solicitud de Feedback";
            // 
            // dateTimeSolicitudFeedback
            // 
            dateTimeSolicitudFeedback.Font = new Font("Segoe UI", 12F);
            dateTimeSolicitudFeedback.Location = new Point(590, 324);
            dateTimeSolicitudFeedback.Name = "dateTimeSolicitudFeedback";
            dateTimeSolicitudFeedback.Size = new Size(490, 29);
            dateTimeSolicitudFeedback.TabIndex = 36;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            label8.Location = new Point(70, 294);
            label8.Name = "label8";
            label8.Size = new Size(207, 32);
            label8.TabIndex = 35;
            label8.Text = "Fecha de Registro";
            // 
            // dateTimeFechaCompra
            // 
            dateTimeFechaCompra.Font = new Font("Segoe UI", 12F);
            dateTimeFechaCompra.Location = new Point(75, 324);
            dateTimeFechaCompra.Name = "dateTimeFechaCompra";
            dateTimeFechaCompra.Size = new Size(490, 29);
            dateTimeFechaCompra.TabIndex = 34;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            label2.Location = new Point(585, 40);
            label2.Name = "label2";
            label2.Size = new Size(149, 32);
            label2.TabIndex = 33;
            label2.Text = "Responsable";
            // 
            // textBoxResponsable
            // 
            textBoxResponsable.BackColor = Color.FromArgb(244, 246, 248);
            textBoxResponsable.Font = new Font("Segoe UI", 12F);
            textBoxResponsable.Location = new Point(590, 70);
            textBoxResponsable.Name = "textBoxResponsable";
            textBoxResponsable.PlaceholderText = "Ejemplo: Martin Garate";
            textBoxResponsable.Size = new Size(489, 29);
            textBoxResponsable.TabIndex = 32;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            label7.Location = new Point(69, 200);
            label7.Name = "label7";
            label7.Size = new Size(139, 32);
            label7.TabIndex = 23;
            label7.Text = "Descripción";
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.BackColor = Color.FromArgb(244, 246, 248);
            textBoxDescripcion.Font = new Font("Segoe UI", 12F);
            textBoxDescripcion.Location = new Point(75, 230);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.PlaceholderText = "Detalles de uso y cualquier información relevante para el comprador";
            textBoxDescripcion.Size = new Size(1004, 29);
            textBoxDescripcion.TabIndex = 22;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            label6.Location = new Point(70, 121);
            label6.Name = "label6";
            label6.Size = new Size(226, 32);
            label6.TabIndex = 21;
            label6.Text = "Producto o Servicio";
            // 
            // textBoxProductoServicio
            // 
            textBoxProductoServicio.BackColor = Color.FromArgb(244, 246, 248);
            textBoxProductoServicio.Font = new Font("Segoe UI", 12F);
            textBoxProductoServicio.Location = new Point(76, 151);
            textBoxProductoServicio.Name = "textBoxProductoServicio";
            textBoxProductoServicio.PlaceholderText = "Ejemplo: Auriculares ASTROS A10";
            textBoxProductoServicio.Size = new Size(1004, 29);
            textBoxProductoServicio.TabIndex = 20;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(71, 40);
            label4.Name = "label4";
            label4.Size = new Size(226, 32);
            label4.TabIndex = 19;
            label4.Text = "Nombre del Cliente";
            // 
            // textBoxCliente
            // 
            textBoxCliente.BackColor = Color.FromArgb(244, 246, 248);
            textBoxCliente.Font = new Font("Segoe UI", 12F);
            textBoxCliente.Location = new Point(76, 70);
            textBoxCliente.Name = "textBoxCliente";
            textBoxCliente.PlaceholderText = "Ejemplo: Martin Garate";
            textBoxCliente.Size = new Size(489, 29);
            textBoxCliente.TabIndex = 0;
            // 
            // labelAccion
            // 
            labelAccion.AutoSize = true;
            labelAccion.BackColor = Color.Transparent;
            labelAccion.Font = new Font("Segoe UI Semibold", 30F, FontStyle.Bold);
            labelAccion.Location = new Point(158, 86);
            labelAccion.Name = "labelAccion";
            labelAccion.Size = new Size(757, 54);
            labelAccion.TabIndex = 17;
            labelAccion.Text = "Registrá una nueva compra en el sistema";
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
        private Label label7;
        private TextBox textBoxDescripcion;
        private Label label6;
        private TextBox textBoxProductoServicio;
        private CheckBox checkBoxEliminados;
        private FontAwesome.Sharp.IconButton BtnRestaurar;
        private FontAwesome.Sharp.IconButton BtnEliminar;
        private FontAwesome.Sharp.IconButton BtnEditar;
        private FontAwesome.Sharp.IconButton BtnCancelar;
        private FontAwesome.Sharp.IconButton BtnGuardar;
        private Label label2;
        private TextBox textBoxResponsable;
        private Label label9;
        private DateTimePicker dateTimeSolicitudFeedback;
        private Label label8;
        private DateTimePicker dateTimeFechaCompra;
        private TabPage SeleccionarClienteResponsable_TabPage;
        private FontAwesome.Sharp.IconButton iconButton1;
        private TextBox textBoxBuscarUsuario;
        private Label label10;
        private FontAwesome.Sharp.IconButton iconButton2;
        private Label label11;
        private DataGridView dataGridViewUsuarios;
    }
}