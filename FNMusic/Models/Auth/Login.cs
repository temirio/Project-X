using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FNMusic.Models.Auth
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public virtual string email { get; set; }

        [Required]
        public virtual string password { get; set; }
    }
}
