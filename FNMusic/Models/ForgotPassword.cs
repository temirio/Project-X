using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FNMusic.Models
{
    public class ForgotPassword
    {
        [Required(ErrorMessage = "*")]
        [EmailAddress]
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
