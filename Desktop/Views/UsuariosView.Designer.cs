namespace Desktop.Views
{
    partial class UsuariosView
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
            dataGridViewUsuarios = new DataGridView();
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
            lblInstagram = new Label();
            textBoxInstagram = new TextBox();
            lblTelefono = new Label();
            textBoxTelefono = new TextBox();
            comboBoxTipoUsuario = new ComboBox();
            label8 = new Label();
            label7 = new Label();
            textBoxEmail = new TextBox();
            label6 = new Label();
            textBoxDNI = new TextBox();
            label4 = new Label();
            textBoxNombre = new TextBox();
            labelAccion = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).BeginInit();
            tabControl.SuspendLayout();
            Lista_TabPage.SuspendLayout();
            AgregarEditar_TabPage.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Clash Display Semibold", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(52, 71);
            label5.Name = "label5";
            label5.Size = new Size(861, 46);
            label5.TabIndex = 15;
            label5.Text = "Administrá a todos los usuarios del sistema";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Clash Display", 14F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(52, 117);
            label1.Name = "label1";
            label1.Size = new Size(631, 22);
            label1.TabIndex = 16;
            label1.Text = "Revisá la lista completa de cuentas y gestiona roles, estados y accesos.";
            // 
            // dataGridViewUsuarios
            // 
            dataGridViewUsuarios.BackgroundColor = Color.White;
            dataGridViewUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsuarios.Location = new Point(52, 260);
            dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            dataGridViewUsuarios.Size = new Size(1415, 649);
            dataGridViewUsuarios.TabIndex = 17;
            // 
            // BtnAgregar
            // 
            BtnAgregar.BackColor = Color.FromArgb(88, 1, 180);
            BtnAgregar.FlatAppearance.BorderSize = 0;
            BtnAgregar.FlatStyle = FlatStyle.Flat;
            BtnAgregar.Font = new Font("Clash Display Medium", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
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
            BtnAgregar.Click += BtnAgregar_Click;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(Lista_TabPage);
            tabControl.Controls.Add(AgregarEditar_TabPage);
            tabControl.Location = new Point(11, -4);
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
            Lista_TabPage.Controls.Add(BtnBuscar);
            Lista_TabPage.Controls.Add(textBoxBuscar);
            Lista_TabPage.Controls.Add(label5);
            Lista_TabPage.Controls.Add(BtnAgregar);
            Lista_TabPage.Controls.Add(label1);
            Lista_TabPage.Controls.Add(dataGridViewUsuarios);
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
            BtnRestaurar.Font = new Font("Clash Display Medium", 12F);
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
            BtnEliminar.TabIndex = 23;
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
            BtnEditar.Font = new Font("Clash Display Medium", 12F);
            BtnEditar.ForeColor = Color.FromArgb(19, 10, 29);
            BtnEditar.IconChar = FontAwesome.Sharp.IconChar.UserPen;
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
            BtnEditar.Click += BtnEditar_Click;
            // 
            // checkBoxEliminados
            // 
            checkBoxEliminados.AutoSize = true;
            checkBoxEliminados.Font = new Font("Clash Display", 10F, FontStyle.Italic);
            checkBoxEliminados.Location = new Point(1230, 920);
            checkBoxEliminados.Name = "checkBoxEliminados";
            checkBoxEliminados.Size = new Size(124, 20);
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
            BtnBuscar.Font = new Font("Clash Display Medium", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
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
            textBoxBuscar.PlaceholderText = " ¿A quién estás buscando?…";
            textBoxBuscar.Size = new Size(1368, 32);
            textBoxBuscar.TabIndex = 19;
            textBoxBuscar.TextChanged += textBoxBuscar_TextChanged;
            // 
            // AgregarEditar_TabPage
            // 
            AgregarEditar_TabPage.BackColor = Color.FromArgb(244, 246, 248);
            AgregarEditar_TabPage.Controls.Add(BtnCancelar);
            AgregarEditar_TabPage.Controls.Add(BtnGuardar);
            AgregarEditar_TabPage.Controls.Add(panel1);
            AgregarEditar_TabPage.Controls.Add(labelAccion);
            AgregarEditar_TabPage.Controls.Add(label3);
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
            BtnCancelar.Font = new Font("Clash Display Semibold", 9F, FontStyle.Bold);
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
            BtnCancelar.Click += BtnCancelar_Click;
            // 
            // BtnGuardar
            // 
            BtnGuardar.BackColor = Color.FromArgb(68, 0, 154);
            BtnGuardar.FlatStyle = FlatStyle.Flat;
            BtnGuardar.Font = new Font("Clash Display Semibold", 9F, FontStyle.Bold);
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
            BtnGuardar.Click += BtnGuardar_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lblInstagram);
            panel1.Controls.Add(textBoxInstagram);
            panel1.Controls.Add(lblTelefono);
            panel1.Controls.Add(textBoxTelefono);
            panel1.Controls.Add(comboBoxTipoUsuario);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(textBoxEmail);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(textBoxDNI);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBoxNombre);
            panel1.Location = new Point(164, 185);
            panel1.Name = "panel1";
            panel1.Size = new Size(1180, 661);
            panel1.TabIndex = 19;
            // 
            // lblInstagram
            // 
            lblInstagram.AutoSize = true;
            lblInstagram.BackColor = Color.Transparent;
            lblInstagram.Font = new Font("Clash Display Medium", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInstagram.Location = new Point(75, 554);
            lblInstagram.Name = "lblInstagram";
            lblInstagram.Size = new Size(132, 27);
            lblInstagram.TabIndex = 30;
            lblInstagram.Text = "Instagram";
            // 
            // textBoxInstagram
            // 
            textBoxInstagram.BackColor = Color.FromArgb(244, 246, 248);
            textBoxInstagram.Font = new Font("Segoe UI", 12F);
            textBoxInstagram.Location = new Point(75, 584);
            textBoxInstagram.Name = "textBoxInstagram";
            textBoxInstagram.PlaceholderText = "+54 9 3498 123456";
            textBoxInstagram.Size = new Size(1004, 29);
            textBoxInstagram.TabIndex = 29;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.BackColor = Color.Transparent;
            lblTelefono.Font = new Font("Clash Display Medium", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTelefono.Location = new Point(76, 451);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(115, 27);
            lblTelefono.TabIndex = 28;
            lblTelefono.Text = "Telefono";
            // 
            // textBoxTelefono
            // 
            textBoxTelefono.BackColor = Color.FromArgb(244, 246, 248);
            textBoxTelefono.Font = new Font("Segoe UI", 12F);
            textBoxTelefono.Location = new Point(76, 481);
            textBoxTelefono.Name = "textBoxTelefono";
            textBoxTelefono.PlaceholderText = "+54 9 3498 123456";
            textBoxTelefono.Size = new Size(1004, 29);
            textBoxTelefono.TabIndex = 27;
            // 
            // comboBoxTipoUsuario
            // 
            comboBoxTipoUsuario.BackColor = Color.FromArgb(244, 246, 248);
            comboBoxTipoUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTipoUsuario.Font = new Font("Segoe UI", 12F);
            comboBoxTipoUsuario.FormattingEnabled = true;
            comboBoxTipoUsuario.Location = new Point(76, 373);
            comboBoxTipoUsuario.Name = "comboBoxTipoUsuario";
            comboBoxTipoUsuario.Size = new Size(1004, 29);
            comboBoxTipoUsuario.TabIndex = 26;
            comboBoxTipoUsuario.SelectedIndexChanged += comboBoxTipoUsuario_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Clash Display Medium", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(76, 343);
            label8.Name = "label8";
            label8.Size = new Size(191, 27);
            label8.TabIndex = 25;
            label8.Text = "Tipo de Usuario";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Clash Display Medium", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(76, 242);
            label7.Name = "label7";
            label7.Size = new Size(74, 27);
            label7.TabIndex = 23;
            label7.Text = "Email";
            // 
            // textBoxEmail
            // 
            textBoxEmail.BackColor = Color.FromArgb(244, 246, 248);
            textBoxEmail.Font = new Font("Segoe UI", 12F);
            textBoxEmail.Location = new Point(76, 272);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.PlaceholderText = "martin@fidelium.com";
            textBoxEmail.Size = new Size(1004, 29);
            textBoxEmail.TabIndex = 22;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Clash Display Medium", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(75, 141);
            label6.Name = "label6";
            label6.Size = new Size(52, 27);
            label6.TabIndex = 21;
            label6.Text = "DNI";
            // 
            // textBoxDNI
            // 
            textBoxDNI.BackColor = Color.FromArgb(244, 246, 248);
            textBoxDNI.Font = new Font("Segoe UI", 12F);
            textBoxDNI.Location = new Point(76, 171);
            textBoxDNI.Name = "textBoxDNI";
            textBoxDNI.PlaceholderText = "Ejemplo: 123456789";
            textBoxDNI.Size = new Size(1004, 29);
            textBoxDNI.TabIndex = 20;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Clash Display Medium", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(75, 40);
            label4.Name = "label4";
            label4.Size = new Size(225, 27);
            label4.TabIndex = 19;
            label4.Text = "Nombre Completo";
            // 
            // textBoxNombre
            // 
            textBoxNombre.BackColor = Color.FromArgb(244, 246, 248);
            textBoxNombre.Font = new Font("Segoe UI", 12F);
            textBoxNombre.Location = new Point(76, 70);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.PlaceholderText = "Ejemplo: Martin Garate";
            textBoxNombre.Size = new Size(1004, 29);
            textBoxNombre.TabIndex = 0;
            // 
            // labelAccion
            // 
            labelAccion.AutoSize = true;
            labelAccion.BackColor = Color.Transparent;
            labelAccion.Font = new Font("Clash Display Semibold", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAccion.Location = new Point(164, 86);
            labelAccion.Name = "labelAccion";
            labelAccion.Size = new Size(782, 46);
            labelAccion.TabIndex = 17;
            labelAccion.Text = "Incorporá a alguien más a la plataforma\n";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Clash Display", 14F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(164, 132);
            label3.Name = "label3";
            label3.Size = new Size(610, 22);
            label3.TabIndex = 18;
            label3.Text = "Completá sus datos básicos para darle acceso según sus funciones.";
            // 
            // UsuariosView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 248);
            ClientSize = new Size(1534, 1041);
            Controls.Add(tabControl);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UsuariosView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UsuariosView";
            WindowState = FormWindowState.Maximized;
            Load += UsuariosView_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).EndInit();
            tabControl.ResumeLayout(false);
            Lista_TabPage.ResumeLayout(false);
            Lista_TabPage.PerformLayout();
            AgregarEditar_TabPage.ResumeLayout(false);
            AgregarEditar_TabPage.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label5;
        private Label label1;
        private DataGridView dataGridViewUsuarios;
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
        private TextBox textBoxNombre;
        private ComboBox comboBoxTipoUsuario;
        private Label label8;
        private Label label7;
        private TextBox textBoxEmail;
        private Label label6;
        private TextBox textBoxDNI;
        private Label lblInstagram;
        private TextBox textBoxInstagram;
        private Label lblTelefono;
        private TextBox textBoxTelefono;
        private CheckBox checkBoxEliminados;
        private FontAwesome.Sharp.IconButton BtnRestaurar;
        private FontAwesome.Sharp.IconButton BtnEliminar;
        private FontAwesome.Sharp.IconButton BtnEditar;
        private FontAwesome.Sharp.IconButton BtnCancelar;
        private FontAwesome.Sharp.IconButton BtnGuardar;
    }
}