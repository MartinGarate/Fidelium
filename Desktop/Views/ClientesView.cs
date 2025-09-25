using Service.Enums;
using Service.Models;
using Service.Services;
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
using System.Windows.Controls;
using System.Windows.Forms;

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
            ConfigurarControlesIniciales();
            CargarDatosIniciales();
        }

        private void ConfigurarControlesIniciales()
        {
            textBoxBuscar.ContextMenuStrip = contextMenuStripLimpiar;
            buttonRestaurar.Visible = false;
            
            // Configurar el ComboBox de TipoUsuario
            comboBoxTipoUsuario.DataSource = Enum.GetValues(typeof(TipoUsuarioEnum));
            comboBoxTipoUsuario.SelectedIndex = -1;
        }

        private async void CargarDatosIniciales()
        {
            try
            {
                Cursor = Cursors.WaitCursor; // Cambia el cursor a "espera" mientras se cargan los datos 
                await GetAllData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos iniciales: {ex.Message}", 
                               "Error", 
                               MessageBoxButtons.OK, 
                               MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
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
        }

        private async Task GetAllData()
        {
            dataGridView.Enabled = false; // Deshabilita el DataGridView mientras se cargan los datos
            try
            {
                if (checkBox_VerEliminados.Checked)
                    _clientes = await _clienteService.GetAllDeletedsAsync() ?? new List<Cliente>(); // Obtener todos los clientes, incluidos los eliminados
                else
                    _clientes = await _clienteService.GetAllAsync() ?? new List<Cliente>(); // Obtener solo los clientes activos

                _usuarios = await _usuarioService.GetAllAsync() ?? new List<Usuario>(); // Obtener todos los usuarios

                if (_clientes == null || _usuarios == null)
                {
                    throw new Exception("No se pudieron cargar los datos del servidor"); // Manejo de error si la lista es null
                }

                ActualizarGridView();
            }
            catch (Exception)
            {
                throw; // Re-lanzar la excepción para que sea manejada en el método llamante
            }
            finally
            {
                dataGridView.Enabled = true; // Asegúrate de que el DataGridView esté habilitado después de la carga
            }
        }

        private void ActualizarGridView()
        {
            // Asocia el usuario correspondiente a cada cliente
            foreach (var cliente in _clientes)
            {
                cliente.Usuario = _usuarios.FirstOrDefault(u => u.ID == cliente.UsuarioID);
            }

            var datosParaGrid = _clientes.Select(c => new
            {
                c.ID,
                DNI = c.Usuario?.DNI?.ToString() ?? "Sin DNI",
                Nombre = c.Usuario?.Nombre ?? "Sin nombre",
                Email = c.Usuario?.Email ?? "Sin email",
                Instagram = c.Instagram ?? "",
                ClienteTelefono = c.Telefono ?? "",
                Eliminado = c.IsDeleted
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

        private void LimpiarCampos()
        {
            textBoxNombre.Clear();
            textBoxEmail.Clear();
            textBoxInstagram.Clear();
            textBoxTelefono.Clear();
            comboBoxTipoUsuario.DataSource = Enum.GetValues(typeof(TipoUsuarioEnum));
            comboBoxTipoUsuario.SelectedIndex = -1; // No seleccionar nada por defecto
            textBoxDNI.Clear();

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
            tabControl.SelectedTab = tabPageLista;
            LimpiarCampos();
        }

        private void ButtonEditar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que haya un cliente seleccionado
                if (dataGridView.RowCount == 0 || dataGridView.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar un cliente para modificarlo",
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                    return;
                }

                // Obtener y validar el ID del cliente
                if (!int.TryParse(dataGridView.SelectedRows[0].Cells["ID"].Value?.ToString(), out int idCliente))
                {
                    MessageBox.Show("Error al obtener el ID del cliente",
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                    return;
                }

                // Buscar el cliente seleccionado
                _currentCliente = _clientes.FirstOrDefault(c => c.ID == idCliente);
                if (_currentCliente == null)
                {
                    MessageBox.Show("No se encontró el cliente seleccionado",
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                    return;
                }

                // Llenar los campos con la información del cliente
                textBoxDNI.Text = _currentCliente.Usuario?.DNI?.ToString() ?? "";
                textBoxNombre.Text = _currentCliente.Usuario?.Nombre ?? "";
                textBoxEmail.Text = _currentCliente.Usuario?.Email ?? "";
                textBoxInstagram.Text = _currentCliente.Instagram ?? "";
                textBoxTelefono.Text = _currentCliente.Telefono ?? "";
                comboBoxTipoUsuario.SelectedItem = _currentCliente.Usuario?.TipoUsuario ?? TipoUsuarioEnum.Usuario;

                // Cambiar a la pestaña de edición
                tabControl.SelectedTab = tabPageAgregar_Editar;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del cliente: {ex.Message}",
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        private async void ButtonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validación de campos obligatorios
                if (string.IsNullOrWhiteSpace(textBoxDNI.Text) ||
                    string.IsNullOrWhiteSpace(textBoxNombre.Text) ||
                    string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
                    comboBoxTipoUsuario.SelectedItem == null)
                {
                    MessageBox.Show("Todos los campos marcados son obligatorios.",
                                  "Validación",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return;
                }

                // 2. Validación del formato de DNI
                if (!int.TryParse(textBoxDNI.Text, out int dniValue))
                {
                    MessageBox.Show("El DNI debe ser un número válido.",
                                  "Validación",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return;
                }

                // 3. Validación de DNI único
                var usuarios = await _usuarioService.GetAllAsync();
                var dniExistente = usuarios?.Any(u =>
                    u.DNI == dniValue &&
                    u.ID != (_currentCliente?.UsuarioID ?? 0)) ?? false;

                if (dniExistente)
                {
                    MessageBox.Show("El DNI ingresado ya existe en el sistema.",
                                  "Validación",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return;
                }

                // 4. Validación del formato de email
                if (!textBoxEmail.Text.Contains("@") || !textBoxEmail.Text.Contains("."))
                {
                    MessageBox.Show("El formato del email no es válido.",
                                  "Validación",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return;
                }

                Cliente clienteAGuardar = new Cliente
                {
                    ID = _currentCliente?.ID ?? 0,
                    UsuarioID = _currentCliente?.UsuarioID ?? 0,
                    Telefono = textBoxTelefono.Text?.Trim(),
                    Instagram = textBoxInstagram.Text?.Trim()
                };

                Usuario usuarioAGuardar = new Usuario
                {
                    ID = _currentCliente?.UsuarioID ?? 0,
                    DNI = dniValue,
                    Nombre = textBoxNombre.Text.Trim(),
                    Email = textBoxEmail.Text.Trim(),
                    TipoUsuario = (TipoUsuarioEnum)comboBoxTipoUsuario.SelectedItem
                };

                bool success = false;

                if (_currentCliente != null)
                {
                    // Actualización
                    if (!await _usuarioService.UpdateAsync(usuarioAGuardar))
                        throw new Exception("Error al actualizar el usuario");

                    if (!await _clienteService.UpdateAsync(clienteAGuardar))
                        throw new Exception("Error al actualizar el cliente");

                    success = true;
                }
                else
                {
                    // Creación
                    var nuevoUsuario = await _usuarioService.AddAsync(usuarioAGuardar);
                    if (nuevoUsuario == null)
                        throw new Exception("Error al crear el usuario");

                    clienteAGuardar.UsuarioID = nuevoUsuario.ID;
                    var nuevoCliente = await _clienteService.AddAsync(clienteAGuardar);
                    if (nuevoCliente == null)
                        throw new Exception("Error al crear el cliente");

                    success = true;
                }

                if (success)
                {
                    MessageBox.Show($"Cliente {usuarioAGuardar.Nombre} guardado correctamente",
                                  "Éxito",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                    await GetAllData();
                    LimpiarCampos();
                    tabControl.SelectedTab = tabPageLista;
                    _currentCliente = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la operación: {ex.Message}",
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        private void textBoxImagenAuto_TextChanged(object sender, EventArgs e)
        {
            // Implementa lógica si lo necesitas
        }

        private void ButtonAgregarAuto_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            tabControl.SelectedTab = tabPageAgregar_Editar;
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

        private async void ButtonBuscar_Click_1(object sender, EventArgs e)
        {
            dataGridView.DataSource = await _clienteService.GetAllAsync(textBoxBuscar.Text);

        }
    }
}