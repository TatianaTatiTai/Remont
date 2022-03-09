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
    public interface IRegistrationService : IDisposable
    {
        Task<string> RegisterAsync(string email, string userName, string password);


        Task<string> HrRegistration(User user);
    }
}
