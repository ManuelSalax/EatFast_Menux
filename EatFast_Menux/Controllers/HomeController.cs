using EatFast_Menux.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace EatFast_Menux.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Constructor con inyección de logger
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Página de bienvenida principal
        public IActionResult Index()
        {
            return View();
        }

        // Página de privacidad (opcional)
        public IActionResult Privacy()
        {
            return View();
        }

        // Página de error (invocada automáticamente en caso de excepciones)
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
