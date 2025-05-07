using EatFast_Menux.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EatFast_Menux.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> ObtenerTodosAsync();
        Task<Usuario?> ObtenerPorEmailAsync(string email);
        Task<Usuario?> ObtenerPorIdAsync(Guid id);
        Task CrearAsync(Usuario usuario);
        Task ActualizarAsync(Usuario usuario);
        Task EliminarAsync(Guid id);
        Task<bool> ValidarCredencialesAsync(string email, string passwordHash);
    }
}
