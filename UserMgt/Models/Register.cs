using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserMgt.Models
{
    public class Register
    {
        [Required(ErrorMessage = "*")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Username too short!!!")]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = "Please input a valid Email")]
        public string Email { get; set; }
    
        [Phone(ErrorMessage = "Please input a valid phone")]
        public string Phone { get; set; } 

        [Required(ErrorMessage = "*")]
        [StringLength(60,MinimumLength = 8, ErrorMessage = "Password is too short")]
        public virtual string Password { get; set; }

        [JsonIgnore]
        [Required(ErrorMessage = "*")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "*")]
        public DateTime DateCreated { get; set; }

        public virtual AuthKey AuthKey { get; set; }
    }
}
