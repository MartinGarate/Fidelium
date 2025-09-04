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
        public bool IsDeleted { get; set; } = false; // Soft delete
        public DateTime DeleteDate { get; set; } = DateTime.MinValue;
        public int UsuarioID { get; set; } // FK
        public Usuario? Usuario { get; set; }

    }
}