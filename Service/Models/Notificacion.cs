using Service.Enums;
using Service.Models.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Service.Models
{

    public class Notificacion
    {
        public int ID { get; set; }
        public int CompraServicioID { get; set; }
        public CompraServicio? CompraServicio { get; set; }

        public EstadoNotificacion Estado { get; set; } = EstadoNotificacion.Pendiente;

        // Para rastrear cuándo se generó el aviso
        public DateTime FechaGenerada { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;
    }

}
