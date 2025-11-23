using Desktop.Utils.HelpersDesktop;
using Service.Models;
using Service.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class UsuariosView : Form
    {
        GenericService<Usuario> _usuarioService = new();
        GenericService<Cliente> _clienteService = new();
        List<Usuario> _usuarios = new();
        List<Cliente> _clientes = new();

        public UsuariosView()
        {
            InitializeComponent();
        }
        private async void UsuariosView_Load(object sender, EventArgs e)
        {
            await GetAllData();
        }

        private async Task<(List<Cliente> clientes, List<Usuario> usuarios)> ObtenerDatosAsync(string? filtro = null)
        {
            if (checkBoxEliminados.Checked)
            {
                var clientes = await _clienteService.GetAllDeletedsAsync(filtro) ?? new List<Cliente>();
                var usuarios = await _usuarioService.GetAllDeletedsAsync(filtro) ?? new List<Usuario>();
                return (clientes, usuarios);
            }
            else
            {
                var clientes = await _clienteService.GetAllAsync(filtro) ?? new List<Cliente>();
                var usuarios = await _usuarioService.GetAllAsync(filtro) ?? new List<Usuario>();
                return (clientes, usuarios);
            }
        }
        private void AsociarUsuariosAClientes(List<Cliente> clientes, List<Usuario> usuarios)
        {
            foreach (var cliente in clientes)
            {
                cliente.Usuario = usuarios.FirstOrDefault(u => u.ID == cliente.UsuarioID);
            }
        }
        private object TransformarDatosParaGrid(List<Cliente> clientes)
        {
            // Retorna una lista que el DataGridView puede manejar.
            var datosParaGrid = clientes.Select(c => new
            {
                c.ID,
                // Acceso seguro a la propiedad Usuario que fue asignada previamente
                DNI = c.Usuario?.DNI,
                Nombre = c.Usuario?.Nombre,
                Email = c.Usuario?.Email,

                // Datos propios del Cliente
                Instagram = c.Instagram ?? "N/A",
                ClienteTelefono = c.Telefono ?? "N/A",
            }).ToList();

            return datosParaGrid; // Retorna List<tipo anónimo> como 'object'
        }
        private void ActualizarGrid(object datos)
        {
            dataGridViewUsuarios.DataSource = null;
            dataGridViewUsuarios.DataSource = datos;
            DataGridHelpers.HideColumns(dataGridViewUsuarios, "UsuarioID", "IsDeleted");
        }
        private async Task GetAllData(string? filtro = null)
        {
            try
            {
                // 1. Obtención de datos
                var (clientes, usuarios) = await ObtenerDatosAsync(filtro);

                if (clientes == null || usuarios == null)
                {
                    MessageHelpers.ShowError("No se pudieron cargar los datos del servidor");
                    return;
                }

                //  Asociación de Datos (SRP)
                AsociarUsuariosAClientes(clientes, usuarios);

                //  Transformación de Datos (SRP)
                var datosParaGrid = TransformarDatosParaGrid(clientes);

                //  Actualización de Interfaz (SRP)
                ActualizarGrid(datosParaGrid);
            }
            catch (Exception ex)
            {
                MessageHelpers.ShowError($"Error al cargar datos: {ex.Message}");
            }
        }

    }
}

      