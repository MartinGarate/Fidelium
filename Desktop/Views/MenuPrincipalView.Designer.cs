namespace Desktop
{
    partial class MenuPrincipalView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipalView));
            salirMenu = new ToolStripMenuItem();
            subMenu_Salir = new ToolStripMenuItem();
            subMenu_Principal = new ToolStripMenuItem();
            Menu = new Panel();
            panel1 = new Panel();
            BtnCompras = new FontAwesome.Sharp.IconButton();
            BtnUsuarios = new FontAwesome.Sharp.IconButton();
            BtnDashboard = new FontAwesome.Sharp.IconButton();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // salirMenu
            // 
            salirMenu.DropDownItems.AddRange(new ToolStripItem[] { subMenu_Salir });
            salirMenu.Name = "salirMenu";
            salirMenu.Size = new Size(41, 20);
            salirMenu.Text = "Salir";
            // 
            // subMenu_Salir
            // 
            subMenu_Salir.Name = "subMenu_Salir";
            subMenu_Salir.Size = new Size(158, 22);
            subMenu_Salir.Text = "Salir del sistema";
            // 
            // subMenu_Principal
            // 
            subMenu_Principal.Name = "subMenu_Principal";
            subMenu_Principal.Size = new Size(180, 22);
            subMenu_Principal.Text = "Menu Principal";
            // 
            // Menu
            // 
            Menu.BackColor = Color.White;
            Menu.Controls.Add(panel1);
            Menu.Controls.Add(BtnCompras);
            Menu.Controls.Add(BtnUsuarios);
            Menu.Controls.Add(BtnDashboard);
            Menu.Controls.Add(pictureBox1);
            Menu.Controls.Add(label5);
            Menu.Dock = DockStyle.Left;
            Menu.Location = new Point(0, 0);
            Menu.Name = "Menu";
            Menu.Size = new Size(370, 1041);
            Menu.TabIndex = 13;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(24, 194);
            panel1.Name = "panel1";
            panel1.Size = new Size(323, 2);
            panel1.TabIndex = 23;
            // 
            // BtnCompras
            // 
            BtnCompras.BackColor = Color.Transparent;
            BtnCompras.FlatAppearance.BorderSize = 0;
            BtnCompras.FlatStyle = FlatStyle.Flat;
            BtnCompras.Font = new Font("Clash Display Medium", 15F);
            BtnCompras.ForeColor = Color.FromArgb(4, 5, 4);
            BtnCompras.IconChar = FontAwesome.Sharp.IconChar.CartShopping;
            BtnCompras.IconColor = Color.FromArgb(4, 5, 4);
            BtnCompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnCompras.IconSize = 33;
            BtnCompras.ImageAlign = ContentAlignment.MiddleLeft;
            BtnCompras.Location = new Point(45, 443);
            BtnCompras.Name = "BtnCompras";
            BtnCompras.Padding = new Padding(3);
            BtnCompras.Size = new Size(259, 52);
            BtnCompras.TabIndex = 18;
            BtnCompras.Text = "Ventas y Feedback";
            BtnCompras.TextAlign = ContentAlignment.MiddleRight;
            BtnCompras.UseVisualStyleBackColor = false;
            BtnCompras.Click += BtnCompras_Click;
            // 
            // BtnUsuarios
            // 
            BtnUsuarios.BackColor = Color.Transparent;
            BtnUsuarios.FlatAppearance.BorderSize = 0;
            BtnUsuarios.FlatStyle = FlatStyle.Flat;
            BtnUsuarios.Font = new Font("Clash Display Medium", 15F);
            BtnUsuarios.ForeColor = Color.FromArgb(4, 5, 4);
            BtnUsuarios.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            BtnUsuarios.IconColor = Color.FromArgb(4, 5, 4);
            BtnUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnUsuarios.IconSize = 33;
            BtnUsuarios.ImageAlign = ContentAlignment.MiddleLeft;
            BtnUsuarios.Location = new Point(45, 350);
            BtnUsuarios.Name = "BtnUsuarios";
            BtnUsuarios.Padding = new Padding(3, 3, 100, 3);
            BtnUsuarios.Size = new Size(259, 52);
            BtnUsuarios.TabIndex = 17;
            BtnUsuarios.Text = "Usuarios";
            BtnUsuarios.TextAlign = ContentAlignment.MiddleRight;
            BtnUsuarios.UseVisualStyleBackColor = false;
            BtnUsuarios.Click += BtnUsuarios_Click;
            // 
            // BtnDashboard
            // 
            BtnDashboard.BackColor = Color.FromArgb(88, 1, 180);
            BtnDashboard.FlatAppearance.BorderSize = 0;
            BtnDashboard.FlatStyle = FlatStyle.Flat;
            BtnDashboard.Font = new Font("Clash Display Medium", 15F);
            BtnDashboard.ForeColor = Color.White;
            BtnDashboard.IconChar = FontAwesome.Sharp.IconChar.ChartLine;
            BtnDashboard.IconColor = Color.White;
            BtnDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnDashboard.IconSize = 33;
            BtnDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            BtnDashboard.Location = new Point(45, 257);
            BtnDashboard.Name = "BtnDashboard";
            BtnDashboard.Padding = new Padding(3, 3, 76, 3);
            BtnDashboard.Size = new Size(259, 52);
            BtnDashboard.TabIndex = 16;
            BtnDashboard.Text = "Dashboard";
            BtnDashboard.TextAlign = ContentAlignment.MiddleRight;
            BtnDashboard.UseVisualStyleBackColor = false;
            BtnDashboard.Click += BtnDashboard_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(42, 71);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(90, 46);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Clash Display Semibold", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(129, 72);
            label5.Name = "label5";
            label5.Size = new Size(188, 46);
            label5.TabIndex = 14;
            label5.Text = "Fidelium";
            // 
            // MenuPrincipalView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(Menu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MenuPrincipalView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fidelium";
            WindowState = FormWindowState.Maximized;
            Menu.ResumeLayout(false);
            Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ToolStripMenuItem subMenuPrincipal;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem salirSubMenu;
        private ToolStripMenuItem subMenu_Principal;
        private ToolStripMenuItem salirMenu;
        private ToolStripMenuItem subMenu_Salir;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem3;
        private ToolStripMenuItem sub_menuPrincipal;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem sub_menuSalir;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem4;
        private Panel Menu;
        private Label label5;
        private PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton BtnDashboard;
        private FontAwesome.Sharp.IconButton BtnUsuarios;
        private FontAwesome.Sharp.IconButton BtnCompras;
        private Panel panel1;
    }
}
