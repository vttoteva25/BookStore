using BS.ApplicationServices.ViewModels;

namespace BS.ApplicationServices.Messaging.Responses.OrderResponses
{
    public class GetOrderByIdResponse:ServiceResponseBase
    {
        public OrderVM? Order { get; set; }
    }
}
