using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMgt.Models
{
    public class TwoFactorVerification
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
