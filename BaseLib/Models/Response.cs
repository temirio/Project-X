using System;
using System.Collections.Generic;
using System.Text;

namespace BaseLib.Models
{
    public class Response
    {
        public string Token { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public List<Error> Errors { get; set; }
    }
}
