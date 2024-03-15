using BS.ApplicationServices.ViewModels;

namespace BS.ApplicationServices.Messaging.Requests.OrderRequests.CreateOrder
{
    public class CreateOrderRequest
    {
        public OrderVM? Order { get; set; }

        public CreateOrderRequest(OrderVM? order)
        {
            Order = order;
        }
    }
}
