﻿using EatFast_Menux.Domain.Entities;
using EatFast_Menux.Domain.Interfaces;
using EatFast_Menux.Infrastucture.DbData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatFast_Menux.Infrastucture.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly AppDbContext _context;

        public ReservaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Reserva>> ObtenerTodasAsync()
        {
            return await _context.Reservas.ToListAsync();
        }

        public async Task<Reserva?> ObtenerPorIdAsync(Guid id)
        {
            return await _context.Reservas.FindAsync(id);
        }

        public async Task CrearAsync(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(Guid id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
                await _context.SaveChangesAsync();
            }
        }
        public async Task ActualizarAsync(Reserva reserva)
        {
            _context.Reservas.Update(reserva);
            await _context.SaveChangesAsync();
        }
    }
}
