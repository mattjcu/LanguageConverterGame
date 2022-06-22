using LanguageConverterGame.Entities;
using LanguageConverterGame.Infraustrature;
using LanguageConverterGame.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LanguageGame.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MessageBoardController : ControllerBase
    {
        private readonly PlaygroundContext _context;
        private readonly IFindUsers _findUserService;
        private readonly ICreateMessages _createMessageService;
        private readonly ITranslateMessages _translateMessageService;
        private readonly IFindMessages _findMessageService;
        public MessageBoardController(PlaygroundContext context, IFindUsers findUserService, ICreateMessages createMessageService, ITranslateMessages translateMessageService, IFindMessages findMessageService)
        {
            _context = context;
            _findUserService = findUserService;
            _createMessageService = createMessageService;
            _translateMessageService = translateMessageService;
            _findMessageService = findMessageService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageBoard>>> GetAllMessageBoards()
        {
            return Ok(await _findMessageService.FindMessagesAsync().ConfigureAwait(true));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MessageBoard>> GetMessageBoard(int id)
        {
            var messageBoard = await _context.MessageBoard.FindAsync(id).ConfigureAwait(true);

            if (messageBoard is null)
            {
                return NotFound();
            }

            return messageBoard;
        }

        [HttpPost]
        public async Task<ActionResult<MessageBoard>> PostMessageBoard([FromQuery] string userName, MessageBoard message)
        {
            var verifiedUser = await _findUserService.FindUserAsync(userName).ConfigureAwait(true);
            if (verifiedUser is null)
            {
                return BadRequest("Unable to find user");
            }
            message.UserId = verifiedUser.Id;
            message.UserName = verifiedUser.UserName;
            var createdMessage = await _createMessageService.CreateMessageAsync(message).ConfigureAwait(true);
            return Ok(createdMessage);
        }

        [HttpPost]
        [Route("Translate")]
        public async Task<ActionResult> TranslateMessage(MessageBoard message)
        {
            var translatedMessage = await _translateMessageService.Translate(message.Message).ConfigureAwait(true);
            return Ok(new TranslatedResponse { TranslatedMessage = translatedMessage });
        }

    }
}
