using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class BookingController : Controller
    {
        BookingService bookingService;
        GamingSetupService gamingSetupService;

        public BookingController(BookingService bookingService, GamingSetupService gamingSetupService)
        {
            this.bookingService = bookingService;
            this.gamingSetupService = gamingSetupService;
        }

        [HttpGet]
        public IActionResult Available()
        {
            return View(new AvailableSetupDTO());
        }

        [HttpPost]
        public IActionResult Available(AvailableSetupDTO s)
        {
            if (ModelState.IsValid)
            {
                var data = bookingService.GetAvailableSetups(s);
                ViewBag.AvailableSetups = data;
            }

            return View(s);
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            var setup = gamingSetupService.Get(id);

            var b = new BookingDTO();

            b.GamingSetupId = setup.Id;
            b.TotalAmount = setup.HourlyRate;
            b.BookingStatus = "Confirmed";

            return View(b);
        }

        [HttpPost]
        public IActionResult Create(BookingDTO b)
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext.Session.GetInt32("UserId");

                if (userId != null)
                {
                    var setup = gamingSetupService.Get(b.GamingSetupId);

                    b.UserId = (int)userId;
                    b.TotalAmount = setup.HourlyRate;
                    b.BookingStatus = "Confirmed";

                    var res = bookingService.Create(b);

                    if (res == true)
                    {
                        return RedirectToAction("MyBookings");
                    }
                }

                return Unauthorized();
            }

            return View(b);
        }

        public IActionResult MyBookings()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId != null)
            {
                var data = bookingService.GetByUser((int)userId);
                return View(data);
            }

            return Unauthorized();
        }
    }
}