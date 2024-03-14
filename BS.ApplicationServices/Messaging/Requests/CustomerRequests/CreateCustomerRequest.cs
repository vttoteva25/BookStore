using BS.ApplicationServices.ViewModels;

namespace BS.ApplicationServices.Messaging.Requests.CustomerRequests
{
    public class CreateCustomerRequest
    {
        public RegisterUserVM User { get; set; }

        public CreateCustomerRequest(RegisterUserVM user)
        {
            User = user;
        }
    }
}
