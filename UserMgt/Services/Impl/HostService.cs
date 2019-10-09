using UserMgt.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using BaseLib.Services;

namespace UserMgt.Services.Impl
{
    public class HostService : GatewayHostService
    {
        public IConfiguration configuration;

        public HostService(IConfiguration configuration) : base (configuration)
        {
            this.configuration = configuration;
        }

        private string GetIPAddress()
        {
            return configuration.GetValue<string>("services:userMgt:ipAddress");
        }

        private string GetPort()
        {
            return configuration.GetValue<string>("services:userMgt:port");
        }

        private string GetGatewayPath()
        {
            return configuration.GetValue<string>("services:userMgt:gatewayPath");
        }

        public string GetBaseAddress()
        {
            if (GetGatewayAddress() != null)
            {
                if (!string.IsNullOrEmpty(GetGatewayPath()))
                    return GetGatewayAddress() + "/" + GetGatewayPath() + "/";
            }
                
            return "http://" + GetIPAddress() + ":" + GetPort() + "/";
        }

        public string AuthBaseAddress => string.Concat(GetBaseAddress(), configuration.GetValue<string>("services:userMgt:auth:basePath"));
        public string SignUpUri => configuration.GetValue<string>("services:userMgt:auth:signUp");
        public string SignInUri => configuration.GetValue<string>("services:userMgt:auth:signIn");
        public string SignInVerificationUri => configuration.GetValue<string>("services:userMgt:auth:signInVerification");
        public string SignInTokenVerificationUri => configuration.GetValue<string>("services:userMgt:auth:signInTokenVerification");
        public string ConfirmationUri => configuration.GetValue<string>("services:userMgt:auth:confirm");
        public string ActivateUri => configuration.GetValue<string>("services:userMgt:auth:activate");
        public string ForgotPasswordVerificationUri => configuration.GetValue<string>("services:userMgt:auth:forgotPasswordVerification");
        public string ForgotPasswordTokenVerificationUri => configuration.GetValue<string>("services:userMgt:auth:forgotPasswordTokenVerification");
        public string PasswordResetUri => configuration.GetValue<string>("services:userMgt:auth:passwordReset");
        public string ResetPasswordUri => configuration.GetValue<string>("services:userMgt:auth:resetPassword");


        public string UserBaseAddress => string.Concat(GetBaseAddress(), configuration.GetValue<string>("services:userMgt:user:basePath"));
        public string FindByIdUri => configuration.GetValue<string>("services:userMgt:user:findById");
        public string FindByEmailUri => configuration.GetValue<string>("services:userMgt:user:findByEmail");
        public string FindByUsernameUri => configuration.GetValue<string>("services:userMgt:user:findByUsername");
        public string UpdateProfileUri => configuration.GetValue<string>("services:userMgt:user:update");
        public string FollowUri => configuration.GetValue<string>("services:userMgt:user:follow");
        public string UnfollowUri => configuration.GetValue<string>("services:userMgt:user:unfollow");
        public string GetFollowersUri => configuration.GetValue<string>("services:userMgt:user:followers");
        public string GetFollowingUri => configuration.GetValue<string>("services:userMgt:user:following");
        public string IsFollowerUri => configuration.GetValue<string>("services:userMgt:user:isFollower");
        public string IsFollowingUri => configuration.GetValue<string>("services:userMgt:user:isFollowing");
        public string LogOutUri => configuration.GetValue<string>("services:userMgt:user:logOut");

        //Account Settings Service
        public string AccountSettingsBaseAddress => string.Concat(GetBaseAddress(), configuration.GetValue<string>("services:userMgt:settings:account:basePath"));
        public string UpdateUsernameUri => configuration.GetValue<string>("services:userMgt:settings:account:username");
        public string SendPhoneVerificationTokenUri => configuration.GetValue<string>("services:userMgt:settings:account:updatePhoneVerification");
        public string UpdatePhoneUri => configuration.GetValue<string>("services:userMgt:settings:account:phone");
        public string SendEmailVerificationTokenUri => configuration.GetValue<string>("services:userMgt:settings:account:updateEmailVerification");
        public string UpdateEmailUri => configuration.GetValue<string>("services:userMgt:settings:account:email");
        public string UpdatePasswordUri => configuration.GetValue<string>("services:userMgt:settings:account:password");
        public string SendTwoFactorVerificationTokenUri => configuration.GetValue<string>("services:userMgt:settings:account:updateTwoFactorVerification");
        public string UpdateTwoFactorUri => configuration.GetValue<string>("services:userMgt:settings:account:twoFactor");
        public string VerifyPasswordUri => configuration.GetValue<string>("services:userMgt:settings:account:verifyPassword");
        public string PasswordResetProtectionUri => configuration.GetValue<string>("services:userMgt:settings:account:passwordResetProtection");
        public string UpdateNationalityUri => configuration.GetValue<string>("services:userMgt:settings:account:nationality");
        public string Deactivateuri => configuration.GetValue<string>("services:userMgt:settings:account:deactivate");

    }
}
