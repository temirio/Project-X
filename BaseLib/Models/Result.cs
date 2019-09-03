using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseLib.Models
{
    public class Result<T>
    {
        public List<T> List { get; set; }
        public T Data { get; set; }
        public int ResultCode { get; set; }
        public long IdentityValue { get; set; }
        public long NoOfRecords { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
