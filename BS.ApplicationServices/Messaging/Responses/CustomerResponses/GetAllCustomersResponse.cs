using BS.ApplicationServices.ViewModels;

namespace BS.ApplicationServices.Messaging.Responses.CustomerResponse
{
    public class GetAllCustomersResponse : ServiceResponseBase
    {
        public List<UserVM> Users { get; set; }
    }
}
