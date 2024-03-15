using System.ComponentModel.DataAnnotations;

namespace BS.ApplicationServices.Messaging.Requests.UserRequests.AuthenticateUser
{
    public class AuthenticateUserRequest 
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
