using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace webapp.Controllers
{
    public class CheffController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ICheffService service;

        public CheffController(
            ILogger<HomeController> logger,
            ICheffService service){
            _logger = logger;
            this.service = service;
      
        }

        [HttpGet]
         public IActionResult Solicitud()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Solicitud(Models.CheffModel model){
            try{
                _logger.LogInformation("ingreso a metodo de solicitud");
                if(ModelState.IsValid){
                
                    if(service.registrar(model)){
                        return RedirectToAction("Agradecimiento", "Cheff");
                    }
                }
                ModelState.AddModelError(string.Empty, "Acceso negado");
            }catch(Exception ex){
                _logger.LogError($"Error: {ex}");
               return RedirectToAction("Error");
            }
            
            return View(model);
        }

        public IActionResult Agradecimiento()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
