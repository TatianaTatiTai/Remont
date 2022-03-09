using LAMS.Logic.Common.Models.Users;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LAMS.Logic.Common.Services.Users
{
    /// <summary>
    /// Standart BL level interface provides standart methods of working with User model.
    /// </summary>
    public interface IUserService : IDisposable
    {
        Task<User> SignIn(string userName, string password);
        Task<User> GetUserInfo(string userName);
        Task<User> DelUser(string Id);


        Task<IEnumerable<User>> GetUsers();
    }
}
