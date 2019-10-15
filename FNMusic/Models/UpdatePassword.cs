using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FNMusic.Models
{
    public class UpdatePassword
    {
        [Required(ErrorMessage = "*")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "*")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "*")]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }
    }
}
