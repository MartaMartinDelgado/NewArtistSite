using ArtistSite.Services;
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
        private readonly IMailService _mailService;

        public AppController(IMailService mailService)
        {
            _mailService = mailService;
        }
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
                //test send email
                _mailService.SendMessage("marta.martin.d93@gmail.com", model.ArtistRole, $"From: {model.ContactEmail}, Message: {model.RoleDescription}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();

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
