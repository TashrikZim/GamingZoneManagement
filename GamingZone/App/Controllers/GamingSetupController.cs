using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class GamingSetupController : Controller
    {
        GamingSetupService gamingSetupService;

        public GamingSetupController(GamingSetupService gamingSetupService)
        {
            this.gamingSetupService = gamingSetupService;
        }
        public IActionResult Index()
        {
            var data = gamingSetupService.Get();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new GamingSetupDTO());
        }

        [HttpPost]
        public IActionResult Create(GamingSetupDTO g)
        {
            if (ModelState.IsValid)
            {
                var res = gamingSetupService.Create(g);

                if (res == true)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(g);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = gamingSetupService.Get(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(GamingSetupDTO g)
        {
            if (ModelState.IsValid)
            {
                var res = gamingSetupService.Update(g);

                if (res == true)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(g);
        }

        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    var data = gamingSetupService.Get(id);
        //    return View(data);
        //}

        //[HttpPost]
        //public IActionResult Delete(int id, string Decision)
        //{
        //    if (Decision.Equals("Yes"))
        //    {
        //        gamingSetupService.Delete(id);
        //        return RedirectToAction("Index");
        //    }

        //    return RedirectToAction("Index");
        //}


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = gamingSetupService.Get(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Delete(int id, string Decision)
        {
            if (Decision.Equals("Yes"))
            {
                gamingSetupService.Delete(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
