using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FNMusic.Models
{
    public class Login
    {
        [Required(ErrorMessage = "*")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "*")]
        public virtual string Password { get; set; }

    }
}
