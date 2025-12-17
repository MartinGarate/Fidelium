using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Service.Enums;
using Service.Models;
using Service.Models.Service.Models;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MovilApp.ViewModels.Admin
{
    public partial class SeguimientoVentasViewViewModel : ObservableObject
    {
        // ==================== SERVICIOS DE DATOS ====================
        private readonly GenericService<Usuario> _usuarioService = new();
        private readonly GenericService<Cliente> _clienteService = new();
        private readonly GenericService<CompraServicio> _compraServicioService = new();

        // ==================== REPOSITORIO LOCAL SINCRONIZADO (CACHÉ RAM) ====================
        private List<Cliente> _clientesCache = new();
        private List<Usuario> _usuariosCache = new();
        private List<CompraServicio> _comprasCache = new();

        // ==================== COLECCIONES OBSERVABLES PARA LA UI ====================
        [ObservableProperty]
        private ObservableCollection<CompraServicio> compras = new();

        // ==================== ESTADOS Y FILTROS ====================
        [ObservableProperty]
        private bool isRefreshing;

        [ObservableProperty]
        private string filterText = string.Empty;

        [ObservableProperty]
        private ModoVistaCompra modoVistaSeleccionado = ModoVistaCompra.TodasLasCompras;

        [ObservableProperty]
        private string errorMessage = string.Empty;

        // ==================== PROPIEDADES PARA EL PICKER ====================
        public List<string> ModosDeVista { get; } = new()
        {
            "TodasLasCompras",
            "FeedbacksRecibidos",
            "FeedbacksPendientes"
        };

        [ObservableProperty]
        private string modoVistaSeleccionadoTexto = "TodasLasCompras";

        // ==================== ENUMERACIÓN DE MODOS DE VISTA ====================
        public enum ModoVistaCompra
        {
            TodasLasCompras,
            FeedbacksRecibidos,
            FeedbacksPendientes
        }

        // ==================== COMANDOS ====================
        public IAsyncRelayCommand RefreshCommand { get; }
        public IAsyncRelayCommand BuscarCommand { get; }

        // ==================== CONSTRUCTOR ====================
        public SeguimientoVentasViewViewModel()
        {
            // Inicializar comandos
            RefreshCommand = new AsyncRelayCommand(SincronizarCacheConServidor);
            BuscarCommand = new AsyncRelayCommand(RefrescarGrillaCompras);

            // Cargar datos iniciales
            _ = SincronizarCacheConServidor();
        }

        // ==================== LÓGICA DE SINCRONIZACIÓN Y DATOS ====================
        private async Task SincronizarCacheConServidor()
        {
            try
            {
                IsRefreshing = true;
                ErrorMessage = string.Empty;

                // Carga normal - solo registros activos
                _clientesCache = await _clienteService.GetAllAsync("") ?? new List<Cliente>();
                _usuariosCache = await _usuarioService.GetAllAsync("") ?? new List<Usuario>();
                _comprasCache = await _compraServicioService.GetAllAsync("") ?? new List<CompraServicio>();

                // VINCULACIÓN EN RAM
                // Vinculamos Cliente -> Usuario para tener el Nombre/DNI
                foreach (var c in _clientesCache)
                    c.Usuario = _usuariosCache.FirstOrDefault(u => u.ID == c.UsuarioID);

                // Vinculamos Compra -> Cliente y Empleado
                foreach (var cs in _comprasCache)
                {
                    cs.Cliente = _clientesCache.FirstOrDefault(c => c.ID == cs.ClienteID);
                    cs.Empleado = _usuariosCache.FirstOrDefault(u => u.ID == cs.EmpleadoID);
                }

                // ACTUALIZACIÓN VISUAL
                await RefrescarGrillaCompras();
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error al sincronizar datos: {ex.Message}";
                if (Application.Current?.MainPage != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ErrorMessage, "OK");
                }
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        private async Task RefrescarGrillaCompras()
        {
            try
            {
                string filtroTexto = FilterText.Trim();

                // Usar método helper para filtrado cuando hay texto de búsqueda
                var comprasFiltradas = string.IsNullOrEmpty(filtroTexto)
                    ? _comprasCache
                    : _comprasCache.Where(cs => CompraMatchesFilter(cs, filtroTexto));

                // Filtro por Estado (Enum)
                comprasFiltradas = ModoVistaSeleccionado switch
                {
                    ModoVistaCompra.FeedbacksRecibidos => comprasFiltradas.Where(cs => cs.FeedbackRecibido == true),
                    ModoVistaCompra.FeedbacksPendientes => comprasFiltradas.Where(cs => cs.FeedbackRecibido == false),
                    _ => comprasFiltradas
                };

                // Ordenamiento y Binding
                var comprasOrdenadas = comprasFiltradas.OrderByDescending(cs => cs.FechaCompra).ToList();

                Compras = new ObservableCollection<CompraServicio>(comprasOrdenadas);
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error al refrescar lista: {ex.Message}";
            }

            await Task.CompletedTask;
        }

        private bool CompraMatchesFilter(CompraServicio compra, string filtro)
        {
            // Verificación segura del nombre del producto
            if (compra.Nombre?.Contains(filtro, StringComparison.OrdinalIgnoreCase) == true)
                return true;

            // Verificación segura del nombre del cliente
            if (compra.Cliente?.Usuario?.Nombre?.Contains(filtro, StringComparison.OrdinalIgnoreCase) == true)
                return true;

            // Verificación segura del nombre del empleado
            if (compra.Empleado?.Nombre?.Contains(filtro, StringComparison.OrdinalIgnoreCase) == true)
                return true;

            return false;
        }

        // ==================== PROPIEDADES COMPUTADAS ====================
        partial void OnModoVistaSeleccionadoTextoChanged(string value)
        {
            ModoVistaSeleccionado = value switch
            {
                "FeedbacksRecibidos" => ModoVistaCompra.FeedbacksRecibidos,
                "FeedbacksPendientes" => ModoVistaCompra.FeedbacksPendientes,
                _ => ModoVistaCompra.TodasLasCompras
            };
            
            _ = RefrescarGrillaCompras();
        }

        partial void OnFilterTextChanged(string value)
        {
            _ = RefrescarGrillaCompras();
        }
    }
}
