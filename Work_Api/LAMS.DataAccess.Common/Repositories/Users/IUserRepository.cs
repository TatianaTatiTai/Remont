using LAMS.DataAccess.Common.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Repositories.Users
{
    /// <summary>
    /// Provides a standart DAL methods to work with users.
    /// </summary>
    public interface IUserRepository : IDisposable
    {
        Task<string> AddAsync(string email, string userName, string password);

        Task<UserDb> SignIn(string userName, string password);

        Task<bool> IsUserNameAvailable(string userName);

        Task<UserDb> GetUserInfo(string userName);
        Task<UserDb> DelUser(string Id);

        Task<IEnumerable<UserDb>> GetUsers();

        Task<string> HrRegistration(UserDb user);
    }
}
