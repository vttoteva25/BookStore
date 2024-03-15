namespace BS.ApplicationServices.Messaging.Requests.AuthorRequests.DeleteAuthor
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
