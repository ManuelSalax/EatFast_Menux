using EatFast_Menux.Application.Services;
using EatFast_Menux.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EatFast_Menux.Controllers
{
    public class PedidoController : Controller
    {
        private readonly PedidoService _pedidoService;

        public PedidoController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        public async Task<IActionResult> Index()
        {
            var pedidos = await _pedidoService.ListarPedidosAsync();
            return View(pedidos);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                await _pedidoService.CrearPedidoAsync(pedido);
                return RedirectToAction("Index");
            }
            return View(pedido);
        }
    }
}
