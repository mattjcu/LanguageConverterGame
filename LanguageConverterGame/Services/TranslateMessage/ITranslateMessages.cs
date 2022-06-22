
using System.Threading.Tasks;

namespace LanguageConverterGame.Services
{
    public interface ITranslateMessages
    {
        public Task<string> Translate(string message);
    }
}
