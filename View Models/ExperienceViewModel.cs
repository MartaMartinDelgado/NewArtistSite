using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistSite.ViewModels
{
    public class ExperienceViewModel
    {
        [Required]
        public string ArtistRole { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        [MaxLength(1000)]
        public string RoleDescription { get; set; }
        [Required]
        [EmailAddress]
        public string ContactEmail { get; set; }
        //public bool PrivatePublic { get; set; }
    }
}
