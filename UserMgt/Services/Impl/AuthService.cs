using BaseLib.Models;
using BaseLib.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

namespace UserMgt.Services.Impl
{
    public class AuthService : HostService, IAuthService<ServiceResponse>
    {
        private IRestTemplate<ServiceResponse> restTemplate;
        private IRestTemplate<AccessTokenWithUserDetails> loginRestTemplate;
        private HttpRequestHeaders httpRequestHeaders;

        public AuthService(IConfiguration configuration, IRestTemplate<ServiceResponse> restTemplate, IRestTemplate<AccessTokenWithUserDetails> loginRestTemplate) : base (configuration)
        {
            this.restTemplate = restTemplate;
            this.loginRestTemplate = loginRestTemplate;
            httpRequestHeaders = new HttpRequestMessage().Headers;
        }

        public async Task<HttpResult<ServiceResponse>> RegisterAsync(HttpContent content)
        {    
            return await Task.Run(async ()=>
            {
                try
                {
                    HttpResult<ServiceResponse> response = await restTemplate.PostAsync(AuthBaseAddress, SignUpUri, null, content);
                    return response;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });
        }

        public async Task<HttpResult<AccessTokenWithUserDetails>> LogInAsync(string uid, string password)
        {     
            return await Task.Run(async ()=> 
            { 
                try
                {
                    httpRequestHeaders.Add("X-AUTH-UID", uid);
                    httpRequestHeaders.Add("X-AUTH-PASSWORD", password);
                    HttpResult<AccessTokenWithUserDetails> response = await loginRestTemplate.PostAsync(AuthBaseAddress, SignInUri, httpRequestHeaders, null);
                    return response;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });
        }

        public async Task<HttpResult<ServiceResponse>> LoginVerificationAsync(string email)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    httpRequestHeaders.Add("X-AUTH-EMAIL", email);
                    HttpResult<ServiceResponse> response = await restTemplate.PostAsync(AuthBaseAddress, SignInVerificationUri, httpRequestHeaders, null);
                    return response;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });
        }

        public async Task<HttpResult<ServiceResponse>> LoginTokenVerificationAsync(string email, string token)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    httpRequestHeaders.Add("X-AUTH-EMAIL", email);
                    httpRequestHeaders.Add("X-AUTH-TOKEN", token);
                    HttpResult<ServiceResponse> response = await restTemplate.PostAsync(AuthBaseAddress, SignInTokenVerificationUri, httpRequestHeaders, null);
                    return response;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });
        }

        public async Task<HttpResult<ServiceResponse>> SendEmailConfirmationMessageAsync(string email)
        {
            return await Task.Run(async()=> 
            {
                try
                {
                    httpRequestHeaders.Add("Email", email);
                    httpRequestHeaders.Add("ActivationLink", "/activate/");
                    HttpResult<ServiceResponse> response = await restTemplate.PostAsync(AuthBaseAddress, ConfirmationUri, httpRequestHeaders, null);
                    return response;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });
        }

        public async Task<HttpResult<ServiceResponse>> ActivateAccountAsync(string email, string token)
        {
            return await Task.Run(async () => {
                try
                {
                    httpRequestHeaders.Add("Email", email);
                    httpRequestHeaders.Add("Token", token);
                    HttpResult<ServiceResponse> response = await restTemplate.PostAsync(AuthBaseAddress, ActivateUri, httpRequestHeaders, null);
                    return response;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });
        }

        public async Task<HttpResult<ServiceResponse>> ForgotPasswordVerificationAsync(string email)
        {
            return await Task.Run((Func<Task<HttpResult<ServiceResponse>>>)(async () => {
                try
                {
                    httpRequestHeaders.Add("Email", email);
                    HttpResult<ServiceResponse> response = await restTemplate.PostAsync(AuthBaseAddress, ForgotPasswordVerificationUri, httpRequestHeaders, null);
                    return response;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }));
        }

        public async Task<HttpResult<ServiceResponse>> ForgotPasswordTokenVerificationAsync(string email, string token)
        {
            return await Task.Run((Func<Task<HttpResult<ServiceResponse>>>)(async () =>
            {
                try
                {
                    httpRequestHeaders.Add("Email", email);
                    httpRequestHeaders.Add("Token", token);
                    HttpResult<ServiceResponse> response = await restTemplate.PostAsync(AuthBaseAddress, ForgotPasswordTokenVerificationUri, httpRequestHeaders, null);
                    return response;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }));
        }

        public async Task<HttpResult<ServiceResponse>> PasswordResetAsync(string email, string resetLink)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    httpRequestHeaders.Add("Email", email);
                    httpRequestHeaders.Add("ResetLink", resetLink);
                    HttpResult<ServiceResponse> response = await restTemplate.PostAsync(AuthBaseAddress, PasswordResetUri, httpRequestHeaders, null);
                    return response;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });
        }

        public async Task<HttpResult<ServiceResponse>> ResetPasswordAsync(string email, string password, string token)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    httpRequestHeaders.Add("X-AUTH-EMAIL", email);
                    httpRequestHeaders.Add("X-AUTH-NEW-PASSWORD", password);
                    httpRequestHeaders.Add("X-AUTH-RESET-TOKEN", token);
                    HttpResult<ServiceResponse> response = await restTemplate.PostAsync(AuthBaseAddress, ResetPasswordUri, httpRequestHeaders, null);
                    return response;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });
        }

    }
}
