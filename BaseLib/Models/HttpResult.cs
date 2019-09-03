using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace BaseLib.Models
{
    public class HttpResult<T>
    {
        public HttpStatusCode Status { get; set; }
        public HttpResponseHeaders Headers { get; set; }
        public T Content { get; set; }
        public ServiceResponse FailureResponse { get; set; }
    }
}
