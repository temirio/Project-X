using System;
using System.Collections.Generic;

namespace UserMgt.Models {
    
    public class Feature {

        public string Name {get; set;}
        public string Description {get;set;}
        public List<Permission> Permissions {get; set;}
    }
}