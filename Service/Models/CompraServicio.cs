using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class CompraServicio
    {
        public int ID { get; set; }
        public int ClienteID { get; set; } // FK    
        public Cliente? Cliente { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaCompra { get; set; } = DateTime.Now;
        public string ComentarioFeedback { get; set; } = string.Empty; // Campo libre para feedback
        public int EmpleadoID { get; set; } // FK
        public Usuario? Empleado { get; set; } // Usuario que realizó la venta/servicio
        public bool IsDeleted { get; set; } = false; // Soft delete
        public DateTime DeleteDate { get; set; } = DateTime.MinValue; // Fecha de eliminación (soft delete)
        public DateTime UpdateAt { get; set; } = DateTime.MinValue; // Fecha de última actualización
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Fecha de creación del registro

    }
}