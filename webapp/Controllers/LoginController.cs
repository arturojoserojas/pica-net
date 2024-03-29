﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webapp.Models;

namespace webapp.Controllers
{
    public class LoginController : Controller
    {        
        private readonly ILoginService loginService;
        private readonly ILogger<HomeController> _logger;

        public LoginController(ILogger<HomeController> logger,
            ILoginService loginService){
                _logger = logger;
                this.loginService = loginService;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(Models.LoginModel loginModel)
        {
            try{

            }catch(Exception ex){
                _logger.LogError($"Error: {ex}");
               return RedirectToAction("Error");
            }
            if (ModelState.IsValid)
            {

                if (loginService.autenticacion(loginModel))
                {
                    var claims = new List<Claim>
                {
                    new Claim("user", "user"),
                    new Claim("role", "Member")
                };

                await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies", "user", "role")));

                    return RedirectToAction("autenticado", "login");
                }
                ModelState.AddModelError(string.Empty, "Acceso negado");

            }
            return View(loginModel);
        }        

        [Authorize]
        public IActionResult Autenticado()
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
