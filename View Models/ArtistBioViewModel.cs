using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArtistSite.View_Models
{
    public class ArtistBioViewModel
    {
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
    }
}
