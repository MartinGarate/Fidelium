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
                    //creamos datos semillas para clientes
                    ID= 1,
                    UsuarioID = 1,
                    Instagram = "Vale.macha2",
                    Telefono = "3498 474852",
                    IsDeleted = false

                },
                new Cliente
                {
                    ID = 2,
                    UsuarioID = 2,
                    Instagram = "Fulanito.detal",
                    Telefono = "3498 474853",
                    IsDeleted = false
                }
                );
            modelBuilder.Entity<Usuario>().HasData(
               new Usuario
               {
                     ID = 1,
                     DNI = "46447189",
                     Nombre = "Valentino", 
                     Email = "valemacha1805@gmail.com",
                     TipoUsuario = Service.Enums.TipoUsuarioEnum.Usuario,
                     IsDeleted = false
                     },
                new Usuario
                {
                    ID = 2,
                    DNI = "46447190",
                    Nombre = "Martin",
                    Email = "martingarate0@gmail.com",
                    TipoUsuario = Service.Enums.TipoUsuarioEnum.Empleado,
                    IsDeleted = false
                },
                new Usuario
                {
                    ID = 3,
                    DNI = "46997851",
                    Nombre = "Martin G",
                    Email = "martingarate100@gmail.com",
                    TipoUsuario = Service.Enums.TipoUsuarioEnum.Administrador,
                    IsDeleted = false
                }
                );
            modelBuilder.Entity<CompraServicio>().HasData(
              new CompraServicio
                            {
                  ID = 1,
                  ClienteID = 1,
                  Descripcion = "Compra de PC Gamer",
                  FechaCompra = new DateTime(2025, 8, 1),
                  ComentarioFeedback = "Muy conforme con el servicio",
                  EmpleadoID = 2,
                  IsDeleted = false,
                  CreatedAt = new DateTime(2025, 8, 1)
              },
                new CompraServicio
                {
                    ID = 2,
                    ClienteID = 2,
                    Descripcion = "Servicio Tecnico de PC",
                    FechaCompra = new DateTime(2025, 8, 10),
                    ComentarioFeedback = "Buen servicio, pero podría mejorar la atención",
                    EmpleadoID = 2,
                    IsDeleted = false,
                    CreatedAt = new DateTime(2025, 8, 10)
                }
                );
            modelBuilder.Entity<Notificacion>().HasData(
                new Notificacion
                {
                     ID = 1,
                     CompraServicioID = 1,
                     FechaGenerada = new DateTime(2025, 8, 1),
                     DiasParaRecordatorio = 7,
                     FechaRecordatorio = new DateTime(2025, 8, 8),
                     Estado = Service.Enums.EstadoNotificacion.Pendiente,
                     ComentarioEmpleado = "Recordatorio programado para seguimiento.",
                     ClienteID = 1,
                     EmpleadoID = 2,
                     IsDeleted = false,
                     CreateAt = new DateTime(2025, 8, 1)
                },
                 new Notificacion
                 {
                      ID = 2,
                      CompraServicioID = 2,
                      FechaGenerada = new DateTime(2025, 8, 15),
                      DiasParaRecordatorio = 3,
                      FechaRecordatorio = new DateTime(2025, 8, 18),
                      Estado = Service.Enums.EstadoNotificacion.Atendida,
                      ComentarioEmpleado = null,
                      ClienteID = 2,
                      EmpleadoID = 2,
                      IsDeleted = false,
                      CreateAt = new DateTime(2025, 8, 15)
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

