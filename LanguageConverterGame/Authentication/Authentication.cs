using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using LanguageConverterGame.Services;
using System.Threading.Tasks;

namespace LanguageConverterGame.Authentication
{
    public class Authenticate : IJwtAuth
    {

        private readonly string _key;
        private readonly IFindUsers _findUserService;
        public Authenticate(string key, IFindUsers findUsersService)
        {
            _key = key;
            _findUserService = findUsersService;
        }
        public async Task<string> AuthenticateUser(string username, string password)
        {
            var userLookup = await _findUserService.VerifyUserIsActiveAndMatching(username, password).ConfigureAwait(true);
            if (userLookup == false)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, username)
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}