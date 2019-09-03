using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BaseLib.Models
{
    public class User
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "*")]
        public string Username { get; set; }

        [Required(ErrorMessage = "*")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*")]
        public string LastName { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "*")]
        public Privacy MonthAndDay { get; set; }

        [Required(ErrorMessage = "*")]
        public Privacy Year { get; set; }

        [Required(ErrorMessage = "*")]
        public string Nationality { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public string Location { get; set; }

        public string Genre { get; set; }

        public string Biography { get; set; }

        public string Website { get; set; }

        public string ProfileImagePath { get; set; }

        public string CoverImagePath { get; set; }

        public long Following { get; set; }

        public long Followers { get; set; }

        [DataType(DataType.Url, ErrorMessage = "Invalid url")]
        public string TwitterProfile { get; set; }

        [DataType(DataType.Url, ErrorMessage = "Invalid url")]
        public string FacebookProfile { get; set; }

        [DataType(DataType.Url, ErrorMessage = "Invalid url")]
        public string YoutubePage { get; set; }

        public Role Role { get; set; }

        public bool Verified { get; set; }

        public DateTime DateCreated { get; set; }

        public MultipartFileData ProfilePhoto { get; set; }

        public MultipartFileData CoverPhoto { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public bool Activated { get; set; }

        public bool PasswordResetProtection { get; set; }

        public bool Suspended { get; set; }

        
    }
}
