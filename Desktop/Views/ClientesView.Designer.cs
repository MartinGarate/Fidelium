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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientesView));
            tabControl = new TabControl();
            tabPageLista = new TabPage();
            buttonRestaurar = new FontAwesome.Sharp.IconButton();
            checkBox_VerEliminados = new CheckBox();
            ButtonEliminarAuto = new FontAwesome.Sharp.IconButton();
            ButtonEditarAuto = new FontAwesome.Sharp.IconButton();
            ButtonAgregarAuto = new FontAwesome.Sharp.IconButton();
            ButtonBuscarAuto = new FontAwesome.Sharp.IconButton();
            textBoxFiltrarAuto = new TextBox();
            dataGridView = new DataGridView();
            panel1 = new Panel();
            ButtonClose = new FontAwesome.Sharp.IconButton();
            tabPageAgregar_Editar = new TabPage();
            panel2 = new Panel();
            numericPrecioAuto = new NumericUpDown();
            numericAnioAuto = new NumericUpDown();
            ButtonCancelar = new FontAwesome.Sharp.IconButton();
            ButtonGuardar = new FontAwesome.Sharp.IconButton();
            checkBoxUsado = new CheckBox();
            label5 = new Label();
            label4 = new Label();
            textBoxModeloAuto = new TextBox();
            label3 = new Label();
            label2 = new Label();
            textBoxMarcaAuto = new TextBox();
            label1 = new Label();
            textBoxImagenAuto = new TextBox();
            contextMenuStripLimpiar = new ContextMenuStrip(components);
            limpiarToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            tabControl.SuspendLayout();
            tabPageLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            panel1.SuspendLayout();
            tabPageAgregar_Editar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericPrecioAuto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericAnioAuto).BeginInit();
            contextMenuStripLimpiar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
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
            tabPageLista.Controls.Add(buttonRestaurar);
            tabPageLista.Controls.Add(checkBox_VerEliminados);
            tabPageLista.Controls.Add(ButtonEliminarAuto);
            tabPageLista.Controls.Add(ButtonEditarAuto);
            tabPageLista.Controls.Add(ButtonAgregarAuto);
            tabPageLista.Controls.Add(ButtonBuscarAuto);
            tabPageLista.Controls.Add(textBoxFiltrarAuto);
            tabPageLista.Controls.Add(dataGridView);
            tabPageLista.Controls.Add(panel1);
            tabPageLista.Location = new Point(4, 24);
            tabPageLista.Name = "tabPageLista";
            tabPageLista.Size = new Size(981, 577);
            tabPageLista.TabIndex = 0;
            tabPageLista.Text = "Lista";
            // 
            // buttonRestaurar
            // 
            buttonRestaurar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonRestaurar.BackColor = Color.FromArgb(28, 28, 27);
            buttonRestaurar.FlatStyle = FlatStyle.Flat;
            buttonRestaurar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonRestaurar.ForeColor = Color.FromArgb(242, 242, 242);
            buttonRestaurar.IconChar = FontAwesome.Sharp.IconChar.Reply;
            buttonRestaurar.IconColor = Color.FromArgb(242, 242, 242);
            buttonRestaurar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonRestaurar.IconSize = 24;
            buttonRestaurar.ImageAlign = ContentAlignment.MiddleRight;
            buttonRestaurar.Location = new Point(283, 512);
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
            checkBox_VerEliminados.Location = new Point(818, 145);
            checkBox_VerEliminados.Name = "checkBox_VerEliminados";
            checkBox_VerEliminados.Size = new Size(103, 19);
            checkBox_VerEliminados.TabIndex = 8;
            checkBox_VerEliminados.Text = "Ver eliminados";
            checkBox_VerEliminados.UseVisualStyleBackColor = true;
            checkBox_VerEliminados.CheckedChanged += checkBox_VerEliminados_CheckedChanged;
            // 
            // ButtonEliminarAuto
            // 
            ButtonEliminarAuto.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ButtonEliminarAuto.BackColor = Color.FromArgb(242, 242, 242);
            ButtonEliminarAuto.FlatStyle = FlatStyle.Flat;
            ButtonEliminarAuto.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButtonEliminarAuto.ForeColor = Color.FromArgb(28, 28, 27);
            ButtonEliminarAuto.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            ButtonEliminarAuto.IconColor = Color.FromArgb(28, 28, 27);
            ButtonEliminarAuto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonEliminarAuto.IconSize = 24;
            ButtonEliminarAuto.ImageAlign = ContentAlignment.MiddleRight;
            ButtonEliminarAuto.Location = new Point(833, 512);
            ButtonEliminarAuto.Name = "ButtonEliminarAuto";
            ButtonEliminarAuto.Size = new Size(88, 28);
            ButtonEliminarAuto.TabIndex = 7;
            ButtonEliminarAuto.Text = "Eliminar";
            ButtonEliminarAuto.TextAlign = ContentAlignment.MiddleLeft;
            ButtonEliminarAuto.UseVisualStyleBackColor = false;
            ButtonEliminarAuto.Click += ButtonEliminarAuto_Click;
            // 
            // ButtonEditarAuto
            // 
            ButtonEditarAuto.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonEditarAuto.BackColor = Color.FromArgb(28, 28, 27);
            ButtonEditarAuto.FlatStyle = FlatStyle.Flat;
            ButtonEditarAuto.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButtonEditarAuto.ForeColor = Color.FromArgb(242, 242, 242);
            ButtonEditarAuto.IconChar = FontAwesome.Sharp.IconChar.Pencil;
            ButtonEditarAuto.IconColor = Color.FromArgb(242, 242, 242);
            ButtonEditarAuto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonEditarAuto.IconSize = 24;
            ButtonEditarAuto.ImageAlign = ContentAlignment.MiddleRight;
            ButtonEditarAuto.Location = new Point(174, 512);
            ButtonEditarAuto.Name = "ButtonEditarAuto";
            ButtonEditarAuto.Size = new Size(103, 28);
            ButtonEditarAuto.TabIndex = 6;
            ButtonEditarAuto.Text = "Editar";
            ButtonEditarAuto.TextAlign = ContentAlignment.MiddleLeft;
            ButtonEditarAuto.UseVisualStyleBackColor = false;
            ButtonEditarAuto.Click += ButtonEditarAuto_Click;
            // 
            // ButtonAgregarAuto
            // 
            ButtonAgregarAuto.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonAgregarAuto.BackColor = Color.FromArgb(28, 28, 27);
            ButtonAgregarAuto.FlatStyle = FlatStyle.Flat;
            ButtonAgregarAuto.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButtonAgregarAuto.ForeColor = Color.FromArgb(242, 242, 242);
            ButtonAgregarAuto.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            ButtonAgregarAuto.IconColor = Color.FromArgb(242, 242, 242);
            ButtonAgregarAuto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonAgregarAuto.IconSize = 24;
            ButtonAgregarAuto.ImageAlign = ContentAlignment.MiddleRight;
            ButtonAgregarAuto.Location = new Point(65, 512);
            ButtonAgregarAuto.Name = "ButtonAgregarAuto";
            ButtonAgregarAuto.Size = new Size(103, 28);
            ButtonAgregarAuto.TabIndex = 5;
            ButtonAgregarAuto.Text = "Agregar";
            ButtonAgregarAuto.TextAlign = ContentAlignment.MiddleLeft;
            ButtonAgregarAuto.UseVisualStyleBackColor = false;
            ButtonAgregarAuto.Click += ButtonAgregarAuto_Click;
            // 
            // ButtonBuscarAuto
            // 
            ButtonBuscarAuto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonBuscarAuto.BackColor = Color.FromArgb(28, 28, 27);
            ButtonBuscarAuto.FlatStyle = FlatStyle.Popup;
            ButtonBuscarAuto.ForeColor = Color.FromArgb(242, 242, 242);
            ButtonBuscarAuto.IconChar = FontAwesome.Sharp.IconChar.Search;
            ButtonBuscarAuto.IconColor = Color.FromArgb(242, 242, 242);
            ButtonBuscarAuto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonBuscarAuto.IconSize = 20;
            ButtonBuscarAuto.Location = new Point(885, 170);
            ButtonBuscarAuto.Name = "ButtonBuscarAuto";
            ButtonBuscarAuto.Size = new Size(36, 25);
            ButtonBuscarAuto.TabIndex = 4;
            ButtonBuscarAuto.UseVisualStyleBackColor = false;
            ButtonBuscarAuto.Click += ButtonBuscarAuto_Click;
            // 
            // textBoxFiltrarAuto
            // 
            textBoxFiltrarAuto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxFiltrarAuto.Font = new Font("Segoe UI", 10F);
            textBoxFiltrarAuto.ForeColor = Color.FromArgb(28, 28, 27);
            textBoxFiltrarAuto.Location = new Point(65, 170);
            textBoxFiltrarAuto.Name = "textBoxFiltrarAuto";
            textBoxFiltrarAuto.PlaceholderText = "¿Qué estás buscando?...";
            textBoxFiltrarAuto.Size = new Size(820, 25);
            textBoxFiltrarAuto.TabIndex = 3;
            textBoxFiltrarAuto.TextChanged += textBoxFiltrarAuto_TextChanged;
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
            dataGridView.BackgroundColor = Color.FromArgb(242, 242, 242);
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.GridColor = Color.FromArgb(20, 21, 20);
            dataGridView.Location = new Point(65, 201);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(856, 305);
            dataGridView.TabIndex = 2;
            dataGridView.SelectionChanged += dataGridViewAutos_SelectionChanged;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(20, 21, 20);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(ButtonClose);
            panel1.Location = new Point(-4, -7);
            panel1.Name = "panel1";
            panel1.Size = new Size(986, 110);
            panel1.TabIndex = 0;
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
            ButtonClose.Location = new Point(917, 15);
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
            tabPageAgregar_Editar.Controls.Add(pictureBox2);
            tabPageAgregar_Editar.Controls.Add(panel2);
            tabPageAgregar_Editar.Controls.Add(numericPrecioAuto);
            tabPageAgregar_Editar.Controls.Add(numericAnioAuto);
            tabPageAgregar_Editar.Controls.Add(ButtonCancelar);
            tabPageAgregar_Editar.Controls.Add(ButtonGuardar);
            tabPageAgregar_Editar.Controls.Add(checkBoxUsado);
            tabPageAgregar_Editar.Controls.Add(label5);
            tabPageAgregar_Editar.Controls.Add(label4);
            tabPageAgregar_Editar.Controls.Add(textBoxModeloAuto);
            tabPageAgregar_Editar.Controls.Add(label3);
            tabPageAgregar_Editar.Controls.Add(label2);
            tabPageAgregar_Editar.Controls.Add(textBoxMarcaAuto);
            tabPageAgregar_Editar.Controls.Add(label1);
            tabPageAgregar_Editar.Controls.Add(textBoxImagenAuto);
            tabPageAgregar_Editar.Location = new Point(4, 24);
            tabPageAgregar_Editar.Name = "tabPageAgregar_Editar";
            tabPageAgregar_Editar.Padding = new Padding(3);
            tabPageAgregar_Editar.Size = new Size(981, 577);
            tabPageAgregar_Editar.TabIndex = 1;
            tabPageAgregar_Editar.Text = "Agregar o Editar";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(20, 21, 20);
            panel2.Location = new Point(-4, -7);
            panel2.Name = "panel2";
            panel2.Size = new Size(986, 110);
            panel2.TabIndex = 22;
            // 
            // numericPrecioAuto
            // 
            numericPrecioAuto.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            numericPrecioAuto.Font = new Font("Segoe UI", 10F);
            numericPrecioAuto.ForeColor = Color.FromArgb(28, 28, 27);
            numericPrecioAuto.Location = new Point(159, 341);
            numericPrecioAuto.Maximum = new decimal(new int[] { 268435456, 1042612833, 542101086, 0 });
            numericPrecioAuto.Name = "numericPrecioAuto";
            numericPrecioAuto.Size = new Size(291, 25);
            numericPrecioAuto.TabIndex = 21;
            // 
            // numericAnioAuto
            // 
            numericAnioAuto.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            numericAnioAuto.Font = new Font("Segoe UI", 10F);
            numericAnioAuto.ForeColor = Color.FromArgb(28, 28, 27);
            numericAnioAuto.Location = new Point(159, 279);
            numericAnioAuto.Maximum = new decimal(new int[] { 2025, 0, 0, 0 });
            numericAnioAuto.Minimum = new decimal(new int[] { 1886, 0, 0, 0 });
            numericAnioAuto.Name = "numericAnioAuto";
            numericAnioAuto.Size = new Size(291, 25);
            numericAnioAuto.TabIndex = 20;
            numericAnioAuto.Value = new decimal(new int[] { 1886, 0, 0, 0 });
            // 
            // ButtonCancelar
            // 
            ButtonCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonCancelar.BackColor = Color.FromArgb(242, 242, 242);
            ButtonCancelar.FlatStyle = FlatStyle.Flat;
            ButtonCancelar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButtonCancelar.ForeColor = Color.FromArgb(28, 28, 27);
            ButtonCancelar.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            ButtonCancelar.IconColor = Color.FromArgb(28, 28, 27);
            ButtonCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonCancelar.IconSize = 24;
            ButtonCancelar.ImageAlign = ContentAlignment.MiddleRight;
            ButtonCancelar.Location = new Point(357, 413);
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
            ButtonGuardar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonGuardar.BackColor = Color.FromArgb(28, 28, 27);
            ButtonGuardar.FlatStyle = FlatStyle.Flat;
            ButtonGuardar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButtonGuardar.ForeColor = Color.FromArgb(242, 242, 242);
            ButtonGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            ButtonGuardar.IconColor = Color.FromArgb(242, 242, 242);
            ButtonGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonGuardar.IconSize = 24;
            ButtonGuardar.ImageAlign = ContentAlignment.MiddleRight;
            ButtonGuardar.Location = new Point(258, 413);
            ButtonGuardar.Name = "ButtonGuardar";
            ButtonGuardar.Size = new Size(93, 28);
            ButtonGuardar.TabIndex = 18;
            ButtonGuardar.Text = "Guardar";
            ButtonGuardar.TextAlign = ContentAlignment.MiddleLeft;
            ButtonGuardar.UseVisualStyleBackColor = false;
            ButtonGuardar.Click += ButtonGuardar_Click;
            // 
            // checkBoxUsado
            // 
            checkBoxUsado.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            checkBoxUsado.AutoSize = true;
            checkBoxUsado.Font = new Font("Orbitron SemiBold", 13F, FontStyle.Bold | FontStyle.Italic);
            checkBoxUsado.ForeColor = Color.FromArgb(20, 21, 20);
            checkBoxUsado.Location = new Point(159, 372);
            checkBoxUsado.Name = "checkBoxUsado";
            checkBoxUsado.Size = new Size(147, 26);
            checkBoxUsado.TabIndex = 15;
            checkBoxUsado.Text = "¿Es Usado?";
            checkBoxUsado.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Font = new Font("Orbitron SemiBold", 13F, FontStyle.Bold | FontStyle.Italic);
            label5.ForeColor = Color.FromArgb(20, 21, 20);
            label5.Location = new Point(80, 344);
            label5.Name = "label5";
            label5.Size = new Size(74, 22);
            label5.TabIndex = 13;
            label5.Text = "Precio";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Font = new Font("Orbitron SemiBold", 13F, FontStyle.Bold | FontStyle.Italic);
            label4.ForeColor = Color.FromArgb(20, 21, 20);
            label4.Location = new Point(73, 313);
            label4.Name = "label4";
            label4.Size = new Size(81, 22);
            label4.TabIndex = 11;
            label4.Text = "Modelo";
            // 
            // textBoxModeloAuto
            // 
            textBoxModeloAuto.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            textBoxModeloAuto.Font = new Font("Segoe UI", 10F);
            textBoxModeloAuto.ForeColor = Color.FromArgb(28, 28, 27);
            textBoxModeloAuto.Location = new Point(159, 310);
            textBoxModeloAuto.Name = "textBoxModeloAuto";
            textBoxModeloAuto.PlaceholderText = " Ingrese el MODELO del auto...";
            textBoxModeloAuto.Size = new Size(291, 25);
            textBoxModeloAuto.TabIndex = 10;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Orbitron SemiBold", 13F, FontStyle.Bold | FontStyle.Italic);
            label3.ForeColor = Color.FromArgb(20, 21, 20);
            label3.Location = new Point(103, 282);
            label3.Name = "label3";
            label3.Size = new Size(50, 22);
            label3.TabIndex = 9;
            label3.Text = "Año";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Orbitron SemiBold", 13F, FontStyle.Bold | FontStyle.Italic);
            label2.ForeColor = Color.FromArgb(20, 21, 20);
            label2.Location = new Point(80, 251);
            label2.Name = "label2";
            label2.Size = new Size(73, 22);
            label2.TabIndex = 7;
            label2.Text = "Marca";
            // 
            // textBoxMarcaAuto
            // 
            textBoxMarcaAuto.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            textBoxMarcaAuto.Font = new Font("Segoe UI", 10F);
            textBoxMarcaAuto.ForeColor = Color.FromArgb(28, 28, 27);
            textBoxMarcaAuto.Location = new Point(159, 248);
            textBoxMarcaAuto.Name = "textBoxMarcaAuto";
            textBoxMarcaAuto.PlaceholderText = " Ingrese la MARCA del auto...";
            textBoxMarcaAuto.Size = new Size(291, 25);
            textBoxMarcaAuto.TabIndex = 6;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Orbitron SemiBold", 13F, FontStyle.Bold | FontStyle.Italic);
            label1.ForeColor = Color.FromArgb(20, 21, 20);
            label1.Location = new Point(72, 220);
            label1.Name = "label1";
            label1.Size = new Size(81, 22);
            label1.TabIndex = 5;
            label1.Text = "Imagen";
            // 
            // textBoxImagenAuto
            // 
            textBoxImagenAuto.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            textBoxImagenAuto.BackColor = Color.FromArgb(242, 242, 242);
            textBoxImagenAuto.Font = new Font("Segoe UI", 10F);
            textBoxImagenAuto.ForeColor = Color.FromArgb(28, 28, 27);
            textBoxImagenAuto.Location = new Point(159, 217);
            textBoxImagenAuto.Name = "textBoxImagenAuto";
            textBoxImagenAuto.PlaceholderText = " Ingrese la IMAGEN del auto...";
            textBoxImagenAuto.Size = new Size(291, 25);
            textBoxImagenAuto.TabIndex = 4;
            textBoxImagenAuto.TextChanged += textBoxImagenAuto_TextChanged;
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
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(40, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(105, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(654, 175);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(275, 266);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 23;
            pictureBox2.TabStop = false;
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
            tabPageAgregar_Editar.ResumeLayout(false);
            tabPageAgregar_Editar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericPrecioAuto).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericAnioAuto).EndInit();
            contextMenuStripLimpiar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabPageLista;
        private TabPage tabPageAgregar_Editar;
        private Panel panel1;
        private PictureBox pictureBoxAuto;
        private FontAwesome.Sharp.IconButton ButtonBuscarAuto;
        private TextBox textBoxFiltrarAuto;
        private DataGridView dataGridView;
        private FontAwesome.Sharp.IconButton ButtonAgregarAuto;
        private FontAwesome.Sharp.IconButton ButtonEliminarAuto;
        private FontAwesome.Sharp.IconButton ButtonEditarAuto;
        private ContextMenuStrip contextMenuStripLimpiar;
        private ToolStripMenuItem limpiarToolStripMenuItem;
        private Label label2;
        private TextBox textBoxMarcaAuto;
        private Label label1;
        private TextBox textBoxImagenAuto;
        private Label label3;
        private Label label4;
        private TextBox textBoxModeloAuto;
        private Label label5;
        private CheckBox checkBoxUsado;
        private FontAwesome.Sharp.IconButton ButtonCancelar;
        private FontAwesome.Sharp.IconButton ButtonGuardar;
        private NumericUpDown numericAnioAuto;
        private NumericUpDown numericPrecioAuto;
        private Panel panel2;
        private FontAwesome.Sharp.IconButton ButtonClose;
        private CheckBox checkBox_VerEliminados;
        private FontAwesome.Sharp.IconButton buttonRestaurar;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}