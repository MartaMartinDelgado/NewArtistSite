using ArtistSite.Repositories;
using ArtistSite.Services;
using ArtistSite.ViewModels;
using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistSite.Controllers
{
    public class AppController : Controller
    {
        private readonly ArtistContext _context;
        private readonly UserManager<Artist> _userManager;
        private readonly IExperienceRepository _experienceRepository;

        public AppController(ArtistContext context, IExperienceRepository experienceRepository, UserManager<Artist> userManager)
        {
            _context = context;
            _userManager = userManager;
            _experienceRepository = experienceRepository;
        }

        public IActionResult Index()
        {
            var results = _context.Artists.ToList();

            foreach (var artist in results)
            {
                artist.Experiences = _context.Experiences.Where(x => x.Artist.Id == artist.Id).ToList();
            }

            return View(results.ToList());
            //return View();
        }

        [Authorize]
        [HttpGet("experience")]
        public IActionResult Experience()
        {
            return View();
        }

        [HttpPost("experience")]
        public async Task<IActionResult> Experience(ExperienceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
                var experience = new Experience(model.ArtistRole, model.StartDate, model.EndDate, model.RoleDescription, model.ContactEmail, currentUser);

                _context.Experiences.Add(experience);
                _context.SaveChanges();
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

        [Authorize]
        [HttpGet("content")]
        public IActionResult Content()
        {
            return View();
        }

        [HttpPost("content")]
        public async Task<IActionResult> Content(ContentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
                var content = new Content(model.ContentName, model.DateRecorded, model.Category, model.Link, model.PrivateContent, currentUser);

                _context.Contents.Add(content);
                _context.SaveChanges();
                ModelState.Clear();
            }
            return View();
        }

        [HttpGet("Artists")]
        public IActionResult Artists()
        {
            var results = from a in _context.Artists
                          orderby a.Email
                          select a;

            return View(results.ToList());
        }
    }
}
