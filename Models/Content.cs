using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Content
    {
        public int Id { get; set; }
        public string ArtistId { get; set; }
        public string ContentName { get; set; }
        public DateTime DateRecorded { get; set; }
        public CategoryEnum Category { get; set; }
        //URL Link to actual content stored elsewhere, e.g. in YouTube
        public string Link { get; set; }
        //1 or True for Private content, 0 or False for Public content
        //Double-check if bool is the correct type
        public bool PrivateContent { get; set; }
        public Artist Artist { get; set; }


        public Content()
        { }

        public Content(string contentName, DateTime dateRec, CategoryEnum category, string link, bool priv, Artist artist)
        {
            ContentName = contentName;
            DateRecorded = dateRec;
            Category = category;
            Link = link;
            PrivateContent = priv;
            Artist = artist;
        }
    }
}
