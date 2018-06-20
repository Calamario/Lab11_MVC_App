using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Time_PotY.Models;

namespace Time_PotY.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int startYear, int endYear)
        {
            return RedirectToAction("Results", new { startYear, endYear });
        }

        public IActionResult Results(int startYear, int endYear)
        {
            //Okay to do for titles
            ViewData["Message"] = "Person of the Year Results";

            TimePerson person = new TimePerson();

            return View(person.GetPeople(startYear, endYear)); 
        }

    }
}
