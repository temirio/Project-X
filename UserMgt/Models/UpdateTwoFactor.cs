using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UserMgt.Models
{
    public class UpdateTwoFactor
    {
        [Required]
        public bool Enabled { get; set; }

        public VerificationMethod VerificationMethod { get; set; }

        public string Token { get; set; }

    }

    public enum VerificationMethod
    {
        TextMessage,
        MobileSecurityApp,
        SecurityKey
    }
}
