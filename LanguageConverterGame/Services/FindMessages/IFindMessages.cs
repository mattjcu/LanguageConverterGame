using LanguageConverterGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageConverterGame.Services
{
    public interface IFindMessages
    {
        public Task<IEnumerable<MessageBoard>> FindMessagesAsync();
        
    }
}
