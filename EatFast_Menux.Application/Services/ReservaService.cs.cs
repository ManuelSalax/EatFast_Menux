using EatFast_Menux.Domain.Entities;
using EatFast_Menux.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatFast_Menux.Application.Services
{
    public class ReservaService
    {
        private readonly IReservaRepository _reservaRepo;

        public ReservaService(IReservaRepository reservaRepo)
        {
            _reservaRepo = reservaRepo;
        }

        public async Task<List<Reserva>> ListarReservasAsync()
        {
            return await _reservaRepo.ObtenerTodasAsync();
        }

        public async Task<Reserva?> ObtenerPorIdAsync(Guid id)
        {
            return await _reservaRepo.ObtenerPorIdAsync(id);
        }

        public async Task CrearReservaAsync(Reserva reserva)
        {
            await _reservaRepo.CrearAsync(reserva);
        }
        public async Task EliminarReservaAsync(Guid id)
        {
            await _reservaRepo.EliminarAsync(id);
        }
        public async Task ActualizarReservaAsync(Reserva reserva)
        {
            await _reservaRepo.ActualizarAsync(reserva);
        }
    }
}
