using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FNMusic.Models
{
    public class Register : Login
    {
        [Required(ErrorMessage = "*")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Username too short!!!")]
        public string Username { get; set; }

        [StringLength(15, MinimumLength = 2, ErrorMessage = "First Name too short")]
        public string FirstName { get; set; }
        
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Last Name too short")]
        public string LastName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        [Required(ErrorMessage = "*")]
        [EmailAddress (ErrorMessage = "Please input a valid email address")]
        public string Email { get => base.UserId; set => base.UserId = value; }

        [Required(ErrorMessage = "*")]
        public override string Password { get => base.Password; set => base.Password = value; }

        [JsonIgnore]
        [Required(ErrorMessage = "*")]
        [Compare("Password",ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

    }
}
