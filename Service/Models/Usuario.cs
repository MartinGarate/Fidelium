using Service.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class Usuario
    {
        public int ID { get; set; }
        public string? DNI { get; set; } // Opcional
        public string Nombre { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty; // Opcional
        public TipoUsuarioEnum TipoUsuario { get; set; } = TipoUsuarioEnum.Cliente;
        public bool IsDeleted { get; set; } = false;
        public DateTime DeleteDate { get; set; } = DateTime.MinValue; // Fecha de eliminación (soft delete)

        public override string ToString()
        {
            return Nombre;
        }

    }
}
