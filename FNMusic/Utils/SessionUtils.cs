using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMgt.Utils;

namespace FNMusic.Utils
{
    public class SessionUtils : Controller
    {

        public Dictionary<string, string> AddUserSessionDetails(string token)
        {
            Dictionary<string, string> userDetails = AuthorizeJWToken.Authorize(token);
            userDetails.Add("X-AUTH-TOKEN", token);

            foreach (string key in userDetails.Keys)
            {
                HttpContext.Session.SetString(key.ToString(), userDetails.GetValueOrDefault(key));
            }

            return userDetails;
        }
    }
}
