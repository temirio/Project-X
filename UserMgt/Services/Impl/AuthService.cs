using BaseLib.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserMgt.Utils;

namespace UserMgt.Services.Impl
{
    public class AuthService : IAuthService
    {
        private static readonly HttpClient client = new HttpClient();

        public Task<Response> Register(HttpContent content)
        {    
            return Task.Run(async ()=>
            {
                Response response = new Response();
                try
                {
                    HttpResponseMessage httpResponse = await client.PostAsync("http://localhost:6000/rest/v1/fnmusic/usermgt/auth/signup", content);
                    if (httpResponse.StatusCode.Equals(HttpStatusCode.Created))
                    {
                        string json = await httpResponse.Content.ReadAsStringAsync();
                        JObject jsonObject = JObject.Parse(json);
                        response.Code = jsonObject["code"].ToString();
                        response.Description = jsonObject["description"].ToString();
                        response.Token = jsonObject["accessToken"].ToString();      
                    }

                    return response;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }         
            });
        }

        public Task<Response> Login(HttpContent content)
        {     
            return Task.Run(async ()=> 
            {
                Response response = new Response();
                try
                {
                    HttpResponseMessage httpResponse = await client.PostAsync("http://localhost:6000/rest/v1/fnmusic/usermgt/auth/login", content);
                    if (httpResponse.StatusCode.Equals(HttpStatusCode.OK))
                    {
                        string json = await httpResponse.Content.ReadAsStringAsync();
                        JObject jsonObject = JObject.Parse(json);
                        response.Code = jsonObject["code"].ToString();
                        response.Description = jsonObject["description"].ToString();
                        response.Token = jsonObject["accessToken"].ToString();
                    }
                   
                    return response;
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    return null;
                }               
            });
        }

        
    }
}
