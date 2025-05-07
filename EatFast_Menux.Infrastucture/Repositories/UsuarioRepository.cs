using EatFast_Menux.Domain.Entities;
using EatFast_Menux.Domain.Interfaces;
using EatFast_Menux.Infrastucture.DbData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatFast_Menux.Infrastucture.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> ObtenerTodosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> ObtenerPorEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Usuario?> ObtenerPorIdAsync(Guid id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task CrearAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(Guid id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ValidarCredencialesAsync(string email, string passwordHash)
        {
            return await _context.Usuarios.AnyAsync(u => u.Email == email && u.PasswordHash == passwordHash);
        }
    }
}
