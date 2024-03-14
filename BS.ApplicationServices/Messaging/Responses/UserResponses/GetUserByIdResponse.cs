using BS.ApplicationServices.ViewModels;

namespace BS.ApplicationServices.Messaging.Responses.UserResponses
{
    public class GetUserByIdResponse : ServiceResponseBase
    {
        public UserVM User { get; set; }
    }
}
