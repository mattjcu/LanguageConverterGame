using LanguageConverterGame.Authentication;
using LanguageConverterGame.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace LanguageGame.Controllers
{

    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IJwtAuth _jwtAuth;
        public LoginController(IJwtAuth jwtAuth)
        {
            _jwtAuth = jwtAuth;
        }

        [AllowAnonymous]
        [HttpPost()]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var token = await _jwtAuth.AuthenticateUser(user.UserName, user.Password).ConfigureAwait(true);
            if (token is null)
            {
                return Unauthorized();
            }

            return Ok(new AuthenticatedResponse { Token = token, UserName = user.UserName });
        }

    }
}
