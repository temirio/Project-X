using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FNMusic.Models.Auth
{
    public class Register : Login
    {
        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string username { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 2)]
        public string firstname { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 2)]
        public string lastname { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime dateOfBirth { get; set; }

        [Required]
        public string gender { get; set; }

        [Required]
        public override string email { get => base.email; set => base.email = value; }

        [Required]
        public override string password { get => base.password; set => base.password = value; }


    }
}
