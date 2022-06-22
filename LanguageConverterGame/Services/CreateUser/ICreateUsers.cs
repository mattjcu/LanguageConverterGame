using LanguageConverterGame.Entities;
using System.Threading.Tasks;

namespace LanguageConverterGame.Services.CreateUser
{
    public interface ICreateUsers
    {
        Task<User> CreateUserAsync(User user);
    }
}
