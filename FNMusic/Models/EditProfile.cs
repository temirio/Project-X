using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FNMusic.Models
{
    public class EditProfile
    {
        public string Username { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Nationality { get; set; }
        public string Location { get; set; }
        public string PrimaryGenre { get; set; }
        public string Biography { get; set; }
        public string Website { get; set; }
        public string ProfileImagePath { get; set; }
        public string CoverImagePath { get; set; }

    }
}
