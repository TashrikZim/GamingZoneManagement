using App.Models;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.Controllers
{
    public class HomeController : Controller
    {

        BookingService bookingService;

        public HomeController(BookingService bookingService)
        {
            this.bookingService = bookingService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserDashboard()
        {
            if (HttpContext.Session.GetString("Uname") != null)
            {

                ViewBag.Uname = HttpContext.Session.GetString("Uname");
                ViewBag.Role = HttpContext.Session.GetString("Role");

                return View();
            }
            return Unauthorized();
        }

        public IActionResult AdminDashboard()
        {
            if (HttpContext.Session.GetString("Uname") != null)
            {
                ViewBag.Uname = HttpContext.Session.GetString("Uname");
                ViewBag.Role = HttpContext.Session.GetString("Role");

                ViewBag.TotalBookingAmount = bookingService.TotalBookingAmount();

                return View();
            }

            return Unauthorized();
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
