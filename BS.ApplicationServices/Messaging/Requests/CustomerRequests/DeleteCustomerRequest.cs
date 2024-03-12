namespace BS.ApplicationServices.Messaging.Requests.CustomerRequests
{
    public class DeleteCustomerRequest
    {
        public Guid CustomerId { get; set; }
        
        public DeleteCustomerRequest(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
