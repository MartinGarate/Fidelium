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

            // =============================================================
            // Datos semilla para Cliente
            // =============================================================

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

            // =============================================================
            // Datos semilla para CompraServicio
            // =============================================================
            modelBuilder.Entity<CompraServicio>()
                .HasData(
                    // Compras del cliente Daniel Alejandro Obregon (ID 1) - Administrador Martin
                    new CompraServicio 
                    { 
                        ID = 1, 
                        ClienteID = 1,
                        Nombre = "Compra de Tarjeta Gráfica Gigabyte RTX 3050Ti",
                        Descripcion = "Upgrade de GPU para mejorar rendimiento en gaming y rendering",
                        FechaCompra = new DateTime(2025, 11, 5),
                        ComentarioFeedback = "Excelente producto y muy buena atención al público. Muy recomendado.",
                        EmpleadoID = 1,
                        IsDeleted = false,
                        DeleteDate = DateTime.MinValue,
                        CreatedAt = new DateTime(2025, 11, 5),
                        UpdateAt = new DateTime(2025, 11, 6)
                    },
                    new CompraServicio 
                    { 
                        ID = 2, 
                        ClienteID = 1,
                        Nombre = "Servicio de Instalación de SO Windows 11 Pro",
                        Descripcion = "Instalación limpia de Windows 11 Pro con drivers actualizados",
                        FechaCompra = new DateTime(2025, 11, 8),
                        ComentarioFeedback = "Trabajo muy profesional, PC corriendo perfectamente",
                        EmpleadoID = 5,
                        IsDeleted = false,
                        DeleteDate = DateTime.MinValue,
                        CreatedAt = new DateTime(2025, 11, 8),
                        UpdateAt = DateTime.MinValue
                    },
                    // Compras del cliente Lucia Lencina (ID 2) - Administrador Leonel
                    new CompraServicio 
                    { 
                        ID = 3, 
                        ClienteID = 2,
                        Nombre = "Servicio de Limpieza Profesional de PC",
                        Descripcion = "Limpieza a fondo interna y externa, cambio de pasta térmica",
                        FechaCompra = new DateTime(2025, 10, 15),
                        ComentarioFeedback = "Excelente servicio, la PC ahora funciona mucho más rápido",
                        EmpleadoID = 2,
                        IsDeleted = false,
                        DeleteDate = DateTime.MinValue,
                        CreatedAt = new DateTime(2025, 10, 15),
                        UpdateAt = new DateTime(2025, 10, 16)
                    },
                    new CompraServicio 
                    { 
                        ID = 4, 
                        ClienteID = 2,
                        Nombre = "Upgrade de RAM a 32GB DDR4",
                        Descripcion = "Instalación de módulos RAM Corsair Vengeance para multitarea",
                        FechaCompra = new DateTime(2025, 10, 22),
                        ComentarioFeedback = "Proceso rápido y eficiente. Ahora puedo correr múltiples aplicaciones sin lag",
                        EmpleadoID = 6,
                        IsDeleted = false,
                        DeleteDate = DateTime.MinValue,
                        CreatedAt = new DateTime(2025, 10, 22),
                        UpdateAt = DateTime.MinValue
                    },
                    new CompraServicio 
                    { 
                        ID = 5, 
                        ClienteID = 2,
                        Nombre = "Consultoría de Configuración de Red",
                        Descripcion = "Asesoramiento en configuración de red doméstica y seguridad",
                        FechaCompra = new DateTime(2025, 11, 1),
                        ComentarioFeedback = "Muy útil, ahora tengo mi red segura y optimizada",
                        EmpleadoID = 3,
                        IsDeleted = false,
                        DeleteDate = DateTime.MinValue,
                        CreatedAt = new DateTime(2025, 11, 1),
                        UpdateAt = new DateTime(2025, 11, 2)
                    },
                    // Compra del cliente Test3 Delete (ID 3) - ELIMINADA para testing
                    new CompraServicio 
                    { 
                        ID = 6,
                        ClienteID = 3,
                        Nombre = "Compra de SSD NVMe 1TB",
                        Descripcion = "Instalación de unidad SSD rápida para sistema operativo",
                        FechaCompra = new DateTime(2025, 9, 10),
                        ComentarioFeedback = "Servicio eliminado - prueba de soft delete",
                        EmpleadoID = 2,
                        IsDeleted = true,
                        DeleteDate = new DateTime(2025, 11, 10),
                        CreatedAt = new DateTime(2025, 9, 10),
                        UpdateAt = new DateTime(2025, 9, 11)
                    }
                );

            // Datos semilla para Notificacion
            modelBuilder.Entity<Notificacion>()
                .HasData(
                    // Notificaciones para Daniel Alejandro Obregon (Cliente ID 1)
                    new Notificacion 
                    { 
                        ID = 1, 
                        CompraServicioID = 1,
                        ClienteID = 1,
                        EmpleadoID = 1,
                        ComentarioEmpleado = "Seguimiento post-venta de GPU, verificar compatibilidad y rendimiento",
                        DiasParaRecordatorio = 7,
                        Estado = EstadoNotificacion.Pendiente,
                        FechaGenerada = new DateTime(2025, 11, 5),
                        FechaRecordatorio = new DateTime(2025, 11, 12),
                        IsDeleted = false,
                        DeleteDate = DateTime.MinValue,
                        CreateAt = new DateTime(2025, 11, 5),
                        UpdateAt = DateTime.MinValue
                    },
                    new Notificacion 
                    { 
                        ID = 2, 
                        CompraServicioID = 2,
                        ClienteID = 1,
                        EmpleadoID = 5,
                        ComentarioEmpleado = "Verificar que la instalación de Windows 11 Pro se completó correctamente",
                        DiasParaRecordatorio = 3,
                        Estado = EstadoNotificacion.Atendida,
                        FechaGenerada = new DateTime(2025, 11, 8),
                        FechaRecordatorio = new DateTime(2025, 11, 11),
                        IsDeleted = false,
                        DeleteDate = DateTime.MinValue,
                        CreateAt = new DateTime(2025, 11, 8),
                        UpdateAt = new DateTime(2025, 11, 11)
                    },
                    // Notificaciones para Lucia Lencina (Cliente ID 2)
                    new Notificacion 
                    { 
                        ID = 3, 
                        CompraServicioID = 3,
                        ClienteID = 2,
                        EmpleadoID = 2,
                        ComentarioEmpleado = "Follow-up de limpieza de PC, preguntar si hay mejora en temperatura",
                        DiasParaRecordatorio = 14,
                        Estado = EstadoNotificacion.Atendida,
                        FechaGenerada = new DateTime(2025, 10, 15),
                        FechaRecordatorio = new DateTime(2025, 10, 29),
                        IsDeleted = false,
                        DeleteDate = DateTime.MinValue,
                        CreateAt = new DateTime(2025, 10, 15),
                        UpdateAt = new DateTime(2025, 10, 29)
                    },
                    new Notificacion 
                    { 
                        ID = 4, 
                        CompraServicioID = 4,
                        ClienteID = 2,
                        EmpleadoID = 6,
                        ComentarioEmpleado = "Verificación del upgrade de RAM, evaluar satisfacción del cliente",
                        DiasParaRecordatorio = 10,
                        Estado = EstadoNotificacion.Pendiente,
                        FechaGenerada = new DateTime(2025, 10, 22),
                        FechaRecordatorio = new DateTime(2025, 11, 1),
                        IsDeleted = false,
                        DeleteDate = DateTime.MinValue,
                        CreateAt = new DateTime(2025, 10, 22),
                        UpdateAt = DateTime.MinValue
                    },
                    new Notificacion 
                    { 
                        ID = 5, 
                        CompraServicioID = 5,
                        ClienteID = 2,
                        EmpleadoID = 3,
                        ComentarioEmpleado = "Evaluación de satisfacción post-consultoría de configuración de red",
                        DiasParaRecordatorio = 30,
                        Estado = EstadoNotificacion.Pendiente,
                        FechaGenerada = new DateTime(2025, 11, 1),
                        FechaRecordatorio = new DateTime(2025, 12, 1),
                        IsDeleted = false,
                        DeleteDate = DateTime.MinValue,
                        CreateAt = new DateTime(2025, 11, 1),
                        UpdateAt = DateTime.MinValue
                    },

                    // Notificación del cliente Test3 Delete (Cliente ID 3) - ELIMINADA para testing
                    new Notificacion 
                    { 
                        ID = 6, 
                        CompraServicioID = 6,
                        ClienteID = 3,
                        EmpleadoID = 2,
                        ComentarioEmpleado = "Notificación eliminada - prueba de soft delete",
                        DiasParaRecordatorio = 5,
                        Estado = EstadoNotificacion.Pendiente,
                        FechaGenerada = new DateTime(2025, 9, 10),
                        FechaRecordatorio = new DateTime(2025, 9, 15),
                        IsDeleted = true,
                        DeleteDate = new DateTime(2025, 11, 10),
                        CreateAt = new DateTime(2025, 9, 10),
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

