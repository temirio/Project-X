using BaseLib.Models;
using BaseLib.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace UserMgt.Services.Impl
{
    public class AccountSettingsService : HostService, IAccountSettingsService<ServiceResponse>
    {
        private IRestTemplate<ServiceResponse> restTemplate;
        private HttpRequestHeaders requestHeaders;

        public AccountSettingsService(IConfiguration configuration, IRestTemplate<ServiceResponse> restTemplate) : base(configuration)
        {
            this.restTemplate = restTemplate;
            requestHeaders = new HttpRequestMessage().Headers;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<HttpResult<ServiceResponse>> UpdateUsernameAsync(string username, string accessToken)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    requestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    requestHeaders.Add("Username", username);
                    HttpResult<ServiceResponse> httpResult = await restTemplate.PutAsync(AccountSettingsBaseAddress, UpdateUsernameUri, requestHeaders, null);
                    return httpResult;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<HttpResult<ServiceResponse>> UpdatePhoneAsync(string phone, string accessToken)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    requestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    requestHeaders.Add("Phone", phone);
                    HttpResult<ServiceResponse> httpResult = await restTemplate.PutAsync(AccountSettingsBaseAddress, UpdatePhoneUri, requestHeaders, null);
                    return httpResult;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<HttpResult<ServiceResponse>> SendPhoneVerificationTokenAsync(string phone, string accessToken)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    requestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    requestHeaders.Add("Phone", phone);
                    HttpResult<ServiceResponse> httpResult = await restTemplate.PostAsync(AccountSettingsBaseAddress, SendPhoneVerificationTokenUri, requestHeaders, null);
                    return httpResult;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="token"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<HttpResult<ServiceResponse>> UpdatePhoneVerificationAsync(string phone, string token, string accessToken)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    requestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    requestHeaders.Add("Phone", phone);
                    requestHeaders.Add("Token", token);
                    HttpResult<ServiceResponse> httpResult = await restTemplate.PutAsync(AccountSettingsBaseAddress, UpdatePhoneVerificationUri, requestHeaders, null);
                    return httpResult;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<HttpResult<ServiceResponse>> UpdateEmailAsync(string email, string accessToken)
        {
            return await Task.Run(async()=> 
            {
                try
                {
                    requestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    requestHeaders.Add("Email", email);
                    HttpResult<ServiceResponse> httpResult = await restTemplate.PutAsync(AccountSettingsBaseAddress, UpdateEmailUri, requestHeaders, null);
                    return httpResult;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<HttpResult<ServiceResponse>> SendEmailVerificationTokenAsync(string email, string accessToken)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    requestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    requestHeaders.Add("Email", email);
                    HttpResult<ServiceResponse> httpResult = await restTemplate.PostAsync(AccountSettingsBaseAddress, SendEmailVerificationTokenUri, requestHeaders, null);
                    return httpResult;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="token"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<HttpResult<ServiceResponse>> UpdateEmailVerificationAsync(string email, string token, string accessToken)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    requestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    requestHeaders.Add("Email", email);
                    requestHeaders.Add("Token", token);
                    HttpResult<ServiceResponse> httpResult = await restTemplate.PutAsync(AccountSettingsBaseAddress, UpdateEmailVerificationUri, requestHeaders, null);
                    return httpResult;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentPassword"></param>
        /// <param name="newPassword"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<HttpResult<ServiceResponse>> UpdatePasswordAsync(string currentPassword, string newPassword, string accessToken)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    requestHeaders.Add("X-AUTH-OLD-PASSWORD", currentPassword);
                    requestHeaders.Add("X-AUTH-NEW-PASSWORD", newPassword);
                    requestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    HttpResult<ServiceResponse> httpResult = await restTemplate.PutAsync(AccountSettingsBaseAddress, UpdatePasswordUri, requestHeaders, null);
                    return httpResult;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<HttpResult<ServiceResponse>> SendTwoFactorVerificationTokenAsync(string phone, string accessToken)
        {
            return await Task.Run(async () => 
            {
                try
                {
                    requestHeaders.Add("Phone", phone);
                    requestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    HttpResult<ServiceResponse> httpResult = await restTemplate.PostAsync(AccountSettingsBaseAddress, SendTwoFactorVerificationTokenUri, requestHeaders, null);
                    return httpResult;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="status"></param>
        /// <param name="token"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<HttpResult<ServiceResponse>> UpdateTwoFactorAsync(string phone, bool status, string token, string accessToken)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    requestHeaders.Add("Phone", phone);
                    requestHeaders.Add("Status", status.ToString());
                    requestHeaders.Add("Token", token);
                    requestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    HttpResult<ServiceResponse> httpResult = await restTemplate.PutAsync(AccountSettingsBaseAddress, UpdateTwoFactorUri, requestHeaders, null);
                    return httpResult;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<HttpResult<ServiceResponse>> VerifyPasswordAsync(string password, string accessToken)
        {
            return await Task.Run(async () => 
            {
                try
                {
                    requestHeaders.Add("X-AUTH-PASSWORD", password);
                    requestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    HttpResult<ServiceResponse> httpResult = await restTemplate.PostAsync(AccountSettingsBaseAddress, VerifyPasswordUri, requestHeaders, null);
                    return httpResult;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<HttpResult<ServiceResponse>> UpdatePasswordResetProtectionAsync(bool status, string accessToken)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    requestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    requestHeaders.Add("Status", status.ToString());
                    HttpResult<ServiceResponse> httpResult = await restTemplate.PutAsync(AccountSettingsBaseAddress, UpdatePasswordResetProtectionUri, requestHeaders, null);
                    return httpResult;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            });
        }
        public Task<HttpResult<ServiceResponse>> DeactivateAccountAsync(bool status, string accessToken)
        {
            throw new NotImplementedException();
        }
        
        

        public Task<HttpResult<ServiceResponse>> UpdateNationalityAsync(string country, string accessToken)
        {
            throw new NotImplementedException();
        }

        
    }
}
