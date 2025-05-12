using EatFast_Menux.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatFast_Menux.Domain.Interfaces
{
    public interface IInventarioRepository
    {
        Task<List<ProductoInventario>> ObtenerTodosAsync();
        Task<ProductoInventario?> ObtenerPorIdAsync(Guid id);
        Task CrearAsync(ProductoInventario producto);
        Task ActualizarAsync(ProductoInventario producto);
        Task EliminarAsync(Guid id);
        Task<List<ProductoInventario>> ObtenerProductosCriticosAsync();
    }
}

