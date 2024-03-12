using BS.ApplicationServices.ViewModels;

namespace BS.ApplicationServices.Messaging.Requests.AuthorRequests
{
    public class UpdateAuthorRequest
    {
        public Guid AuthorId { get; set; }

        public AuthorVM? Author { get; set; }

        public UpdateAuthorRequest(Guid authorId, AuthorVM author)
        {  
            AuthorId = authorId;
            Author = author;
        }
    }
}
