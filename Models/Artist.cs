using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Artist : IdentityUser
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Bio { get; set; }
        public DateTime UpdatedOn { get; set; }
        //Convert this to a list to display all available experiences
        public ICollection<Experience> Experiences { get; set; }
        public ICollection<Content> Contents { get; set; }


        public Artist()
        { }

        public Artist(string fName, string lName, string email, string bio, DateTime updatedOn, ICollection<Experience> experiences, ICollection<Content> contents)
        {
            FName = fName;
            LName = lName;
            Email = email;
            Bio = bio;
            UpdatedOn = updatedOn;
            Experiences = experiences;
            Contents = contents;
        }
    }
}
