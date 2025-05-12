using EatFast_Menux.Domain.Entities;
using EatFast_Menux.Domain.Interfaces;
using EatFast_Menux.Infrastucture.DbData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EatFast_Menux.Infrastucture.Repositories
{
    public class InventarioRepository : IInventarioRepository
    {
        private readonly AppDbContext _context;

        public InventarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductoInventario>> ObtenerTodosAsync()
        {
            return await _context.ProductosInventario.ToListAsync();
        }

        public async Task<ProductoInventario?> ObtenerPorIdAsync(Guid id)
        {
            return await _context.ProductosInventario.FindAsync(id);
        }

        public async Task CrearAsync(ProductoInventario producto)
        {
            _context.ProductosInventario.Add(producto);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(ProductoInventario producto)
        {
            _context.ProductosInventario.Update(producto);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(Guid id)
        {
            var producto = await _context.ProductosInventario.FindAsync(id);
            if (producto != null)
            {
                _context.ProductosInventario.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ProductoInventario>> ObtenerProductosCriticosAsync()
        {
            return await _context.ProductosInventario
                .Where(p => p.Cantidad <= p.NivelMinimo)
                .ToListAsync();
        }
    }
}
