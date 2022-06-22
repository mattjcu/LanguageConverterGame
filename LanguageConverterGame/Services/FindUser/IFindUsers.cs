using LanguageConverterGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageConverterGame.Services
{
    public interface IFindUsers
    {
        public Task<bool> VerifyUserIsActiveAndMatching(string userName, string password);
        public Task<IEnumerable<User>> GetActiveUsersAsync();
        public Task<User> FindUserAsync(int id);
        public Task<User> FindUserAsync(string userName);

    }
}
