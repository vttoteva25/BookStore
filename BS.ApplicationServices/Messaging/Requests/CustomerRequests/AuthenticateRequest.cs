using System.ComponentModel.DataAnnotations;

namespace BS.ApplicationServices.Messaging.Requests.CustomerRequests
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
