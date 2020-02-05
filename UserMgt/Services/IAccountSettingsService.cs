using BaseLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UserMgt.Services
{
    public interface IAccountSettingsService<T>
    {
        //Account Settings
        Task<HttpResult<T>> UpdateUsernameAsync(string username, string accessToken);

        Task<HttpResult<T>> UpdatePhoneAsync(string phone, string accessToken);

        Task<HttpResult<T>> SendPhoneVerificationTokenAsync(string phone, string accessToken);

        Task<HttpResult<T>> UpdatePhoneVerificationAsync(string phone, string token, string accessToken);

        Task<HttpResult<T>> UpdateEmailAsync(string email, string accessToken);

        Task<HttpResult<T>> SendEmailVerificationTokenAsync(string email, string accessToken);

        Task<HttpResult<T>> UpdateEmailVerificationAsync(string email, string token, string accessToken);

        Task<HttpResult<T>> UpdatePasswordAsync(string currentPassword, string newPassword, string accessToken);

        Task<HttpResult<T>> SendTwoFactorVerificationTokenAsync(string phone, string accessToken);

        Task<HttpResult<T>> UpdateTwoFactorAsync(string phone, bool status, string token, string accessToken);

        Task<HttpResult<T>> VerifyPasswordAsync(string password, string accessToken);

        Task<HttpResult<T>> UpdatePasswordResetProtectionAsync(bool status, string accessToken);

        Task<HttpResult<T>> UpdateNationalityAsync(string country, string accessToken);

        Task<HttpResult<T>> DeactivateAccountAsync(bool status, string accessToken);



    }
}
