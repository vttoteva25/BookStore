namespace BS.ApplicationServices.Messaging.Requests.OrderRequests
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
