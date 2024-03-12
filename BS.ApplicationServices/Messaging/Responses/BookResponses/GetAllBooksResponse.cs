using BS.ApplicationServices.ViewModels;

namespace BS.ApplicationServices.Messaging.Responses.BookResponses
{
    public class GetAllBooksResponse:ServiceResponseBase
    {
        public List<BookVM> Books { get; set; }
    }
}
