using BS.ApplicationServices.ViewModels;

namespace BS.ApplicationServices.Messaging.Requests.AuthorRequests
{
    public class CreateAuthorRequest
    {
        public AuthorVM Author { get; set; }

        public CreateAuthorRequest(AuthorVM author)
        {
            Author = author;
        }
    }
}
