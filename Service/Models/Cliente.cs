using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Models;

namespace Service.Models
{
    public class Cliente
        
    {
        public int ID { get; set; }
        public int UsuarioID { get; set; } // Foreign key to Usuario
        public Usuario? Usuario { get; set; } 
        public string? Telefono { get; set; } = string.Empty;
        public string? Instagram { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false; // Soft delete


    }

}
