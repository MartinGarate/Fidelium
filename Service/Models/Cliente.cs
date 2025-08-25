using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class Cliente
    {
        public int ID { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        public string? Email { get; set; } // Opcional, puede ser null

        public string? Instagram { get; set; } // Opcional, puede ser null

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false; // Soft delete

        public DateTime DeleteDate { get; set; } = DateTime.MinValue; // Fecha de eliminación lógica



        public override string ToString()
        {
            return $"{Nombre} {Apellido}";
        }
    }

}
