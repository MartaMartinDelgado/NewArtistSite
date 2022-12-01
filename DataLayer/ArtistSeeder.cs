using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ArtistSeeder
    {
        private readonly ArtistContext _ctx;
        private readonly IHostingEnvironment _hosting;
        private readonly UserManager<Artist> _userManager;

        public ArtistSeeder(ArtistContext ctx, IHostingEnvironment hosting, UserManager<Artist> userManager)
        {
            _ctx = ctx;
            _hosting = hosting;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            _ctx.Database.EnsureCreated();

            Artist artist = await _userManager.FindByEmailAsync("ana.martin1995@gmail.com");
            if (artist == null)
            {
                artist = new Artist()
                {
                    FName = "Ana",
                    LName = "Martin Delgado",
                    Email = "ana.martin1995@gmail.com",
                    UserName = "ana.martin1995@gmail.com",
                    UpdatedOn = DateTime.Now
                };

                var result = await _userManager.CreateAsync(artist, "P@ssw0rd!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user in Seeder");
                }

                var experience = _ctx.Experiences.Where(e => e.Id == 1).FirstOrDefault();
                if(experience != null)
                {
                    experience.Artist = artist;
                    experience.ArtistRole = "Second Basoon";
                    experience.StartDate = new DateTime(2021,08,01);
                    experience.EndDate = new DateTime(2022,07,30);
                    experience.RoleDescription = "Prakticum";
                    experience.Contact = "marta.martin.d93@gmail.com";
                }

                var content = _ctx.Contents.Where(c => c.Id == 1).FirstOrDefault();
                if (content != null)
                {
                    content.Artist = artist;
                    content.ContentName = "Audition";
                    content.DateRecorded = new DateTime(2021, 12, 01);
                    content.Category = CategoryEnum.Video;
                    content.Link = "www.YouTube.com";
                    content.PrivateContent = false;
                }
            }

            //if (!_ctx.Artists.Any())
            //{
            //    var artist1 = new Artist()
            //    {
            //        FName = "Ana",
            //        LName = "Martin Delgado",
            //        Email = "ana.martin1995@gmail.com",
            //        UpdatedOn = DateTime.Today
            //    };

                var artist2 = new Artist()
                {
                    FName = "Marta",
                    LName = "Martin",
                    Email = "marta.martin.d93@gmail.com"
                };
                var artist3 = new Artist()
                {
                    FName = "Leandro",
                    LName = "Dantas",
                    Email = "leandro@gmail.com"
                };
                var artist4 = new Artist()
                {
                    FName = "Monse",
                    LName = "Delgado",
                    Email = "monse@gmail.com"
                };

                _ctx.Artists.Add(artist2);
                _ctx.Artists.Add(artist3);
                _ctx.Artists.Add(artist4);

            _ctx.SaveChanges();
            //}
        }
    }
}
