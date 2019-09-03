using BaseLib.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BaseLib.Services
{
    public interface IRestTemplate<T> where T: class
    {
        Task<HttpResult<T>> GetAsync(string baseAddress, string requestUri, HttpRequestHeaders headers, HttpContent content);

        Task<HttpResult<T>> PostAsync(string baseAddress, string requestUri, HttpRequestHeaders headers, HttpContent content);

        Task<HttpResult<T>> PutAsync(string baseAddress, string requestUri, HttpRequestHeaders headers, HttpContent content);

        Task<HttpResult<T>> DeleteAsync(string baseAddress, string requestUri, HttpRequestHeaders headers);
    }
}
