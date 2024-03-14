using BS.ApplicationServices.ViewModels;

namespace BS.ApplicationServices.Messaging.Responses.UserResponse
{
    public class GetAllUsersResponse : ServiceResponseBase
    {
        public List<UserVM> Users { get; set; }
    }
}
