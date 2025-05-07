using EatFast_Menux.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatFast_Menux.Domain.Interfaces
{
    public interface IReservaRepository
    {
        Task<List<Reserva>> ObtenerTodasAsync();
        Task<Reserva?> ObtenerPorIdAsync(Guid id);
        Task CrearAsync(Reserva reserva);
        Task EliminarAsync(Guid id);
        Task ActualizarAsync(Reserva reserva);

    }
}

