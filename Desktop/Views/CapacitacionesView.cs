using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Models;
using Service.Services;

namespace Desktop.Views
{
    public partial class CapacitacionesView : Form
    {
        GenericService<Cliente> _clienteService = new GenericService<Cliente>();
        GenericService<Usuario> _usuarioService = new GenericService<Usuario>();
        Cliente _currentCliente; // Capacitacion que esta seleccionada (con la que vamos a operar)
        Usuario _currentUsuario; // Capacitacion que esta seleccionada (con la que vamos a operar)
        List<Cliente> _clientes; // Lista de capacitaciones obtenidas de la API
        List<Usuario> _usuarios; // Lista de capacitaciones obtenidas de la API

        public CapacitacionesView()
        {
            InitializeComponent();
            _ = GetAllData();
            textBoxFiltrarAuto.ContextMenuStrip = contextMenuStripLimpiar; // Asignar el menú contextual al TextBox
            buttonRestaurar.Visible = false;
        }

        private void ConfigurarDataGridView()
        {


            // Crear columnas manualmente
            dataGridView.Columns.Add("Nombre", "Nombre");
            dataGridView.Columns.Add("Email", "Email");
            dataGridView.Columns.Add("DNI", "DNI");
            dataGridView.Columns.Add("TipoUsuario", "Tipo Usuario");
            dataGridView.Columns.Add("Instagram", "Instagram");
            dataGridView.Columns.Add("Telefono", "Teléfono");


            if (_clientes != null)
            {
                foreach (var cli in _clientes)
                {
                    var nombre = cli?.Usuario?.Nombre ?? "";
                    var email = cli?.Usuario?.Email ?? "";
                    var dni = cli?.Usuario?.DNI?.ToString() ?? "";
                    var tipoUsuario = cli?.Usuario?.TipoUsuario.ToString() ?? "";
                    var instagram = string.IsNullOrEmpty(cli?.Instagram) ? "" : cli.Instagram;
                    var telefono = string.IsNullOrEmpty(cli?.Telefono) ? "" : cli.Telefono;

                    dataGridView.Rows.Add(nombre, email, dni, tipoUsuario, instagram, telefono);
                }
            }

            // Opcional: ajustar el tamaño de las columnas
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private async Task GetAllData()
        {
            if (checkBox_VerEliminados.Checked)
            {
                _clientes = await _clienteService.GetAllDeletedsAsync();
            }
            else
                _clientes = await _clienteService.GetAllAsync();
            dataGridView.DataSource = _clientes;
            ConfigurarDataGridView();
        }

        private async void ButtonEliminarAuto_Click(object sender, EventArgs e)
        {
            // Verificamos que haya clientes seleccionados
            if (dataGridView.RowCount > 0 && dataGridView.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView.SelectedRows[0].Index;
                if (rowIndex >= 0 && rowIndex < _clientes.Count)
                {
                    Cliente clienteSeleccionado = _clientes[rowIndex];
                    var respuesta = MessageBox.Show($"¿Seguro que quieres borrar a {clienteSeleccionado.Usuario?.Nombre}?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        if (await _clienteService.DeleteAsync(clienteSeleccionado.ID))
                        {
                            MessageBox.Show($"{clienteSeleccionado.Usuario?.Nombre} ha sido borrado correctamente", "Borrado correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await GetAllData();
                        }
                        else
                        {
                            MessageBox.Show("Error al borrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe de seleccionar un campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewAutos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.RowCount > 0 && dataGridView.SelectedRows.Count > 0)
            {
                //Capacitacion autoSeleccionado = (Autos)dataGridViewAutos.SelectedRows[0].DataBoundItem;
                //pictureBoxAuto.ImageLocation = autoSeleccionado.imagen;
            }
        }

        private void ButtonBuscarAuto_Click(object sender, EventArgs e)
        {
            //string filtro = textBoxFiltrarAuto.Text?.Trim().ToLower() ?? string.Empty;

            //if (string.IsNullOrWhiteSpace(filtro))
            //{
            //    dataGridView.DataSource = null;
            //    dataGridView.DataSource = _capacitaciones;
            //    ConfigurarDataGridView();
            //    return;
            //}

            //var capacitacionesFiltrados = _capacitaciones
            //    .Where(c =>
            //        (!string.IsNullOrEmpty(c.Nombre) && c.Ponente.ToLower().ToString().Contains(filtro)).ToList());

            //dataGridViewAutos.DataSource = null;
            //dataGridViewAutos.DataSource = autosFiltrados;
            //ConfigurarDataGridView();
        }

        private void LimpiarCampos()
        {
            textBoxFiltrarAuto.Clear();
            dataGridView.ClearSelection();
            textBoxImagenAuto.Clear();
            textBoxMarcaAuto.Clear();
            numericAnioAuto.Value = numericAnioAuto.Minimum;
            textBoxModeloAuto.Clear();
            numericPrecioAuto.Value = numericPrecioAuto.Minimum;
            checkBoxUsado.Checked = false;
        }

        public void limpiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void textBoxFiltrarAuto_TextChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(textBoxFiltrarAuto.Text))
            //{
            //    ButtonBuscarAuto.PerformClick();
            //}
        }

        private void ButtonCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab("tabPageLista");
            LimpiarCampos();
        }

        private void ButtonEditarAuto_Click(object sender, EventArgs e)
        {

            //if (dataGridViewAutos.RowCount > 0 && dataGridViewAutos.SelectedRows.Count > 0)
            //{
            //    autoModificado = (Autos)dataGridViewAutos.SelectedRows[0].DataBoundItem;
            //    textBoxImagenAuto.Text = autoModificado.imagen;
            //    textBoxMarcaAuto.Text = autoModificado.marca;
            //    numericAnioAuto.Value = autoModificado.anio;
            //    textBoxModeloAuto.Text = autoModificado.modelo;
            //    numericPrecioAuto.Value = (decimal)autoModificado.precio;
            //    checkBoxUsado.Checked = autoModificado.usado;
            //    tabControl.SelectTab("tabPageAgregar_Editar");
            //}
            //else
            //{
            //    MessageBox.Show("No hay auto seleccionado para editar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        private async void ButtonGuardar_Click(object sender, EventArgs e)
        {
            //Autos autoAGuardar = new Autos
            //{
            //    imagen = textBoxImagenAuto.Text,
            //    marca = textBoxMarcaAuto.Text,
            //    anio = (int)numericAnioAuto.Value,
            //    modelo = textBoxModeloAuto.Text,
            //    precio = (double)numericPrecioAuto.Value,
            //    usado = checkBoxUsado.Checked
            //};
            //HttpResponseMessage response;
            //if (autoModificado != null)
            //{
            //    var urlEditar = $"https://autostock-c2a0.restdb.io/rest/autostock/{autoModificado._id}?apikey=d600303563746b80ed362976592e68879b394";
            //    response = await clientHttp.PutAsJsonAsync(urlEditar, autoAGuardar);
            //}
            //else
            //{
            //    response = await clientHttp.PostAsJsonAsync(url, autoAGuardar);
            //}
            //if (response.IsSuccessStatusCode)
            //{
            //    autoModificado = null;
            //    MessageBox.Show("El auto se guardó correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    ObtenemosAutos();
            //    tabControl.SelectTab("tabPageLista");
            //}
            //else
            //{
            //    MessageBox.Show("Error al guardar el auto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //LimpiarCampos();
        }

        private void textBoxImagenAuto_TextChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrWhiteSpace(textBoxImagenAuto.Text))
            //{
            //    pictureBoxImagenAuto.ImageLocation = textBoxImagenAuto.Text;
            //}
        }

        private void ButtonAgregarAuto_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab("tabPageAgregar_Editar");
            LimpiarCampos();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void checkBox_VerEliminados_CheckedChanged(object sender, EventArgs e)
        {
                await GetAllData(); 
                if (checkBox_VerEliminados.Checked)
                {
                    buttonRestaurar.Visible = true;
                }
                else
                {
                    buttonRestaurar.Visible = false;
            }

        }

        private async void buttonRestaurar_Click(object sender, EventArgs e)
        {
            if (!checkBox_VerEliminados.Checked)
            {
                MessageBox.Show("Debe de estar seleccionado 'Ver eliminados' para restaurar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dataGridView.RowCount > 0 && dataGridView.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView.SelectedRows[0].Index;
                if (rowIndex >= 0 && rowIndex < _clientes.Count)
                {
                    Cliente clienteSeleccionado = _clientes[rowIndex];
                    var respuesta = MessageBox.Show($"¿Seguro que quieres restaurar a {clienteSeleccionado.Usuario?.Nombre}?", "Restaurar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        if (await _clienteService.RestoreAsync(clienteSeleccionado.ID))
                        {
                            MessageBox.Show($"{clienteSeleccionado.Usuario?.Nombre} ha sido restaurado correctamente", "Restaurado correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await GetAllData();
                        }
                        else
                        {
                            MessageBox.Show("Error al restaurar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe de seleccionar un campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

