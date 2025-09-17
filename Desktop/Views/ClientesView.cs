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
    public partial class ClientesView : Form
    {
        GenericService<Cliente> _clienteService = new GenericService<Cliente>();
        Cliente _currentCliente; // Capacitacion que esta seleccionada (con la que vamos a operar)
        List<Cliente> _capacitaciones; // Lista de capacitaciones obtenidas de la API

        public ClientesView()
        {
            InitializeComponent();
            _=GetAllData();
            textBoxFiltrarAuto.ContextMenuStrip = contextMenuStripLimpiar; // Asignar el menú contextual al TextBox
        }

        private void ConfigurarDataGridView()
        {
                dataGridView.Columns["Id"].Visible = false;
                dataGridView.Columns["IsDeleted"].Visible = false;
                dataGridView.Columns["DeleteTime"].Visible = false;
                dataGridView.Columns["FechaHora"].Name = "Fecha y Hora";
                dataGridView.Columns["InscripcionAbierta"].Name = "Inscripción Abierta";

        }

        private async Task GetAllData()
        {
            //_clientes = await _clienteService.GetAllAsync();
            dataGridView.DataSource = _capacitaciones;
            ConfigurarDataGridView();
        }

        private async void ButtonEliminarAuto_Click(object sender, EventArgs e)
        {
            //checkeamos que haya autos seleccionados
            //if (dataGridView.RowCount > 0 && dataGridView.SelectedRows.Count > 0)
            //{
            //    Cliente entitySelected = (Cliente)dataGridView.SelectedRows[0].DataBoundItem;
            //    //var respuesta = MessageBox.Show($"¿Seguro que quieres borrar {entitySelected.Nombre}?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //    if (respuesta == DialogResult.Yes)
            //    {
                    
            //        //if (await _clienteService.DeleteAsync(entitySelected.Id))
            //        {
            //            //MessageBox.Show($"El {entitySelected.Nombre} ha sido borrado correctamente", "Borrado correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            await GetAllData();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Error al borrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Debe de seleccionar un campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
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
            //    dataGridViewAutos.DataSource = null;
            //    dataGridViewAutos.DataSource = autos;
            //    ConfigurarDataGridView();
            //    return;
            //}

            //var autosFiltrados = autos
            //    .Where(p =>
            //        (!string.IsNullOrEmpty(p.modelo) && p.modelo.ToLower().Contains(filtro)) ||
            //        (!string.IsNullOrEmpty(p.marca) && p.marca.ToLower().Contains(filtro)) ||
            //        p.anio.ToString().Contains(filtro)
            //    )
            //    .ToList();

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
    }
}

