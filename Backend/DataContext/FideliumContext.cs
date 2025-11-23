using Microsoft.EntityFrameworkCore;
using Service.Models;
using Service.Enums;
using System;
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

       // creamos datos semillas para todos los modelos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Datos semilla para Usuario
            modelBuilder.Entity<Usuario>()
                .HasData(
                    new Usuario 
                    { 
                        ID = 1, 
                        DNI = "46997850",
                        Nombre = "Martin Garte", 
                        Email = "martingarate0@gmail.com",
                        Password = "qwerty123",
                        TipoUsuario = TipoUsuarioEnum.Administrador,
                        IsDeleted = false,
                        DeleteDate = DateTime.MinValue
                    },
                    new Usuario 
                    { 
                        ID = 2, 
                        DNI = "39144832",
                        Nombre = "Leonel Arrieta", 
                        Email = "leonelarrieta@gmail.com",
                        Password = "qwerty123",
                        TipoUsuario = TipoUsuarioEnum.Administrador,
                        IsDeleted = false,
                        DeleteDate = DateTime.MinValue
                    },
                    new Usuario 
                    { 
                        ID = 3, 
                        DNI = "46447189",
                        Nombre = "Valentino Machado", 
                        Email = "valentinomachado@gmail.com",
                        Password = "qwerty123",
                        TipoUsuario = TipoUsuarioEnum.Administrador,
                        IsDeleted = false,
                        DeleteDate = DateTime.MinValue
                    },
                    new Usuario
                    {
                        ID = 4,
                        DNI = "123456789",
                        Nombre = "Test Delete",
                        Email = "testdelete@gmail.com",
                        Password = "qwerty123",
                        TipoUsuario = TipoUsuarioEnum.Administrador,
                        IsDeleted = true,
                        DeleteDate = DateTime.MinValue
                    },


                    // =============================================================
                    // datos semillas para usuarios empleados
                    // =============================================================

                    new Usuario
                    {
                        ID = 5,
                        DNI = "41287827",
                        Nombre = "Candela Agustina Corradi",
                        Email = "corradicande@gmail.com",
                        Password = "qwerty123",
                        TipoUsuario = TipoUsuarioEnum.Empleado,
                        IsDeleted = false,
                        DeleteDate = DateTime.MinValue
                    },

                    new Usuario
                    {
                        ID = 6,
                        DNI = "40317292",
                        Nombre = "Ximena Gorosito",
                        Email = "ximenagorosito0@gmail.com",
                        Password = "qwerty123",
                        TipoUsuario = TipoUsuarioEnum.Empleado,
                        IsDeleted = false,
                        DeleteDate = DateTime.MinValue
                    },

                    new Usuario
                    {
                        ID = 7,
                        DNI = "123456781",
                        Nombre = "Test2 Delete",
                        Email = "testdelete2@gmail.com",
                        Password = "qwerty123",
                        TipoUsuario = TipoUsuarioEnum.Empleado,
                        IsDeleted = true,
                        DeleteDate = DateTime.MinValue
                    },

                    // =============================================================
                    // datos semillas para usuarios clientes
                    // =============================================================

                    new Usuario
                    {
                        ID = 8,
                        DNI = "46133497",
                        Nombre = "Daniel Alejandro Obregon",
                        Email = "danielobregon621@gmail.com",
                        Password = "qwerty123",
                        TipoUsuario = TipoUsuarioEnum.Cliente,
                        IsDeleted = false,
                        DeleteDate = DateTime.MinValue
                    },
                    new Usuario
                    {
                        ID = 9,
                        DNI = "45641614",
                        Nombre = "Lucia Lencina",
                        Email = "lucilencina6@gmail.com",
                        Password = "qwerty123",
                        TipoUsuario = TipoUsuarioEnum.Cliente,
                        IsDeleted = false,
                        DeleteDate = DateTime.MinValue
                    },
                    new Usuario
                    {
                        ID = 10,
                        DNI = "123456782",
                        Nombre = "Test3 Delete",
                        Email = "testdelete3@gmail.com",
                        Password = "qwerty123",
                        TipoUsuario = TipoUsuarioEnum.Cliente,
                        IsDeleted = true,
                        DeleteDate = DateTime.MinValue
                    }
                );

            // Datos semilla para Cliente
            modelBuilder.Entity<Cliente>()
                .HasData(
                    new Cliente 
                    { 
                        ID = 1, 
                        UsuarioID = 8,
                        Telefono = "+54 9 3498 455605",
                        Instagram = "@danielobregon02",
                        IsDeleted = false,
                        DeleteDate = DateTime.MinValue
                    },
                    new Cliente 
                    { 
                        ID = 2, 
                        UsuarioID = 9,
                        Telefono = "+54 9 3498 416195",
                        Instagram = "@lucia.nwn_",
                        IsDeleted = false,
                        DeleteDate = DateTime.MinValue
                    },
                    new Cliente 
                    { 
                        ID = 3, 
                        UsuarioID = 10,
                        Telefono = "+12 3 4567 890123",
                        Instagram = "@test",
                        IsDeleted = true,
                        DeleteDate = DateTime.MinValue
                    }
                );

            // Datos semilla para CompraServicio
            modelBuilder.Entity<CompraServicio>()
                .HasData(
                    new CompraServicio 
                    { 
                        ID = 1, 
                        ClienteID = 8,
                        Nombre = "Compra de Tarjeta Grafica Gigabyte 3050Ti",
                        Descripcion = "Upgradear PC para un mejor rendimiento",
                        FechaCompra = new DateTime(2025, 11, 10),
                        ComentarioFeedback = "Excelente servicio y atencion al publico, muy recomendado",
                        EmpleadoID = 2,
                        IsDeleted = false,
                        DeleteDate = DateTime.MinValue,
                        CreatedAt = new DateTime(2025, 11, 10),
                        UpdateAt = DateTime.MinValue
                    },
                    new CompraServicio 
                    { 
                        ID = 2, 
                        ClienteID = 9,
                        Nombre = "Servicio de limpieza de PC",
                        Descripcion = "PC que no se limpiaba hace 6 meses.",
                        FechaCompra = new DateTime(2025, 11, 10),
                        ComentarioFeedback = "Buen servicio, cumple expectativas",
                        EmpleadoID = 1,
                        IsDeleted = false,
                        DeleteDate = DateTime.MinValue,
                        CreatedAt = new DateTime(2025, 11, 10),
                        UpdateAt = DateTime.MinValue
                    },
                    new CompraServicio 
                    { 
                        ID = 3,
                        ClienteID = 10,
                        Nombre = "Consultoría Especializada",
                        Descripcion = "Sesión de consultoría personalizada",
                        FechaCompra = new DateTime(2025, 11, 10),
                        ComentarioFeedback = "Muy útil y profesional",
                        EmpleadoID = 2,
                        IsDeleted = true,
                        DeleteDate = DateTime.MinValue,
                        CreatedAt = new DateTime(2025, 11, 10),
                        UpdateAt = DateTime.MinValue
                    }
                );

            // Datos semilla para Notificacion
            modelBuilder.Entity<Notificacion>()
                .HasData(
                    new Notificacion 
                    { 
                        ID = 1, 
                        CompraServicioID = 1,
                        ClienteID = 8,
                        EmpleadoID = 2,
                        ComentarioEmpleado = "Recordatorio para seguimiento de cliente",
                        DiasParaRecordatorio = 7,
                        Estado = EstadoNotificacion.Pendiente,
                        FechaGenerada = new DateTime(2025, 11, 10),
                        FechaRecordatorio = new DateTime(2025, 11, 17),
                        IsDeleted = false,
                        DeleteDate = DateTime.MinValue,
                        CreateAt = new DateTime(2025, 11, 10),
                        UpdateAt = DateTime.MinValue
                    },
                    new Notificacion 
                    { 
                        ID = 2, 
                        CompraServicioID = 2,
                        ClienteID = 9,
                        EmpleadoID = 1,
                        ComentarioEmpleado = "Follow-up de compra",
                        DiasParaRecordatorio = 14,
                        Estado = EstadoNotificacion.Atendida,
                        FechaGenerada = new DateTime(2025, 11, 10),
                        FechaRecordatorio = new DateTime(2025, 11, 24),
                        IsDeleted = false,
                        DeleteDate = DateTime.MinValue,
                        CreateAt = new DateTime(2025, 11, 10),
                        UpdateAt = new DateTime(2025, 11, 10)
                    },
                    new Notificacion 
                    { 
                        ID = 3, 
                        CompraServicioID = 3,
                        ClienteID = 10,
                        EmpleadoID = 3,
                        ComentarioEmpleado = "Evaluación de satisfacción",
                        DiasParaRecordatorio = 30,
                        Estado = EstadoNotificacion.Pendiente,
                        FechaGenerada = new DateTime(2025, 11, 10),
                        FechaRecordatorio = new DateTime(2025, 11, 24),
                        IsDeleted = true,
                        DeleteDate = DateTime.MinValue,
                        CreateAt = new DateTime(2025, 11, 10),
                        UpdateAt = DateTime.MinValue
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

