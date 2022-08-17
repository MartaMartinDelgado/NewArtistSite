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
        private readonly IArtistRepository _artistRepository;
        private readonly IContentRepository _contentRepository;

        public AppController(ArtistContext context, IExperienceRepository experienceRepository, UserManager<Artist> userManager, IArtistRepository artistRepository, IContentRepository contentRepository)
        {
            _context = context;
            _userManager = userManager;
            _experienceRepository = experienceRepository;
            _artistRepository = artistRepository;
            _contentRepository = contentRepository;
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
        [HttpGet("experience/{id:int}")]
        public async Task<IActionResult> Experience(int id)
        {
            var experience = await _experienceRepository.GetByIdAsync(id);
            var experienceViewModel = new ExperienceViewModel();

            experienceViewModel.ArtistRole = experience.ArtistRole;
            experienceViewModel.StartDate = experience.StartDate;
            experienceViewModel.EndDate = experience.EndDate;
            experienceViewModel.RoleDescription = experience.RoleDescription;
            experienceViewModel.ContactEmail = experience.Contact;
            return View(experienceViewModel);
        }

        [Authorize]
        [HttpGet("experience")]
        public IActionResult Experience()
        {
            return View();
        }

        [HttpPost("experience/{id:int}")]
        public async Task<IActionResult> Experience(ExperienceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
                var experience = new Experience(model.ArtistRole, model.StartDate, model.EndDate, model.RoleDescription, model.ContactEmail, currentUser);

                await _experienceRepository.InsertAsync(experience);
                ModelState.Clear();
            }

            return View();
        }

        [HttpGet("artist/{id:Guid}")]
        public IActionResult Artist(Guid id)
        {
            ViewBag.Title = "Artist";

            var artist = _artistRepository.GetById(id);
            var artistViewModel = new ArtistViewModel();
            artistViewModel.FName = artist.FName;
            artistViewModel.LName = artist.LName;
            artistViewModel.Email = artist.Email;
            artistViewModel.Bio = artist.Bio;
            artistViewModel.Experiences = _context.Experiences.Where(x => x.Artist.Id == artist.Id).ToList();
            artistViewModel.Contents = _context.Contents.Where(x => x.Artist.Id == artist.Id && !x.PrivateContent).ToList();

            return View(artistViewModel);
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

    }
}
