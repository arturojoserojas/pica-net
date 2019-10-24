using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webapp.Models;

namespace webapp.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public LoginController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager){
            this.userManager = userManager;
            this.signInManager = signInManager;
      
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Models.LoginModel loginModel){
            if(ModelState.IsValid){
                var result = await signInManager.PasswordSignInAsync(
                    loginModel.Email, loginModel.Password, false, false);
                if(result.Succeeded){
                    return RedirectToAction("index","home");
                }
                ModelState.AddModelError(string.Empty, "Acceso negado");

            }
            return View(loginModel);
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
