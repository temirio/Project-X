using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UserMgt.Models;

namespace FNMusic.Models
{
    public class EditProfile
    {
        [MinLength(1,ErrorMessage = "name cannot be blank")]
        public string Name { get; set; }
        public string Biography { get; set; }
        public string Genre { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
        public DateTime DateOfBirth { get; set; }
        public Privacy MonthAndDay { get; set; }
        public Privacy Year { get; set; }
        public string Twitter { get; set; }
        public string FaceBook { get; set; }
        public string Youtube { get; set; }
        public string ProfileImagePath { get; set; }
        public string CoverImagePath { get; set; }
        public MultipartFileData ProfilePhoto { get; set; }
        public MultipartFileData CoverPhoto { get; set; }
    }
}
