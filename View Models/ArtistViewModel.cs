using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArtistSite.ViewModels
{
    public class ArtistViewModel
    {
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Bio { get; set; }
        [Required]
        public DateTime UpdatedOn { get; set; }
        public ICollection<ExperienceViewModel> Experiences { get; set; }
        public ICollection<ContentViewModel> Contents { get; set; }

    }
}
