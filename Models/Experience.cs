using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Experience
    {
        public int Id { get; set; }
        public string ArtistId  { get; set; }
        public string ArtistRole { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RoleDescription { get; set; }
        public string Contact { get; set; }
        //Add extra attribute to be able to select whether to display the experience or not
        //public bool PrivatePublic { get; set; }
        public Artist Artist { get; set; }

        public Experience()
        { }

        public Experience(string artistRole, DateTime startDate, DateTime endDate, string roleDesc, string contact, Artist artist)
        {
            ArtistRole = artistRole;
            StartDate = startDate;
            EndDate = endDate;
            RoleDescription = roleDesc;
            Contact = contact;
            Artist = artist;
        }
    }
}
