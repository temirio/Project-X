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

        public async Task<HttpResult<ServiceResponse>> UpdatePhoneAsync(string phone, string token, string accessToken)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    requestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    requestHeaders.Add("Phone", phone);
                    requestHeaders.Add("Token", token);
                    HttpResult<ServiceResponse> httpResult = await restTemplate.PutAsync(AccountSettingsBaseAddress, UpdatePhoneUri, requestHeaders, null);
                    return httpResult;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            });
        }

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

        public async Task<HttpResult<ServiceResponse>> UpdateEmailAsync(string email, string token, string accessToken)
        {
            return await Task.Run(async()=> 
            {
                try
                {
                    requestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    requestHeaders.Add("Email", email);
                    requestHeaders.Add("Token", token);
                    HttpResult<ServiceResponse> httpResult = await restTemplate.PutAsync(AccountSettingsBaseAddress, UpdateEmailUri, requestHeaders, null);
                    return httpResult;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            });
        }

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

        public Task<HttpResult<ServiceResponse>> DeactivateAccountAsync(bool status, string accessToken)
        {
            throw new NotImplementedException();
        }
        
        public Task<HttpResult<ServiceResponse>> SendTwoFactorVerificationTokenAsync(string phonenumber, string accessToken)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<ServiceResponse>> UpdateTwoFactorAsync(bool status, string token, string accessToken)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<ServiceResponse>> UpdateNationalityAsync(string country, string accessToken)
        {
            throw new NotImplementedException();
        }

        

        

       

        

        public Task<HttpResult<ServiceResponse>> VerifyEmailVerificationTokenAsync(string phone, string accessToken)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<ServiceResponse>> VerifyPasswordForPasswordResetProtectionAsync(string password, string accessToken)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResult<ServiceResponse>> VerifyPhoneVerificationTokenAsync(string phone, string accessToken)
        {
            throw new NotImplementedException();
        }
    }
}
