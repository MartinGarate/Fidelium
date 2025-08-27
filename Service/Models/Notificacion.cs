using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public enum EstadoNotificacion
    {
        Pendiente,
        Atendida
    }
    public class Notificacion
    {
        public int ID { get; set; }
        public int CompraServicioID { get; set; } // FK
        public CompraServicio? CompraServicio { get; set; }
        public DateTime FechaGenerada { get; set; } = DateTime.Now;
        public int DiasParaRecordatorio { get; set; } = 0;
        public DateTime FechaRecordatorio { get; set; } = DateTime.MinValue;
        public EstadoNotificacion Estado { get; set; } = EstadoNotificacion.Pendiente;
        public string? ComentarioEmpleado { get; set; } // Opcional
        public bool IsDeleted { get; set; } = false; // Soft delete

    }

}
