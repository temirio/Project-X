using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BaseLib.Services
{
    public class RestHandler<T> where T: class
    {

        private HttpClient client;

        public RestHandler()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }

        public void SetDefaultRequestHeaders(Dictionary<string,string> headers)
        {
            
            foreach (var header in headers)
            {
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }

            
        }

        public string ModifyRequestUrl(string url, string[] pathVariables)
        {
            
            if (pathVariables != null)
            {
                int pathLength = pathVariables.Length;
                for (int i = 0; i < pathLength; i++)
                {
                    url += "/"+pathVariables[i]+"";
                }

                return url;
            }

            return url;
        }

        public Task<T> GetForObject(string path, Dictionary<string,string> headers, string[] pathVariables)
        {       
            return Task.Run(async () =>
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(path);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        T model = (T) JsonConvert.DeserializeObject(json);
                        return model;
                    }
                    
                    return null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            });       
        }
    }
}
