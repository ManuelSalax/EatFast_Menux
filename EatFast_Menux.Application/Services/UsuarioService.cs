using EatFast_Menux.Domain.Entities;
using EatFast_Menux.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatFast_Menux.Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepo;

        public UsuarioService(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        public async Task<List<Usuario>> ListarUsuariosAsync()
        {
            return await _usuarioRepo.ObtenerTodosAsync();
        }

        public async Task<Usuario?> ObtenerPorEmailAsync(string email)
        {
            return await _usuarioRepo.ObtenerPorEmailAsync(email);
        }

        public async Task<Usuario?> ObtenerPorIdAsync(Guid id)
        {
            return await _usuarioRepo.ObtenerPorIdAsync(id);
        }

        public async Task CrearUsuarioAsync(Usuario usuario)
        {
            await _usuarioRepo.CrearAsync(usuario);
        }

        public async Task ActualizarUsuarioAsync(Usuario usuario)
        {
            await _usuarioRepo.ActualizarAsync(usuario);
        }

        public async Task EliminarUsuarioAsync(Guid id)
        {
            await _usuarioRepo.EliminarAsync(id);
        }

        public async Task<bool> LoginAsync(string email, string passwordHash)
        {
            return await _usuarioRepo.ValidarCredencialesAsync(email, passwordHash);
        }
    }
}
