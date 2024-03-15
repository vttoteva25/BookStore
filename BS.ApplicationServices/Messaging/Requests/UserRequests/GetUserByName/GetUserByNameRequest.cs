namespace BS.ApplicationServices.Messaging.Requests.UserRequests.GetUserByName
{
    public class GetUserByNameRequest
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public GetUserByNameRequest(string? firstName, string? lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
