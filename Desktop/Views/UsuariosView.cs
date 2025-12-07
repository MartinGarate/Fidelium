using Desktop.Utils.HelpersDesktop;
using Service.Enums;
using Service.Models;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class UsuariosView : Form
    {
        // Servicios
        readonly GenericService<Usuario> _usuarioService = new();
        readonly GenericService<Cliente> _clienteService = new();

        // Universo de datos en RAM (Cache local estilo profesor)
        List<Cliente> _clientesCache = new();
        List<Usuario> _usuariosCache = new();

        // Objetos actuales para edición (referencias directas)
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

        //CARGA Y ASOCIACIÓN (API -> RAM)

        private async Task LoadDataAsync()
        {
            try
            {
                // Carga masiva inicial
                if (checkBoxEliminados.Checked)
                {
                    _clientesCache = await _clienteService.GetAllDeletedsAsync("") ?? new List<Cliente>();
                    _usuariosCache = await _usuarioService.GetAllDeletedsAsync("") ?? new List<Usuario>();
                }
                else
                {
                    _clientesCache = await _clienteService.GetAllAsync("") ?? new List<Cliente>();
                    _usuariosCache = await _usuarioService.GetAllAsync("") ?? new List<Usuario>();
                }

                // Asociación lógica (Estilo profesor)
                foreach (var cliente in _clientesCache)
                {
                    cliente.Usuario = _usuariosCache.FirstOrDefault(u => u.ID == cliente.UsuarioID);
                }

                RefrescarGrillaLocal();
            }
            catch (Exception ex)
            {
                MessageHelpers.ShowError($"Error al sincronizar con el servidor: {ex.Message}");
            }
        }

        
        //FILTRADO LOCAL (RAM -> GRID)

        private void RefrescarGrillaLocal()
        {
            string filtro = textBoxBuscar.Text.Trim();

            // Filtrado en memoria de Clientes
            var clientesFiltrados = _clientesCache.Where(c =>
                string.IsNullOrEmpty(filtro) ||
                (c.Usuario?.Nombre?.Contains(filtro, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (c.Usuario?.DNI?.Contains(filtro, StringComparison.OrdinalIgnoreCase) ?? false)
            ).ToList();

            // Filtrado en memoria de Usuarios puros
            var usuariosFiltrados = _usuariosCache.Where(u =>
                !_clientesCache.Any(c => c.UsuarioID == u.ID) &&
                (string.IsNullOrEmpty(filtro) || u.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase))
            ).ToList();

            // Seteamos el DataSource con los objetos transformados para la UI
            dataGridViewUsuarios.DataSource = TransformarParaUI(clientesFiltrados, usuariosFiltrados);

            // Helpers de visualización
            DataGridHelpers.HideColumns(dataGridViewUsuarios, "ID");
            DataGridHelpers.SetupBasicGrid(dataGridViewUsuarios);
        }

        private List<object> TransformarParaUI(List<Cliente> clientes, List<Usuario> usuarios)
        {
            List<object> listaParaGrilla = new List<object>();

            // 1. Proyectamos Clientes
            var datosClientes = clientes.Select(c => new
            {
                TipoUsuario = "Cliente",
                Nombre = c.Usuario?.Nombre ?? "Sin Nombre",
                DNI = string.IsNullOrEmpty(c.Usuario?.DNI) ? "N/A" : c.Usuario.DNI,
                Email = c.Usuario?.Email ?? "N/A",
                Telefono = c.Telefono ?? "N/A",
                Instagram = c.Instagram ?? "N/A",
                ID = (int)c.ID
            });

            // 2. Proyectamos Usuarios
            var datosUsuarios = usuarios.Select(u => new
            {
                TipoUsuario = u.TipoUsuario.ToString(),
                Nombre = u.Nombre ?? "N/A",
                DNI = string.IsNullOrEmpty(u.DNI) ? "N/A" : u.DNI,
                Email = u.Email ?? "N/A",
                Telefono = "N/A",
                Instagram = "N/A",
                ID = (int)u.ID
            });

            // 3. Unimos todo en la lista base
            listaParaGrilla.AddRange(datosClientes);
            listaParaGrilla.AddRange(datosUsuarios);

            return listaParaGrilla
                .OrderBy(item => ((dynamic)item).Nombre)
                .ToList();
        }


        //EVENTOS DE UI Y FILTRADO

        private void textBoxBuscar_TextChanged(object sender, EventArgs e) => RefrescarGrillaLocal();
        private void textBoxBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                // evita que el sistema reproduzca el sonido de alerta
                e.Handled = true;

                // Como ya tenemos todo cargado en RAM, simplemente ejecutamos la lógica de filtrado local sin ir a la API
                RefrescarGrillaLocal();

                // Opcional: Avisar visualmente al usuario si no hubo resultados
                if (dataGridViewUsuarios.RowCount == 0)
                {
                    MessageHelpers.ShowWarning("No se encontraron resultados locales.");
                }
            }
        }

        private async void checkBoxEliminados_CheckedChanged(object sender, EventArgs e)
        {
            // 1. Recargamos la caché local con los datos de la base de datos (eliminados o activos)
            await LoadDataAsync();

            // 2. Si checkBoxEliminados está marcado (true), mostramos el botón de restaurar
            BtnRestaurar.Visible = checkBoxEliminados.Checked;

            // 3. BLOQUEO: Si estamos viendo eliminados, desactivamos Editar y Eliminar
            // Si checkBoxEliminados.Checked es true, Enabled será false.
            BtnEditar.Enabled = !checkBoxEliminados.Checked;
            BtnEliminar.Enabled = !checkBoxEliminados.Checked;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            labelAccion.Text = "Nuevo Registro";
            tabControl.SelectedTab = AgregarEditar_TabPage;
        }


        // CRUD

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            // 1. Obtenemos el objeto vinculado a la fila
            var item = dataGridViewUsuarios.CurrentRow?.DataBoundItem;
            if (item == null) return;

            if (checkBoxEliminados.Checked) return;

            try
            {
                
                dynamic rowData = item;
                int idGrid = rowData.ID;
                string tipo = rowData.TipoUsuario; 

                _currentUsuario = null;
                _currentCliente = null;

                // 3. Búsqueda en la caché local
                if (tipo == "Cliente")
                {
                    _currentCliente = _clientesCache.FirstOrDefault(c => c.ID == idGrid);
                    _currentUsuario = _currentCliente?.Usuario;
                }
                else
                {
                    _currentUsuario = _usuariosCache.FirstOrDefault(u => u.ID == idGrid);
                }

                // 4. Actualización de la UI
                if (_currentUsuario != null)
                {
                    CargarDatosEnControles(_currentUsuario, _currentCliente);
                    labelAccion.Text = $"Modificando a: {_currentUsuario.Nombre}";
                    tabControl.SelectedTab = AgregarEditar_TabPage;
                }
                else
                {
                    MessageHelpers.ShowError("No se pudo localizar al usuario en memoria local.");
                }
            }
            catch (Exception ex)
            {
                MessageHelpers.ShowError("Error al intentar editar el registro: " + ex.Message);
            }
        }

        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            var item = dataGridViewUsuarios.CurrentRow?.DataBoundItem;
            if (item == null) return;

            // Extraemos ID del Usuario y el Tipo
            int id = (int)item.GetType().GetProperty("ID").GetValue(item);
            string tipo = (string)item.GetType().GetProperty("Tipo").GetValue(item);

            if (MessageBox.Show($"¿Desea eliminar este {tipo} por completo?", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    // 1. Si es cliente, primero borramos la entidad Cliente
                    if (tipo == "Cliente")
                    {
                        // Buscamos el ID del cliente en nuestra cache para borrarlo en su tabla
                        var cliente = _clientesCache.FirstOrDefault(c => c.ID == id);
                        if (cliente != null)
                        {
                            await _clienteService.DeleteAsync(cliente.ID);
                        }

                        // 2. AHORA borramos el Usuario vinculado para que desaparezca de la plataforma
                        // el ID del item es el ID del Usuario cuando viene del Grid
                        await _usuarioService.DeleteAsync(cliente.UsuarioID);
                    }
                    else
                    {
                        // Es un usuario puro, solo borramos Usuario
                        await _usuarioService.DeleteAsync(id);
                    }

                    // 3. RECARGA MASIVA: Trae el nuevo estado de la DB a la RAM
                    await LoadDataAsync();

                    MessageHelpers.ShowSuccess("Registro eliminado correctamente.");
                }
                catch (Exception ex)
                {
                    MessageHelpers.ShowError($"Error al eliminar: {ex.Message}");
                }
            }
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                bool esNuevo = _currentUsuario == null;
                Usuario usuario = esNuevo ? new Usuario() : _currentUsuario!;

                usuario.Nombre = textBoxNombre.Text;
                usuario.TipoUsuario = (TipoUsuarioEnum)comboBoxTipoUsuario.SelectedItem;

                if (esNuevo) await _usuarioService.AddAsync(usuario);
                else await _usuarioService.UpdateAsync(usuario);

                // Lógica de cliente si aplica
                if (usuario.TipoUsuario == TipoUsuarioEnum.Cliente)
                {
                    Cliente cliente = esNuevo || _currentCliente == null ? new Cliente { UsuarioID = usuario.ID } : _currentCliente;
                    cliente.Telefono = textBoxTelefono.Text;
                    if (esNuevo || _currentCliente == null)
                        await _clienteService.AddAsync(cliente);
                    else
                        await _clienteService.UpdateAsync(cliente);
                }

                await LoadDataAsync(); // Refresca cache local
                LimpiarControles();
                tabControl.SelectedTab = Lista_TabPage;
            }
            catch (Exception ex) { MessageHelpers.ShowError(ex.Message); }
        }

        private async void BtnRestaurar_Click(object sender, EventArgs e)
        {
            // Obtenemos el objeto directamente de la fila
            var item = dataGridViewUsuarios.CurrentRow?.DataBoundItem;
            if (item == null) return;

            try
            {
                
                int id = (int)item.GetType().GetProperty("ID").GetValue(item);
                string tipo = (string)item.GetType().GetProperty("Tipo").GetValue(item);

                if (MessageBox.Show($"¿Desea restaurar este {tipo}?", "Restaurar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (tipo == "Cliente")
                    {
                        var cliente = _clientesCache.FirstOrDefault(c => c.ID == id);
                        if (cliente != null)
                        {
                            // Restauramos ambos
                            await _usuarioService.RestoreAsync(cliente.UsuarioID);
                            await _clienteService.RestoreAsync(cliente.ID);
                        }
                    }
                    else
                    {
                        await _usuarioService.RestoreAsync(id);
                    }

                    // IMPORTANTE: Sincronizamos RAM con Servidor tras restaurar
                    await LoadDataAsync();
                    MessageHelpers.ShowSuccess("Registro restaurado correctamente.");
                }
            }
            catch (Exception ex) { MessageHelpers.ShowError(ex.Message); }

        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            // Aplicamos el filtro sobre lo que ya tenemos cargado en _clientesCache y _usuariosCache
            RefrescarGrillaLocal();
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = Lista_TabPage;
            LimpiarControles();
        }


        //HELPERS DE UI

        private void CargarDatosEnControles(Usuario u, Cliente? c = null)
        {
            textBoxNombre.Text = u.Nombre;
            comboBoxTipoUsuario.SelectedItem = u.TipoUsuario;

            // Mostramos DNI y Email (Campos de Usuario)
            textBoxDNI.Text = u.DNI ?? "";
            textBoxEmail.Text = u.Email ?? "";
            textBoxDNI.Visible = true;
            textBoxEmail.Visible = true;

            // Si es cliente, mostramos y llenamos Instagram/Teléfono
            if (u.TipoUsuario == TipoUsuarioEnum.Cliente)
            {
                textBoxTelefono.Text = c?.Telefono ?? "";
                textBoxInstagram.Text = c?.Instagram ?? "";
                textBoxTelefono.Visible = true;
                textBoxInstagram.Visible = true;
            }
        }

        private void LimpiarControles()
        {
            _currentUsuario = null;
            _currentCliente = null;

            textBoxNombre.Clear();
            textBoxDNI.Clear();
            textBoxEmail.Clear();
            textBoxTelefono.Clear();
            textBoxInstagram.Clear();
            comboBoxTipoUsuario.SelectedIndex = -1;

            // Al ser nuevo, ocultamos los campos hasta que elija el tipo
            textBoxTelefono.Visible = false;
            textBoxInstagram.Visible = false;
            lblTelefono.Visible = false;
            lblInstagram.Visible = false;
        }

        private void AjustarVisibilidad(bool esCliente)
        {
            // Mostrar/Ocultar campos específicos de Cliente
            textBoxTelefono.Visible = esCliente;
            textBoxInstagram.Visible = esCliente;
            lblTelefono.Visible = esCliente;
            lblInstagram.Visible = esCliente;
        }

        private void comboBoxTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipoUsuario.SelectedItem is TipoUsuarioEnum tipo)
                AjustarVisibilidad(tipo == TipoUsuarioEnum.Cliente);
        }





    }
}