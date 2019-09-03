using System;
using System.Collections.Generic;
using System.Text;

namespace BaseLib.Models
{
    public class ServiceResponse
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public List<Error> Errors { get; set; }

    }
}
