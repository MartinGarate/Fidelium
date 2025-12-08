using Microsoft.Reporting.WinForms;
using Service.Models;
using Service.Models.Service.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Desktop.ViewReports
{
    public partial class FeedbackPendientesViewReport : Form
    {
        private readonly ReportViewer _report;
        private readonly List<CompraServicio> _comprasPendientes;

        // Constructor adaptado: Recibimos la lista filtrada de la View principal
        public FeedbackPendientesViewReport(List<CompraServicio> comprasPendientes)
        {
            InitializeComponent();
            _comprasPendientes = comprasPendientes;

            _report = new ReportViewer();
            _report.Dock = DockStyle.Fill;
            this.Controls.Add(_report);

            // Suscribimos el evento Load programáticamente si no está en el diseñador
            this.Load += FeedbackPendientesViewReport_Load;
        }

        private void FeedbackPendientesViewReport_Load(object sender, EventArgs e)
        {
            // 1. Apuntamos al archivo RDLC (Asegúrate que la ruta sea correcta)
            _report.LocalReport.ReportEmbeddedResource = "Desktop.Reports.FeedbackPendientesReport.rdlc";

            // 2. Transformamos los datos vinculados incluyendo información de contacto
            var dataset = _comprasPendientes.Select(cs => new
            {
                Producto = cs.Nombre ?? "Sin Nombre",
                Cliente = cs.Cliente?.Usuario != null
                    ? $"{cs.Cliente.Usuario.Nombre} (DNI: {cs.Cliente.Usuario.DNI})"
                    : "N/A",

                // CAMPOS DE CONTACTO (NUEVO)
                Telefono = cs.Cliente?.Telefono ?? "Sin Teléfono",
                Instagram = cs.Cliente?.Instagram ?? "Sin IG",
                Email = cs.Cliente?.Usuario?.Email ?? "Sin Email",

                Vendedor = cs.Empleado?.Nombre ?? "N/A",
                FechaCompra = cs.FechaCompra.ToString("dd/MM/yyyy"),
                FechaRecordatorio = cs.FechaRecordatorio.ToString("dd/MM/yyyy"),
                Notas = cs.NotasVentaInternas ?? ""
            }).ToList();

            // 3. Limpiamos y cargamos el DataSource (Nombre debe coincidir con el del RDLC)
            _report.LocalReport.DataSources.Clear();
            _report.LocalReport.DataSources.Add(new ReportDataSource("DSComprasPendientes", dataset));

            // 4. Configuración estética de impresión
            _report.SetDisplayMode(DisplayMode.PrintLayout);
            _report.ZoomMode = ZoomMode.Percent;
            _report.ZoomPercent = 100;

            _report.RefreshReport();
        }
    }
}