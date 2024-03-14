using BS.ApplicationServices.ViewModels;

namespace BS.ApplicationServices.Messaging.Responses.CustomerResponses
{
    public class GetUserByIdResponse : ServiceResponseBase
    {
        public UserVM User { get; set; }
    }
}
