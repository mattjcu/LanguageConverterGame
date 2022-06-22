using LanguageConverterGame.Entities;
using LanguageConverterGame.Extensions;
using LanguageConverterGame.Infraustrature;
using System.Threading.Tasks;

namespace LanguageConverterGame.Services.CreateUser
{
    public class CreateUser : ICreateUsers
    {

        private readonly PlaygroundContext _context;
        public CreateUser(PlaygroundContext context)
        {
            _context = context;

        }
        public async Task<User> CreateUserAsync(User user)
        {
            user.Active = true;
            var result = _context.User.AddIfNotExists(user, x => x.UserName == user.UserName);
            if (result is null)
            {
                return null;
            }
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return user;
        }
    }
}
