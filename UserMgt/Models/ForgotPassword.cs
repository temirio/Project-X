using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserMgt.Models
{
    public class ForgotPassword
    {
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid Phone")]
        public string Phone { get; set; }

        [StringLength(maximumLength: 7, MinimumLength = 6)]
        public string Token { get; set; }

        [Required(ErrorMessage = "Invalid Request")]
        public AuthKey AuthKey { get; set; }
    }
}
