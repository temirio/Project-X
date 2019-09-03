using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BaseLib.Models;

namespace UserMgt.Services
{
    public interface IUserService<T>
    {
        Task<HttpResult<T>> FindUserByEmail(string email);

        Task<HttpResult<T>> FindUserByUsername(string username);

        Task UpdateProfile(HttpContent httpContent, string accessToken);

        Task FollowUser(long userId, long fanId, string accessToken);

        Task UnfollowUser(long userId, long fanId, string accessToken);

        Task<HttpResult<T>> GetFollowers(long id, int pageNumber, int pageSize, string accessToken);

        Task<HttpResult<T>> GetFollowing(long id, int pageNumber, int pageSize, string accessToken);

        Task<HttpResult<T>> IsFollower(long userId, long fanId, string accessToken);

        Task<HttpResult<T>> IsFollowing(long userId, long fanId, string accessToken);

        Task<HttpResult<T>> LogOut(string accessToken);

    }
}
