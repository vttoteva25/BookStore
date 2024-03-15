namespace BS.ApplicationServices.Messaging.Requests.OrderRequests.GetOrderById
{
    public class GetOrderByIdRequest
    {
        public Guid OrderId { get; set; }

        public GetOrderByIdRequest(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
