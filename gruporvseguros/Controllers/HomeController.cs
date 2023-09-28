using gruporvseguros.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace gruporvseguros.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contactanos()
        {
            return View();
        }

        public IActionResult Privacidad()
        {
            return View();
        }
        public IActionResult Productos()
        {
            return View();
        }
        public IActionResult Cotizacion()
        {
            return View();
        }
        public IActionResult Galeria()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}