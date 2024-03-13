namespace BS.ApplicationServices.Messaging.Responses.CustomerResponse
{
    public class CreateCustomerResponse : ServiceResponseBase
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
