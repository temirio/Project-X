using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UserMgt.Models
{
    /// <summary>
    /// The model representation of a User
    /// </summary>
    public class User
    {
        #region Public Properties
        public long Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Privacy MonthAndDay { get; set; }
        public Privacy Year { get; set; }
        public string Nationality { get; set; }
        public string Phone { get; set; }
        public bool PhoneConfirmed { get; set; }
        public string Location { get; set; }
        public string Genre { get; set; }
        public string Biography { get; set; }
        [DataType(DataType.Url, ErrorMessage = "Invalid url")]
        public string Website { get; set; }
        [DataType(DataType.ImageUrl, ErrorMessage = "Invalid url")]
        public string ProfileImagePath { get; set; }
        [DataType(DataType.ImageUrl, ErrorMessage = "Invalid url")]
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
        public bool TwoFactorEnabled { get; set; }
        public bool Activated { get; set; }
        public bool PasswordResetProtection { get; set; }
        public bool Suspended { get; set; }

        #endregion

    }
}
