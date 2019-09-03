using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserMgt.Services.Impl
{
    public class HostService
    {
        public IConfiguration configuration;

        public HostService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GetIPAddress()
        {
            return configuration.GetValue<string>("services:userMgt:ipAddress");
        }

        public string GetPort()
        {
            return configuration.GetValue<string>("services:userMgt:port");
        }

        public string GetBaseAddress()
        {
            return "http://" + GetIPAddress() + ":" + GetPort() + "/";
        }

        public string AuthBaseAddress => string.Concat(GetBaseAddress(),configuration.GetValue<string>("services:userMgt:auth:basePath"));
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


        public string UserBaseAddress => string.Concat(GetBaseAddress(),configuration.GetValue<string>("services:userMgt:user:basePath"));
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
    }
}
