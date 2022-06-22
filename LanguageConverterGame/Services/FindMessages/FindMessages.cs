using LanguageConverterGame.Entities;
using LanguageConverterGame.Infraustrature;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageConverterGame.Services
{
    public class FindMessages : IFindMessages
    {
        private readonly PlaygroundContext _context;
        public FindMessages(PlaygroundContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MessageBoard>> FindMessagesAsync()
        {
            var items = await _context.MessageBoard.ToListAsync().ConfigureAwait(true);
            return items.OrderByDescending(x => x.CreateDate).Take(5).OrderBy(x=> x.CreateDate);
        }
    }
}
