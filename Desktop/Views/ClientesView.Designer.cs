namespace Desktop.Views
{
    partial class ClientesView
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientesView));
            tabControl = new TabControl();
            tabPageLista = new TabPage();
            label9 = new Label();
            label8 = new Label();
            buttonRestaurar = new FontAwesome.Sharp.IconButton();
            checkBox_VerEliminados = new CheckBox();
            ButtonEliminarAuto = new FontAwesome.Sharp.IconButton();
            ButtonEditar = new FontAwesome.Sharp.IconButton();
            ButtonAgregar = new FontAwesome.Sharp.IconButton();
            ButtonBuscar = new FontAwesome.Sharp.IconButton();
            textBoxBuscar = new TextBox();
            dataGridView = new DataGridView();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            ButtonClose = new FontAwesome.Sharp.IconButton();
            tabPageAgregar_Editar = new TabPage();
            label7 = new Label();
            comboBoxTipoUsuario = new ComboBox();
            label6 = new Label();
            textBoxEmail = new TextBox();
            label4 = new Label();
            labelAccion = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label5 = new Label();
            textBoxTelefono = new TextBox();
            textBoxInstagram = new TextBox();
            textBoxNombre = new TextBox();
            textBoxDNI = new TextBox();
            pictureBox2 = new PictureBox();
            panel2 = new Panel();
            ButtonCancelar = new FontAwesome.Sharp.IconButton();
            ButtonGuardar = new FontAwesome.Sharp.IconButton();
            contextMenuStripLimpiar = new ContextMenuStrip(components);
            limpiarToolStripMenuItem = new ToolStripMenuItem();
            tabControl.SuspendLayout();
            tabPageLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabPageAgregar_Editar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            contextMenuStripLimpiar.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabPageLista);
            tabControl.Controls.Add(tabPageAgregar_Editar);
            tabControl.Location = new Point(-5, -2);
            tabControl.Margin = new Padding(0);
            tabControl.Multiline = true;
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(989, 605);
            tabControl.TabIndex = 0;
            // 
            // tabPageLista
            // 
            tabPageLista.BackColor = Color.FromArgb(242, 242, 242);
            tabPageLista.BackgroundImageLayout = ImageLayout.None;
            tabPageLista.Controls.Add(label9);
            tabPageLista.Controls.Add(label8);
            tabPageLista.Controls.Add(buttonRestaurar);
            tabPageLista.Controls.Add(checkBox_VerEliminados);
            tabPageLista.Controls.Add(ButtonEliminarAuto);
            tabPageLista.Controls.Add(ButtonEditar);
            tabPageLista.Controls.Add(ButtonAgregar);
            tabPageLista.Controls.Add(ButtonBuscar);
            tabPageLista.Controls.Add(textBoxBuscar);
            tabPageLista.Controls.Add(dataGridView);
            tabPageLista.Controls.Add(panel1);
            tabPageLista.Location = new Point(4, 24);
            tabPageLista.Name = "tabPageLista";
            tabPageLista.Size = new Size(981, 577);
            tabPageLista.TabIndex = 0;
            tabPageLista.Text = "Lista";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(19, 10, 29);
            label9.Location = new Point(22, 216);
            label9.Name = "label9";
            label9.Size = new Size(458, 15);
            label9.TabIndex = 35;
            label9.Text = "Administra, crea y actualiza la información de tus clientes de manera rápida y sencilla.";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(19, 10, 29);
            label8.Location = new Point(13, 157);
            label8.Name = "label8";
            label8.Size = new Size(487, 54);
            label8.TabIndex = 34;
            label8.Text = "Gestión Total de Clientes";
            // 
            // buttonRestaurar
            // 
            buttonRestaurar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonRestaurar.BackColor = Color.Transparent;
            buttonRestaurar.FlatAppearance.BorderColor = Color.FromArgb(115, 108, 122);
            buttonRestaurar.FlatStyle = FlatStyle.Flat;
            buttonRestaurar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonRestaurar.ForeColor = Color.FromArgb(19, 10, 29);
            buttonRestaurar.IconChar = FontAwesome.Sharp.IconChar.ChevronCircleLeft;
            buttonRestaurar.IconColor = Color.FromArgb(19, 10, 29);
            buttonRestaurar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonRestaurar.IconSize = 24;
            buttonRestaurar.ImageAlign = ContentAlignment.MiddleRight;
            buttonRestaurar.Location = new Point(866, 353);
            buttonRestaurar.Name = "buttonRestaurar";
            buttonRestaurar.Size = new Size(103, 28);
            buttonRestaurar.TabIndex = 9;
            buttonRestaurar.Text = "Restaurar";
            buttonRestaurar.TextAlign = ContentAlignment.MiddleLeft;
            buttonRestaurar.UseVisualStyleBackColor = false;
            buttonRestaurar.Click += buttonRestaurar_Click;
            // 
            // checkBox_VerEliminados
            // 
            checkBox_VerEliminados.AutoSize = true;
            checkBox_VerEliminados.FlatStyle = FlatStyle.Flat;
            checkBox_VerEliminados.Location = new Point(866, 530);
            checkBox_VerEliminados.Name = "checkBox_VerEliminados";
            checkBox_VerEliminados.RightToLeft = RightToLeft.No;
            checkBox_VerEliminados.Size = new Size(100, 19);
            checkBox_VerEliminados.TabIndex = 8;
            checkBox_VerEliminados.Text = "Ver eliminados";
            checkBox_VerEliminados.UseVisualStyleBackColor = true;
            checkBox_VerEliminados.CheckedChanged += checkBox_VerEliminados_CheckedChanged;
            // 
            // ButtonEliminarAuto
            // 
            ButtonEliminarAuto.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ButtonEliminarAuto.BackColor = Color.Transparent;
            ButtonEliminarAuto.FlatAppearance.BorderSize = 0;
            ButtonEliminarAuto.FlatStyle = FlatStyle.Flat;
            ButtonEliminarAuto.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButtonEliminarAuto.ForeColor = Color.FromArgb(19, 10, 29);
            ButtonEliminarAuto.IconChar = FontAwesome.Sharp.IconChar.UserMinus;
            ButtonEliminarAuto.IconColor = Color.FromArgb(19, 10, 29);
            ButtonEliminarAuto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonEliminarAuto.IconSize = 24;
            ButtonEliminarAuto.ImageAlign = ContentAlignment.MiddleRight;
            ButtonEliminarAuto.Location = new Point(866, 387);
            ButtonEliminarAuto.Name = "ButtonEliminarAuto";
            ButtonEliminarAuto.Size = new Size(103, 28);
            ButtonEliminarAuto.TabIndex = 7;
            ButtonEliminarAuto.Text = "Eliminar";
            ButtonEliminarAuto.TextAlign = ContentAlignment.MiddleLeft;
            ButtonEliminarAuto.UseVisualStyleBackColor = false;
            ButtonEliminarAuto.Click += ButtonEliminarAuto_Click;
            // 
            // ButtonEditar
            // 
            ButtonEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonEditar.BackColor = Color.Transparent;
            ButtonEditar.FlatAppearance.BorderColor = Color.FromArgb(115, 108, 122);
            ButtonEditar.FlatStyle = FlatStyle.Flat;
            ButtonEditar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButtonEditar.ForeColor = Color.FromArgb(19, 10, 29);
            ButtonEditar.IconChar = FontAwesome.Sharp.IconChar.UserPen;
            ButtonEditar.IconColor = Color.FromArgb(19, 10, 29);
            ButtonEditar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonEditar.IconSize = 24;
            ButtonEditar.ImageAlign = ContentAlignment.MiddleRight;
            ButtonEditar.Location = new Point(866, 319);
            ButtonEditar.Name = "ButtonEditar";
            ButtonEditar.Size = new Size(103, 28);
            ButtonEditar.TabIndex = 6;
            ButtonEditar.Text = "Editar";
            ButtonEditar.TextAlign = ContentAlignment.MiddleLeft;
            ButtonEditar.UseVisualStyleBackColor = false;
            ButtonEditar.Click += ButtonEditar_Click;
            // 
            // ButtonAgregar
            // 
            ButtonAgregar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonAgregar.BackColor = Color.FromArgb(109, 40, 217);
            ButtonAgregar.FlatAppearance.BorderSize = 0;
            ButtonAgregar.FlatStyle = FlatStyle.Flat;
            ButtonAgregar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            ButtonAgregar.ForeColor = Color.FromArgb(242, 242, 242);
            ButtonAgregar.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            ButtonAgregar.IconColor = Color.FromArgb(242, 242, 242);
            ButtonAgregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonAgregar.IconSize = 26;
            ButtonAgregar.ImageAlign = ContentAlignment.MiddleRight;
            ButtonAgregar.Location = new Point(866, 285);
            ButtonAgregar.Name = "ButtonAgregar";
            ButtonAgregar.Size = new Size(103, 28);
            ButtonAgregar.TabIndex = 5;
            ButtonAgregar.Text = "Agregar";
            ButtonAgregar.TextAlign = ContentAlignment.MiddleLeft;
            ButtonAgregar.UseVisualStyleBackColor = false;
            ButtonAgregar.Click += ButtonAgregar_Click;
            // 
            // ButtonBuscar
            // 
            ButtonBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonBuscar.BackColor = Color.FromArgb(31, 31, 35);
            ButtonBuscar.FlatStyle = FlatStyle.Popup;
            ButtonBuscar.ForeColor = Color.FromArgb(242, 242, 242);
            ButtonBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            ButtonBuscar.IconColor = Color.FromArgb(242, 242, 242);
            ButtonBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonBuscar.IconSize = 20;
            ButtonBuscar.Location = new Point(817, 260);
            ButtonBuscar.Name = "ButtonBuscar";
            ButtonBuscar.Size = new Size(36, 25);
            ButtonBuscar.TabIndex = 4;
            ButtonBuscar.UseVisualStyleBackColor = false;
            ButtonBuscar.Click += ButtonBuscar_Click_1;
            // 
            // textBoxBuscar
            // 
            textBoxBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxBuscar.Font = new Font("Segoe UI", 10F);
            textBoxBuscar.ForeColor = Color.FromArgb(28, 28, 27);
            textBoxBuscar.Location = new Point(22, 260);
            textBoxBuscar.Name = "textBoxBuscar";
            textBoxBuscar.PlaceholderText = " Escriba el cliente que desea encontrar...";
            textBoxBuscar.Size = new Size(797, 25);
            textBoxBuscar.TabIndex = 3;
            textBoxBuscar.TextChanged += textBoxFiltrarAuto_TextChanged;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.BackgroundColor = Color.FromArgb(245, 245, 244);
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle17.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle17.ForeColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle17.SelectionBackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle17.SelectionForeColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle17.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle18.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle18.ForeColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle18.SelectionBackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle18.SelectionForeColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle18.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle18;
            dataGridView.GridColor = Color.FromArgb(24, 24, 27);
            dataGridView.Location = new Point(22, 285);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(831, 264);
            dataGridView.TabIndex = 2;
            dataGridView.SelectionChanged += dataGridViewAutos_SelectionChanged;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(19, 10, 29);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(ButtonClose);
            panel1.Location = new Point(-4, -7);
            panel1.Name = "panel1";
            panel1.Size = new Size(986, 146);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(17, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(133, 133);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // ButtonClose
            // 
            ButtonClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ButtonClose.BackColor = Color.Transparent;
            ButtonClose.FlatAppearance.BorderSize = 0;
            ButtonClose.FlatStyle = FlatStyle.Flat;
            ButtonClose.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButtonClose.ForeColor = Color.FromArgb(242, 242, 242);
            ButtonClose.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            ButtonClose.IconColor = Color.FromArgb(242, 242, 242);
            ButtonClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonClose.IconSize = 24;
            ButtonClose.ImageAlign = ContentAlignment.MiddleRight;
            ButtonClose.Location = new Point(917, 10);
            ButtonClose.Name = "ButtonClose";
            ButtonClose.Size = new Size(65, 28);
            ButtonClose.TabIndex = 8;
            ButtonClose.Text = "Salir";
            ButtonClose.TextAlign = ContentAlignment.MiddleLeft;
            ButtonClose.UseVisualStyleBackColor = false;
            ButtonClose.Click += ButtonClose_Click;
            // 
            // tabPageAgregar_Editar
            // 
            tabPageAgregar_Editar.BackColor = Color.FromArgb(242, 242, 242);
            tabPageAgregar_Editar.Controls.Add(label7);
            tabPageAgregar_Editar.Controls.Add(comboBoxTipoUsuario);
            tabPageAgregar_Editar.Controls.Add(label6);
            tabPageAgregar_Editar.Controls.Add(textBoxEmail);
            tabPageAgregar_Editar.Controls.Add(label4);
            tabPageAgregar_Editar.Controls.Add(labelAccion);
            tabPageAgregar_Editar.Controls.Add(label3);
            tabPageAgregar_Editar.Controls.Add(label2);
            tabPageAgregar_Editar.Controls.Add(label1);
            tabPageAgregar_Editar.Controls.Add(label5);
            tabPageAgregar_Editar.Controls.Add(textBoxTelefono);
            tabPageAgregar_Editar.Controls.Add(textBoxInstagram);
            tabPageAgregar_Editar.Controls.Add(textBoxNombre);
            tabPageAgregar_Editar.Controls.Add(textBoxDNI);
            tabPageAgregar_Editar.Controls.Add(pictureBox2);
            tabPageAgregar_Editar.Controls.Add(panel2);
            tabPageAgregar_Editar.Controls.Add(ButtonCancelar);
            tabPageAgregar_Editar.Controls.Add(ButtonGuardar);
            tabPageAgregar_Editar.Location = new Point(4, 24);
            tabPageAgregar_Editar.Name = "tabPageAgregar_Editar";
            tabPageAgregar_Editar.Padding = new Padding(3);
            tabPageAgregar_Editar.Size = new Size(981, 577);
            tabPageAgregar_Editar.TabIndex = 1;
            tabPageAgregar_Editar.Text = "Agregar o Editar";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold | FontStyle.Italic);
            label7.ForeColor = Color.FromArgb(20, 21, 20);
            label7.Location = new Point(21, 216);
            label7.Name = "label7";
            label7.Size = new Size(153, 22);
            label7.TabIndex = 38;
            label7.Text = "Tipo de Usuario";
            // 
            // comboBoxTipoUsuario
            // 
            comboBoxTipoUsuario.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            comboBoxTipoUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTipoUsuario.FormattingEnabled = true;
            comboBoxTipoUsuario.Location = new Point(197, 215);
            comboBoxTipoUsuario.Name = "comboBoxTipoUsuario";
            comboBoxTipoUsuario.Size = new Size(174, 23);
            comboBoxTipoUsuario.TabIndex = 37;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold | FontStyle.Italic);
            label6.ForeColor = Color.FromArgb(20, 21, 20);
            label6.Location = new Point(115, 290);
            label6.Name = "label6";
            label6.Size = new Size(59, 22);
            label6.TabIndex = 35;
            label6.Text = "Email";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBoxEmail.Location = new Point(197, 289);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.PlaceholderText = "usuario@ejemplo.com";
            textBoxEmail.Size = new Size(174, 23);
            textBoxEmail.TabIndex = 36;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(50, 191);
            label4.Name = "label4";
            label4.Size = new Size(250, 15);
            label4.TabIndex = 34;
            label4.Text = "Por favor, completa los datos para continuar...";
            // 
            // labelAccion
            // 
            labelAccion.AutoSize = true;
            labelAccion.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            labelAccion.Location = new Point(41, 131);
            labelAccion.Name = "labelAccion";
            labelAccion.Size = new Size(0, 54);
            labelAccion.TabIndex = 33;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold | FontStyle.Italic);
            label3.ForeColor = Color.FromArgb(20, 21, 20);
            label3.Location = new Point(85, 401);
            label3.Name = "label3";
            label3.Size = new Size(89, 22);
            label3.TabIndex = 31;
            label3.Text = "Telefono";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold | FontStyle.Italic);
            label2.ForeColor = Color.FromArgb(20, 21, 20);
            label2.Location = new Point(77, 364);
            label2.Name = "label2";
            label2.Size = new Size(97, 22);
            label2.TabIndex = 29;
            label2.Text = "Instagram";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold | FontStyle.Italic);
            label1.ForeColor = Color.FromArgb(20, 21, 20);
            label1.Location = new Point(95, 327);
            label1.Name = "label1";
            label1.Size = new Size(79, 22);
            label1.TabIndex = 25;
            label1.Text = "Nombre";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold | FontStyle.Italic);
            label5.ForeColor = Color.FromArgb(20, 21, 20);
            label5.Location = new Point(131, 253);
            label5.Name = "label5";
            label5.Size = new Size(43, 22);
            label5.TabIndex = 13;
            label5.Text = "DNI";
            // 
            // textBoxTelefono
            // 
            textBoxTelefono.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBoxTelefono.Location = new Point(197, 400);
            textBoxTelefono.Name = "textBoxTelefono";
            textBoxTelefono.PlaceholderText = "Ej: +54 9 11 1234-5678";
            textBoxTelefono.Size = new Size(174, 23);
            textBoxTelefono.TabIndex = 32;
            // 
            // textBoxInstagram
            // 
            textBoxInstagram.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBoxInstagram.Location = new Point(197, 363);
            textBoxInstagram.Name = "textBoxInstagram";
            textBoxInstagram.PlaceholderText = "@usuario_instagram";
            textBoxInstagram.Size = new Size(174, 23);
            textBoxInstagram.TabIndex = 30;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBoxNombre.Location = new Point(197, 328);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.PlaceholderText = "Ej: Juan Pérez";
            textBoxNombre.Size = new Size(174, 23);
            textBoxNombre.TabIndex = 26;
            // 
            // textBoxDNI
            // 
            textBoxDNI.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBoxDNI.Location = new Point(197, 252);
            textBoxDNI.Name = "textBoxDNI";
            textBoxDNI.PlaceholderText = "Ej: 45678912";
            textBoxDNI.Size = new Size(174, 23);
            textBoxDNI.TabIndex = 24;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(654, 175);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(275, 266);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 23;
            pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(6, 1, 9);
            panel2.Location = new Point(-4, -7);
            panel2.Name = "panel2";
            panel2.Size = new Size(986, 110);
            panel2.TabIndex = 22;
            // 
            // ButtonCancelar
            // 
            ButtonCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonCancelar.BackColor = Color.FromArgb(242, 242, 242);
            ButtonCancelar.FlatStyle = FlatStyle.Flat;
            ButtonCancelar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButtonCancelar.ForeColor = Color.FromArgb(28, 28, 27);
            ButtonCancelar.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            ButtonCancelar.IconColor = Color.FromArgb(28, 28, 27);
            ButtonCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonCancelar.IconSize = 24;
            ButtonCancelar.ImageAlign = ContentAlignment.MiddleRight;
            ButtonCancelar.Location = new Point(278, 476);
            ButtonCancelar.Name = "ButtonCancelar";
            ButtonCancelar.Size = new Size(93, 28);
            ButtonCancelar.TabIndex = 19;
            ButtonCancelar.Text = "Cancelar";
            ButtonCancelar.TextAlign = ContentAlignment.MiddleLeft;
            ButtonCancelar.UseVisualStyleBackColor = false;
            ButtonCancelar.Click += ButtonCancelar_Click;
            // 
            // ButtonGuardar
            // 
            ButtonGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonGuardar.BackColor = Color.FromArgb(6, 1, 9);
            ButtonGuardar.FlatStyle = FlatStyle.Flat;
            ButtonGuardar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButtonGuardar.ForeColor = Color.FromArgb(242, 242, 242);
            ButtonGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            ButtonGuardar.IconColor = Color.FromArgb(242, 242, 242);
            ButtonGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonGuardar.IconSize = 24;
            ButtonGuardar.ImageAlign = ContentAlignment.MiddleRight;
            ButtonGuardar.Location = new Point(179, 476);
            ButtonGuardar.Name = "ButtonGuardar";
            ButtonGuardar.Size = new Size(93, 28);
            ButtonGuardar.TabIndex = 18;
            ButtonGuardar.Text = "Guardar";
            ButtonGuardar.TextAlign = ContentAlignment.MiddleLeft;
            ButtonGuardar.UseVisualStyleBackColor = false;
            ButtonGuardar.Click += ButtonGuardar_Click;
            // 
            // contextMenuStripLimpiar
            // 
            contextMenuStripLimpiar.Items.AddRange(new ToolStripItem[] { limpiarToolStripMenuItem });
            contextMenuStripLimpiar.Name = "contextMenuStrip1";
            contextMenuStripLimpiar.ShowImageMargin = false;
            contextMenuStripLimpiar.Size = new Size(99, 26);
            // 
            // limpiarToolStripMenuItem
            // 
            limpiarToolStripMenuItem.Name = "limpiarToolStripMenuItem";
            limpiarToolStripMenuItem.Size = new Size(98, 22);
            limpiarToolStripMenuItem.Text = "Limpiar...";
            limpiarToolStripMenuItem.Click += limpiarToolStripMenuItem_Click;
            // 
            // ClientesView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 242, 242);
            ClientSize = new Size(980, 599);
            Controls.Add(tabControl);
            Name = "ClientesView";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Clientes";
            WindowState = FormWindowState.Maximized;
            tabControl.ResumeLayout(false);
            tabPageLista.ResumeLayout(false);
            tabPageLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabPageAgregar_Editar.ResumeLayout(false);
            tabPageAgregar_Editar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            contextMenuStripLimpiar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabPageLista;
        private TabPage tabPageAgregar_Editar;
        private Panel panel1;
        private PictureBox pictureBoxAuto;
        private FontAwesome.Sharp.IconButton ButtonBuscar;
        private TextBox textBoxBuscar;
        private DataGridView dataGridView;
        private FontAwesome.Sharp.IconButton ButtonAgregar;
        private FontAwesome.Sharp.IconButton ButtonEliminarAuto;
        private FontAwesome.Sharp.IconButton ButtonEditar;
        private ContextMenuStrip contextMenuStripLimpiar;
        private ToolStripMenuItem limpiarToolStripMenuItem;
        private Label label5;
        private FontAwesome.Sharp.IconButton ButtonCancelar;
        private FontAwesome.Sharp.IconButton ButtonGuardar;
        private Panel panel2;
        private FontAwesome.Sharp.IconButton ButtonClose;
        private CheckBox checkBox_VerEliminados;
        private FontAwesome.Sharp.IconButton buttonRestaurar;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private TextBox textBoxTelefono;
        private Label label3;
        private TextBox textBoxInstagram;
        private Label label2;
        private TextBox textBoxNombre;
        private Label label1;
        private TextBox textBoxDNI;
        private Label label4;
        private Label labelAccion;
        private Label label6;
        private TextBox textBoxEmail;
        private Label label7;
        private ComboBox comboBoxTipoUsuario;
        private Label label8;
        private Label label9;
    }
}