using EatFast_Menux.Application.Services;
using EatFast_Menux.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EatFast_Menux.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioService.ListarUsuariosAsync();
            return View(usuarios);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                await _usuarioService.CrearUsuarioAsync(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        public async Task<IActionResult> Editar(Guid id)
        {
            var usuario = await _usuarioService.ObtenerPorIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                await _usuarioService.ActualizarUsuarioAsync(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            await _usuarioService.EliminarUsuarioAsync(id);
            return RedirectToAction("Index");
        }
    }
}
