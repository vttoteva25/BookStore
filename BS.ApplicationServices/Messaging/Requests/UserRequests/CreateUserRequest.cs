using BS.ApplicationServices.ViewModels;

namespace BS.ApplicationServices.Messaging.Requests.UserRequests
{
    public class CreateUserRequest
    {
        public RegisterUserVM User { get; set; }

        public CreateUserRequest(RegisterUserVM user)
        {
            User = user;
        }
    }
}
