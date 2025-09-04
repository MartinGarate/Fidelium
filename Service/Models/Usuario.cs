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
        public int? DNI { get; set; } // Opcional
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty; // Único → login
        public string Password{ get; set; } = string.Empty; // Guardado encriptado
        public TipoUsuarioEnum TipoUsuario { get; set; } = TipoUsuarioEnum.Empleado;
        public DateTime DeleteDate { get; set; } = DateTime.MinValue; // Soft delete
        public bool IsDeleted { get; set; } = false;

        public override string ToString()
        {
            return Nombre;
        }

        public enum TipoUsuarioEnum
        {
            Administrador,
            Empleado,
            Usuario
        }
        
    }
}
