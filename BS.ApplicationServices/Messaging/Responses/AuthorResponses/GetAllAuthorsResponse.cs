using BS.ApplicationServices.ViewModels;

namespace BS.ApplicationServices.Messaging.Responses.AuthorResponses
{
    public class GetAllAuthorsResponse : ServiceResponseBase
    {
        public List<AuthorVM> Authors { get; set; }
    }
}
