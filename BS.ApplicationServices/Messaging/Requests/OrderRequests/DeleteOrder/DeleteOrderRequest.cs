namespace BS.ApplicationServices.Messaging.Requests.OrderRequests.DeleteOrder
{
    public class DeleteOrderRequest
    {
        public Guid OrderId { get; set; }

        public DeleteOrderRequest(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
