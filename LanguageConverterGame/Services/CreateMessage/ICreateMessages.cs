using LanguageConverterGame.Entities;
using System.Threading.Tasks;

namespace LanguageConverterGame.Services
{
    public interface ICreateMessages
    {
        Task<MessageBoard> CreateMessageAsync(MessageBoard message);
    }
}
