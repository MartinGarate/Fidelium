using Microsoft.EntityFrameworkCore;
using Service.Enums;
using Service.Models;
using Service.Models.Service.Models;
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

        public FideliumContext(DbContextOptions<FideliumContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // === SEMILLA: USUARIOS ===
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { ID = 1, DNI = "46997850", Nombre = "Martin Garte", Email = "martingarate0@gmail.com", TipoUsuario = TipoUsuarioEnum.Administrador },
                new Usuario { ID = 2, DNI = "39144832", Nombre = "Leonel Arrieta", Email = "leonelarrieta@gmail.com", TipoUsuario = TipoUsuarioEnum.Administrador },
                new Usuario { ID = 3, DNI = "46447189", Nombre = "Valentino Machado", Email = "valentinomachado@gmail.com", TipoUsuario = TipoUsuarioEnum.Administrador },
                new Usuario { ID = 4, DNI = "123456789", Nombre = "Test Delete", Email = "testdelete@gmail.com", TipoUsuario = TipoUsuarioEnum.Administrador, IsDeleted = true },
                new Usuario { ID = 5, DNI = "41287827", Nombre = "Candela Agustina Corradi", Email = "corradicande@gmail.com", TipoUsuario = TipoUsuarioEnum.Empleado },
                new Usuario { ID = 6, DNI = "40317292", Nombre = "Ximena Gorosito", Email = "ximenagorosito0@gmail.com", TipoUsuario = TipoUsuarioEnum.Empleado },
                new Usuario { ID = 7, DNI = "123456781", Nombre = "Test2 Delete", Email = "testdelete2@gmail.com", TipoUsuario = TipoUsuarioEnum.Empleado, IsDeleted = true },
                new Usuario { ID = 8, DNI = "46133497", Nombre = "Daniel Alejandro Obregon", Email = "danielobregon621@gmail.com", TipoUsuario = TipoUsuarioEnum.Cliente },
                new Usuario { ID = 9, DNI = "45641614", Nombre = "Lucia Lencina", Email = "lucilencina6@gmail.com", TipoUsuario = TipoUsuarioEnum.Cliente },
                new Usuario { ID = 10, DNI = "123456782", Nombre = "Test3 Delete", Email = "testdelete3@gmail.com", TipoUsuario = TipoUsuarioEnum.Cliente, IsDeleted = true }
            );

            // === SEMILLA: CLIENTES ===
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { ID = 1, UsuarioID = 8, Telefono = "+54 9 3498 455605", Instagram = "@danielobregon02" },
                new Cliente { ID = 2, UsuarioID = 9, Telefono = "+54 9 3498 416195", Instagram = "@lucia.nwn_" },
                new Cliente { ID = 3, UsuarioID = 10, Telefono = "+12 3 4567 890123", Instagram = "@test", IsDeleted = true }
            );

            // === SEMILLA: COMPRASERVICIOS (Adaptado a nuevas propiedades) ===
            modelBuilder.Entity<CompraServicio>().HasData(
                new CompraServicio
                {
                    ID = 1,
                    ClienteID = 1,
                    EmpleadoID = 1,
                    Nombre = "Gigabyte RTX 3050Ti",
                    Descripcion = "Upgrade de GPU",
                    NotasVentaInternas = "Buscaba jugar CSGO, se llevó esta por presupuesto.",
                    FechaCompra = new DateTime(2025, 11, 5),
                    FechaRecordatorio = new DateTime(2025, 11, 5).AddDays(7),
                    ComentarioFeedback = "Excelente producto.",
                    FeedbackRecibido = true,
                    CreatedAt = new DateTime(2025, 11, 5)
                },
                new CompraServicio
                {
                    ID = 2,
                    ClienteID = 1,
                    EmpleadoID = 5,
                    Nombre = "Instalación Windows 11",
                    Descripcion = "Instalación limpia",
                    NotasVentaInternas = "PC vieja, chequear que no tire BSOD.",
                    FechaCompra = new DateTime(2025, 11, 8),
                    FechaRecordatorio = new DateTime(2025, 11, 8).AddDays(7),
                    ComentarioFeedback = "",
                    FeedbackRecibido = false,
                    CreatedAt = new DateTime(2025, 11, 8)
                },
                new CompraServicio
                {
                    ID = 6,
                    ClienteID = 3,
                    EmpleadoID = 2,
                    Nombre = "SSD NVMe 1TB",
                    NotasVentaInternas = "Test de borrado",
                    FechaCompra = new DateTime(2025, 9, 10),
                    FechaRecordatorio = new DateTime(2025, 9, 17),
                    IsDeleted = true,
                    CreatedAt = new DateTime(2025, 9, 10)
                }
            );

            // === SEMILLA: NOTIFICACIONES (Simplificado) ===
            modelBuilder.Entity<Notificacion>().HasData(
                new Notificacion { ID = 1, CompraServicioID = 1, Estado = EstadoNotificacion.Atendida, FechaGenerada = new DateTime(2025, 11, 5) },
                new Notificacion { ID = 2, CompraServicioID = 2, Estado = EstadoNotificacion.Pendiente, FechaGenerada = new DateTime(2025, 11, 8) },
                new Notificacion { ID = 6, CompraServicioID = 6, Estado = EstadoNotificacion.Pendiente, FechaGenerada = new DateTime(2025, 9, 10), IsDeleted = true }
            );

            // === FILTROS GLOBALES (Soft Delete) ===
            modelBuilder.Entity<Cliente>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Usuario>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<CompraServicio>().HasQueryFilter(cs => !cs.IsDeleted);
            modelBuilder.Entity<Notificacion>().HasQueryFilter(n => !n.IsDeleted);
        }
    }
}