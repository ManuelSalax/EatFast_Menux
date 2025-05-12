using EatFast_Menux.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatFast_Menux.Domain.Interfaces
{
    public interface IPedidoDomicilioRepository
    {
        Task<List<PedidoDomicilio>> ObtenerTodosAsync();
        Task<PedidoDomicilio?> ObtenerPorIdAsync(Guid id);
        Task AsignarDomicilioAsync(PedidoDomicilio pedido);
        Task ActualizarEstadoAsync(Guid id, EstadoDomicilio nuevoEstado);
        Task<List<PedidoDomicilio>> ObtenerPorRepartidorAsync(Guid repartidorId);
    }
}
