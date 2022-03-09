using AutoMapper;
using LAMS.DataAccess.Common.Models.Users;
using LAMS.DataAccess.Common.Repositories.Users;
using LAMS.Logic.Common.Models.Users;
using LAMS.Logic.Common.Services.Users;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LAMS.Logic.Services.Users
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IUserRepository _repo;

        private readonly IMapper _mapper;

        private bool _disposed;

        public RegistrationService(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _repo?.Dispose();
                _disposed = true;
                GC.SuppressFinalize(this);
            }
        }

        public async Task<string> RegisterAsync(string email, string userName, string password)
        {
            if (!await _repo.IsUserNameAvailable(userName))
            {
                // throws 409 conflict
                return null;
            }
            var id = await _repo.AddAsync(email, userName, password).ContinueWith(t => t.Result);
            return id;
        }

        public async Task<string> HrRegistration(User user)
        {
            try
            {
                if (!await _repo.IsUserNameAvailable(user.UserName))
                {
                    // throws 409 conflict
                    return null;
                }
                var id = await _repo.HrRegistration(_mapper.Map<UserDb>(user)).ContinueWith(t => t.Result);

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ~RegistrationService()
        {
            Dispose();
        }
    }
}

