using Desktop.Utils.HelpersDesktop;
using Service.Enums;
using Service.Models;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Desktop.Views
{
    public partial class UsuariosView : Form
    {
        readonly GenericService<Usuario> _usuarioService = new(); // Readonly es una practica mas segura para no romper nada, evitando cambiarlo.
        readonly GenericService<Cliente> _clienteService = new(); // no esta en memoria

        List<Cliente> _clientes = new(); 
        List<Usuario> _usuarios = new();// Si esta En memoria

        Cliente? _currentCliente;
        Usuario? _currentUsuario;


        public UsuariosView()
        {
            InitializeComponent();
        }

        private async void UsuariosView_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
            comboBoxTipoUsuario.DataSource = Enum.GetValues(typeof(TipoUsuarioEnum));
        }


        private async Task<(List<Cliente> clientes, List<Usuario> usuarios)> ObtenerDatosAsync(string? filtro = null)
        {
            if (checkBoxEliminados.Checked)
            {
                return (
                    await _clienteService.GetAllDeletedsAsync(filtro) ?? new List<Cliente>(),
                    await _usuarioService.GetAllDeletedsAsync(filtro) ?? new List<Usuario>()
                );
            }

            return (
                await _clienteService.GetAllAsync(filtro) ?? new List<Cliente>(),
                await _usuarioService.GetAllAsync(filtro) ?? new List<Usuario>()
            );
        }
        private void AsociarUsuariosAClientes(List<Cliente> clientes, List<Usuario> usuarios)
        {
            foreach (var cliente in clientes)
            {
                cliente.Usuario = usuarios.FirstOrDefault(u => u.ID == cliente.UsuarioID);
            }
        }
        private object TransformarDatosParaGrid(List<Cliente> clientes, List<Usuario> usuarios)
        {
            var listaFinal = new List<object>();

            // Agregar clientes con su usuario 
            foreach (var c in clientes)
            {
                listaFinal.Add(new
                {
                    c.ID,
                    DNI = c.Usuario?.DNI ?? "N/A",
                    Nombre = c.Usuario.Nombre,
                    Email = c.Usuario?.Email ?? "N/A",
                    Instagram = c.Instagram ?? "N/A",
                    ClienteTelefono = c.Telefono ?? "N/A",
                    Tipo = "Cliente"
                });
            }

            // Agregar usuarios sin cliente 
            foreach (var u in usuarios)
            {
                bool tieneCliente = clientes.Any(c => c.UsuarioID == u.ID);

                if (!tieneCliente)
                {
                    listaFinal.Add(new
                    {
                        u.ID,
                        DNI = u.DNI ?? "N/A",
                        Nombre = u.Nombre,
                        Email = u.Email,
                        Instagram = "N/A",
                        ClienteTelefono = "N/A",
                        Tipo = u.TipoUsuario.ToString()
                    });
                }
            }

            return listaFinal;
        }
        private void UpdateGrid(object datos)
        {
            dataGridViewUsuarios.DataSource = null;
            dataGridViewUsuarios.DataSource = datos;
            DataGridHelpers.HideColumns(dataGridViewUsuarios, "ID");
            DataGridHelpers.RenameColumn(dataGridViewUsuarios, "ClienteTelefono", "Teléfono");
            DataGridHelpers.SetupBasicGrid(dataGridViewUsuarios);
        }
        private async Task LoadDataAsync(string? filtro = null)
        {
            try
            {
                // Obtener TODOS los datos sin filtro del backend
                var (clientes, usuarios) = await ObtenerDatosAsync();

                _clientes = clientes;
                _usuarios = usuarios;

                AsociarUsuariosAClientes(clientes, usuarios);

                // Aplicar filtro EN MEMORIA después de obtener los datos
                if (!string.IsNullOrEmpty(filtro))
                {
                    clientes = clientes.Where(c =>
                        (c.Usuario?.Nombre?.Contains(filtro, StringComparison.OrdinalIgnoreCase) ?? false) ||
                        (c.Usuario?.DNI?.Contains(filtro, StringComparison.OrdinalIgnoreCase) ?? false) ||
                        (c.Usuario?.Email?.Contains(filtro, StringComparison.OrdinalIgnoreCase) ?? false)
                    ).ToList();

                    usuarios = usuarios.Where(u =>
                        (u.Nombre?.Contains(filtro, StringComparison.OrdinalIgnoreCase) ?? false) ||
                        (u.DNI?.Contains(filtro, StringComparison.OrdinalIgnoreCase) ?? false) ||
                        (u.Email?.Contains(filtro, StringComparison.OrdinalIgnoreCase) ?? false)
                    ).ToList();
                }

                var datosParaGrid = TransformarDatosParaGrid(clientes, usuarios);

                UpdateGrid(datosParaGrid);
            }
            catch (Exception ex)
            {
                MessageHelpers.ShowError($"Error al cargar datos: {ex.Message}");
            }
        }

        private void CargarDatosEnControles(Usuario usuario, Cliente? cliente = null)
        {
            // Datos comunes del usuario
            textBoxNombre.Text = usuario.Nombre ?? "";
            textBoxDNI.Text = usuario.DNI ?? "";
            textBoxEmail.Text = usuario.Email ?? "";

            // Tipo de usuario (Enum) en el comboBox
            comboBoxTipoUsuario.SelectedItem = usuario.TipoUsuario;

            // Mostrar/ocultar campos según si es cliente
            bool esCliente = usuario.TipoUsuario == TipoUsuarioEnum.Cliente;

            lblInstagram.Visible = esCliente;
            lblTelefono.Visible = esCliente;
            textBoxTelefono.Visible = esCliente;
            textBoxInstagram.Visible = esCliente;

            if (cliente != null)
            {
                textBoxTelefono.Text = cliente.Telefono ?? "";
                textBoxInstagram.Text = cliente.Instagram ?? "";
            }
            else
            {
                textBoxTelefono.Text = "";
                textBoxInstagram.Text = "";
            }
        }
        private void LimpiarControles()
        {
            _currentUsuario = null;
            _currentCliente = null;

            textBoxNombre.Text = "";
            textBoxDNI.Text = "";
            textBoxEmail.Text = "";
            textBoxTelefono.Text = "";
            textBoxInstagram.Text = "";
            comboBoxTipoUsuario.SelectedIndex = -1;
        }


        // TabPage Lista
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            labelAccion.Text = "Incorporá a alguien más a la plataforma";
            tabControl.SelectedTab = AgregarEditar_TabPage;

        }
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            // 1. Validar selección
            if (dataGridViewUsuarios.RowCount == 0 || dataGridViewUsuarios.SelectedRows.Count == 0)
            {
                MessageHelpers.ShowError("Debe seleccionar un campo.");
                return;
            }

            // 2. Obtener la fila seleccionada
            DataGridViewRow fila = dataGridViewUsuarios.SelectedRows[0];

            // 3. Obtener el ID
            if (!int.TryParse(fila.Cells["ID"].Value?.ToString(), out int idSeleccionado))
            {
                MessageHelpers.ShowError("No se pudo obtener el ID del registro seleccionado.");
                return;
            }

            // 4. Saber si es Cliente o Usuario
            string tipo = fila.Cells["Tipo"].Value.ToString();

            Usuario usuarioSeleccionado = null;
            Cliente? clienteSeleccionado = null;

            if (tipo == "Cliente")
            {
                // Buscar cliente
                clienteSeleccionado = _clientes.FirstOrDefault(c => c.ID == idSeleccionado);
                if (clienteSeleccionado == null)
                {
                    MessageHelpers.ShowError("Cliente no encontrado.");
                    return;
                }

                usuarioSeleccionado = clienteSeleccionado.Usuario!;
                _currentCliente = clienteSeleccionado;
                _currentUsuario = usuarioSeleccionado;

                labelAccion.Text = "Modificá la información de alguien en la plataforma";
            }
            else
            {
                // Buscar usuario
                usuarioSeleccionado = _usuarios.FirstOrDefault(u => u.ID == idSeleccionado);
                if (usuarioSeleccionado == null)
                {
                    MessageHelpers.ShowError("Usuario no encontrado.");
                    return;
                }

                _currentUsuario = usuarioSeleccionado;
                _currentCliente = null;

                labelAccion.Text = "Modificá la información de alguien en la plataforma";
            }

            // 5. Cargar datos en los controles (usa siempre la misma función)
            CargarDatosEnControles(usuarioSeleccionado, clienteSeleccionado);

            // 6. Cambiar de pestaña
            tabControl.SelectedTab = AgregarEditar_TabPage;
        }
        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.RowCount == 0 || dataGridViewUsuarios.SelectedRows.Count == 0)
            {
                MessageHelpers.ShowError("Debe seleccionar un registro.");
                return;
            }

            DataGridViewRow fila = dataGridViewUsuarios.SelectedRows[0];

            if (!int.TryParse(fila.Cells["ID"].Value?.ToString(), out int idSeleccionado))
            {
                MessageHelpers.ShowError("No se pudo obtener el ID del registro seleccionado.");
                return;
            }

            string tipo = fila.Cells["Tipo"].Value.ToString();

            bool confirmado = MessageBox.Show(
                $"¿Está seguro que desea eliminar este {tipo}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes;

            if (!confirmado)
                return;

            try
            {
                if (tipo == "Cliente")
                {
                    var cliente = _clientes.FirstOrDefault(c => c.ID == idSeleccionado);
                    if (cliente == null)
                    {
                        MessageHelpers.ShowError("Cliente no encontrado.");
                        return;
                    }

                    // Soft delete
                    await _clienteService.DeleteAsync(cliente.ID);

                    MessageHelpers.ShowSuccess($"Cliente {cliente.Usuario?.Nombre ?? ""} eliminado correctamente.");
                }
                else
                {
                    var usuario = _usuarios.FirstOrDefault(u => u.ID == idSeleccionado);
                    if (usuario == null)
                    {
                        MessageHelpers.ShowError("Usuario no encontrado.");
                        return;
                    }

                    // Soft delete
                    await _usuarioService.DeleteAsync(usuario.ID);

                    MessageHelpers.ShowSuccess($"Usuario {usuario.Nombre} eliminado correctamente.");
                }

                // Refrescar grilla
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageHelpers.ShowError($"Error al eliminar: {ex.Message}");
            }
        }
        private void checkBoxEliminados_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEliminados.Checked)
            {
                LoadDataAsync();
                BtnRestaurar.Visible = true;
            }
            if (!checkBoxEliminados.Checked)
            {
                LoadDataAsync();
                BtnRestaurar.Visible = false;
            }
        }
        private async void BtnRestaurar_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.RowCount == 0 || dataGridViewUsuarios.SelectedRows.Count == 0)
            {
                MessageHelpers.ShowError("Debe seleccionar un registro para restaurar.");
                return;
            }

            DataGridViewRow fila = dataGridViewUsuarios.SelectedRows[0];

            if (!int.TryParse(fila.Cells["ID"].Value?.ToString(), out int idSeleccionado))
            {
                MessageHelpers.ShowError("No se pudo obtener el ID del registro seleccionado.");
                return;
            }

            string tipo = fila.Cells["Tipo"].Value.ToString();

            bool confirmado = MessageBox.Show(
                $"¿Está seguro que desea restaurar este {tipo}?",
                "Confirmar restauración",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;

            if (!confirmado)
                return;

            try
            {
                if (tipo == "Cliente")
                {
                    var cliente = _clientes.FirstOrDefault(c => c.ID == idSeleccionado);
                    if (cliente == null)
                    {
                        MessageHelpers.ShowError("Cliente no encontrado.");
                        return;
                    }

                    // Restaurar soft delete
                    await _clienteService.RestoreAsync(cliente.ID);

                    MessageHelpers.ShowSuccess($"Cliente {cliente.Usuario?.Nombre ?? ""} restaurado correctamente.");
                }
                else
                {
                    var usuario = _usuarios.FirstOrDefault(u => u.ID == idSeleccionado);
                    if (usuario == null)
                    {
                        MessageHelpers.ShowError("Usuario no encontrado.");
                        return;
                    }

                    // Restaurar soft delete
                    await _usuarioService.RestoreAsync(usuario.ID);

                    MessageHelpers.ShowSuccess($"Usuario {usuario.Nombre} restaurado correctamente.");
                }

                // Refrescar grilla y limpiar búsqueda
                textBoxBuscar.Clear(); // si tenés un textbox de búsqueda
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageHelpers.ShowError($"Error al restaurar: {ex.Message}");
            }
        }
        private async void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string filtro = textBoxBuscar.Text.Trim();
                // Cargar datos con filtro
                await LoadDataAsync(filtro);
                if (dataGridViewUsuarios.RowCount == 0)
                {
                    MessageHelpers.ShowWarning("No se encontraron resultados para la búsqueda.");
                }
            }
            catch (Exception ex)
            {
                MessageHelpers.ShowError($"Error en la búsqueda: {ex.Message}");
            }
        }
        private async void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxBuscar.Text))
            {
                // Si el cuadro de búsqueda está vacío, recargar todos los datos
                await LoadDataAsync();
            }
        }


        // TabPage Agregar/Editar
        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1️⃣ Validar formulario
                if (string.IsNullOrWhiteSpace(textBoxNombre.Text) ||
                    string.IsNullOrWhiteSpace(comboBoxTipoUsuario.Text))
                {
                    MessageHelpers.ShowError("Nombre y Tipo de Usuario son obligatorios");
                    return;
                }

                //btener tipo de usuario
                Enum.TryParse(comboBoxTipoUsuario.SelectedItem?.ToString(), out TipoUsuarioEnum tipoUsuario);

                //Determinar si es nuevo o existente
                bool esNuevo = _currentUsuario == null || _currentUsuario.ID == 0;

                Usuario usuario = esNuevo ? new Usuario() : _currentUsuario; // Usar el existente si no es nuevo

                //Asignar valores comunes
                usuario.Nombre = textBoxNombre.Text;
                usuario.DNI = textBoxDNI.Text;
                usuario.Email = textBoxEmail.Text;
                usuario.TipoUsuario = tipoUsuario;

                // Guardar usuario
                if (esNuevo)
                {
                    await _usuarioService.AddAsync(usuario);
                }
                else
                {
                    await _usuarioService.UpdateAsync(usuario);
                }

                // Manejar cliente si aplica
                if (tipoUsuario == TipoUsuarioEnum.Cliente)
                {
                    Cliente cliente = esNuevo
                        ? new Cliente { UsuarioID = usuario.ID }
                        : _currentCliente ?? new Cliente { UsuarioID = usuario.ID };

                    cliente.Telefono = textBoxTelefono.Text;
                    cliente.Instagram = textBoxInstagram.Text;

                    if (esNuevo || _currentCliente == null)
                        await _clienteService.AddAsync(cliente);
                    else
                        await _clienteService.UpdateAsync(cliente);
                }

                // Refrescar UI
                await LoadDataAsync();
                LimpiarControles();

                MessageHelpers.ShowSuccess(esNuevo ? "Usuario agregado correctamente" : "Usuario actualizado correctamente");
                tabControl.SelectedTab = Lista_TabPage;
            }
            catch (Exception ex)
            {
                MessageHelpers.ShowError($"Error al guardar: {ex.Message}");
            }
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = Lista_TabPage;
            LimpiarControles();
        }
        private void comboBoxTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipoUsuario.SelectedItem is TipoUsuarioEnum tipo)
            {
                bool esCliente = tipo == TipoUsuarioEnum.Cliente;
                lblInstagram.Visible = esCliente;
                lblTelefono.Visible = esCliente;
                textBoxTelefono.Visible = esCliente;
                textBoxInstagram.Visible = esCliente;
            }
        }


    }
}
