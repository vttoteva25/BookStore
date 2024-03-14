using BS.ApplicationServices.Interfaces;
using BS.Data.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BS.ApplicationServices.Implementations
{
    public class JWTAuthenticationsManager : IJWTAuthenticationsManager
    {
        private readonly IConfiguration configuration;
        private readonly string _secret;

        /// <summary>
        /// Initializes a new instance of the JWTAuthenticationsManager class.
        /// </summary>
        /// <param name="config">The configuration settings for JWT token generation.</param>
        public JWTAuthenticationsManager(IConfiguration config)
        {
            this.configuration = config;
            this._secret = configuration["AppSettings:Secret"];
        }

        /// <summary>
        /// Creates a JWT token for the specified user.
        /// </summary>
        /// <param name="user">The user for whom the token is generated.</param>
        /// <returns>Returns the generated JWT token.</returns>
        public string GenerateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] 
                { new Claim("id", user.UserId.ToString()), new Claim("username", user.Username.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }       
    }
}
