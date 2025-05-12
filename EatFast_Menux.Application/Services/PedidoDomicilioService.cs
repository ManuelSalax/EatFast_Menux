using EatFast_Menux.Domain.Entities;
using EatFast_Menux.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatFast_Menux.Application.Services
{
    public class PedidoDomicilioService
    {
        private readonly IPedidoDomicilioRepository _domicilioRepo;

        public PedidoDomicilioService(IPedidoDomicilioRepository domicilioRepo)
        {
            _domicilioRepo = domicilioRepo;
        }

        public async Task<List<PedidoDomicilio>> ObtenerTodosAsync()
        {
            return await _domicilioRepo.ObtenerTodosAsync();
        }

        public async Task<PedidoDomicilio?> ObtenerPorIdAsync(Guid id)
        {
            return await _domicilioRepo.ObtenerPorIdAsync(id);
        }

        public async Task AsignarDomicilioAsync(PedidoDomicilio pedido)
        {
            pedido.FechaAsignacion = DateTime.UtcNow;
            pedido.Estado = EstadoDomicilio.EnCamino;
            await _domicilioRepo.AsignarDomicilioAsync(pedido);
        }

        public async Task ActualizarEstadoAsync(Guid id, EstadoDomicilio nuevoEstado)
        {
            await _domicilioRepo.ActualizarEstadoAsync(id, nuevoEstado);
        }

        public async Task<List<PedidoDomicilio>> ObtenerPorRepartidorAsync(Guid repartidorId)
        {
            return await _domicilioRepo.ObtenerPorRepartidorAsync(repartidorId);
        }
    }
}
