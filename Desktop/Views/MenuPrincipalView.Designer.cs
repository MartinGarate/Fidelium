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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipalView));
            iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            toolStrip1 = new ToolStrip();
            contextMenuStrip1 = new ContextMenuStrip(components);
            salirMenu = new ToolStripMenuItem();
            subMenu_Salir = new ToolStripMenuItem();
            subMenu_Principal = new ToolStripMenuItem();
            subMenuUsuarios = new FontAwesome.Sharp.IconMenuItem();
            iconMenuItem2 = new FontAwesome.Sharp.IconMenuItem();
            salir_menu = new FontAwesome.Sharp.IconMenuItem();
            menuStrip1 = new MenuStrip();
            menuPrincipal = new FontAwesome.Sharp.IconMenuItem();
            usuarios = new FontAwesome.Sharp.IconMenuItem();
            menuSalir = new FontAwesome.Sharp.IconMenuItem();
            subMenuSalir = new FontAwesome.Sharp.IconMenuItem();
            subMenu_Capacitaciones = new FontAwesome.Sharp.IconMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // iconMenuItem1
            // 
            iconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconMenuItem1.IconColor = Color.Black;
            iconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem1.Name = "iconMenuItem1";
            iconMenuItem1.Size = new Size(32, 19);
            iconMenuItem1.Text = "iconMenuItem1";
            // 
            // toolStrip1
            // 
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 6;
            toolStrip1.Text = "toolStrip1";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
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
            // subMenuUsuarios
            // 
            subMenuUsuarios.IconChar = FontAwesome.Sharp.IconChar.None;
            subMenuUsuarios.IconColor = Color.Black;
            subMenuUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            subMenuUsuarios.Name = "subMenuUsuarios";
            subMenuUsuarios.Size = new Size(180, 22);
            subMenuUsuarios.Text = "Usuarios";
            // 
            // iconMenuItem2
            // 
            iconMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { salir_menu });
            iconMenuItem2.IconChar = FontAwesome.Sharp.IconChar.None;
            iconMenuItem2.IconColor = Color.Black;
            iconMenuItem2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem2.Name = "iconMenuItem2";
            iconMenuItem2.Size = new Size(57, 20);
            iconMenuItem2.Text = "Salir";
            // 
            // salir_menu
            // 
            salir_menu.IconChar = FontAwesome.Sharp.IconChar.None;
            salir_menu.IconColor = Color.Black;
            salir_menu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            salir_menu.Name = "salir_menu";
            salir_menu.Size = new Size(149, 22);
            salir_menu.Text = "Salir del Menu";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuPrincipal, menuSalir });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuPrincipal
            // 
            menuPrincipal.DropDownItems.AddRange(new ToolStripItem[] { usuarios, subMenu_Capacitaciones });
            menuPrincipal.IconChar = FontAwesome.Sharp.IconChar.Bars;
            menuPrincipal.IconColor = Color.Black;
            menuPrincipal.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuPrincipal.Name = "menuPrincipal";
            menuPrincipal.Size = new Size(115, 20);
            menuPrincipal.Text = "Menu Principal";
            // 
            // usuarios
            // 
            usuarios.IconChar = FontAwesome.Sharp.IconChar.Users;
            usuarios.IconColor = Color.Black;
            usuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            usuarios.Name = "usuarios";
            usuarios.Size = new Size(180, 22);
            usuarios.Text = "Usuarios";
            usuarios.Click += usuarios_Click;
            // 
            // menuSalir
            // 
            menuSalir.DropDownItems.AddRange(new ToolStripItem[] { subMenuSalir });
            menuSalir.IconChar = FontAwesome.Sharp.IconChar.RightToBracket;
            menuSalir.IconColor = Color.Black;
            menuSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuSalir.Name = "menuSalir";
            menuSalir.Size = new Size(57, 20);
            menuSalir.Text = "Salir";
            // 
            // subMenuSalir
            // 
            subMenuSalir.IconChar = FontAwesome.Sharp.IconChar.RightToBracket;
            subMenuSalir.IconColor = Color.Black;
            subMenuSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            subMenuSalir.Name = "subMenuSalir";
            subMenuSalir.Size = new Size(149, 22);
            subMenuSalir.Text = "Salir del Menu";
            subMenuSalir.Click += subMenuSalir_Click;
            // 
            // subMenu_Capacitaciones
            // 
            subMenu_Capacitaciones.IconChar = FontAwesome.Sharp.IconChar.BookBookmark;
            subMenu_Capacitaciones.IconColor = Color.Black;
            subMenu_Capacitaciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            subMenu_Capacitaciones.Name = "subMenu_Capacitaciones";
            subMenu_Capacitaciones.Size = new Size(180, 22);
            subMenu_Capacitaciones.Text = "Capacitaciones";
            subMenu_Capacitaciones.Click += subMenu_Capacitaciones_Click;
            // 
            // MenuPrincipalView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            Name = "MenuPrincipalView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ágora | Software de Acreditación de Capacitaciones ISP 20";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
        private ToolStrip toolStrip1;
        private ContextMenuStrip contextMenuStrip1;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem2;
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
        private FontAwesome.Sharp.IconMenuItem subMenuUsuarios;
        private FontAwesome.Sharp.IconMenuItem salir_menu;
        private MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem menuPrincipal;
        private FontAwesome.Sharp.IconMenuItem usuarios;
        private FontAwesome.Sharp.IconMenuItem menuSalir;
        private FontAwesome.Sharp.IconMenuItem subMenuSalir;
        private FontAwesome.Sharp.IconMenuItem subMenu_Capacitaciones;
    }
}
