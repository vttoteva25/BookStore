namespace BS.ApplicationServices.Messaging.Requests.AuthorRequests
{
    public class DeleteAuthorRequest
    {
        public Guid AuthorId { get; set; }

        public DeleteAuthorRequest(Guid authorId) 
        { 
            AuthorId = authorId;
        }

    }
}
