using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FNMusic.Models
{
    public class Activate
    {
        [Required(ErrorMessage = "*")]
        [EmailAddress(ErrorMessage = "kindly fill in a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        public string Token { get; set; }
    }
}
