using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArtistSite.ViewModels
{
    public class ArtistViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        public string Email { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Bio { get; set; }
        [Required]
        public DateTime UpdatedOn { get; set; }
        public ICollection<Experience> Experiences { get; set; }
        public ICollection<Content> Contents { get; set; }

    }
}
