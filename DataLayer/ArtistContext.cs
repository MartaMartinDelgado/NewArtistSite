using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model;

namespace DataLayer
{
    public class ArtistContext : IdentityDbContext<Artist>
    {
        private readonly IConfiguration _config;

        public ArtistContext(IConfiguration config)
        {
            _config = config;
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Content> Contents{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionStrings:ArtistContextDb"], b => b.MigrationsAssembly("ArtistSite"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Artist>()
            //    .HasData(new Artist()
            //    {
            //        Id = 1,
            //        FName = "Ana",
            //        LName = "Martin Delgado",
            //        Email = "ana.martin1995@gmail.com"
            //    });

        }

    }
}
