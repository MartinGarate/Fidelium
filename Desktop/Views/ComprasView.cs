using Desktop.Utils.HelpersDesktop;
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
        List<Notificacion> _notificacionCache = new ();

        // Objetos para la sesión de edición
        Cliente? _currentCliente;
        Usuario? _currentUsuario;
        CompraServicio? _currentCompraServicio;
        Notificacion? _currentNotificacion;




        public ComprasView()
        {
            InitializeComponent();
        }

        private async void ComprasView_Load(object sender, EventArgs e)
        {
            // Carga inicial masiva
            await Task.WhenAll(LoadDataUsuariosAsync(), LoadDataComprasAsync());
        }

        
        //CARGA DE DATOS (API -> MEMORIA)

        private async Task LoadDataComprasAsync()
        {
            try
            {
                // Traemos TODO de la base de datos sin filtro para tenerlo en RAM
                var compras = checkBoxEliminados.Checked
                    ? await _compraServicioService.GetAllDeletedsAsync("")
                    : await _compraServicioService.GetAllAsync("");

                _comprasCache = compras ?? new List<CompraServicio>();

                // Actualizamos la visual
                RefrescarVisualCompras();
            }
            catch (Exception ex)
            {
                MessageHelpers.ShowError($"Error al cargar compras: {ex.Message}");
            }
        }

        private async Task LoadDataUsuariosAsync()
        {
            try
            {
                var (clientes, usuarios) = checkBoxEliminados.Checked
                    ? (await _clienteService.GetAllDeletedsAsync(""), await _usuarioService.GetAllDeletedsAsync(""))
                    : (await _clienteService.GetAllAsync(""), await _usuarioService.GetAllAsync(""));

                _clientesCache = clientes ?? new List<Cliente>();
                _usuariosCache = usuarios ?? new List<Usuario>();

                AsociarUsuariosAClientes(_clientesCache, _usuariosCache);

                RefrescarVisualUsuarios();
            }
            catch (Exception ex)
            {
                MessageHelpers.ShowError($"Error al cargar usuarios: {ex.Message}");
            }
        }


        //FILTRADO Y VISUALIZACIÓN (MEMORIA -> GRID)

        private void RefrescarVisualCompras()
        {
            string filtro = textBoxBuscar.Text.Trim();

            // FILTRADO EN MEMORIA: Instantáneo, sin ir a la API
            var filtrados = _comprasCache.Where(c =>
                string.IsNullOrEmpty(filtro) ||
                (c.Nombre?.Contains(filtro, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (c.Descripcion?.Contains(filtro, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (c.Cliente?.Usuario?.Nombre?.Contains(filtro, StringComparison.OrdinalIgnoreCase) ?? false)
            ).ToList();

            var datosParaGrid = TransformarDatosParaGridCompras(filtrados);
            UpdateGridCompras(datosParaGrid);
        }

        private void RefrescarVisualUsuarios()
        {
            string filtro = textBoxBuscar.Text.Trim();

            var clientesFiltrados = _clientesCache.Where(c =>
                string.IsNullOrEmpty(filtro) ||
                (c.Usuario?.Nombre?.Contains(filtro, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (c.Usuario?.DNI?.Contains(filtro, StringComparison.OrdinalIgnoreCase) ?? false)
            ).ToList();

            var usuariosFiltrados = _usuariosCache.Where(u =>
                string.IsNullOrEmpty(filtro) ||
                (u.Nombre?.Contains(filtro, StringComparison.OrdinalIgnoreCase) ?? false)
            ).ToList();

            var datosParaGrid = TransformarDatosParaGridUsuarios(clientesFiltrados, usuariosFiltrados);
            UpdateGridUsuarios(datosParaGrid);
        }


       //EVENTOS DE UI

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            // No llamamos a LoadData (API), solo refrescamos la visual (RAM)
            RefrescarVisualCompras();
            RefrescarVisualUsuarios();
        }

        private async void checkBoxEliminados_CheckedChanged(object sender, EventArgs e)
        {
            // Aquí sí volvemos a la API porque el set de datos cambia radicalmente
            await Task.WhenAll(LoadDataUsuariosAsync(), LoadDataComprasAsync());
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            // El botón ya no es estrictamente necesario, pero lo dejamos por UX
            RefrescarVisualCompras();
            RefrescarVisualUsuarios();
        }

        

        //HELPERS Y TRANSFORMACIONES

        private object TransformarDatosParaGridCompras(List<CompraServicio> comprasServicios)
        {
            return comprasServicios.Select(c => new
            {
                c.ID,
                ClienteNombre = c.Cliente?.Usuario?.Nombre ?? "N/A",
                c.Nombre,
                c.Descripcion,
                c.FechaCompra,
                EmpleadoNombre = c.Empleado?.Nombre ?? "N/A",
                c.ComentarioFeedback,
                c.IsDeleted
            }).ToList();
        }

        private void UpdateGridCompras(object datos)
        {
            dataGridViewCompras.DataSource = null;
            dataGridViewCompras.DataSource = datos;
            DataGridHelpers.HideColumns(dataGridViewCompras, "ID", "ClienteID", "EmpleadoID", "IsDeleted");
            DataGridHelpers.RenameColumn(dataGridViewCompras, "FechaCompra", "Fecha de Compra");
            DataGridHelpers.SetupBasicGrid(dataGridViewCompras);
        }

        private void AsociarUsuariosAClientes(List<Cliente> clientes, List<Usuario> usuarios)
        {
            foreach (var cliente in clientes)
            {
                cliente.Usuario = usuarios.FirstOrDefault(u => u.ID == cliente.UsuarioID);
            }
        }

        private object TransformarDatosParaGridUsuarios(List<Cliente> clientes, List<Usuario> usuarios)
        {
            var listaFinal = new List<object>();

            foreach (var c in clientes)
            {
                listaFinal.Add(new
                {
                    c.ID,
                    DNI = c.Usuario?.DNI ?? "N/A",
                    c.Usuario?.Nombre,
                    c.Usuario?.Email,
                    Instagram = c.Instagram ?? "N/A",
                    ClienteTelefono = c.Telefono ?? "N/A",
                    Tipo = "Cliente"
                });
            }

            foreach (var u in usuarios)
            {
                if (!clientes.Any(c => c.UsuarioID == u.ID))
                {
                    listaFinal.Add(new
                    {
                        u.ID,
                        DNI = u.DNI ?? "N/A",
                        u.Nombre,
                        u.Email,
                        Instagram = "N/A",
                        ClienteTelefono = "N/A",
                        Tipo = u.TipoUsuario.ToString()
                    });
                }
            }
            return listaFinal;
        }

        private void UpdateGridUsuarios(object datos)
        {
            // Asumiendo que usas la misma grilla o una similar
            dataGridViewCompras.DataSource = null;
            dataGridViewCompras.DataSource = datos;
            DataGridHelpers.HideColumns(dataGridViewCompras, "ID");
            DataGridHelpers.SetupBasicGrid(dataGridViewCompras);
        }

    }
}