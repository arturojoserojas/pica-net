using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webapp.Models;

namespace webapp.Controllers
{
    public class CheffController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public CheffController(
            ILogger<HomeController> logger){
            _logger = logger;
      
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
         public IActionResult Solicitud()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Solicitud(Models.CheffModel model){
            if(ModelState.IsValid){
               
            }
            return View(model);
        }

         [HttpPost]
        public  HttpResponseMessage Solicitudes(Models.CheffModel model){
            if(ModelState.IsValid){
               return new HttpResponseMessage(HttpStatusCode.Created);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }



        public IActionResult Privacy()
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
