using BaseLib.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BaseLib.Services
{
    public class RestTemplate<T> : IRestTemplate<T> where T : class
    {
        private HttpClient client;
        private HttpRequestMessage httpRequestMessage;
        private HttpResponseMessage httpResponseMessage;
        private HttpResult<T> httpResult;

        public RestTemplate()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<HttpResult<T>> GetAsync(string baseAddress, string requestUri, HttpRequestHeaders headers, HttpContent content)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    client.BaseAddress = new Uri(baseAddress);
                    AddRequestHeaders(client, headers);
                    httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri)
                    {
                        Content = content
                    };
                    httpResponseMessage = await client.SendAsync(httpRequestMessage);
                    httpResult = await HandleResponse(httpResponseMessage);
                    return httpResult;
                }
                catch (Exception ex)
                {
                    if (ex.GetType() == typeof(HttpRequestException))
                    {
                        throw new Exception("Service Unavailable");
                    }

                    throw new Exception(ex.Message);
                }
            });
        }

        public async Task<HttpResult<T>> PostAsync(string baseAddress, string requestUri, HttpRequestHeaders headers, HttpContent httpContent)
        {
            return await Task.Run(async () => 
            {
                try
                {
                    client.BaseAddress = new Uri(baseAddress);
                    AddRequestHeaders(client, headers);
                    httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri)
                    {
                        Content = httpContent
                    };
                    httpResponseMessage = await client.SendAsync(httpRequestMessage);
                    httpResult = await HandleResponse(httpResponseMessage);
                    return httpResult;
                }
                catch (Exception ex)
                {
                    if (ex.GetType() == typeof(HttpRequestException))
                    {
                        throw new Exception("Service Unavailable");
                    }

                    throw new Exception(ex.Message);
                }
            });
        }

        public async Task<HttpResult<T>> PutAsync(string baseAddress, string requestUri, HttpRequestHeaders headers, HttpContent httpContent)
        {
            return await Task.Run(async () => 
            {
                try
                {
                    client.BaseAddress = new Uri(baseAddress);
                    AddRequestHeaders(client, headers);
                    httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, requestUri)
                    {
                        Content = httpContent
                    };
                    httpResponseMessage = await client.SendAsync(httpRequestMessage);
                    httpResult = await HandleResponse(httpResponseMessage);
                    return httpResult;
                }
                catch (Exception ex)
                {
                    if (ex.GetType() == typeof(HttpRequestException))
                    {
                        throw new Exception("Service Unavailable");
                    }

                    throw new Exception(ex.Message);
                }
            });
        }

        public async Task<HttpResult<T>> DeleteAsync(string baseAddress, string requestUri, HttpRequestHeaders headers)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    client.BaseAddress = new Uri(baseAddress);
                    AddRequestHeaders(client, headers);
                    httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, requestUri);
                    httpResponseMessage = await client.SendAsync(httpRequestMessage);
                    httpResult = await HandleResponse(httpResponseMessage);
                    return httpResult;
                }
                catch (Exception ex)
                {
                    if (ex.GetType() == typeof(HttpRequestException))
                    {
                        throw new Exception("Service Unavailable");
                    }

                    throw new Exception(ex.Message);
                }
            });    
        }

        private void AddRequestHeaders(HttpClient httpClient, HttpRequestHeaders headers)
        {
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
        }

        private async Task<HttpResult<T>> HandleResponse(HttpResponseMessage _httpResponseMessage)
        {
            HttpResult<T> result = new HttpResult<T>
            {
                Status = _httpResponseMessage.StatusCode,
                Headers = _httpResponseMessage.Headers
            };

            if (!this.httpResponseMessage.IsSuccessStatusCode)
            {
                var failResponse = await Fail(this.httpResponseMessage);
                result.FailureResponse = failResponse;
            }
            else
            {
                if (_httpResponseMessage.Content != null)
                {
                    string json = await httpResponseMessage.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(json))
                    {
                        T obj = (T)JsonConvert.DeserializeObject(json, typeof(T));
                        result.Content = obj;
                    }
                }
            }

            return result;
        }

        private async Task<ServiceResponse> Fail(HttpResponseMessage httpResponseMessage)
        {
            string json = await httpResponseMessage.Content.ReadAsStringAsync();
            return (ServiceResponse) JsonConvert.DeserializeObject(json, typeof(ServiceResponse));
        }
    }
}
