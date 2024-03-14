using BS.ApplicationServices.ViewModels;

namespace BS.ApplicationServices.Messaging.Requests.CustomerRequests
{
    public class UpdateCustomerRequest
    {
        public Guid UserId { get; set; }

        public UserVM? User { get; set; }

        public UpdateCustomerRequest(Guid userId, UserVM user)
        {
            UserId = userId;
            User = user;
        }
    }
}
