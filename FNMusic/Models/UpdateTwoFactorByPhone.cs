using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FNMusic.Models
{
    public class UpdateTwoFactorByPhone
    {
        public string Password { get; set; }
        public string Token { get; set; }

    }

    
}
