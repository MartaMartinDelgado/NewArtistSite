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
    public class ArtistsController : Controller
    {


        private readonly ArtistContext _context;
        private readonly UserManager<Artist> _userManager;
        private readonly IExperienceRepository _experienceRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly IContentRepository _contentRepository;

        public ArtistsController(ArtistContext context, IExperienceRepository experienceRepository, UserManager<Artist> userManager, IArtistRepository artistRepository, IContentRepository contentRepository)
        {
            _context = context;
            _userManager = userManager;
            _experienceRepository = experienceRepository;
            _artistRepository = artistRepository;
            _contentRepository = contentRepository;
        }

        [HttpGet("update/{id:Guid}")]
        public IActionResult Update(Guid id)
        {
            ViewBag.Title = "Artist";

            var artist = _artistRepository.GetById(id);
            var artistViewModel = new ArtistViewModel();

            artistViewModel.Id = new Guid(artist.Id);
            artistViewModel.FName = artist.FName;
            artistViewModel.LName = artist.LName;
            artistViewModel.Email = artist.Email;
            artistViewModel.Bio = artist.Bio;


            return View(artistViewModel);
        }

        [Authorize]
        [HttpPost("update/{id:Guid}")]
        public async Task<IActionResult> Update(Guid id, ArtistViewModel model)
        {
            if (ModelState.IsValid)
            {
                var artist = _artistRepository.GetById(id);

                artist.FName = model.FName;
                artist.LName = model.LName;
                artist.Email = model.Email;
                artist.Bio = model.Bio;

                await _artistRepository.UpdateAsync(artist);

                return Redirect("/artist/" + Guid.Parse(artist.Id));
            }
            return View(model);
        }

    }
}
