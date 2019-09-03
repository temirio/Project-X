using System;
using System.Collections.Generic;
using System.Text;

namespace BaseLib.Models
{
    public class AccessTokenWithUserDetails {
        
        public string AccessToken {get; set;}
        public string Username {get; set;}
        public User User {get; set;}
        public Feature Feature {get; set;}
        
        
    }
}