using ArtistSite.Services;
using ArtistSite.ViewModels;
using DataLayer;
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
        private readonly ArtistContext _context;

        public AppController(IMailService mailService, ArtistContext context)
        {
            _mailService = mailService;
            _context = context;
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

        //public IActionResult Content()
        //{
        //    var results = from c in _context.Contents
        //                  orderby c.Category
        //                  select c;

        //    return View(results.ToList());
        //}

        [HttpGet("Artists")]
        public IActionResult Artists()
        {
            var results = from a in _context.Artists
                          orderby a.Username
                          select a;

            return View(results.ToList());
        }
    }
}
