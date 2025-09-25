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
            pictureBox2 = new PictureBox();
            label1 = new Label();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            ButtonLogIn = new FontAwesome.Sharp.IconButton();
            checkBoxVerContraseña = new CheckBox();
            label2 = new Label();
            label3 = new Label();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            label4 = new Label();
            labelErrorPassword = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(6, 1, 9);
            panel1.Controls.Add(pictureBox2);
            panel1.ForeColor = Color.FromArgb(6, 1, 9);
            panel1.Location = new Point(426, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(488, 355);
            panel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(71, 31);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(275, 266);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 24;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            label1.Location = new Point(12, 29);
            label1.Name = "label1";
            label1.Size = new Size(330, 54);
            label1.TabIndex = 1;
            label1.Text = "¡Hola de Nuevo!";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(48, 131);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Correo Electronico";
            txtEmail.Size = new Size(247, 23);
            txtEmail.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(48, 182);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Contraseña";
            txtPassword.Size = new Size(247, 23);
            txtPassword.TabIndex = 3;
            // 
            // ButtonLogIn
            // 
            ButtonLogIn.BackColor = Color.FromArgb(6, 1, 9);
            ButtonLogIn.FlatStyle = FlatStyle.Flat;
            ButtonLogIn.ForeColor = SystemColors.Control;
            ButtonLogIn.IconChar = FontAwesome.Sharp.IconChar.None;
            ButtonLogIn.IconColor = Color.White;
            ButtonLogIn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonLogIn.Location = new Point(85, 244);
            ButtonLogIn.Name = "ButtonLogIn";
            ButtonLogIn.Size = new Size(102, 28);
            ButtonLogIn.TabIndex = 4;
            ButtonLogIn.Text = "Iniciar Sesion";
            ButtonLogIn.UseVisualStyleBackColor = false;
            ButtonLogIn.Click += ButtonLogIn_Click;
            // 
            // checkBoxVerContraseña
            // 
            checkBoxVerContraseña.AutoSize = true;
            checkBoxVerContraseña.Location = new Point(193, 219);
            checkBoxVerContraseña.Name = "checkBoxVerContraseña";
            checkBoxVerContraseña.Size = new Size(105, 19);
            checkBoxVerContraseña.TabIndex = 5;
            checkBoxVerContraseña.Text = "Ver Contraseña";
            checkBoxVerContraseña.UseVisualStyleBackColor = true;
            checkBoxVerContraseña.CheckedChanged += checkBoxVerContraseña_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8F);
            label2.Location = new Point(44, 115);
            label2.Name = "label2";
            label2.Size = new Size(102, 13);
            label2.TabIndex = 6;
            label2.Text = "Correo Electronico";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8F);
            label3.Location = new Point(43, 166);
            label3.Name = "label3";
            label3.Size = new Size(66, 13);
            label3.TabIndex = 7;
            label3.Text = "Contraseña";
            // 
            // iconButton1
            // 
            iconButton1.BackColor = SystemColors.Control;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.ForeColor = Color.FromArgb(4, 5, 4);
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconButton1.IconColor = Color.FromArgb(4, 5, 4);
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(193, 244);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(102, 28);
            iconButton1.TabIndex = 8;
            iconButton1.Text = "Cancelar";
            iconButton1.UseVisualStyleBackColor = false;
            iconButton1.Click += iconButton1_Click;
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = SystemColors.Control;
            iconPictureBox1.ForeColor = SystemColors.ControlText;
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.User;
            iconPictureBox1.IconColor = SystemColors.ControlText;
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 21;
            iconPictureBox1.Location = new Point(28, 131);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(21, 23);
            iconPictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            iconPictureBox1.TabIndex = 9;
            iconPictureBox1.TabStop = false;
            // 
            // iconPictureBox2
            // 
            iconPictureBox2.BackColor = SystemColors.Control;
            iconPictureBox2.ForeColor = SystemColors.ControlText;
            iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Lock;
            iconPictureBox2.IconColor = SystemColors.ControlText;
            iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox2.IconSize = 21;
            iconPictureBox2.Location = new Point(28, 182);
            iconPictureBox2.Name = "iconPictureBox2";
            iconPictureBox2.Size = new Size(21, 23);
            iconPictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            iconPictureBox2.TabIndex = 10;
            iconPictureBox2.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(21, 89);
            label4.Name = "label4";
            label4.Size = new Size(214, 15);
            label4.TabIndex = 11;
            label4.Text = "Por favor, inicia sesion para continuar...";
            // 
            // labelErrorPassword
            // 
            labelErrorPassword.AutoSize = true;
            labelErrorPassword.Font = new Font("Segoe UI Semibold", 6F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelErrorPassword.ForeColor = Color.Brown;
            labelErrorPassword.Location = new Point(46, 205);
            labelErrorPassword.Name = "labelErrorPassword";
            labelErrorPassword.Size = new Size(211, 11);
            labelErrorPassword.TabIndex = 12;
            labelErrorPassword.Text = "Su correo o contraseña es incorrecto, intentelo de nuevo...";
            // 
            // LoginView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 353);
            Controls.Add(label4);
            Controls.Add(iconButton1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(checkBoxVerContraseña);
            Controls.Add(ButtonLogIn);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(labelErrorPassword);
            Controls.Add(iconPictureBox1);
            Controls.Add(iconPictureBox2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginView";
            Load += LoginView_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private FontAwesome.Sharp.IconButton ButtonLogIn;
        private CheckBox checkBoxVerContraseña;
        private Label label2;
        private Label label3;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private Label label4;
        private Label labelErrorPassword;
        private PictureBox pictureBox2;
    }
}