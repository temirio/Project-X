using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;

namespace UserMgt.Utils
{
    public class AuthorizeJWToken
    {
        public static Dictionary<string,string> Authorize(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            bool isReadableToken = tokenHandler.CanReadToken(token);

            if (isReadableToken != true)
                return null;
            else
            {
                var tokenInput = tokenHandler.ReadJwtToken(token);
                var claims = tokenInput.Claims;

                Dictionary<string, string> userDetails = new Dictionary<string, string>();        
                foreach (Claim c in claims)
                {
                    userDetails.Add(c.Type, c.Value);
                }

                return userDetails;
            }
        }
    }
}
