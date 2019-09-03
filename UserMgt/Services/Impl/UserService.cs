using BaseLib.Models;
using BaseLib.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace UserMgt.Services.Impl
{
    public class UserService : HostService, IUserService<Result<User>>
    {
        private IRestTemplate<Result<User>> restTemplate;
        private HttpRequestHeaders RequestHeaders;

        public UserService(IConfiguration configuration, IRestTemplate<Result<User>> restTemplate) : base(configuration)
        {
            this.restTemplate = restTemplate;
            RequestHeaders = new HttpRequestMessage().Headers;
        }

        public async Task<HttpResult<Result<User>>> FindUserByEmail(string email)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    string requestUri = FindByEmailUri + email;
                    HttpResult<Result<User>> result = await restTemplate.GetAsync(UserBaseAddress, requestUri, RequestHeaders, null);
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });
        }

        public async Task<HttpResult<Result<User>>> FindUserByUsername(string username)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    string requestUri = FindByUsernameUri + username;
                    HttpResult<Result<User>> result = await restTemplate.GetAsync(UserBaseAddress, requestUri, RequestHeaders, null);
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
                    RequestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    await restTemplate.PutAsync(UserBaseAddress, UpdateProfileUri, RequestHeaders, httpContent);
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
                    RequestHeaders.Add("UserId",userId.ToString());
                    RequestHeaders.Add("FanId", fanId.ToString());
                    RequestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    
                    await restTemplate.PostAsync(UserBaseAddress, FollowUri, RequestHeaders, null);
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
                    RequestHeaders.Add("UserId",userId.ToString());
                    RequestHeaders.Add("FanId", fanId.ToString());
                    RequestHeaders.Add("X-AUTH-TOKEN", accessToken);
                   
                    await restTemplate.PostAsync(UserBaseAddress, UnfollowUri, RequestHeaders, null);
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
                    RequestHeaders.Add("UserId", id.ToString());
                    RequestHeaders.Add("PageNumber", pageNumber.ToString());
                    RequestHeaders.Add("PageSize", pageSize.ToString());
                    RequestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    HttpResult<Result<User>> result = await restTemplate.GetAsync(UserBaseAddress, GetFollowersUri, RequestHeaders, null);
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
                    RequestHeaders.Add("UserId", id.ToString());
                    RequestHeaders.Add("PageNumber", pageNumber.ToString());
                    RequestHeaders.Add("PageSize", pageSize.ToString());
                    RequestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    HttpResult<Result<User>> result = await restTemplate.GetAsync(UserBaseAddress, GetFollowingUri, RequestHeaders, null);
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
                    RequestHeaders.Add("UserId", userId.ToString());
                    RequestHeaders.Add("FanId", fanId.ToString());
                    RequestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    HttpResult<Result<User>> result = await restTemplate.GetAsync(UserBaseAddress, IsFollowerUri, RequestHeaders, null);
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
                    RequestHeaders.Add("UserId", userId.ToString());
                    RequestHeaders.Add("FanId", fanId.ToString());
                    RequestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    HttpResult<Result<User>> result = await restTemplate.GetAsync(UserBaseAddress, IsFollowingUri, RequestHeaders, null);
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
                    RequestHeaders.Add("X-AUTH-TOKEN", accessToken);
                    HttpResult<Result<User>> result = await restTemplate.PostAsync(UserBaseAddress, LogOutUri, RequestHeaders, null);
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
