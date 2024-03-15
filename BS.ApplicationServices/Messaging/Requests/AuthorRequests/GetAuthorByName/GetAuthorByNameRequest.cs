namespace BS.ApplicationServices.Messaging.Requests.AuthorRequests.GetAuthorByName
{
    public class GetAuthorByNameRequest
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public GetAuthorByNameRequest(string? firstName, string? lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
