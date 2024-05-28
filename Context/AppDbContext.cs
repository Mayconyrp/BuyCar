using BuyCar.Model;
using Microsoft.EntityFrameworkCore;

namespace BuyCar.Context
{
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {

            }
            public DbSet<Administrador>? Administradores { get; set; }
            public DbSet<Usuario>? Usuarios { get; set; }
            public DbSet<Carro>? Carros { get; set; }

        public DbSet<Compra>? Compras { get; set; }


        public DbSet<Denuncia>? Denuncias { get; set; }

        }
}
