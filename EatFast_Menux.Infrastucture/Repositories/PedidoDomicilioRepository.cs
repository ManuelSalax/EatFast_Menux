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
    public class PedidoDomicilioRepository : IPedidoDomicilioRepository
    {
        private readonly AppDbContext _context;

        public PedidoDomicilioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PedidoDomicilio>> ObtenerTodosAsync()
        {
            return await _context.PedidosDomicilio.ToListAsync();
        }

        public async Task<PedidoDomicilio?> ObtenerPorIdAsync(Guid id)
        {
            return await _context.PedidosDomicilio.FindAsync(id);
        }

        public async Task AsignarDomicilioAsync(PedidoDomicilio pedido)
        {
            _context.PedidosDomicilio.Add(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarEstadoAsync(Guid id, EstadoDomicilio nuevoEstado)
        {
            var pedido = await _context.PedidosDomicilio.FindAsync(id);
            if (pedido != null)
            {
                pedido.Estado = nuevoEstado;
                _context.PedidosDomicilio.Update(pedido);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<PedidoDomicilio>> ObtenerPorRepartidorAsync(Guid repartidorId)
        {
            return await _context.PedidosDomicilio
                .Where(p => p.RepartidorId == repartidorId)
                .ToListAsync();
        }
    }
}
