using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Utils
{
    public static class ApiEndpoints
    {
            public static string Cliente { get; set; } = "clientes";
            public static string CompraServicio { get; set; } = "comprasservicios";
            public static string Notificacion { get; set; } = "notificaciones";
            public static string Usuario { get; set; } = "usuarios";


            public static string GetEndpoint(string name)
            {
                return name switch
                {
                    nameof(Cliente) => Cliente,
                    nameof(Usuario) => Usuario,
                    nameof(CompraServicio) => CompraServicio,
                    nameof(Notificacion) => Notificacion,
                    _ => throw new ArgumentException($"Endpoint '{name}' no está definido.")
                };
            }

    }
}
