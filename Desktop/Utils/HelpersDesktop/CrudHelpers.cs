using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Utils.HelpersDesktop
{
    public static class CrudHelpers
    {
        public static async Task<bool> DeleteEntity<T>(
            IGenericService<T> service,
            int id,
            string entityName) where T : class
        {
            var confirmResult = MessageHelpers.ShowConfirmation(
                $"¿Seguro que quieres borrar {entityName}?", "Borrar");

            if (confirmResult == DialogResult.Yes)
            {
                if (await service.DeleteAsync(id))
                {
                    MessageHelpers.ShowSuccess($"{entityName} ha sido borrado correctamente");
                    return true;
                }
                MessageHelpers.ShowError("Error al borrar");
            }
            return false;
        }

        public static async Task<bool> RestoreEntity<T>(
            IGenericService<T> service,
            int id,
            string entityName) where T : class
        {
            var confirmResult = MessageHelpers.ShowConfirmation(
                $"¿Seguro que quieres restaurar {entityName}?", "Restaurar");

            if (confirmResult == DialogResult.Yes)
            {
                if (await service.RestoreAsync(id))
                {
                    MessageHelpers.ShowSuccess($"{entityName} ha sido restaurado correctamente");
                    return true;
                }
                MessageHelpers.ShowError("Error al restaurar");
            }
            return false;
        }
    }
}