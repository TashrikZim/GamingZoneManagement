using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class AuthController : Controller
    {
        AuthService authService;

        public AuthController(AuthService authService)
        {
            this.authService = authService;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View(new RegisterDTO());
        }

        [HttpPost]
        public IActionResult Registration(RegisterDTO u)
        {
            if (ModelState.IsValid)
            {
                var res = authService.Register(u);

                if (res == true)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(u);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}