namespace BS.ApplicationServices.Messaging.Requests.CustomerRequests
{
    public class GetCustomerByNameRequest
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public GetCustomerByNameRequest(string? firstName, string? lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
