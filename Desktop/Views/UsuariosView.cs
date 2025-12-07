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
        // Servicios de datos
        readonly GenericService<Usuario> _usuarioService = new();
        readonly GenericService<Cliente> _clienteService = new();

        // Repositorio local sincronizado (Caché RAM)
        List<Cliente> _clientesCache = new();
        List<Usuario> _usuariosCache = new();

        // Objetos para la sesión de edición
        Cliente? _currentCliente;
        Usuario? _currentUsuario;

        public UsuariosView()
        {
            InitializeComponent();
        }

        private async void UsuariosView_Load(object sender, EventArgs e)
        {
            await SincronizarCacheConServidor();
            comboBoxTipoUsuario.DataSource = Enum.GetValues(typeof(TipoUsuarioEnum));
        }

        // --- LÓGICA DE SINCRONIZACIÓN Y DATOS ---

        private async Task SincronizarCacheConServidor()
        {
            try
            {
                // Obtenemos el universo completo de datos (Activos o Eliminados)
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

                // Vinculamos las referencias de objetos en RAM
                foreach (var cliente in _clientesCache)
                {
                    cliente.Usuario = _usuariosCache.FirstOrDefault(u => u.ID == cliente.UsuarioID);
                }

                RefrescarGrillaLocal();
            }
            catch (Exception ex)
            {
                MessageHelpers.ShowError($"Error de sincronización: {ex.Message}");
            }
        }

        private void RefrescarGrillaLocal()
        {
            string filtro = textBoxBuscar.Text.Trim();

            // Filtramos las listas originales en memoria
            var clientesFiltrados = _clientesCache.Where(c =>
                string.IsNullOrEmpty(filtro) ||
                (c.Usuario?.Nombre?.Contains(filtro, StringComparison.OrdinalIgnoreCase) ?? false)
            ).ToList();

            var usuariosPurosFiltrados = _usuariosCache.Where(u =>
                !_clientesCache.Any(c => c.UsuarioID == u.ID) &&
                (string.IsNullOrEmpty(filtro) || u.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase))
            ).ToList();

            // Transformamos y ordenamos para la interfaz
            dataGridViewCompras.DataSource = TransformarParaUI(clientesFiltrados, usuariosPurosFiltrados);

            // Estética de la grilla
            DataGridHelpers.HideColumns(dataGridViewCompras, "ID");
            DataGridHelpers.SetupBasicGrid(dataGridViewCompras);
        }

        private List<object> TransformarParaUI(List<Cliente> clientes, List<Usuario> usuarios)
        {
            List<object> listaUnificada = new List<object>();

            // Proyectamos Clientes (El orden aquí define las columnas del Grid)
            var datosClientes = clientes.Select(c => new
            {
                TipoUsuario = "Cliente",
                NOMBRE = c.Usuario?.Nombre ?? "Sin Nombre",
                DNI = string.IsNullOrEmpty(c.Usuario?.DNI) ? "N/A" : c.Usuario.DNI,
                Email = string.IsNullOrEmpty(c.Usuario?.Email) ? "N/A" : c.Usuario.Email,
                Telefono = string.IsNullOrEmpty(c.Telefono) ? "N/A" : c.Telefono,
                Instagram = string.IsNullOrEmpty(c.Instagram) ? "N/A" : c.Instagram,
                ID = (int)c.ID
            });
            listaUnificada.AddRange(datosClientes);

            // Proyectamos Usuarios puros
            var datosUsuarios = usuarios.Select(u => new
            {
                TipoUsuario = u.TipoUsuario.ToString(),
                NOMBRE = u.Nombre ?? "N/A",
                DNI = string.IsNullOrEmpty(u.DNI) ? "N/A" : u.DNI,
                Email = string.IsNullOrEmpty(u.Email) ? "N/A" : u.Email,
                Telefono = "N/A",
                Instagram = "N/A",
                ID = (int)u.ID
            });
            listaUnificada.AddRange(datosUsuarios);

            // Ordenamiento alfabético semántico por Nombre
            return listaUnificada.OrderBy(item => ((dynamic)item).NOMBRE).ToList();
        }

        // --- MANEJO DE EVENTOS ---

        private void textBoxBuscar_TextChanged(object sender, EventArgs e) => RefrescarGrillaLocal();

        private void textBoxBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                RefrescarGrillaLocal();
            }
        }

        private async void checkBoxEliminados_CheckedChanged(object sender, EventArgs e)
        {
            await SincronizarCacheConServidor();
            BtnRestaurar.Visible = checkBoxEliminados.Checked;
            BtnEditar.Enabled = !checkBoxEliminados.Checked;
            BtnEliminar.Enabled = !checkBoxEliminados.Checked;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            labelAccion.Text = "Nuevo Registro";
            tabControl.SelectedTab = AgregarEditar_TabPage;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            tabControl.SelectedTab = Lista_TabPage;
        }
        private void BtnBuscar_Click(object sender, EventArgs e) => RefrescarGrillaLocal();

        // --- CRUD (USANDO DataBoundItem) ---

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            var item = dataGridViewCompras.CurrentRow?.DataBoundItem;
            if (item == null || checkBoxEliminados.Checked) return;

            try
            {
                dynamic row = item;
                int idRecuperado = (int)row.ID;
                string tipo = (string)row.TipoUsuario;

                if (tipo == "Cliente")
                {
                    _currentCliente = _clientesCache.FirstOrDefault(c => c.ID == idRecuperado);
                    _currentUsuario = _currentCliente?.Usuario;
                }
                else
                {
                    _currentUsuario = _usuariosCache.FirstOrDefault(u => u.ID == idRecuperado);
                    _currentCliente = null;
                }

                if (_currentUsuario != null)
                {
                    CargarDatosEnControles(_currentUsuario, _currentCliente);
                    labelAccion.Text = $"Modificando a: {_currentUsuario.Nombre}";
                    tabControl.SelectedTab = AgregarEditar_TabPage;
                }
            }
            catch (Exception ex) { MessageHelpers.ShowError("Error al cargar edición: " + ex.Message); }
        }

        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            var item = dataGridViewCompras.CurrentRow?.DataBoundItem;
            if (item == null || checkBoxEliminados.Checked) return;

            try
            {
                dynamic row = item;
                int idGrid = (int)row.ID;
                string tipo = (string)row.TipoUsuario;

                if (MessageBox.Show($"¿Desea eliminar este {tipo}?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (tipo == "Cliente")
                    {
                        var cliente = _clientesCache.FirstOrDefault(c => c.ID == idGrid);
                        if (cliente != null)
                        {
                            await _clienteService.DeleteAsync(cliente.ID);
                            await _usuarioService.DeleteAsync(cliente.UsuarioID);
                        }
                    }
                    else await _usuarioService.DeleteAsync(idGrid);

                    await SincronizarCacheConServidor();
                    MessageHelpers.ShowSuccess("Registro eliminado correctamente.");
                }
            }
            catch (Exception ex) { MessageHelpers.ShowError(ex.Message); }
        }

        private async void BtnRestaurar_Click(object sender, EventArgs e)
        {
            var item = dataGridViewCompras.CurrentRow?.DataBoundItem;
            if (item == null) return;

            try
            {
                dynamic row = item;
                int idGrid = (int)row.ID;
                string tipo = (string)row.TipoUsuario;

                if (MessageBox.Show($"¿Desea restaurar este {tipo}?", "Restaurar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (tipo == "Cliente")
                    {
                        var cliente = _clientesCache.FirstOrDefault(c => c.ID == idGrid);
                        if (cliente != null)
                        {
                            await _usuarioService.RestoreAsync(cliente.UsuarioID);
                            await _clienteService.RestoreAsync(cliente.ID);
                        }
                    }
                    else await _usuarioService.RestoreAsync(idGrid);

                    await SincronizarCacheConServidor();
                    MessageHelpers.ShowSuccess("Registro restaurado.");
                }
            }
            catch (Exception ex) { MessageHelpers.ShowError(ex.Message); }
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                bool esNuevo = _currentUsuario == null;
                Usuario usuario = esNuevo ? new Usuario() : _currentUsuario!;

                usuario.Nombre = textBoxNombre.Text;
                usuario.DNI = textBoxDNI.Text;
                usuario.Email = textBoxEmail.Text;
                usuario.TipoUsuario = (TipoUsuarioEnum)comboBoxTipoUsuario.SelectedItem;

                if (esNuevo) _currentUsuario = await _usuarioService.AddAsync(usuario);
                else await _usuarioService.UpdateAsync(usuario);

                if (usuario.TipoUsuario == TipoUsuarioEnum.Cliente)
                {
                    Cliente cliente = (esNuevo || _currentCliente == null)
                        ? new Cliente { UsuarioID = _currentUsuario!.ID }
                        : _currentCliente!;

                    cliente.Telefono = textBoxTelefono.Text;
                    cliente.Instagram = textBoxInstagram.Text;

                    if (esNuevo || _currentCliente == null) await _clienteService.AddAsync(cliente);
                    else await _clienteService.UpdateAsync(cliente);
                }

                await SincronizarCacheConServidor();
                LimpiarControles();
                tabControl.SelectedTab = Lista_TabPage;
                MessageHelpers.ShowSuccess("Cambios guardados.");
            }
            catch (Exception ex) { MessageHelpers.ShowError(ex.Message); }
        }

        // --- HELPERS DE UI ---

        private void CargarDatosEnControles(Usuario u, Cliente? c = null)
        {
            textBoxNombre.Text = u.Nombre;
            comboBoxTipoUsuario.SelectedItem = u.TipoUsuario;
            textBoxDNI.Text = u.DNI ?? "";
            textBoxEmail.Text = u.Email ?? "";

            textBoxDNI.Visible = true;
            textBoxEmail.Visible = true;

            bool esCliente = u.TipoUsuario == TipoUsuarioEnum.Cliente;
            AjustarVisibilidad(esCliente);

            if (c != null)
            {
                textBoxTelefono.Text = c.Telefono ?? "";
                textBoxInstagram.Text = c.Instagram ?? "";
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
            AjustarVisibilidad(false);
        }

        private void AjustarVisibilidad(bool esCliente)
        {
            textBoxTelefono.Visible = esCliente;
            textBoxInstagram.Visible = esCliente;
            lblInstagram.Visible = esCliente;
            lblTelefono.Visible = esCliente;
            // Si tienes Labels, añádelos aquí: lblTelefono.Visible = esCliente;
        }

        private void comboBoxTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipoUsuario.SelectedItem is TipoUsuarioEnum tipo)
            {
                textBoxDNI.Visible = true;
                textBoxEmail.Visible = true;
                AjustarVisibilidad(tipo == TipoUsuarioEnum.Cliente);
            }
        }
    }
}