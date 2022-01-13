using ArtistSite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistSite.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("experience")]
        public IActionResult Experience()
        {
            return View();
        }

        [HttpPost("experience")]
        public IActionResult Experience(ExperienceViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Save to Exp list
            }
            else
            {
                // Show error
            }
            return View();
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            ViewBag.Title = "About";

            return View();
        }
    }
}
