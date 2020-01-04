using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BaseLib.Models;
using BaseLib.Services;
using UserMgt.Models;

namespace FNMusic.Services.Impl
{
    public class UserService : HostService, IUserService<Result<User>>
    {
        private IRestTemplate<Result<User>> restTemplate;
        private HttpRequestHeaders requestHeaders;

        public UserService(IConfiguration configuration, IRestTemplate<Result<User>> restTemplate) : base(configuration)
        {
            this.restTemplate = restTemplate;
            requestHeaders = new HttpRequestMessage().Headers;
        }

        public async Task<HttpResult<Result<User>>> FindUserById(long id, string accessToken) {
            return await Task.Run(async () =>
            {
                try
                {
                    requestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    string requestUri = FindByIdUri + id;
                    HttpResult<Result<User>> result = await restTemplate.GetAsync(UserBaseAddress, requestUri, requestHeaders, null);
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });
        }

        public async Task<HttpResult<Result<User>>> FindUserByEmail(string email, string accessToken)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    requestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    string requestUri = FindByEmailUri + email;
                    HttpResult<Result<User>> result = await restTemplate.GetAsync(UserBaseAddress, requestUri, requestHeaders, null);
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });
        }

        public async Task<HttpResult<Result<User>>> FindUserByPhone(string phone, string accessToken)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    requestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    string requestUri = FindByPhoneUri + phone;
                    HttpResult<Result<User>> result = await restTemplate.GetAsync(UserBaseAddress, requestUri, requestHeaders, null);
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });
        }

        public async Task<HttpResult<Result<User>>> FindUserByUsername(string username, string accessToken)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    requestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    string requestUri = FindByUsernameUri + username;
                    HttpResult<Result<User>> result = await restTemplate.GetAsync(UserBaseAddress, requestUri, requestHeaders, null);
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });
        }

        public async Task UpdateProfile(HttpContent httpContent, string accessToken)
        {
            await Task.Run(async() =>
            {
                try
                {
                    requestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    await restTemplate.PutAsync(UserBaseAddress, UpdateProfileUri, requestHeaders, httpContent);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });
        }

        public async Task FollowUser(long userId, long fanId, string accessToken)
        {
            await Task.Run(async()=> {
                try
                {
                    requestHeaders.Add("UserId",userId.ToString());
                    requestHeaders.Add("FanId", fanId.ToString());
                    requestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    
                    await restTemplate.PostAsync(UserBaseAddress, FollowUri, requestHeaders, null);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });
        }

        public async Task UnfollowUser(long userId, long fanId, string accessToken)
        {
            await Task.Run(async () => {
                try
                {
                    requestHeaders.Add("UserId",userId.ToString());
                    requestHeaders.Add("FanId", fanId.ToString());
                    requestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    await restTemplate.PostAsync(UserBaseAddress, UnfollowUri, requestHeaders, null);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });
        }

        public async Task<HttpResult<Result<User>>> GetFollowers(long id, int pageNumber, int pageSize, string accessToken)
        {
            return await Task.Run(async () => 
            {
                try
                {
                    requestHeaders.Add("UserId", id.ToString());
                    requestHeaders.Add("PageNumber", pageNumber.ToString());
                    requestHeaders.Add("PageSize", pageSize.ToString());
                    requestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    HttpResult<Result<User>> result = await restTemplate.GetAsync(UserBaseAddress, GetFollowersUri, requestHeaders, null);
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });
        }

        public async Task<HttpResult<Result<User>>> GetFollowing(long id, int pageNumber, int pageSize, string accessToken)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    requestHeaders.Add("UserId", id.ToString());
                    requestHeaders.Add("PageNumber", pageNumber.ToString());
                    requestHeaders.Add("PageSize", pageSize.ToString());
                    requestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    HttpResult<Result<User>> result = await restTemplate.GetAsync(UserBaseAddress, GetFollowingUri, requestHeaders, null);
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });
        }

        public async Task<HttpResult<Result<User>>> IsFollower(long userId, long fanId, string accessToken)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    requestHeaders.Add("UserId", userId.ToString());
                    requestHeaders.Add("FanId", fanId.ToString());
                    requestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    HttpResult<Result<User>> result = await restTemplate.GetAsync(UserBaseAddress, IsFollowerUri, requestHeaders, null);
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });
        }

        public async Task<HttpResult<Result<User>>> IsFollowing(long userId, long fanId, string accessToken)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    requestHeaders.Add("UserId", userId.ToString());
                    requestHeaders.Add("FanId", fanId.ToString());
                    requestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    HttpResult<Result<User>> result = await restTemplate.GetAsync(UserBaseAddress, IsFollowingUri, requestHeaders, null);
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });
        }

        public async Task<HttpResult<Result<User>>> LogOut(string accessToken)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    requestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    HttpResult<Result<User>> result = await restTemplate.PostAsync(UserBaseAddress, LogOutUri, requestHeaders, null);
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });
        }

        
    }
}
