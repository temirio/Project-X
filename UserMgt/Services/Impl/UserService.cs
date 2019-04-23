using BaseLib.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserMgt.Models;

namespace UserMgt.Services.Impl
{
    public class UserService : IUserService
    {
        private static readonly HttpClient client = new HttpClient();
        private RestHandler<User> restHandler;

        public UserService()
        {
            this.restHandler = new RestHandler<User>();
        }

        public async Task<User> FindUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindUserByUsername(string username, string accessToken)
        {
            return await Task.Run(async() =>
            {
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("X-AUTH-TOKEN", accessToken);
                string[] pathVariables = new string[] { username };

                string path = "http://localhost:6000/rest/v1/fnmusic/usermgt/user/findbyusername/"+username+"";
                User user = await restHandler.GetForObject(path, headers, pathVariables);

                return user;
            });
        }
    }
}
