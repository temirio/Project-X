using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserMgt.Models;

namespace UserMgt.Services
{
    public interface IUserService
    {

        Task<User> FindUserByEmail(string email);

        Task<User> FindUserByUsername(string username,string accessToken);

    }
}
