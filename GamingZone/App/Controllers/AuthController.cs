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
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginDTO());
        }
        [HttpPost]
      
        public IActionResult Login(LoginDTO obj)
        {
            if (ModelState.IsValid)
            {
                var user = authService.Authenticate(obj);

                if (user != null)
                {
                    HttpContext.Session.SetString("Uname", user.UserName);
                    HttpContext.Session.SetString("Role", user.Role);
                    HttpContext.Session.SetInt32("UserId", user.Id);
                    var role = user.Role.Trim();

                    if (role.Equals("Admin"))
                    {
                        return RedirectToAction("AdminDashboard", "Home");
                    }

                    return RedirectToAction("UserDashboard", "Home");
                }

                ModelState.AddModelError("", "Invalid Username or Password");
            }

            return View(obj);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }


        [HttpGet]
        public IActionResult EditProfile()
        {
            var id = HttpContext.Session.GetInt32("UserId");

            if (id != null)
            {
                var data = authService.Get((int)id);
                return View(data);
            }

            return Unauthorized();
        }

        [HttpPost]
        public IActionResult EditProfile(EditProfileDTO p)
        {
            if (ModelState.IsValid)
            {
                var res = authService.Update(p);

                if (res == true)
                {
                    return RedirectToAction("UserDashboard", "Home");
                }
            }

            return View(p);
        }
    }
}