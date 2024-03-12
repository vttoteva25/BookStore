using BS.ApplicationServices.ViewModels;

namespace BS.ApplicationServices.Messaging.Responses.OrderResponses
{
    public class GetAllOrdersResponse:ServiceResponseBase
    {
        public List<OrderVM> Orders { get; set; }
    }
}
