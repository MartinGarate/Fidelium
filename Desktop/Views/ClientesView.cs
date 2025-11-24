using Desktop.Utils.HelpersDesktop;
using Service.Enums;
using Service.Models;
using Service.Services;
using Service.Utils.Helpers;
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
            _ = GetAllData();
        }


        // Métodos principales
        private async Task<bool> GuardarEntidades(Cliente cliente, Usuario usuario)
        {
            // Si estamos editando un cliente existente
            if (_currentCliente != null)
            {
                if (!await _usuarioService.UpdateAsync(usuario))
                    throw new Exception("Error al actualizar el usuario");

                if (!await _clienteService.UpdateAsync(cliente))
                    throw new Exception("Error al actualizar el cliente");
            }
            else // Si estamos creando un nuevo cliente
            {
                // Verificar nuevamente si existe un usuario con el mismo DNI justo antes de crear
                var existingUser = _usuarios.FirstOrDefault(u => u.DNI == usuario.DNI);
                if (existingUser != null)
                    throw new Exception("Ya existe un usuario con este DNI");

                var nuevoUsuario = await _usuarioService.AddAsync(usuario)
                    ?? throw new Exception("Error al crear el usuario");

                cliente.UsuarioID = nuevoUsuario.ID;
                var nuevoCliente = await _clienteService.AddAsync(cliente)
                    ?? throw new Exception("Error al crear el cliente");
            }

            return true;
        }
        private (Cliente cliente, Usuario usuario) CrearEntidades()
        {
            // Método que crea objetos Cliente y Usuario desde los campos del formulario
            // Retorna una    tupla     (dos objetos relacionados en una sola devolución)
            var cliente = new Cliente
            {
                ID = _currentCliente?.ID ?? 0,          // Si hay cliente actual usa su ID, si no 0
                UsuarioID = _currentCliente?.UsuarioID ?? 0, // Lo mismo para UsuarioID
                Telefono = textBoxTelefono.Text?.Trim(),
                Instagram = textBoxInstagram.Text?.Trim()
            };

            var usuario = new Usuario
            {
                ID = _currentCliente?.UsuarioID ?? 0,
                DNI = textBoxDNI.Text,
                Nombre = textBoxNombre.Text.Trim(),
                Email = textBoxEmail.Text.Trim(),
                TipoUsuario = TipoUsuarioEnum.Cliente
            };

            return (cliente, usuario); // Devuelve ambos objetos en una tupla
        }
        private bool ValidarFormulario()
        {
            // Método que valida todos los campos del formulario
            // Usa la clase Validations para reglas de validación reutilizables
            if (!Validations.Strings.HasValue(textBoxDNI.Text) ||
                !Validations.Strings.HasValue(textBoxNombre.Text) ||
                !Validations.Strings.HasValue(textBoxEmail.Text))
            {
                MessageBox.Show("Todos los campos marcados son obligatorios.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Valida formato de DNI usando el helper
            if (!Validations.Numbers.IsValidDNI(textBoxDNI.Text))
            {
                MessageBox.Show("El DNI debe ser un número válido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Valida formato de email usando el helper
            if (!Validations.Strings.IsValidEmail(textBoxEmail.Text))
            {
                MessageBox.Show("El formato del email no es válido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void CargarDatosEnControles(Cliente cliente)
        {
            textBoxDNI.Text = cliente.Usuario?.DNI?.ToString() ?? "";
            textBoxNombre.Text = cliente.Usuario?.Nombre ?? "";
            textBoxEmail.Text = cliente.Usuario?.Email ?? "";
            textBoxInstagram.Text = cliente.Instagram ?? "";
            textBoxTelefono.Text = cliente.Telefono ?? "";
        }
        private void SetControlsEnabled(bool enabled)
        {
            // Lista de controles a deshabilitar durante operaciones
            var controls = new Control[]
            {
                buttonRestaurar,
                ButtonAgregar,
                ButtonBuscar,
                ButtonCancelar,
                ButtonClose,
                ButtonEditar,
                ButtonEliminar,
                ButtonGuardar,
                checkBox_VerEliminados,
                textBoxBuscar,
                textBoxDNI,
                textBoxNombre,
                textBoxEmail,
                textBoxInstagram,
                textBoxTelefono,
                dataGridView // Agregar también el grid
            };

            foreach (var control in controls)
            {
                control.Enabled = enabled;
            }

            // Mostrar cursor de espera
            Cursor = enabled ? Cursors.Default : Cursors.WaitCursor;
        }


        // Poniendo a prueba: Principios de Responsabilidades Únicas (SRP) :D
        private void ConfigurarControlesIniciales()
        {
            textBoxBuscar.ContextMenuStrip = contextMenuStripLimpiar;
            buttonRestaurar.Visible = false;
            DataGridHelpers.SetupBasicGrid(dataGridView);
        }
        private void LimpiarCampos()
        {
            textBoxNombre.Clear();
            textBoxEmail.Clear();
            textBoxInstagram.Clear();
            textBoxTelefono.Clear();
            textBoxDNI.Clear();

        }
        private void ConfigurarDataGridView()
        {
            DataGridHelpers.HideColumns(dataGridView, "ID", "UsuarioID", "IsDeleted");
        }
        private void ActualizarGridView()
        {
            foreach (var cliente in _clientes)
            {
                cliente.Usuario = _usuarios.FirstOrDefault(u => u.ID == cliente.UsuarioID); //Ejemplo: Si Cliente.UsuarioID = 5, busca el Usuario donde Usuario.ID = 5
            }

            var datosParaGrid = _clientes.Select(c => new
            {
                c.ID,                                              // ID del cliente
                DNI = c.Usuario?.DNI?.ToString() ?? "Sin DNI",    // Datos del usuario asociado
                Nombre = c.Usuario?.Nombre ?? "Sin nombre",        // Datos del usuario asociado
                Email = c.Usuario?.Email ?? "Sin email",          // Datos del usuario asociado
                Instagram = c.Instagram ?? "",                     // Datos propios del cliente
                ClienteTelefono = c.Telefono ?? "",               // Datos propios del cliente
                Eliminado = c.IsDeleted
            }).ToList();

            dataGridView.DataSource = null; // Limpia la fuente de datos antes de asignar una nueva
            dataGridView.DataSource = datosParaGrid; // Asigna la nueva fuente de datos
            ConfigurarDataGridView();
        }
        private async Task GetAllData(string? filtro = null)
        {
            try
            {
                SetControlsEnabled(false);

                if (checkBox_VerEliminados.Checked)
                    _clientes = await _clienteService.GetAllDeletedsAsync(filtro) ?? new List<Cliente>();
                else
                    _clientes = await _clienteService.GetAllAsync(filtro) ?? new List<Cliente>();

                _usuarios = await _usuarioService.GetAllAsync() ?? new List<Usuario>();

                if (_clientes == null || _usuarios == null)
                    MessageHelpers.ShowError("No se pudieron cargar los datos del servidor");
                else
                    ActualizarGridView();
            }
            catch (Exception ex)
            {
                MessageHelpers.ShowError($"Error al cargar datos: {ex.Message}");
            }
            finally
            {
                SetControlsEnabled(true);
            }
        }




        // Eventos de los controles
        private void ButtonAgregar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            _currentCliente = null; //
            tabControl.SelectedTab = tabPageAgregar_Editar;
            labelAccion.Text = "Agregar Cliente";
        }
        private async void ButtonEditar_Click(object sender, EventArgs e)
        {
        //    try
        //    {
        //        // Deshabilitar controles mientras carga
        //        SetControlsEnabled(false);

        //        if (!DataGridHelpers.TryGetSelectedId(dataGridView, "ID", out int idCliente))
        //        {
        //            MessageHelpers.ShowError("Debe seleccionar un cliente");
        //            return;
        //        }

        //        _currentCliente = _clientes.FirstOrDefault(c => c.ID == idCliente);
        //        if (_currentCliente == null)
        //        {
        //            MessageHelpers.ShowError("Cliente no encontrado");
        //            return;
        //        }

        //        // Cargar datos en los controles
        //        CargarDatosEnControles(_currentCliente);

        //        tabControl.SelectedTab = tabPageAgregar_Editar;
        //        labelAccion.Text = "Editar Cliente";
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageHelpers.ShowError($"Error: {ex.Message}");
        //    }
        //    finally
        //    {
        //        // Rehabilitar controles
        //        SetControlsEnabled(true);
        //    }
        }
        private async void ButtonEliminar_Click(object sender, EventArgs e)
        {
        //    if (!DataGridHelpers.TryGetSelectedId(dataGridView, "ID", out int idCliente))
        //    {
        //        MessageHelpers.ShowError("Debe seleccionar un cliente");
        //        return;
        //    }

        //    var cliente = _clientes.FirstOrDefault(c => c.ID == idCliente);
        //    if (cliente == null)
        //    {
        //        MessageHelpers.ShowError("Cliente no encontrado");
        //        return;
        //    }

        //    if (await CrudHelpers.DeleteEntity(_clienteService, cliente.ID, cliente.Usuario?.Nombre ?? "Cliente"))
        //    {
        //        await GetAllData();
        //    }
        }

        private async void buttonRestaurar_Click(object sender, EventArgs e)
        {
        //    if (!DataGridHelpers.TryGetSelectedId(dataGridView, "ID", out int idCliente))
        //    {
        //        MessageHelpers.ShowError("Debe seleccionar un cliente");
        //        return;
        //    }

        //    var cliente = _clientes.FirstOrDefault(c => c.ID == idCliente);
        //    if (cliente == null)
        //    {
        //        MessageHelpers.ShowError("Cliente no encontrado");
        //        return;
        //    }

        //    if (await CrudHelpers.RestoreEntity(_clienteService, cliente.ID, cliente.Usuario?.Nombre ?? "Cliente"))
        //    {
        //        textBoxBuscar.Clear(); // Limpiar el texto de búsqueda
        //        await GetAllData(); // Recargar todos los datos
        //    }
        }
        private async void ButtonBuscar_Click(object sender, EventArgs e)
        {
            await GetAllData(textBoxBuscar.Text);
        }

        private async void ButtonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                SetControlsEnabled(false);

                if (!ValidarFormulario()) return;

                // Validar DNI único antes de guardar
                var validacionDni = await Validations.Users.ValidarDNIUnico(
                    dni: textBoxDNI.Text,
                    existingUsers: _usuarios,
                    getDNI: u => u.DNI,
                    currentUserId: _currentCliente?.UsuarioID,
                    getUserId: u => u.ID);

                if (!validacionDni.IsValid)
                {
                    MessageHelpers.ShowError(validacionDni.ErrorMessage ?? "DNI duplicado");
                    return;
                }

                var (cliente, usuario) = CrearEntidades();
                if (await GuardarEntidades(cliente, usuario))
                {
                    MessageHelpers.ShowSuccess($"Cliente {usuario.Nombre} guardado correctamente");
                    await GetAllData();
                    LimpiarCampos();
                    tabControl.SelectedTab = tabPageLista;
                    _currentCliente = null;
                }
            }
            catch (Exception ex)
            {
                MessageHelpers.ShowError($"Error: {ex.Message}");
            }
            finally
            {
                SetControlsEnabled(true);
            }
        }
        private void ButtonCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPageLista;
            LimpiarCampos();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void limpiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        private async void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxBuscar.Text))
            {
                await GetAllData(); // Recargar todos los datos cuando se limpia el texto
            }
        }
        private async void checkBox_VerEliminados_CheckedChanged(object sender, EventArgs e)
        {
            await GetAllData();
            buttonRestaurar.Visible = checkBox_VerEliminados.Checked;
        }
    }
}