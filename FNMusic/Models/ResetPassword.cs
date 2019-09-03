using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FNMusic.Models
{
    public class ResetPassword
    {
        [Required(ErrorMessage = "*")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        public string Password { get; set; }

        [JsonIgnore]
        [Required(ErrorMessage = "*")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
