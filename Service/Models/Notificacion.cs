﻿using Service.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    
    public class Notificacion
    {
        public int ID { get; set; }
        public int CompraServicioID { get; set; } // FK
        public CompraServicio? CompraServicio { get; set; }
        public DateTime FechaGenerada { get; set; } = DateTime.Now;
        public int DiasParaRecordatorio { get; set; } = 0; // Días a partir de la fecha generada para el recordatorio
        public DateTime? FechaRecordatorio { get; set; } //Fecha Ya calculada
        public EstadoNotificacion Estado { get; set; } = EstadoNotificacion.Pendiente;
        public string? ComentarioEmpleado { get; set; } // Opcional
        public int ClienteID { get; set; } // FK
        public Cliente? Cliente { get; set; } // Cliente al que se le envía la notificación
        public int EmpleadoID { get; set; } // FK
        public Usuario? Empleado { get; set; } // Usuario que creó la notificación
        public bool IsDeleted { get; set; } = false; // Soft delete
        public DateTime CreateAt { get; set; } = DateTime.Now; // Fecha de creación del registro
        public DateTime UpdateAt { get; set; } = DateTime.MinValue; // Fecha de última actualización


    }

}
