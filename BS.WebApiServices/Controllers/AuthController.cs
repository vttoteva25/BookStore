using BS.ApplicationServices.Interfaces;
using BS.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BS.WebApiServices.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJWTAuthenticationsManager _jwtauthenticationsManager;

        public AuthController(IJWTAuthenticationsManager jwtauthenticationsManager)
        {
            _jwtauthenticationsManager = jwtauthenticationsManager;
        }

        [HttpPut]
        public async Task<AuthenticationResponse> Authenticate([FromQuery] Customer customer)
        {
            string? token = _jwtauthenticationsManager.Authenticate(customer);

            ArgumentNullException.ThrowIfNull(token);

            return await Task.FromResult(new AuthenticationResponse() { Token = token });
        }
    }

    public class AuthenticationResponse
    {
        required public string Token { get; set; }
    }
}
