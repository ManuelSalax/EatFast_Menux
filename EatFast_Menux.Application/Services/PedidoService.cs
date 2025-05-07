using EatFast_Menux.Domain.Entities;
using EatFast_Menux.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatFast_Menux.Application.Services
{
    public class PedidoService
    {
        private readonly IPedidoRepository _pedidoRepo;

        public PedidoService(IPedidoRepository pedidoRepo)
        {
            _pedidoRepo = pedidoRepo;
        }

        public async Task<List<Pedido>> ListarPedidosAsync()
        {
            return await _pedidoRepo.ObtenerTodosAsync();
        }

        public async Task<Pedido?> ObtenerPorIdAsync(Guid id)
        {
            return await _pedidoRepo.ObtenerPorIdAsync(id);
        }

        public async Task CrearPedidoAsync(Pedido pedido)
        {
            await _pedidoRepo.CrearAsync(pedido);
        }
    }
}
