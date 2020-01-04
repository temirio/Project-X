using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserMgt.Models
{
    public class Login
    {
        [Required(ErrorMessage = "*")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(60, MinimumLength = 8, ErrorMessage = "Password is too short")]
        public virtual string Password { get; set; }

        public virtual AuthKey AuthKey { get; set; }

    }
}
