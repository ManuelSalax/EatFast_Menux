using EatFast_Menux.Domain.Entities;
using EatFast_Menux.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatFast_Menux.Application.Services
{
    public class InventarioService
    {
        private readonly IInventarioRepository _inventarioRepo;

        public InventarioService(IInventarioRepository inventarioRepo)
        {
            _inventarioRepo = inventarioRepo;
        }

        public async Task<List<ProductoInventario>> ObtenerTodosAsync()
        {
            return await _inventarioRepo.ObtenerTodosAsync();
        }

        public async Task<ProductoInventario?> ObtenerPorIdAsync(Guid id)
        {
            return await _inventarioRepo.ObtenerPorIdAsync(id);
        }

        public async Task CrearAsync(ProductoInventario producto)
        {
            producto.FechaUltimaActualizacion = DateTime.UtcNow;
            await _inventarioRepo.CrearAsync(producto);
        }

        public async Task ActualizarAsync(ProductoInventario producto)
        {
            producto.FechaUltimaActualizacion = DateTime.UtcNow;
            await _inventarioRepo.ActualizarAsync(producto);
        }

        public async Task EliminarAsync(Guid id)
        {
            await _inventarioRepo.EliminarAsync(id);
        }

        public async Task<List<ProductoInventario>> ObtenerCriticosAsync()
        {
            return await _inventarioRepo.ObtenerProductosCriticosAsync();
        }
    }
}
