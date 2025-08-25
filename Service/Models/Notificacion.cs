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
        public int NotificacionID { get; set; }
        public int CompraID { get; set; } // FK
        public DateTime FechaGenerada { get; set; } = DateTime.Now;
        public int DiasParaRecordatorio { get; set; } = 0;
        public DateTime FechaRecordatorio { get; set; } = DateTime.MinValue;
        public EstadoNotificacion Estado { get; set; } = EstadoNotificacion.Pendiente;
        public string? ComentarioEmpleado { get; set; } // Opcional

    }

}
