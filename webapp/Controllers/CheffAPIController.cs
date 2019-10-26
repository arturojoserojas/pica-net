using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webapp;
using webapp.Models;

namespace apiCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json","application/xml")]
    public class CheffAPIController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly ICheffService service;

        public CheffAPIController(
            ILogger<WeatherForecastController> logger,
             ICheffService service)
        {
            _logger = logger;
            this.service = service;
        }

        [HttpPost]
        public IActionResult Post(CheffModel model){
            var htmlCode = StatusCode(StatusCodes.Status400BadRequest,"");

            if(ModelState.IsValid){
                if(service.registrar(model)){
                    htmlCode = StatusCode(StatusCodes.Status201Created,"regitro procesado");
                }else{
                    htmlCode = StatusCode(StatusCodes.Status206PartialContent,"falta información la entrada");
                }
            }
            return htmlCode;
        }
    }
}
