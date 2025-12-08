using Desktop.Utils.HelpersDesktop;
using Service.Enums;
using Service.Models;
using Service.Models.Service.Models;
using Service.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class SeguimientoVentasView : Form
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
        public enum ModoVistaCompra
        {
            TodasLasCompras,
            FeedbacksRecibidos,
            FeedbacksPendientes
        }

        public SeguimientoVentasView()
        {
            InitializeComponent();
        }

        private async void ComprasView_Load(object sender, EventArgs e)
        {
            // 1. Desvinculamos el evento para evitar excepciones por datos nulos
            comboBoxModoVista.SelectedIndexChanged -= comboBoxModoVista_SelectedIndexChanged;

            await SincronizarCacheConServidor();

            // Definimos la fuente de datos
            var modos = new[] {
        new { Texto = "Todas las Compras", Valor = ModoVistaCompra.TodasLasCompras },
        new { Texto = "Feedbacks Recibidos", Valor = ModoVistaCompra.FeedbacksRecibidos },
        new { Texto = "Feedbacks Pendientes", Valor = ModoVistaCompra.FeedbacksPendientes }
    };

            // 2. IMPORTANTE: Configurar Display y Value ANTES del DataSource 
            // Esto ayuda a WinForms a preparar la estructura interna
            comboBoxModoVista.DisplayMember = "Texto";
            comboBoxModoVista.ValueMember = "Valor";
            comboBoxModoVista.DataSource = modos;

            // 3. Verificamos disponibilidad antes de asignar el índice
            if (comboBoxModoVista.Items.Count > 0)
            {
                comboBoxModoVista.SelectedIndex = 0;
            }

            // 4. Volvemos a vincular el evento
            comboBoxModoVista.SelectedIndexChanged += comboBoxModoVista_SelectedIndexChanged;

            // 5. Refresco manual inicial
            RefrescarGrillaCompras();
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
            // Verificación de nulidad y estabilidad
            if (comboBoxModoVista.SelectedValue == null) return;

            string filtroTexto = textBoxBuscar.Text.Trim();

            // Extraemos el valor real del objeto anónimo
            ModoVistaCompra modoSeleccionado = (ModoVistaCompra)comboBoxModoVista.SelectedValue;

            var query = _comprasCache.AsQueryable();

            if (!string.IsNullOrEmpty(filtroTexto))
            {
                query = query.Where(cs =>
                    (cs.Nombre != null && cs.Nombre.Contains(filtroTexto, StringComparison.OrdinalIgnoreCase)) ||
                    (cs.Cliente != null && cs.Cliente.Usuario != null && cs.Cliente.Usuario.Nombre != null &&
                     cs.Cliente.Usuario.Nombre.Contains(filtroTexto, StringComparison.OrdinalIgnoreCase)) ||
                    (cs.Empleado != null && cs.Empleado.Nombre != null &&
                     cs.Empleado.Nombre.Contains(filtroTexto, StringComparison.OrdinalIgnoreCase))
                );
            }

            // 4. Filtro por Estado (Enum)
            switch (modoSeleccionado)
            {
                case ModoVistaCompra.FeedbacksRecibidos:
                    query = query.Where(cs => cs.FeedbackRecibido == true);
                    break;
                case ModoVistaCompra.FeedbacksPendientes:
                    query = query.Where(cs => cs.FeedbackRecibido == false);
                    break;
            }

            // 5. Ordenamiento y Binding
            var comprasFiltradas = query.OrderByDescending(cs => cs.FechaCompra).ToList();

            // Limpiamos siempre el DataSource antes para evitar conflictos de columnas
            dataGridViewCompras.DataSource = null;
            dataGridViewCompras.DataSource = TransformarParaUICompras(comprasFiltradas);

            // 6. Lógica de estética y cabeceras (DataGridHelpers)
            if (dataGridViewCompras.ColumnCount > 0)
            {
                // Ocultamos el ID que usamos para editar/eliminar pero que el usuario no ve
                DataGridHelpers.HideColumns(dataGridViewCompras, "ID");

                // Aplica colores, bordes y estilos básicos definidos en tu helper
                DataGridHelpers.SetupBasicGrid(dataGridViewCompras);

                // Renombramos cabeceras para que se vean profesionales
                DataGridHelpers.RenameColumn(dataGridViewCompras, "FECHA", "FECHA VENTA");
            }
        }
        private List<object> TransformarParaUICompras(List<CompraServicio> compras)
        {
            // Obtenemos el modo usando SelectedValue igual que arriba
            ModoVistaCompra modoActual = comboBoxModoVista.SelectedValue is ModoVistaCompra modo
                                         ? modo
                                         : ModoVistaCompra.TodasLasCompras;

            var datosParaGrilla = compras.Select(cs =>
            {
                if (modoActual == ModoVistaCompra.FeedbacksRecibidos)
                {
                    return (object)new
                    {
                        PRODUCTO = cs.Nombre ?? "Sin Nombre",
                        CLIENTE = cs.Cliente?.Usuario?.Nombre ?? "N/A",
                        COMENTARIO = cs.ComentarioFeedback ?? "Sin comentarios",
                        ID = (int)cs.ID,
                    };
                }
                else
                {
                    return (object)new
                    {
                        PRODUCTO = cs.Nombre ?? "Sin Nombre",
                        CLIENTE = cs.Cliente?.Usuario?.Nombre ?? "N/A",
                        VENDEDOR = cs.Empleado?.Nombre ?? "N/A",
                        FECHA = cs.FechaCompra.ToShortDateString(),
                        RECORDATORIO = cs.FechaRecordatorio.ToShortDateString(),
                        FEEDBACK = cs.FeedbackRecibido ? "Recibido" : "Pendiente",
                        ID = (int)cs.ID
                    };
                }
            });

            return datosParaGrilla.ToList();
        }


        private void RefrescarGrillaUsuario()
        {
            // 1. Capturamos el texto de búsqueda
            string filtro = textBoxBuscarUsuario.Text.Trim();
            List<object> datosAMostrar;

            if (_isSelectingClient)
            {
                // Filtramos la lista de Clientes
                var clientesFiltrados = _clientesCache.Where(c =>
                    string.IsNullOrEmpty(filtro) ||
                    (c.Usuario?.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (c.Usuario?.DNI.Contains(filtro, StringComparison.OrdinalIgnoreCase) ?? false)
                ).ToList();

                datosAMostrar = TransformarParaUICliente(clientesFiltrados);
            }
            else
            {
                // Filtramos la lista de Vendedores (Usuarios puros)
                var vendedoresFiltrados = _usuariosCache.Where(u =>
                    u.TipoUsuario != TipoUsuarioEnum.Cliente &&
                    (string.IsNullOrEmpty(filtro) ||
                     u.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                     u.DNI.Contains(filtro, StringComparison.OrdinalIgnoreCase))
                ).ToList();

                datosAMostrar = TransformarParaUIUsuarioPuro(vendedoresFiltrados);
            }

            // 2. Binding y Estética
            dataGridViewUsuarios.DataSource = null;
            dataGridViewUsuarios.DataSource = datosAMostrar;

            if (dataGridViewUsuarios.ColumnCount > 0)
            {
                DataGridHelpers.HideColumns(dataGridViewUsuarios, "ID");
                DataGridHelpers.SetupBasicGrid(dataGridViewUsuarios);
            }
        }
        private List<object> TransformarParaUICliente(List<Cliente> origen)
        {
            return origen.Select(c => new
            {
                NOMBRE = c.Usuario?.Nombre ?? "N/A",
                DNI = c.Usuario?.DNI ?? "N/A",
                TIPO = "Cliente",
                ID = (int)c.ID
            }).Cast<object>().ToList();
        }

        private List<object> TransformarParaUIUsuarioPuro(List<Usuario> origen)
        {
            return origen.Select(u => new
            {
                NOMBRE = u.Nombre ?? "N/A",
                DNI = u.DNI ?? "N/A",
                TIPO = u.TipoUsuario.ToString(), // .ToString() evita el error de casting de Enum
                ID = (int)u.ID
            }).Cast<object>().ToList();
        }
        private void DetectarTipoUsuario(bool esCliente)
        {
            var item = dataGridViewUsuarios.CurrentRow?.DataBoundItem;
            if (item == null) return;

            try
            {
                dynamic row = item;
                int idRecuperado = (int)row.ID;

                if (esCliente)
                {
                    _currentCliente = _clientesCache.FirstOrDefault(c => c.ID == idRecuperado);
                    _currentUsuario = _currentCliente?.Usuario;

                    if (_currentUsuario != null)
                        textBoxCliente.Text = $"{_currentUsuario.Nombre} (DNI: {_currentUsuario.DNI})";
                }
                else
                {
                    _currentUsuario = _usuariosCache.FirstOrDefault(u => u.ID == idRecuperado);
                    _currentCliente = null;

                    if (_currentUsuario != null)
                        textBoxEmpleado.Text = $"{_currentUsuario.Nombre} (DNI: {_currentUsuario.DNI})";
                }

                if (_currentUsuario != null)
                {
                    labelAccion.Text = esCliente ? "Cliente seleccionado" : "Vendedor seleccionado";
                    tabControl.SelectedTab = AgregarEditar_TabPage;
                }
            }
            catch (Exception ex)
            {
                MessageHelpers.ShowError("Error al seleccionar usuario: " + ex.Message);
            }
        }


        // MÉTODOS AUXILIARES DE CONTROLES
        private void CargarDatosEnControles(CompraServicio cs)
        {
            // 1. Definimos el límite seguro para WinForms/SQL (1 de enero de 1753)
            DateTime fechaMinimaSegura = new DateTime(1753, 1, 1);

            // 2. RESETEAR LÍMITES ANTES DE ASIGNAR VALOR
            // Usamos el límite real del picker para evitar la excepción de '0001-01-01'
            dateTime_FechaCompra.MinDate = fechaMinimaSegura;
            dateTime_FechaCompra.MaxDate = DateTime.MaxValue;
            dateTime_FechaRecordatorio.MinDate = fechaMinimaSegura;
            dateTime_FechaRecordatorio.MaxDate = DateTime.MaxValue;

            // 3. ASIGNACIÓN SEGURA DE FECHAS (Validación contra año 0001)
            if (cs.FechaCompra >= fechaMinimaSegura)
            {
                dateTime_FechaCompra.Value = cs.FechaCompra;
            }
            else
            {
                dateTime_FechaCompra.Value = DateTime.Now;
            }

            if (cs.FechaRecordatorio >= fechaMinimaSegura)
            {
                dateTime_FechaRecordatorio.Value = cs.FechaRecordatorio;
            }
            else
            {
                // Si no hay fecha de recordatorio válida, sugerimos +7 días sobre la compra
                dateTime_FechaRecordatorio.Value = dateTime_FechaCompra.Value.AddDays(7);
            }

            // 4. LÓGICA DE MÍNIMO DINÁMICO
            // Ahora que ambos tienen valores seguros, fijamos que el recordatorio sea posterior a la compra
            dateTime_FechaRecordatorio.MinDate = dateTime_FechaCompra.Value;

            // 5. DATOS DE PERSONAS (UI)
            textBoxCliente.Text = cs.Cliente?.Usuario != null
                ? $"{cs.Cliente.Usuario.Nombre} (DNI: {cs.Cliente.Usuario.DNI})"
                : "N/A";

            textBoxEmpleado.Text = cs.Empleado != null
                ? $"{cs.Empleado.Nombre} (DNI: {cs.Empleado.DNI})"
                : "N/A";

            // 6. DATOS DE LA TRANSACCIÓN
            textBoxProductoServicio.Text = cs.Nombre;
            textBoxDescripcion.Text = cs.Descripcion ?? "";
            textBoxNotasVentaInternas.Text = cs.NotasVentaInternas ?? "";

            // 7. SEGUIMIENTO POST-VENTA
            checkBoxFeedbackRecibido.Checked = cs.FeedbackRecibido;
            textBoxFeedbackCliente.Text = cs.ComentarioFeedback ?? "";

            // 8. BLOQUEO DE EDICIÓN
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

            // IMPORTANTE: Resetear límites antes de asignar fechas
            dateTime_FechaCompra.MinDate = new DateTime(1753, 1, 1);
            dateTime_FechaRecordatorio.MinDate = new DateTime(1753, 1, 1);

            // 3. Resetear fechas a la actualidad
            dateTime_FechaCompra.Value = DateTime.Now;
            dateTime_FechaRecordatorio.Value = DateTime.Now.AddDays(7);

            // Fijamos el mínimo dinámico
            dateTime_FechaRecordatorio.MinDate = dateTime_FechaCompra.Value;

            // 4. Resetear estados booleanos
            checkBoxFeedbackRecibido.Checked = false;


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
            // Bloqueamos la grilla visualmente para dar feedback de carga
            dataGridViewCompras.Enabled = false;

            try
            {
                // 1. Volvemos a pedir los datos al servidor según el nuevo estado del checkbox
                await SincronizarCacheConServidor();

                // 2. Ajustamos visibilidad de botones
                BtnRestaurar.Visible = checkBoxEliminados.Checked;
                BtnEditar.Enabled = !checkBoxEliminados.Checked;
                BtnEliminar.Enabled = !checkBoxEliminados.Checked;

                // El botón Agregar suele ocultarse en la papelera para evitar errores
                BtnAgregar.Enabled = !checkBoxEliminados.Checked;
            }
            finally
            {
                dataGridViewCompras.Enabled = true;
            }
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
        private void comboBoxModoVista_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefrescarGrillaCompras();
        }
        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. DETERMINAR MODO (NUEVO O EDICIÓN)
                bool esNuevo = _currentCompraServicio == null;

                // 2. VALIDACIONES PREVIAS (SEGURIDAD DE DATOS)
                // Validar que el nombre del producto no esté vacío
                if (string.IsNullOrWhiteSpace(textBoxProductoServicio.Text))
                {
                    MessageHelpers.ShowWarning("El nombre del producto o servicio es obligatorio.");
                    return;
                }

                // Si es un registro nuevo, verificar obligatoriamente Cliente y Vendedor
                if (esNuevo)
                {
                    if (_currentCliente == null || _currentCliente.ID == 0)
                    {
                        MessageHelpers.ShowWarning("Debe seleccionar un Cliente para registrar esta compra.");
                        return;
                    }

                    if (_currentUsuario == null || _currentUsuario.ID == 0)
                    {
                        MessageHelpers.ShowWarning("Debe seleccionar un Vendedor para esta transacción.");
                        return;
                    }
                }

                // 3. MAPEO DE OBJETO
                CompraServicio compra = esNuevo ? new CompraServicio() : _currentCompraServicio!;

                // Datos básicos
                compra.Nombre = textBoxProductoServicio.Text.Trim();
                compra.Descripcion = textBoxDescripcion.Text.Trim();
                compra.NotasVentaInternas = textBoxNotasVentaInternas.Text.Trim();

                // Fechas (Ya validadas dinámicamente en el control visual)
                compra.FechaCompra = dateTime_FechaCompra.Value;
                compra.FechaRecordatorio = dateTime_FechaRecordatorio.Value;

                // IDs de Relación (Solo en registros nuevos)
                if (esNuevo)
                {
                    compra.ClienteID = _currentCliente.ID; // Ya validado arriba que no es null
                    compra.EmpleadoID = _currentUsuario.ID; // Ya validado arriba que no es null
                }

                // Feedback (Disponible siempre para edición o carga inicial)
                compra.FeedbackRecibido = checkBoxFeedbackRecibido.Checked;
                compra.ComentarioFeedback = textBoxFeedbackCliente.Text.Trim();

                // 4. PERSISTENCIA EN SERVIDOR
                if (esNuevo)
                {
                    await _compraServicioService.AddAsync(compra);
                }
                else
                {
                    await _compraServicioService.UpdateAsync(compra);
                }

                // 5. FINALIZACIÓN Y LIMPIEZA
                await SincronizarCacheConServidor(); // Recarga la RAM local con los datos del servidor
                LimpiarControles();

                tabControl.SelectedTab = Lista_TabPage;
                MessageHelpers.ShowSuccess(esNuevo ? "Venta registrada con éxito." : "Registro de feedback actualizado correctamente.");
            }
            catch (Exception ex)
            {
                // Captura errores de red, base de datos (FK) o lógica de servidor
                MessageHelpers.ShowError($"No se pudo completar la operación: {ex.Message}");
            }
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            tabControl.SelectedTab = Lista_TabPage;
        }
        private void dateTime_FechaCompra_ValueChanged(object sender, EventArgs e)
        {
            // Bloqueo de seguridad: Evitar procesar si la fecha es inválida (año 0001)
            if (dateTime_FechaCompra.Value < new DateTime(1753, 1, 1)) return;

            // 1. Reset temporal para permitir cambios
            dateTime_FechaRecordatorio.MinDate = new DateTime(1753, 1, 1);

            // 2. Solo sugerimos +7 días si es un registro nuevo
            if (_currentCompraServicio == null)
            {
                dateTime_FechaRecordatorio.Value = dateTime_FechaCompra.Value.AddDays(7);
            }

            // 3. Validación lógica
            if (dateTime_FechaRecordatorio.Value < dateTime_FechaCompra.Value)
                dateTime_FechaRecordatorio.Value = dateTime_FechaCompra.Value;

            // 4. Fijar el mínimo real
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
        private void textBoxBuscarUsuario_TextChanged(object sender, EventArgs e) => RefrescarGrillaUsuario();
        private void BtnBuscarUsuario_Click(object sender, EventArgs e) => RefrescarGrillaUsuario();

    }
}