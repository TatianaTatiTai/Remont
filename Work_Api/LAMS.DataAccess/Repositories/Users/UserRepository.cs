using LAMS.DataAccess.Common.Models.Users;
using LAMS.DataAccess.Common.Repositories.Users;
using LAMS.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly DocContext _context;


        private bool _disposed;

        public UserRepository(DocContext context) => _context = context;

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                GC.SuppressFinalize(this);
            }
        }

        public async Task<string> AddAsync(string email, string userName, string password)
        {
            string id = Guid.NewGuid().ToString();

            var user = new UserDb
            {
                Id = id,
                Created = DateTime.UtcNow,
                Email = email,
                Password = password,
                UserName = userName,
                RoleId = "f4c9fe7b-1e77-4e67-8800-1d33948b22a1",
                Name = "",
                Surname = "",
            };

            var result = _context.Users.Add(user);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return result.UserName;
        }    
        public async Task<UserDb> DelUser(string Id)
        {
            UserDb user = await _context.Users.FirstOrDefaultAsync(p => p.Id == Id).ConfigureAwait(false);

            var result = _context.Users.Remove(user);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return result;
        }

        public async Task<UserDb> SignIn(string userName, string password)
        {
            return await _context.Users.Where(p =>
                                    p.UserName == userName && p.Password == password
                                    ).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<bool> IsUserNameAvailable(string userName)
        {
            return !(await _context.Users.AnyAsync(u => u.UserName == userName).ConfigureAwait(false));
        }

        public async Task<UserDb> GetUserInfo(string userName)
        {
            return await _context.Users.Where(p =>
                                    p.UserName == userName).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<string> HrRegistration(UserDb user)
        {
            user.Id = Guid.NewGuid().ToString();
            user.Created = DateTime.UtcNow;
            user.RoleId = "f285ccac-1a2f-4df3-ace4-0751f105dafc";
            _context.Users.Add(user);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return user.Id;
        }

        public async Task<IEnumerable<UserDb>> GetUsers()
        {
            return await _context.Users.Where(o =>
                o.RoleId != "2d314154-6b40-47d7-a277-385e17b114c0"
            ).ToListAsync().ConfigureAwait(false);
        }

        ~UserRepository()
        {
            Dispose();
        }
    }
}
