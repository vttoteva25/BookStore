using BS.ApplicationServices.ViewModels;

namespace BS.ApplicationServices.Messaging.Responses.BookResponses
{
    public class GetBookByTitleResponse:ServiceResponseBase
    {
        public BookVM? Book { get; set; }

    }
}
