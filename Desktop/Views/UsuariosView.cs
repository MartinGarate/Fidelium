using Desktop.Utils.HelpersDesktop;
using Service.Models;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Desktop.Views
{
    public partial class UsuariosView : Form
    {
        private readonly GenericService<Usuario> _usuarioService = new(); // Readonly es una practica mas segura para no romper nada, evitando cambiarlo.
        private readonly GenericService<Cliente> _clienteService = new();

        public UsuariosView()
        {
            InitializeComponent();
        }

        private async void UsuariosView_Load(object sender, EventArgs e)
        {
            await GetAllData();
        }

        //  Obtener datos (SRP)
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

        //  Asociar usuarios a clientes (SRP)
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


        private void ActualizarGrid(object datos)
        {
            dataGridViewUsuarios.DataSource = null;
            dataGridViewUsuarios.DataSource = datos;
        }


        private async Task GetAllData(string? filtro = null)
        {
            try
            {
                var (clientes, usuarios) = await ObtenerDatosAsync(filtro);

                AsociarUsuariosAClientes(clientes, usuarios);

                var datosParaGrid = TransformarDatosParaGrid(clientes, usuarios);

                ActualizarGrid(datosParaGrid);
            }
            catch (Exception ex)
            {
                MessageHelpers.ShowError($"Error al cargar datos: {ex.Message}");
            }
        }
    }
}
