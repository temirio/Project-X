using BaseLib.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UserMgt.Services
{
    public interface IAuthService<T>
    {
        Task<HttpResult<T>> RegisterAsync(HttpContent content);

        Task<HttpResult<AccessTokenWithUserDetails>> LogInAsync(string email, string password);

        Task<HttpResult<ServiceResponse>> LoginVerificationAsync(string email);

        Task<HttpResult<ServiceResponse>> LoginTokenVerificationAsync(string email, string password);

        Task<HttpResult<T>> SendEmailConfirmationMessageAsync(string email);

        Task<HttpResult<T>> ActivateAccountAsync(string email, string token);

        Task<HttpResult<T>> ForgotPasswordVerificationAsync(string email);

        Task<HttpResult<T>> ForgotPasswordTokenVerificationAsync(string email, string token);

        Task<HttpResult<T>> PasswordResetAsync(string email, string resetLink);

        Task<HttpResult<T>> ResetPasswordAsync(string email, string password, string token);
    }
}
