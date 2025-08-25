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
            //cargamos los datos iniciales de los tipos de usuarios del models usuario


        }
    }
}
