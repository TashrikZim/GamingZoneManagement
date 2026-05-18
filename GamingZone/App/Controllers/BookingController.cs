using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class BookingController : Controller
    {
        BookingService bookingService;

        public BookingController(BookingService bookingService)
        {
            this.bookingService = bookingService;
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
    }
}
