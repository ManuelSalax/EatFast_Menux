using EatFast_Menux.Application.Services;
using EatFast_Menux.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EatFast_Menux.Controllers
{
    public class InventarioController : Controller
    {
        private readonly InventarioService _inventarioService;

        public InventarioController(InventarioService inventarioService)
        {
            _inventarioService = inventarioService;
        }

        public async Task<IActionResult> Index()
        {
            var productos = await _inventarioService.ObtenerTodosAsync();
            var criticos = productos.Where(p => p.Cantidad <= p.NivelMinimo).ToList();

            if (criticos.Any())
            {
                TempData["AlertaInventario"] = $"¡Atención! Hay {criticos.Count} producto(s) con stock bajo.";
            }

            return View(productos);
        }

        public IActionResult Crear() => View();

        [HttpPost]
        public async Task<IActionResult> Crear(ProductoInventario producto)
        {
            if (ModelState.IsValid)
            {
                await _inventarioService.CrearAsync(producto);
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        public async Task<IActionResult> Editar(Guid id)
        {
            var producto = await _inventarioService.ObtenerPorIdAsync(id);
            if (producto == null) return NotFound();
            return View(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(ProductoInventario producto)
        {
            if (ModelState.IsValid)
            {
                await _inventarioService.ActualizarAsync(producto);
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            await _inventarioService.EliminarAsync(id);
            return RedirectToAction("Index");
        }



    }
}
