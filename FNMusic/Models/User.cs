using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FNMusic.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Username{ get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public string Email{ get; set; }
        public string PasswordHash{ get; set; }
        public string Gender{ get; set; }
        public DateTime DateOfBirth{ get; set; }
        public string Nationality{ get; set; }
        public string PhoneNumber{ get; set; }
        public string Location{ get; set; }
        public string PrimaryGenre{ get; set; }
        public string Biography{ get; set; }
        public string Website{ get; set; }
        public string ProfileImagePath{ get; set; }
        public string CoverImagePath{ get; set; }
        public long Following{ get; set; }
        public long Followers{ get; set; }
        public string Role{ get; set; }
        public string AccountVerificationStatus{ get; set; }
        public DateTime DateCreated{ get; set; }
        public bool LockOutEnabled{ get; set; }
        public DateTime LockOutEndDateUtc{ get; set; }
    }
}
