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
                artist.Experiences = _context.Experiences.Where(x => x.ArtistId == artist.Id).ToList();
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

                await _experienceRepository.InsertAsync(experience);
                ModelState.Clear();
            }

            return View();
        }

        [Authorize]
        [HttpPost("deleteExperience/{id:int}")]
        //[HttpPost("deleteExperience/{id:int}")]
        public async Task DeleteExperience(int id)
        {
            var experience = await _experienceRepository.GetByIdAsync(id);
            _experienceRepository.DeleteAsync(experience);
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

        [HttpPost("experience/{id:int}")]
        public async Task<IActionResult> Experience(int id, ExperienceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var experience = await _experienceRepository.GetByIdAsync(id);

                experience.ArtistRole = model.ArtistRole;
                experience.StartDate = model.StartDate;
                experience.EndDate = model.EndDate;
                experience.RoleDescription = model.RoleDescription;
                experience.Contact = model.ContactEmail;

                await _experienceRepository.UpdateAsync(experience);
                //var user = _artistRepository.GetById()

                return Redirect("/artist/" + Guid.Parse(experience.ArtistId));
            }

            return View(model);
        }

        [HttpGet("artist/{id:Guid}")]
        public async Task<IActionResult> Artist(Guid id)
        {
            ViewBag.Title = "Artist";

            Guid currentUserId = Guid.Empty;

            try
            {
                var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
                currentUserId = new Guid(currentUser.Id);
            }
            catch (Exception ex) { }

            var artist = _artistRepository.GetById(id);
            var artistViewModel = new ArtistViewModel();

            artistViewModel.Id = new Guid(artist.Id);
            artistViewModel.CurrentUserId = currentUserId;
            artistViewModel.FName = artist.FName;
            artistViewModel.LName = artist.LName;
            artistViewModel.Email = artist.Email;
            artistViewModel.Bio = artist.Bio;
            artistViewModel.Experiences = _context.Experiences.Where(x => x.Artist.Id == artist.Id).ToList();
            artistViewModel.Contents = _context.Contents.Where(x => x.Artist.Id == artist.Id).ToList();
            //artistViewModel.Contents = _context.Contents.Where(x => x.Artist.Id == artist.Id && !x.PrivateContent).ToList();

            return View(artistViewModel);
        }

       

        [Authorize]
        [HttpGet("content")]
        public IActionResult Content()
        {
            return View();
        }

        // Create
        [HttpPost("content")]
        public async Task<IActionResult> Content(ContentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
                var content = new Content(model.ContentName, model.DateRecorded, model.Category, model.Link, model.PrivateContent, currentUser);

                await _contentRepository.InsertAsync(content);
                //_context.Contents.Add(content);
                //_context.SaveChanges();
                ModelState.Clear();
            }
            return View();
        }

        //Delete
        [Authorize]
        [HttpPost("deleteContent/{id:int}")]
        public async Task DeleteContent(int id)
        {
            var content = await _contentRepository.GetByIdAsync(id);
            _contentRepository.DeleteAsync(content);
        }

        //Display Content Updated /to be Updated
        [Authorize]
        [HttpGet("Content/{id:int}")]
        public async Task<IActionResult> Content(int id)
        {
            var content = await _contentRepository.GetByIdAsync(id);
            var contentViewModel = new ContentViewModel();

            contentViewModel.ContentName = content.ContentName;
            contentViewModel.DateRecorded = content.DateRecorded;
            contentViewModel.Category = content.Category;
            contentViewModel.Link = content.Link;
            contentViewModel.PrivateContent = content.PrivateContent;

            return View(contentViewModel);
        }

        //Update Content
        [HttpPost("Content/{id:int}")]
        public async Task<IActionResult> Content(int id, ContentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var content = await _contentRepository.GetByIdAsync(id);

                content.ContentName = model.ContentName;
                content.DateRecorded = model.DateRecorded;
                content.Category = model.Category;
                content.Link = model.Link;
                content.PrivateContent = model.PrivateContent;

                await _contentRepository.UpdateAsync(content);

                return Redirect("/artist/" + Guid.Parse(content.ArtistId));
            }

            return View(model);
        }
    }
}
