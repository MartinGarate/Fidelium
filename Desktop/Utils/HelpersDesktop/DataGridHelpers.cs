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
            // Evita que el usuario modifique el grid manualmente
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.ReadOnly = true;
            // Configura el modo de selección de filas
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            // Ajusta el tamaño de las columnas automáticamente
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centra los encabezados
            grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centra el contenido de las celdas
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

        // Obtiene el ID de la fila seleccionada buscando en la columna especificada
        public static bool TryGetSelectedId(DataGridView grid, string columnName, out int id)
        {
            id = 0;
            return grid.SelectedRows.Count > 0 &&
                   int.TryParse(grid.SelectedRows[0].Cells[columnName].Value?.ToString(), out id);
        }
    }
}

