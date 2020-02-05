using System;
using System.Collections.Generic;
using System.Text;

namespace UserMgt.Models
{
    public class AccessTokenWithUserDetails {
        
        public string AccessToken {get; set;}
        public string RefreshToken { get; set; }
        public string Username {get; set;}
        public User User {get; set;}
        public Feature Feature {get; set;}
        
    }
}