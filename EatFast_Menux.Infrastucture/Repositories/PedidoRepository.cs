using EatFast_Menux.Domain.Entities;
using EatFast_Menux.Domain.Interfaces;
using EatFast_Menux.Infrastucture.DbData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatFast_Menux.Infrastucture.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pedido>> ObtenerTodosAsync()
        {
            return await _context.Pedidos.Include(p => p.Items).ToListAsync();
        }

        public async Task<Pedido?> ObtenerPorIdAsync(Guid id)
        {
            return await _context.Pedidos.Include(p => p.Items)
                                         .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CrearAsync(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
        }
    }
}
