using EatFast_Menux.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatFast_Menux.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        Task<List<Pedido>> ObtenerTodosAsync();
        Task<Pedido?> ObtenerPorIdAsync(Guid id);
        Task CrearAsync(Pedido pedido);
    }
}
