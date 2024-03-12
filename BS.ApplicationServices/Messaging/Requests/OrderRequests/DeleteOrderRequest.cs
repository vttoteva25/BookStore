namespace BS.ApplicationServices.Messaging.Requests.OrderRequests
{
    public class DeleteOrderRequest
    {
        public Guid OrderId { get; set;}

        public DeleteOrderRequest(Guid orderId) 
        {
            OrderId = orderId;
        }
    }
}
