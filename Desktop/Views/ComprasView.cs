using Desktop.Utils.HelpersDesktop;
using Service.Enums;
using Service.Models;
using Service.Models.Service.Models;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class ComprasView : Form
    {
        // Servicios de datos
        readonly GenericService<Usuario> _usuarioService = new();
        readonly GenericService<Cliente> _clienteService = new();
        readonly GenericService<CompraServicio> _compraServicioService = new();
        readonly GenericService<Notificacion> _notificacionService = new();

        // Repositorio local sincronizado (Caché RAM)
        List<Cliente> _clientesCache = new();
        List<Usuario> _usuariosCache = new();
        List<CompraServicio> _comprasCache = new();
        List<Notificacion> _notificacionCache = new();

        // Objetos para la sesión de edición
        Cliente? _currentCliente;
        Usuario? _currentUsuario;
        CompraServicio? _currentCompraServicio;
        Notificacion? _currentNotificacion;

        // Estado del selector: true = Cliente, false = Vendedor
        bool _isSelectingClient = true;


        public ComprasView()
        {
            InitializeComponent();
        }

        private async void ComprasView_Load(object sender, EventArgs e)
        {
            // Carga inicial masiva
            await SincronizarCacheConServidor();
        }



        // LÓGICA DE SINCRONIZACIÓN Y DATOS
        private async Task SincronizarCacheConServidor()
        {
            try
            {
                if (checkBoxEliminados.Checked)
                {
                    // 1. Cargamos las compras de la papelera
                    _comprasCache = await _compraServicioService.GetAllDeletedsAsync("") ?? new List<CompraServicio>();

                    // 2. IMPORTANTE: Cargamos los Clientes y Usuarios ACTIVOS 
                    // para que los nombres aparezcan aunque la compra esté borrada
                    _clientesCache = await _clienteService.GetAllAsync("") ?? new List<Cliente>();
                    _usuariosCache = await _usuarioService.GetAllAsync("") ?? new List<Usuario>();

                    // 3. OPCIONAL: Si el cliente también estuviera borrado, 
                    // podrías concatenar con GetAllDeletedsAsync, pero usualmente basta con los activos.
                }
                else
                {
                    // Carga normal para registros activos
                    _clientesCache = await _clienteService.GetAllAsync("") ?? new List<Cliente>();
                    _usuariosCache = await _usuarioService.GetAllAsync("") ?? new List<Usuario>();
                    _comprasCache = await _compraServicioService.GetAllAsync("") ?? new List<CompraServicio>();
                }

                // 2. VINCULACIÓN EN RAM
                // Vinculamos Cliente -> Usuario para tener el Nombre/DNI
                foreach (var c in _clientesCache)
                    c.Usuario = _usuariosCache.FirstOrDefault(u => u.ID == c.UsuarioID);

                // Vinculamos Compra -> Cliente y Empleado (Ahora sí los encontrará)
                foreach (var cs in _comprasCache)
                {
                    cs.Cliente = _clientesCache.FirstOrDefault(c => c.ID == cs.ClienteID);
                    cs.Empleado = _usuariosCache.FirstOrDefault(u => u.ID == cs.EmpleadoID);
                }

                // 3. ACTUALIZACIÓN VISUAL
                RefrescarGrillaCompras();
                RefrescarGrillaUsuario();
            }
            catch (Exception ex)
            {
                MessageHelpers.ShowError($"Error al sincronizar datos: {ex.Message}");
            }
        }
        private void RefrescarGrillaCompras()
        {
            string filtro = textBoxBuscar.Text.Trim();

            // 1. Filtramos las Compras en memoria
            var comprasFiltradas = _comprasCache.Where(cs =>
                string.IsNullOrEmpty(filtro) ||
                (cs.Nombre?.Contains(filtro, StringComparison.OrdinalIgnoreCase) ?? false) || // Filtro por nombre de producto
                (cs.Cliente?.Usuario?.Nombre?.Contains(filtro, StringComparison.OrdinalIgnoreCase) ?? false) || // Filtro por Cliente
                (cs.Empleado?.Nombre?.Contains(filtro, StringComparison.OrdinalIgnoreCase) ?? false) // Filtro por Vendedor
            ).OrderByDescending(cs => cs.FechaCompra).ToList();

            // 2. Transformamos la lista filtrada para la interfaz de Compras
            dataGridViewCompras.DataSource = null;
            dataGridViewCompras.DataSource = TransformarParaUICompras(comprasFiltradas);

            // 3. Estética de la grilla
            DataGridHelpers.HideColumns(dataGridViewCompras, "ID");
            DataGridHelpers.SetupBasicGrid(dataGridViewCompras);

            // Renombrar columnas
            DataGridHelpers.RenameColumn(dataGridViewCompras, "Empleado", "VENDEDOR");
        }
        private List<object> TransformarParaUICompras(List<CompraServicio> compras)
        {
            var datosParaGrilla = compras.Select(cs => new
            {
                PRODUCTO = cs.Nombre ?? "Sin Nombre",
                CLIENTE = cs.Cliente?.Usuario != null
                          ? $"{cs.Cliente.Usuario.Nombre} | DNI: {cs.Cliente.Usuario.DNI}" : "N/A",
                VENDEDOR = cs.Empleado != null ? $"{cs.Empleado.Nombre} | DNI: {cs.Empleado.DNI}" : "N/A",
                FECHA = cs.FechaCompra.ToShortDateString(),
                RECORDATORIO = cs.FechaRecordatorio.ToShortDateString(),
                FEEDBACK = cs.FeedbackRecibido ? "Recibido" : "Pendiente",

                // Campo técnico: ID de la compra (Se ocultará en el Grid)
                ID = (int)cs.ID
            });

            // 2. Retornamos la lista casteada a object para que el DataGridView la acepte
            return datosParaGrilla.Cast<object>().ToList();
        }


        private void RefrescarGrillaUsuario()
        {
            // 1. Filtrado lógico basado en el estado
            List<object> datosAMostrar;

            if (_isSelectingClient)
            {
                // Traemos todos los clientes de la caché
                datosAMostrar = TransformarParaUIUsuario(_clientesCache.Cast<object>().ToList());
            }
            else
            {
                // Traemos usuarios que NO son clientes (Administradores y Empleados)
                var vendedores = _usuariosCache.Where(u => u.TipoUsuario != TipoUsuarioEnum.Cliente).Cast<object>().ToList();
                datosAMostrar = TransformarParaUIUsuario(vendedores);
            }

            // 2. Binding a la grilla de selección (usa el nombre de tu control de grilla en ese tab)
            dataGridViewUsuarios.DataSource = null;
            dataGridViewUsuarios.DataSource = datosAMostrar;

            // 3. Estética
            DataGridHelpers.HideColumns(dataGridViewUsuarios, "ID");
            DataGridHelpers.SetupBasicGrid(dataGridViewUsuarios);
        }
        private List<object> TransformarParaUIUsuario(List<object> origen)
        {
            if (_isSelectingClient)
            {
                return origen.Cast<Cliente>().Select(c => new
                {
                    NOMBRE = c.Usuario?.Nombre ?? "N/A",
                    DNI = c.Usuario?.DNI ?? "N/A",
                    TIPO = "Cliente",
                    ID = (int)c.ID // ID de Cliente
                }).Cast<object>().ToList();
            }
            else
            {
                return origen.Cast<Usuario>().Select(u => new
                {
                    NOMBRE = u.Nombre,
                    DNI = u.DNI,
                    TIPO = u.TipoUsuario.ToString(),
                    ID = (int)u.ID // ID de Usuario
                }).Cast<object>().ToList();
            }
        }
        private void DetectarTipoUsuario(bool esCliente)
        {
            if (esCliente)
            {
                lblSeleccionUsuarioCliente_Titulo.Text = "Seleccione el Cliente para esta Compra:";
                lblSeleccionUsuarioCliente_SubTitulo.Text = "Listado de Clientes Registrados";

                var item = dataGridViewUsuarios.CurrentRow?.DataBoundItem;
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

                        if (esCliente)
                        {
                            textBoxCliente.Text = $"{_currentUsuario.Nombre} (DNI: {_currentUsuario.DNI})";
                        }
                        else
                        {
                            textBoxEmpleado.Text = $"{_currentUsuario.Nombre} (DNI: {_currentUsuario.DNI})";
                        }

                        labelAccion.Text = esCliente ? "Cliente seleccionado" : "Vendedor seleccionado";
                        tabControl.SelectedTab = AgregarEditar_TabPage;
                    }
                }
                catch (Exception ex) { MessageHelpers.ShowError("Error al cargar edición: " + ex.Message); }
            }


        }




        // MÉTODOS AUXILIARES DE CONTROLES
        private void CargarDatosEnControles(CompraServicio cs)
        {
            // Datos de Personas (Usamos los objetos vinculados en RAM)
            // Combinamos Nombre y DNI
            textBoxCliente.Text = cs.Cliente?.Usuario != null
                ? $"{cs.Cliente.Usuario.Nombre} (DNI: {cs.Cliente.Usuario.DNI})"
                : "N/A";

            textBoxEmpleado.Text = cs.Empleado != null
                ? $"{cs.Empleado.Nombre} (DNI: {cs.Empleado.DNI})"
                : "N/A";

            // 2. Datos de la Transacción
            textBoxProductoServicio.Text = cs.Nombre;
            textBoxDescripcion.Text = cs.Descripcion ?? "";
            textBoxNotasVentaInternas.Text = cs.NotasVentaInternas ?? "";

            // 3. Fechas
            dateTime_FechaCompra.Value = cs.FechaCompra;
            // La FechaRecordatorio es calculada (FechaCompra + 7), pero la mostramos en su picker
            dateTime_FechaRecordatorio.Value = cs.FechaRecordatorio;

            // 4. Seguimiento Post-Venta
            checkBoxFeedbackRecibido.Checked = cs.FeedbackRecibido;
            textBoxFeedbackCliente.Text = cs.ComentarioFeedback ?? "";

            // Al ser una edición de compra, bloqueamos los datos que no deberían cambiar
            ConfigurarSoloLectura();
        }
        private void ConfigurarSoloLectura()
        {
            // El cliente y el empleado no se cambian desde aquí
            textBoxCliente.Enabled = false;
            textBoxEmpleado.Enabled = false;


        }
        private void LimpiarControles()
        {
            // 1. Resetear referencias de objetos en RAM
            _currentUsuario = null;
            _currentCliente = null;
            _currentCompraServicio = null;
            _currentNotificacion = null;

            // 2. Limpiar cuadros de texto
            textBoxProductoServicio.Clear();
            textBoxEmpleado.Clear();
            textBoxCliente.Clear();
            textBoxDescripcion.Clear();
            textBoxNotasVentaInternas.Clear();
            textBoxFeedbackCliente.Clear();

            // 3. Resetear fechas a la actualidad
            dateTime_FechaCompra.Value = DateTime.Now;
            // El label o control de recordatorio se limpiará/actualizará mediante evento
            dateTime_FechaRecordatorio.Value = DateTime.Now.AddDays(7);

            // 4. Resetear estados booleanos
            checkBoxFeedbackRecibido.Checked = false;

            // 5. Quitar estados de "Solo lectura" para permitir nuevas cargas
            textBoxCliente.ReadOnly = false;
            textBoxEmpleado.ReadOnly = false;
            textBoxNotasVentaInternas.ReadOnly = false;
        }



        // TabPage LISTA | Controles
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            labelAccion.Text = "Nueva Compra de Producto o Servicio";
            labelSubtituloAgregarEditar.Text = "Complete los datos de la nueva compra.";
            tabControl.SelectedTab = AgregarEditar_TabPage;
        }
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            // 1. Obtenemos el objeto vinculado a la fila seleccionada
            var item = dataGridViewCompras.CurrentRow?.DataBoundItem;
            if (item == null || checkBoxEliminados.Checked) return;

            try
            {
                // 2. Extraemos el ID del objeto de la grilla
                dynamic row = item;
                int idRecuperado = (int)row.ID;

                // 3. Buscamos la compra en nuestra RAM (Caché local)
                _currentCompraServicio = _comprasCache.FirstOrDefault(cs => cs.ID == idRecuperado);

                // 4. Verificación y carga del formulario
                if (_currentCompraServicio != null)
                {
                    // Asignamos las referencias
                    _currentCliente = _currentCompraServicio.Cliente;
                    _currentUsuario = _currentCompraServicio.Empleado;

                    // Cargamos los controles usando el objeto completo
                    CargarDatosEnControles(_currentCompraServicio);

                    labelAccion.Text = $"Editando: {_currentCompraServicio.Nombre}";
                    tabControl.SelectedTab = AgregarEditar_TabPage;
                }
                else
                {
                    MessageHelpers.ShowError("No se pudo localizar la compra en la memoria local.");
                }
            }
            catch (Exception ex)
            {
                MessageHelpers.ShowError("Error al abrir la edición: " + ex.Message);
            }
        }
        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            // 1. Verificación de selección y estado de la grilla
            var item = dataGridViewCompras.CurrentRow?.DataBoundItem;
            if (item == null || checkBoxEliminados.Checked) return;

            try
            {
                // 2. Extraemos el ID de la compra desde el objeto anónimo del Grid
                dynamic row = item;
                int idCompra = (int)row.ID;
                string nombreProducto = (string)row.PRODUCTO;

                // 3. Confirmación semántica al usuario
                var mensaje = $"¿Desea eliminar el registro de '{nombreProducto}'? \nEsta acción moverá la transacción a la papelera.";
                if (MessageBox.Show(mensaje, "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    bool exito = await _compraServicioService.DeleteAsync(idCompra);

                    if (exito)
                    {
                        // RECARGA MASIVA: Trae el nuevo estado de la base de datos a la RAM
                        await SincronizarCacheConServidor();
                        MessageHelpers.ShowSuccess("Transacción eliminada correctamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelpers.ShowError($"No se pudo eliminar la compra: {ex.Message}");
            }
        }
        private async void BtnRestaurar_Click(object sender, EventArgs e)
        {
            // 1. Obtener el item seleccionado de la grilla (debe estar en modo "Eliminados")
            var item = dataGridViewCompras.CurrentRow?.DataBoundItem;
            if (item == null) return;

            try
            {
                // 2. Extraer ID y Nombre mediante el objeto anónimo dynamic
                dynamic row = item;
                int idCompra = (int)row.ID;
                string producto = (string)row.PRODUCTO;

                // 3. Confirmación semántica
                if (MessageBox.Show($"¿Desea restaurar la compra de '{producto}'?", "Restaurar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // 4. Ejecutar el Soft Restore solo en la tabla de compras
                    bool exito = await _compraServicioService.RestoreAsync(idCompra);

                    if (exito)
                    {
                        // 5. Sincronizar RAM para que el registro vuelva a la lista de activos
                        await SincronizarCacheConServidor();
                        MessageHelpers.ShowSuccess("Registro restaurado correctamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelpers.ShowError($"Error al restaurar: {ex.Message}");
            }
        }
        private async void checkBoxEliminados_CheckedChanged(object sender, EventArgs e)
        {
            await SincronizarCacheConServidor();
            BtnRestaurar.Visible = checkBoxEliminados.Checked;
            BtnEditar.Enabled = !checkBoxEliminados.Checked;
            BtnEliminar.Enabled = !checkBoxEliminados.Checked;
        }

        private void BtnBuscar_Click(object sender, EventArgs e) => RefrescarGrillaCompras();
        private void textBoxBuscar_TextChanged(object sender, EventArgs e) => RefrescarGrillaCompras();
        private void textBoxBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                RefrescarGrillaCompras();
            }
        }


        // TabPage Agregar/Editar | Controles
        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Determinar si es una nueva compra o edición de feedback
                bool esNuevo = _currentCompraServicio == null;
                CompraServicio compra = esNuevo ? new CompraServicio() : _currentCompraServicio!; // implementamos lo aprendido en clase: "!" indica que sabemos que no es nulo aquí.

                // 2. Mapeo de datos básicos (Producto y Notas)
                compra.Nombre = textBoxProductoServicio.Text.Trim();
                compra.Descripcion = textBoxDescripcion.Text.Trim();
                compra.NotasVentaInternas = textBoxNotasVentaInternas.Text.Trim();
                compra.FechaCompra = dateTime_FechaCompra.Value;
                compra.FechaRecordatorio = dateTime_FechaRecordatorio.Value;
                // 3. Asignación de actores (Solo en registros nuevos)
                if (esNuevo)
                {
                    compra.ClienteID = _currentCliente?.ID ?? 0;
                    compra.EmpleadoID = _currentUsuario?.ID ?? 0;
                }

                // 4. Seguimiento de Feedback (Disponible siempre)
                compra.FeedbackRecibido = checkBoxFeedbackRecibido.Checked;
                compra.ComentarioFeedback = textBoxFeedbackCliente.Text.Trim();

                if (esNuevo)
                {
                    await _compraServicioService.AddAsync(compra);
                }
                else
                {
                    await _compraServicioService.UpdateAsync(compra);
                }

                await SincronizarCacheConServidor(); // Recarga RAM masiva
                LimpiarControles();

                tabControl.SelectedTab = Lista_TabPage;
                MessageHelpers.ShowSuccess(esNuevo ? "Venta registrada con éxito." : "Feedback actualizado.");
            }
            catch (Exception ex)
            {
                MessageHelpers.ShowError($"No se pudo guardar: {ex.Message}");
            }
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            tabControl.SelectedTab = Lista_TabPage;
        }
        private void dateTime_FechaCompra_ValueChanged(object sender, EventArgs e)
        {
            // Solo sugerimos si es un registro nuevo para no sobreescribir ediciones manuales previas
            if (_currentCompraServicio == null)
            {
                dateTime_FechaRecordatorio.Value = dateTime_FechaCompra.Value.AddDays(7);
            }

            // Validación semántica: El recordatorio no puede ser antes que la compra
            dateTime_FechaRecordatorio.MinDate = dateTime_FechaCompra.Value;
        }
        private void checkBoxFeedbackRecibido_CheckedChanged(object sender, EventArgs e)
        {
            // Si ya recibimos feedback, bloqueamos las notas internas para auditoría
            textBoxNotasVentaInternas.Enabled = !checkBoxFeedbackRecibido.Checked;
        }

        private void BtnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            _isSelectingClient = true;
            lblSeleccionUsuarioCliente_Titulo.Text = "Seleccione el Cliente para esta Compra:";
            lblSeleccionUsuarioCliente_SubTitulo.Text = "Listado de Clientes Activos";

            RefrescarGrillaUsuario(); // Llenamos la grilla con clientes
            tabControl.SelectedTab = SeleccionarUsuario_TabPage;
        }
        private void BtnSeleccionarVendedor_Click(object sender, EventArgs e)
        {
            _isSelectingClient = false;
            lblSeleccionUsuarioCliente_Titulo.Text = "Seleccione el Vendedor para esta Compra:";
            lblSeleccionUsuarioCliente_SubTitulo.Text = "Listado de Vendedores";

            RefrescarGrillaUsuario(); // Llenamos la grilla con empleados
            tabControl.SelectedTab = SeleccionarUsuario_TabPage;
        }


        // TabPage Seleccionar Usuario | Controles
        private void BtnSeleccionarUsuario_Click(object sender, EventArgs e)
        {
            // 1. Validamos que haya una fila seleccionada en la grilla del selector
            // Usamos CurrentRow para detectar dónde está parado el usuario
            if (dataGridViewUsuarios.CurrentRow == null)
            {
                MessageHelpers.ShowWarning("Por favor, seleccione una fila de la lista.");
                return;
            }

            var item = dataGridViewUsuarios.CurrentRow.DataBoundItem;
            if (item == null) return;

            try
            {
                // 2. Extraemos el ID y los datos mediante reflexión dinámica
                dynamic row = item;
                int idRecuperado = (int)row.ID;
                string nombre = (string)row.NOMBRE;
                string dni = (string)row.DNI;

                // 3. Asignamos al objeto correspondiente según el estado de selección
                if (_isSelectingClient)
                {
                    // Buscamos el objeto real en la caché de Clientes
                    _currentCliente = _clientesCache.FirstOrDefault(c => c.ID == idRecuperado);

                    // Actualizamos el cuadro de texto del formulario de compras
                    textBoxCliente.Text = $"{nombre} (DNI: {dni})";
                }
                if (!_isSelectingClient)

                {
                    // Buscamos el objeto real en la caché de Usuarios (Vendedores/Admin)
                    _currentUsuario = _usuariosCache.FirstOrDefault(u => u.ID == idRecuperado);

                    // Actualizamos el cuadro de texto del formulario de compras
                    textBoxEmpleado.Text = $"{nombre} (DNI: {dni})";
                }

                // 4. Volvemos automáticamente a la pestaña de carga de compra
                tabControl.SelectedTab = AgregarEditar_TabPage;

                MessageHelpers.ShowSuccess($"{(_isSelectingClient ? "Cliente" : "Vendedor")} seleccionado: {nombre}");
            }
            catch (Exception ex)
            {
                MessageHelpers.ShowError("Error al procesar la selección: " + ex.Message);
            }
        }
        private void BtnCancelarSeleccion_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = AgregarEditar_TabPage;
        }


    }
}