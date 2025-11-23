namespace Desktop.Views
{
    partial class LoginView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            ButtonLogIn = new FontAwesome.Sharp.IconButton();
            checkBoxVerContraseña = new CheckBox();
            label2 = new Label();
            label3 = new Label();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            labelErrorPassword = new Label();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(11, 0, 25);
            panel1.Controls.Add(pictureBox1);
            panel1.ForeColor = Color.FromArgb(6, 1, 9);
            panel1.Location = new Point(471, -5);
            panel1.Name = "panel1";
            panel1.Size = new Size(513, 445);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(101, 114);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(355, 220);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Clash Display Light", 10F);
            txtEmail.Location = new Point(122, 167);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "  usuario@fidelium.com";
            txtEmail.Size = new Size(247, 24);
            txtEmail.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Clash Display Light", 10F);
            txtPassword.Location = new Point(122, 218);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "  Contraseña";
            txtPassword.Size = new Size(247, 24);
            txtPassword.TabIndex = 1;
            txtPassword.KeyPress += txtPassword_KeyPress;
            // 
            // ButtonLogIn
            // 
            ButtonLogIn.BackColor = Color.FromArgb(68, 0, 154);
            ButtonLogIn.FlatStyle = FlatStyle.Flat;
            ButtonLogIn.Font = new Font("Clash Display Semibold", 9F, FontStyle.Bold);
            ButtonLogIn.ForeColor = SystemColors.Control;
            ButtonLogIn.IconChar = FontAwesome.Sharp.IconChar.ArrowRight;
            ButtonLogIn.IconColor = Color.White;
            ButtonLogIn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonLogIn.IconSize = 20;
            ButtonLogIn.ImageAlign = ContentAlignment.MiddleRight;
            ButtonLogIn.Location = new Point(239, 312);
            ButtonLogIn.Name = "ButtonLogIn";
            ButtonLogIn.Padding = new Padding(3);
            ButtonLogIn.Size = new Size(130, 31);
            ButtonLogIn.TabIndex = 3;
            ButtonLogIn.Text = "Iniciar Sesion";
            ButtonLogIn.TextAlign = ContentAlignment.MiddleLeft;
            ButtonLogIn.UseVisualStyleBackColor = false;
            ButtonLogIn.Click += BtnLogin_Click;
            // 
            // checkBoxVerContraseña
            // 
            checkBoxVerContraseña.AutoSize = true;
            checkBoxVerContraseña.Font = new Font("Clash Display Light", 8F);
            checkBoxVerContraseña.Location = new Point(261, 261);
            checkBoxVerContraseña.Name = "checkBoxVerContraseña";
            checkBoxVerContraseña.Size = new Size(108, 17);
            checkBoxVerContraseña.TabIndex = 2;
            checkBoxVerContraseña.Text = "Ver Contraseña";
            checkBoxVerContraseña.UseVisualStyleBackColor = true;
            checkBoxVerContraseña.CheckedChanged += checkBoxVerContraseña_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Clash Display Light", 10F);
            label2.Location = new Point(120, 148);
            label2.Name = "label2";
            label2.Size = new Size(130, 16);
            label2.TabIndex = 6;
            label2.Text = "Correo Electronico";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Clash Display Light", 10F);
            label3.Location = new Point(122, 199);
            label3.Name = "label3";
            label3.Size = new Size(84, 16);
            label3.TabIndex = 7;
            label3.Text = "Contraseña";
            // 
            // iconButton1
            // 
            iconButton1.BackColor = Color.Transparent;
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.Font = new Font("Clash Display Semibold", 9F, FontStyle.Bold);
            iconButton1.ForeColor = Color.FromArgb(4, 5, 4);
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconButton1.IconColor = Color.FromArgb(4, 5, 4);
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(122, 312);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(75, 31);
            iconButton1.TabIndex = 4;
            iconButton1.Text = "Cancelar";
            iconButton1.UseVisualStyleBackColor = false;
            iconButton1.Click += BtnCancelar_Click;
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = Color.White;
            iconPictureBox1.ForeColor = SystemColors.ControlText;
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.UserAstronaut;
            iconPictureBox1.IconColor = SystemColors.ControlText;
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 21;
            iconPictureBox1.Location = new Point(99, 168);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(21, 23);
            iconPictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            iconPictureBox1.TabIndex = 9;
            iconPictureBox1.TabStop = false;
            // 
            // iconPictureBox2
            // 
            iconPictureBox2.BackColor = Color.White;
            iconPictureBox2.ForeColor = SystemColors.ControlText;
            iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Key;
            iconPictureBox2.IconColor = SystemColors.ControlText;
            iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox2.IconSize = 21;
            iconPictureBox2.Location = new Point(99, 219);
            iconPictureBox2.Name = "iconPictureBox2";
            iconPictureBox2.Size = new Size(21, 23);
            iconPictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            iconPictureBox2.TabIndex = 10;
            iconPictureBox2.TabStop = false;
            // 
            // labelErrorPassword
            // 
            labelErrorPassword.AutoSize = true;
            labelErrorPassword.Font = new Font("Clash Display Light", 6.5F);
            labelErrorPassword.ForeColor = Color.Brown;
            labelErrorPassword.Location = new Point(122, 246);
            labelErrorPassword.Name = "labelErrorPassword";
            labelErrorPassword.Size = new Size(238, 10);
            labelErrorPassword.TabIndex = 12;
            labelErrorPassword.Text = "Su correo o contraseña es incorrecto, intentelo de nuevo...";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Clash Display Semibold", 29.9999962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 39);
            label5.Name = "label5";
            label5.Size = new Size(320, 46);
            label5.TabIndex = 13;
            label5.Text = "¡Hola de Nuevo!";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Clash Display", 11F);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(17, 87);
            label4.Name = "label4";
            label4.Size = new Size(277, 17);
            label4.TabIndex = 11;
            label4.Text = "Por favor, inicia sesion para continuar...";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Clash Display", 9F);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(159, 416);
            label1.Name = "label1";
            label1.Size = new Size(155, 14);
            label1.TabIndex = 14;
            label1.Text = "© 2025  Fidelium | Martin G.";
            // 
            // LoginView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(983, 439);
            Controls.Add(label1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(iconButton1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(checkBoxVerContraseña);
            Controls.Add(ButtonLogIn);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(panel1);
            Controls.Add(labelErrorPassword);
            Controls.Add(iconPictureBox1);
            Controls.Add(iconPictureBox2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginView";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private FontAwesome.Sharp.IconButton ButtonLogIn;
        private CheckBox checkBoxVerContraseña;
        private Label label2;
        private Label label3;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private Label labelErrorPassword;
        private PictureBox pictureBox1;
        private Label label5;
        private Label label4;
        private Label label1;
    }
}