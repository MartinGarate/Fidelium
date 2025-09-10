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
            pictureBox1 = new PictureBox();
            BtnCancelar = new FontAwesome.Sharp.IconButton();
            BtnIniciarSesion = new FontAwesome.Sharp.IconButton();
            CheckVerContraseña = new CheckBox();
            TxtPassword = new TextBox();
            label2 = new Label();
            TxtEmail = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(-31, -8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(430, 372);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // BtnCancelar
            // 
            BtnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnCancelar.BackColor = Color.LightGray;
            BtnCancelar.IconChar = FontAwesome.Sharp.IconChar.Close;
            BtnCancelar.IconColor = Color.Black;
            BtnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnCancelar.Location = new Point(679, 246);
            BtnCancelar.Margin = new Padding(2);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(182, 66);
            BtnCancelar.TabIndex = 25;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.TextAlign = ContentAlignment.MiddleRight;
            BtnCancelar.UseVisualStyleBackColor = false;
            // 
            // BtnIniciarSesion
            // 
            BtnIniciarSesion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnIniciarSesion.BackColor = Color.DarkGray;
            BtnIniciarSesion.IconChar = FontAwesome.Sharp.IconChar.CircleArrowRight;
            BtnIniciarSesion.IconColor = Color.Black;
            BtnIniciarSesion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnIniciarSesion.ImageAlign = ContentAlignment.MiddleLeft;
            BtnIniciarSesion.Location = new Point(441, 246);
            BtnIniciarSesion.Margin = new Padding(2);
            BtnIniciarSesion.Name = "BtnIniciarSesion";
            BtnIniciarSesion.Size = new Size(184, 66);
            BtnIniciarSesion.TabIndex = 24;
            BtnIniciarSesion.Text = "Iniciar sesión";
            BtnIniciarSesion.TextAlign = ContentAlignment.MiddleRight;
            BtnIniciarSesion.UseVisualStyleBackColor = false;
            BtnIniciarSesion.Click += BtnIniciarSesion_Click;
            // 
            // CheckVerContraseña
            // 
            CheckVerContraseña.AutoSize = true;
            CheckVerContraseña.Location = new Point(541, 187);
            CheckVerContraseña.Margin = new Padding(2);
            CheckVerContraseña.Name = "CheckVerContraseña";
            CheckVerContraseña.Size = new Size(154, 29);
            CheckVerContraseña.TabIndex = 23;
            CheckVerContraseña.Text = "Ver contraseña";
            CheckVerContraseña.UseVisualStyleBackColor = true;
            CheckVerContraseña.CheckedChanged += CheckVerContraseña_CheckedChanged;
            // 
            // TxtPassword
            // 
            TxtPassword.Location = new Point(541, 129);
            TxtPassword.Margin = new Padding(2);
            TxtPassword.Name = "TxtPassword";
            TxtPassword.PasswordChar = '*';
            TxtPassword.Size = new Size(299, 31);
            TxtPassword.TabIndex = 22;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(421, 129);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(91, 25);
            label2.TabIndex = 21;
            label2.Text = "Password:";
            // 
            // TxtEmail
            // 
            TxtEmail.Location = new Point(541, 62);
            TxtEmail.Margin = new Padding(2);
            TxtEmail.Name = "TxtEmail";
            TxtEmail.Size = new Size(299, 31);
            TxtEmail.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(453, 62);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(58, 25);
            label1.TabIndex = 19;
            label1.Text = "Email:";
            // 
            // LoginView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(888, 364);
            Controls.Add(BtnCancelar);
            Controls.Add(BtnIniciarSesion);
            Controls.Add(CheckVerContraseña);
            Controls.Add(TxtPassword);
            Controls.Add(label2);
            Controls.Add(TxtEmail);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginView";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        public FontAwesome.Sharp.IconButton BtnCancelar;
        public FontAwesome.Sharp.IconButton BtnIniciarSesion;
        private CheckBox CheckVerContraseña;
        private TextBox TxtPassword;
        private Label label2;
        private TextBox TxtEmail;
        private Label label1;
    }
}