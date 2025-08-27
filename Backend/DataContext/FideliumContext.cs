using Microsoft.EntityFrameworkCore;
using Service.Models;
using System.Collections.Generic;

namespace Backend.DataContext
{
    public class FideliumContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<CompraServicio> ComprasServicios { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }



        public FideliumContext() { }

        public FideliumContext(DbContextOptions<FideliumContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Clientes
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    ID = 1,
                    Nombre = "Valentin",
                    Apellido = "Machado",
                    Telefono = "3498000000",
                    Email = "valeprivado03@gmail.com",
                    Instagram = "vale.macha2",
                    FechaCreacion = new DateTime(2025, 8, 1)
                },
                new Cliente
                {
                    ID = 2,
                    Nombre = "Fulanito",
                    Apellido = "Detal",
                    Telefono = "3498000001",
                    Email = "fulanitodetal@gmail.com",
                    Instagram = "fulanito.detal",
                    FechaCreacion = new DateTime(2025, 8, 1)
                }
            );

            // Usuarios
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    ID = 1,
                    Nombre = "Alejandro",
                    Email = "alejandro@gmail.com",
                    PasswordHash = "qwerty12345", //  solo para desarrollo
                    TipoUsuario = Usuario.TipoUsuarioEnum.Administrador
                },
                new Usuario
                {
                    ID = 2,
                    Nombre = "Empleado1",
                    Email = "empleado1@gmail.com",
                    PasswordHash = "qwerty12345",
                    TipoUsuario = Usuario.TipoUsuarioEnum.Empleado
                }
            );

            // CompraServicio
            modelBuilder.Entity<CompraServicio>().HasData(
                new CompraServicio
                {
                    ID = 1,
                    ClienteID = 1,
                    Descripcion = "Compra de PC Gamer",
                    FechaCompra = new DateTime(2025, 8, 1),
                    ComentarioFeedback = "Muy conforme con el servicio",
                    DeleteDate = DateTime.MinValue
                },
                new CompraServicio
                {
                    ID = 2,
                    ClienteID = 2,
                    Descripcion = "Servicio Tecnico de PC",
                    FechaCompra = new DateTime(2025, 8, 10),
                    ComentarioFeedback = "Buen servicio, pero podría mejorar la atención",
                    DeleteDate = DateTime.MinValue
                }
            );

            // Notificaciones
            modelBuilder.Entity<Notificacion>().HasData(
                new Notificacion
                {
                    ID = 1,
                    CompraServicioID = 1,
                    FechaGenerada = new DateTime(2025, 8, 1),
                    DiasParaRecordatorio = 7,
                    FechaRecordatorio = new DateTime(2025, 8, 8),
                    Estado = EstadoNotificacion.Pendiente,
                    ComentarioEmpleado = "Recordatorio programado para seguimiento."
                },
                new Notificacion
                {
                    ID = 2,
                    CompraServicioID = 2,
                    FechaGenerada = new DateTime(2025, 8, 15),
                    DiasParaRecordatorio = 3,
                    FechaRecordatorio = new DateTime(2025, 8, 18),
                    Estado = EstadoNotificacion.Atendida,
                    ComentarioEmpleado = null
                }
            );
            // Configuramos las querys para que no devuelvan los elementos eliminados
            modelBuilder.Entity<Cliente>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Usuario>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<CompraServicio>().HasQueryFilter(cs => !cs.IsDeleted);
            modelBuilder.Entity<Notificacion>().HasQueryFilter(n => !n.IsDeleted);
        }
    }
}

