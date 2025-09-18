using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Models;
using Service.Services;

namespace Desktop.Views
{
    public partial class ClientesView : Form
    {
        GenericService<Cliente> _clienteService = new GenericService<Cliente>();
        GenericService<Usuario> _usuarioService = new GenericService<Usuario>();
        Cliente _currentCliente; // Cliente seleccionado
        List<Cliente> _clientes; // Lista de clientes obtenida de la API
        List<Usuario> _usuarios; // Lista de usuarios obtenida de la API

        public ClientesView()
        {
            InitializeComponent();
            _ = GetAllData();
            textBoxFiltrarAuto.ContextMenuStrip = contextMenuStripLimpiar;
            buttonRestaurar.Visible = false;
        }

        private void ConfigurarDataGridView()
        {
            // Oculta las columnas que no quieres mostrar
            if (dataGridView.Columns.Contains("ID"))
                dataGridView.Columns["ID"].Visible = false;
            if (dataGridView.Columns.Contains("UsuarioID"))
                dataGridView.Columns["UsuarioID"].Visible = false;
            if (dataGridView.Columns.Contains("IsDeleted"))
                dataGridView.Columns["IsDeleted"].Visible = false;

            // Puedes ocultar más columnas si lo necesitas
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private async Task GetAllData()
        {
            if (checkBox_VerEliminados.Checked)
                _clientes = await _clienteService.GetAllDeletedsAsync() ?? new List<Cliente>();
            else
                _clientes = await _clienteService.GetAllAsync() ?? new List<Cliente>();

            _usuarios = await _usuarioService.GetAllAsync() ?? new List<Usuario>();

            // Asocia el usuario correspondiente a cada cliente
            foreach (var cliente in _clientes)
                cliente.Usuario = _usuarios.FirstOrDefault(u => u.ID == cliente.UsuarioID);

            // Proyecta los datos para mostrar en el DataGridView
            var datosParaGrid = _clientes.Select(c => new
            {
                c.ID,
                Nombre = c.Usuario?.Nombre,
                Email = c.Usuario?.Email,
                Instagram = c.Instagram,
                ClienteTelefono = c.Telefono,
                Eliminado = c.IsDeleted
            }).ToList();
            // Proyecta los datos para mostrar en el DataGridView desde la lista de usuarios
            var datosUsuariosParaGrid = _usuarios.Select(u => new
            {
                u.ID,
                Nombre = u.Nombre,
                Email = u.Email,
                TipoUsuario = u.TipoUsuario,
                Eliminado = u.IsDeleted,
                // Busca el cliente relacionado (puede ser null si no existe)
                ClienteTelefono = _clientes.FirstOrDefault(c => c.UsuarioID == u.ID)?.Telefono,
                ClienteInstagram = _clientes.FirstOrDefault(c => c.UsuarioID == u.ID)?.Instagram
            }).ToList();


            dataGridView.DataSource = null;
            dataGridView.DataSource = datosParaGrid;
            ConfigurarDataGridView();
        }

        private async void ButtonEliminarAuto_Click(object sender, EventArgs e)
        {
            if (dataGridView.RowCount > 0 && dataGridView.SelectedRows.Count > 0)
            {
                int idCliente = (int)dataGridView.SelectedRows[0].Cells["ID"].Value;
                Cliente clienteSeleccionado = _clientes.First(c => c.ID == idCliente);
                var respuesta = MessageBox.Show($"¿Seguro que quieres borrar a {clienteSeleccionado.Usuario?.Nombre}?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    if (await _clienteService.DeleteAsync(clienteSeleccionado.ID))
                    {
                        MessageBox.Show($"{clienteSeleccionado.Usuario?.Nombre} ha sido borrado correctamente", "Borrado correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await GetAllData();
                    }
                    else
                    {
                        MessageBox.Show("Error al borrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe de seleccionar un campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewAutos_SelectionChanged(object sender, EventArgs e)
        {
            // Puedes implementar lógica de selección si lo necesitas
        }

        private void ButtonBuscarAuto_Click(object sender, EventArgs e)
        {
            // Implementa lógica de búsqueda si lo necesitas
        }

        private void LimpiarCampos()
        {
            textBoxFiltrarAuto.Clear();
            dataGridView.ClearSelection();
            textBoxImagenAuto.Clear();
            textBoxMarcaAuto.Clear();
            numericAnioAuto.Value = numericAnioAuto.Minimum;
            textBoxModeloAuto.Clear();
            numericPrecioAuto.Value = numericPrecioAuto.Minimum;
            checkBoxUsado.Checked = false;
        }

        public void limpiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void textBoxFiltrarAuto_TextChanged(object sender, EventArgs e)
        {
            // Implementa lógica si lo necesitas
        }

        private void ButtonCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab("tabPageLista");
            LimpiarCampos();
        }

        private void ButtonEditarAuto_Click(object sender, EventArgs e)
        {
            // Implementa lógica de edición si lo necesitas
        }

        private async void ButtonGuardar_Click(object sender, EventArgs e)
        {
            // Implementa lógica de guardado si lo necesitas
        }

        private void textBoxImagenAuto_TextChanged(object sender, EventArgs e)
        {
            // Implementa lógica si lo necesitas
        }

        private void ButtonAgregarAuto_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab("tabPageAgregar_Editar");
            LimpiarCampos();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void checkBox_VerEliminados_CheckedChanged(object sender, EventArgs e)
        {
            await GetAllData();
            buttonRestaurar.Visible = checkBox_VerEliminados.Checked;
        }

        private async void buttonRestaurar_Click(object sender, EventArgs e)
        {
            if (!checkBox_VerEliminados.Checked)
            {
                MessageBox.Show("Debe de estar seleccionado 'Ver eliminados' para restaurar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dataGridView.RowCount > 0 && dataGridView.SelectedRows.Count > 0)
            {
                int idCliente = (int)dataGridView.SelectedRows[0].Cells["ID"].Value;
                Cliente clienteSeleccionado = _clientes.First(c => c.ID == idCliente);
                var respuesta = MessageBox.Show($"¿Seguro que quieres restaurar a {clienteSeleccionado.Usuario?.Nombre}?", "Restaurar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    if (await _clienteService.RestoreAsync(clienteSeleccionado.ID))
                    {
                        MessageBox.Show($"{clienteSeleccionado.Usuario?.Nombre} ha sido restaurado correctamente", "Restaurado correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await GetAllData();
                    }
                    else
                    {
                        MessageBox.Show("Error al restaurar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe de seleccionar un campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}