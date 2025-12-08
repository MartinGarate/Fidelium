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

        public enum ModoVistaUsuario
        {
            Todos,
            Administradores,
            Empleados,
            Clientes
        }
        public UsuariosView()
        {
            InitializeComponent();
        }

        private async void UsuariosView_Load(object sender, EventArgs e)
        {
            // 1. Desvinculamos el evento para evitar disparos prematuros
            comboBoxModoVista.SelectedIndexChanged -= comboBoxModoVista_SelectedIndexChanged;

            await SincronizarCacheConServidor();

            // 2. Cargamos los tipos de usuario para edición
            comboBoxTipoUsuario.DataSource = Enum.GetValues(typeof(TipoUsuarioEnum));

            // 3. Cargamos el modo de vista (Usando una lista anónima para mejor UX)
            comboBoxModoVista.DataSource = new[] {
        new { Texto = "Ver Todos", Valor = ModoVistaUsuario.Todos },
        new { Texto = "Administradores", Valor = ModoVistaUsuario.Administradores },
        new { Texto = "Empleados", Valor = ModoVistaUsuario.Empleados },
        new { Texto = "Clientes", Valor = ModoVistaUsuario.Clientes }
    };
            comboBoxModoVista.DisplayMember = "Texto";
            comboBoxModoVista.ValueMember = "Valor";

            // 4. Verificamos que existan items antes de seleccionar
            if (comboBoxModoVista.Items.Count > 0)
            {
                comboBoxModoVista.SelectedIndex = 0;
            }

            // 5. Volvemos a vincular el evento
            comboBoxModoVista.SelectedIndexChanged += comboBoxModoVista_SelectedIndexChanged;

            // 6. Refresco manual inicial
            RefrescarGrillaLocal();
        }


        // LÓGICA DE SINCRONIZACIÓN Y DATOS
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
            // Verificación de seguridad para evitar NullReference
            if (comboBoxModoVista.SelectedValue == null) return;

            string filtroText = textBoxBuscar.Text.Trim();
            ModoVistaUsuario modoSeleccionado = (ModoVistaUsuario)comboBoxModoVista.SelectedValue;

            List<Cliente> clientesFinal;
            List<Usuario> usuariosFinal;

            // 1. Filtrado por CATEGORÍA
            switch (modoSeleccionado)
            {
                case ModoVistaUsuario.Administradores:
                    clientesFinal = new List<Cliente>();
                    usuariosFinal = _usuariosCache.Where(u => u.TipoUsuario == TipoUsuarioEnum.Administrador).ToList();
                    break;
                case ModoVistaUsuario.Empleados:
                    clientesFinal = new List<Cliente>();
                    usuariosFinal = _usuariosCache.Where(u => u.TipoUsuario == TipoUsuarioEnum.Empleado).ToList();
                    break;
                case ModoVistaUsuario.Clientes:
                    clientesFinal = _clientesCache.ToList();
                    usuariosFinal = new List<Usuario>();
                    break;
                default: // Todos
                    clientesFinal = _clientesCache.ToList();
                    usuariosFinal = _usuariosCache.Where(u => !_clientesCache.Any(c => c.UsuarioID == u.ID)).ToList();
                    break;
            }

            // 2. Filtrado por TEXTO (Nombre o DNI para mayor utilidad)
            if (!string.IsNullOrEmpty(filtroText))
            {
                clientesFinal = clientesFinal.Where(c =>
                    (c.Usuario?.Nombre?.Contains(filtroText, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (c.Usuario?.DNI?.Contains(filtroText) ?? false)
                ).ToList();

                usuariosFinal = usuariosFinal.Where(u =>
                    u.Nombre.Contains(filtroText, StringComparison.OrdinalIgnoreCase) ||
                    u.DNI.Contains(filtroText)
                ).ToList();
            }

            // 3. Renderizado
            dataGridViewCompras.DataSource = TransformarParaUI(clientesFinal, usuariosFinal);

            // Estética
            if (dataGridViewCompras.ColumnCount > 0)
            {
                DataGridHelpers.HideColumns(dataGridViewCompras, "ID");
                DataGridHelpers.SetupBasicGrid(dataGridViewCompras);
            }
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


        // MÉTODOS AUXILIARES DE CONTROLES
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



        // TabPage LISTA | Controles

        private void comboBoxModoVista_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefrescarGrillaLocal();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            labelAccion.Text = "Nuevo Registro";
            tabControl.SelectedTab = AgregarEditar_TabPage;
        }
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
        private async void checkBoxEliminados_CheckedChanged(object sender, EventArgs e)
        {
            await SincronizarCacheConServidor();
            BtnRestaurar.Visible = checkBoxEliminados.Checked;
            BtnEditar.Enabled = !checkBoxEliminados.Checked;
            BtnEliminar.Enabled = !checkBoxEliminados.Checked;
        }

        private void BtnBuscar_Click(object sender, EventArgs e) => RefrescarGrillaLocal();
        private void textBoxBuscar_TextChanged(object sender, EventArgs e) => RefrescarGrillaLocal();
        private void textBoxBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                RefrescarGrillaLocal();
            }
        }


        // TabPage Agregar/Editar | Controles
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
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            tabControl.SelectedTab = Lista_TabPage;
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