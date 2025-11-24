using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Utils.HelpersDesktop
{
    public static class DataGridHelpers
    {
        // Configura las propiedades básicas de seguridad y visualización del grid
        public static void SetupBasicGrid(DataGridView grid)
        {
            // --- Comportamiento ---
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.AllowUserToResizeColumns = false;
            grid.AllowUserToResizeRows = false;

            // --- Encabezados ---
            grid.EnableHeadersVisualStyles = false; // Permite custom UI
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            // --- Estilo general ---
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.FromArgb(220, 220, 220); // gris suave

            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 153, 255); // azul suave
            grid.DefaultCellStyle.SelectionForeColor = Color.White;

            // --- Zebra style (filas alternadas) ---
            grid.RowsDefaultCellStyle.BackColor = Color.White;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245); // gris casi blanco

            // --- Row headers (si están visibles) ---
            grid.RowHeadersVisible = false; // opcional
        }



        // Oculta las columnas especificadas del grid
        public static void HideColumns(DataGridView grid, params string[] columns)
        {
            foreach (var column in columns)
            {
                // Solo intenta ocultar si la columna existe
                if (grid.Columns.Contains(column))
                    grid.Columns[column].Visible = false;
            }
        }

       

        // cambia el nombre de una columna en el grid
        public static void RenameColumn(DataGridView grid, string columnName, string newHeaderText)
        {
            if (grid.Columns.Contains(columnName))
                grid.Columns[columnName].HeaderText = newHeaderText;
        }


    }
}

