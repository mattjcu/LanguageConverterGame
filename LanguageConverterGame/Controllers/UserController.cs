using LanguageConverterGame.Entities;
using LanguageConverterGame.Infraustrature;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using LanguageConverterGame.Services;
using LanguageConverterGame.Services.CreateUser;
using System;

namespace LanguageGame.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly PlaygroundContext _context;
        private readonly IFindUsers _findUserService;
        private readonly ICreateUsers _createUserService;
        public UserController(PlaygroundContext context, IFindUsers findUserService, ICreateUsers createUserService)
        {
            _context = context;
            _findUserService = findUserService;
            _createUserService = createUserService;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            return await _context.User.ToListAsync();
        }

        [HttpGet]
        [Route("active")]
        public async Task<ActionResult<IEnumerable<User>>> GetActiveUsers()
        {
            var result = await _findUserService.GetActiveUsersAsync().ConfigureAwait(true);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _findUserService.FindUserAsync(id).ConfigureAwait(true);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody]User user)
        {
            var foundUser = await _findUserService.FindUserAsync(user.UserName).ConfigureAwait(true);

            if (foundUser != null)
            {
                return BadRequest("This user already exists!");
            }

            var createdUser = await _createUserService.CreateUserAsync(user).ConfigureAwait(true);
            return Ok(createdUser);
        }

    }
}
