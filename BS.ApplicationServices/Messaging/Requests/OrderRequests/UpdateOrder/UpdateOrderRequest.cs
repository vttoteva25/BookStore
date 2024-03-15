using BS.ApplicationServices.ViewModels;

namespace BS.ApplicationServices.Messaging.Requests.OrderRequests.UpdateOrder
{
    public class UpdateOrderRequest
    {
        public Guid OrderId { get; set; }

        public OrderVM? Order { get; set; }

        public UpdateOrderRequest(Guid orderId, OrderVM? order)
        {
            OrderId = orderId;
            Order = order;
        }
    }
}
