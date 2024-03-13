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
        private readonly SymmetricSecurityKey key;

        /// <summary>
        /// Initializes a new instance of the JWTAuthenticationsManager class.
        /// </summary>
        /// <param name="config">The configuration settings for JWT token generation.</param>
        public JWTAuthenticationsManager(IConfiguration config)
        {
            this.configuration = config;
            this.key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SigningKey"]));
        }

        /// <summary>
        /// Creates a JWT token for the specified customer.
        /// </summary>
        /// <param name="customer">The customer for whom the token is generated.</param>
        /// <returns>Returns the generated JWT token.</returns>
        public string Authenticate(Customer customer)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, customer.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, customer.UserName)
            };

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDesc = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credentials,
                Issuer = configuration["JWT:Issuer"],
                Audience = configuration["JWT:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDesc);

            return tokenHandler.WriteToken(token);
        }       
    }
}
