using BaseLib.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace FNMusic.Services
{
    public interface IUserService<T>
    {
        Task<HttpResult<T>> FindUserById(long id, string accessToken);

        Task<HttpResult<T>> FindUserByEmail(string email, string accessToken);

        Task<HttpResult<T>> FindUserByPhone(string phone, string accessToken);

        Task<HttpResult<T>> FindUserByUsername(string username, string accessToken);

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
