using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalaDeEscape.Models;

namespace SalaDeEscape.Controllers
{

    public class EscapeController : Controller
    {
        private readonly ILogger<EscapeController> _logger;

        public EscapeController(ILogger<EscapeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            ViewBag.Logo = Escape.Logo;
            return View();
        }

        public IActionResult Comenzar(){
            ViewBag.EstadoJuego = Escape.EstadoJuego;
            return View("Habitacion1");
        }

        [HttpPost]

        public IActionResult Habitacion(int sala, string clave){
            ViewBag.Error = false;

            bool res = Escape.ResolverSala(sala, clave);
            ViewBag.EstadoJuego = Escape.EstadoJuego;
            if(res == true){
                if(sala == 4){
                    return View("Victoria");
                }else{
                    return View($"Habitacion{Escape.EstadoJuego}");
                }
            }
            else{
                ViewBag.Error = true;
                return View($"Habitacion{sala}");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
