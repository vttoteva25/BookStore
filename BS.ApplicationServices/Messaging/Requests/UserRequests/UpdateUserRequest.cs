using BS.ApplicationServices.ViewModels;

namespace BS.ApplicationServices.Messaging.Requests.UserRequests
{
    public class UpdateUserRequest
    {
        public Guid UserId { get; set; }

        public UserVM? User { get; set; }

        public UpdateUserRequest(Guid userId, UserVM user)
        {
            UserId = userId;
            User = user;
        }
    }
}
