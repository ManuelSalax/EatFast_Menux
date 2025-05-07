using EatFast_Menux.Application.Services;
using EatFast_Menux.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EatFast_Menux.Controllers
{
    public class ReservaController : Controller
    {
        private readonly ReservaService _reservaService;

        public ReservaController(ReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        public async Task<IActionResult> Index()
        {
            var reservas = await _reservaService.ListarReservasAsync();
            return View(reservas);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                await _reservaService.CrearReservaAsync(reserva);
                return RedirectToAction("Index");
            }
            return View(reserva);
        }
        [HttpPost]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            await _reservaService.EliminarReservaAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Editar(Guid id)
        {
            var reserva = await _reservaService.ObtenerPorIdAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                await _reservaService.ActualizarReservaAsync(reserva);
                return RedirectToAction("Index");
            }
            return View(reserva);
        }

    }
}
