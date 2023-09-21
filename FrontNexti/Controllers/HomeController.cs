using FrontNexti.Models;
using FrontNexti.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FrontNexti.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEvento _evento;

        public HomeController(ILogger<HomeController> logger , IEvento evento)
        {
            _logger = logger;
            _evento = evento;
        }

        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult Tabla()
        {
            var evento = _evento.GetAllEventos();

            return PartialView("_tabla.cshtml", evento);
        }

       
    }
}