using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    namespace Service.Models
    {
        public class CompraServicio
        {
            public int ID { get; set; }

            // Relación Cliente
            public int ClienteID { get; set; }
            public Cliente? Cliente { get; set; }

            // Datos del Producto/Servicio
            public string Nombre { get; set; } = string.Empty;
            public string? Descripcion { get; set; } = string.Empty;

            // Comentario de preventa (lo que el empleado anota para el futuro)
            public string NotasVentaInternas { get; set; } = string.Empty;

            public DateTime FechaCompra { get; set; } = DateTime.Now;
            public DateTime FechaRecordatorio { get; set; }

            // Feedback post-venta
            public bool FeedbackRecibido { get; set; } = false;
            public string ComentarioFeedback { get; set; } = string.Empty;

            // Empleado que vendió
            public int EmpleadoID { get; set; }
            public Usuario? Empleado { get; set; }

            public bool IsDeleted { get; set; } = false;
            public DateTime CreatedAt { get; set; } = DateTime.Now;
        }
    }
}