using BaseLib.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UserMgt.Services
{
    public interface IAuthService
    {
        Task<Response> Register(HttpContent content);
        Task<Response> Login(HttpContent content);
    }
}
