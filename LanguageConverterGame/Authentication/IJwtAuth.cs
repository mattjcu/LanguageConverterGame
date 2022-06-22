using System.Threading.Tasks;

namespace LanguageConverterGame.Authentication
{
    public interface IJwtAuth
    {
        Task<string> AuthenticateUser(string userName, string password);
    }
}
