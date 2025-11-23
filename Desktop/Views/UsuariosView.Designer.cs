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
            dataGridView1 = new DataGridView();
            BtnDashboard = new FontAwesome.Sharp.IconButton();
            tabControl = new TabControl();
            Lista_TabPage = new TabPage();
            AgregarEditar_TabPage = new TabPage();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabControl.SuspendLayout();
            Lista_TabPage.SuspendLayout();
            AgregarEditar_TabPage.SuspendLayout();
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
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(52, 260);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1415, 733);
            dataGridView1.TabIndex = 17;
            // 
            // BtnDashboard
            // 
            BtnDashboard.BackColor = Color.FromArgb(88, 1, 180);
            BtnDashboard.FlatAppearance.BorderSize = 0;
            BtnDashboard.FlatStyle = FlatStyle.Flat;
            BtnDashboard.Font = new Font("Clash Display Medium", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnDashboard.ForeColor = Color.White;
            BtnDashboard.IconChar = FontAwesome.Sharp.IconChar.CirclePlus;
            BtnDashboard.IconColor = Color.White;
            BtnDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnDashboard.IconSize = 33;
            BtnDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            BtnDashboard.Location = new Point(1285, 87);
            BtnDashboard.Name = "BtnDashboard";
            BtnDashboard.Padding = new Padding(12, 6, 12, 6);
            BtnDashboard.Size = new Size(182, 52);
            BtnDashboard.TabIndex = 18;
            BtnDashboard.Text = "Agregar";
            BtnDashboard.TextAlign = ContentAlignment.MiddleRight;
            BtnDashboard.UseVisualStyleBackColor = false;
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
            Lista_TabPage.Controls.Add(iconButton1);
            Lista_TabPage.Controls.Add(textBox1);
            Lista_TabPage.Controls.Add(label5);
            Lista_TabPage.Controls.Add(BtnDashboard);
            Lista_TabPage.Controls.Add(label1);
            Lista_TabPage.Controls.Add(dataGridView1);
            Lista_TabPage.Location = new Point(4, 24);
            Lista_TabPage.Name = "Lista_TabPage";
            Lista_TabPage.Padding = new Padding(3);
            Lista_TabPage.Size = new Size(1520, 1020);
            Lista_TabPage.TabIndex = 0;
            Lista_TabPage.Text = "Lista";
            Lista_TabPage.UseVisualStyleBackColor = true;
            // 
            // AgregarEditar_TabPage
            // 
            AgregarEditar_TabPage.Controls.Add(label2);
            AgregarEditar_TabPage.Controls.Add(label3);
            AgregarEditar_TabPage.Location = new Point(4, 24);
            AgregarEditar_TabPage.Name = "AgregarEditar_TabPage";
            AgregarEditar_TabPage.Padding = new Padding(3);
            AgregarEditar_TabPage.Size = new Size(1520, 1020);
            AgregarEditar_TabPage.TabIndex = 1;
            AgregarEditar_TabPage.Text = "Agregar/Editar";
            AgregarEditar_TabPage.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Clash Display Semibold", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(52, 71);
            label2.Name = "label2";
            label2.Size = new Size(782, 46);
            label2.TabIndex = 17;
            label2.Text = "Incorporá a alguien más a la plataforma\n";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Clash Display", 14F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(52, 117);
            label3.Name = "label3";
            label3.Size = new Size(610, 22);
            label3.TabIndex = 18;
            label3.Text = "Completá sus datos básicos para darle acceso según sus funciones.";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Clash Display", 14F, FontStyle.Italic);
            textBox1.Location = new Point(52, 221);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "   ¿A quién estás buscando?…";
            textBox1.Size = new Size(1368, 30);
            textBox1.TabIndex = 19;
            // 
            // iconButton1
            // 
            iconButton1.BackColor = Color.FromArgb(11, 0, 25);
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.Font = new Font("Clash Display Medium", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            iconButton1.ForeColor = Color.White;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.Search;
            iconButton1.IconColor = Color.White;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 28;
            iconButton1.Location = new Point(1420, 221);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(47, 30);
            iconButton1.TabIndex = 20;
            iconButton1.TextAlign = ContentAlignment.MiddleRight;
            iconButton1.UseVisualStyleBackColor = false;
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabControl.ResumeLayout(false);
            Lista_TabPage.ResumeLayout(false);
            Lista_TabPage.PerformLayout();
            AgregarEditar_TabPage.ResumeLayout(false);
            AgregarEditar_TabPage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label5;
        private Label label1;
        private DataGridView dataGridView1;
        private FontAwesome.Sharp.IconButton BtnDashboard;
        private TabControl tabControl;
        private TabPage AgregarEditar_TabPage;
        private TabPage Lista_TabPage;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}