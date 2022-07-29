using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArtistSite.ViewModels
{
    public class ContentViewModel
    {
        [Required]
        public string ContentName { get; set; }
        [Required]
        public DateTime DateRecorded { get; set; }
        [Required]
        public Model.CategoryEnum Category { get; set; }
        [Required]
        public string Link { get; set; }
        [Required]
        public bool PrivateContent { get; set; }

    }
}
