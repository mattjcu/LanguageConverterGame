using LanguageConverterGame.Entities;
using LanguageConverterGame.Infraustrature;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageConverterGame.Extensions;

namespace LanguageConverterGame.Services
{
    public class FindUser : IFindUsers
    {
        private readonly PlaygroundContext _context;
        public FindUser(PlaygroundContext context)
        {
            _context = context;
        }

        public async Task<User> FindUserAsync(int id)
        {
            return await _context.User.FindAsync(id).ConfigureAwait(true);
        }

        public async Task<User> FindUserAsync(string userName)
        {
            return await _context.User.SingleOrDefaultAsync(user => user.UserName == userName).ConfigureAwait(true);
        }

        public async Task<bool> VerifyUserIsActiveAndMatching(string userName, string password)
        {
            if(userName is null || password is null)
            {
                return false;
            }
            var activeUsers = await GetActiveUsersAsync().ConfigureAwait(true);
            if (FindMatchingUser(activeUsers, userName, password) is null)
            {
                return false;
            }
            return true;
        }

        public async Task<IEnumerable<User>> GetActiveUsersAsync()
        {
            var users =  await _context.User.ToArrayAsync();
            var activeUsers = users.Where(s => s.Active);
            return activeUsers;
        }

        private User FindMatchingUser(IEnumerable<User> allActiveUsers, string userName, string password)
        {
            var user = allActiveUsers.FirstOrDefault(s => s.UserName.TrimAndUpper() == userName.TrimAndUpper() && s.Password.TrimAndUpper() == password.TrimAndUpper()) ?? null;
            return user;
        }
    }
}
