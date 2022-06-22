using LanguageConverterGame.Entities;
using LanguageConverterGame.Infraustrature;
using System;
using System.Threading.Tasks;

namespace LanguageConverterGame.Services
{
    public class CreateMessage : ICreateMessages
    {

        private readonly PlaygroundContext _context;
        private readonly ITranslateMessages _translateMessageService;
        public CreateMessage(PlaygroundContext context, ITranslateMessages translateMessageService)
        {
            _context = context;
            _translateMessageService = translateMessageService;
        }

        public async Task<MessageBoard> CreateMessageAsync(MessageBoard message)
        {
            message.TranslatedMessage = await _translateMessageService.Translate(message.Message).ConfigureAwait(true);
            message.CreateDate = DateTime.Now;
            await _context.AddAsync(message).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return message;
        }
    }
}
