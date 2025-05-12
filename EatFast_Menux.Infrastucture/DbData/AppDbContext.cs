using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EatFast_Menux.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EatFast_Menux.Infrastucture.DbData
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItems { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ProductoInventario> ProductosInventario { get; set; }
        public DbSet<PedidoDomicilio> PedidosDomicilio { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PedidoItem>()
                .Property(p => p.Precio)
                .HasPrecision(10, 2); // 10 dígitos en total, 2 decimales

            base.OnModelCreating(modelBuilder);
        }
    }
}
