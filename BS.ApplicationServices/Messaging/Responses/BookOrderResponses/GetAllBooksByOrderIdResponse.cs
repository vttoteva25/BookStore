using BS.ApplicationServices.ViewModels;

namespace BS.ApplicationServices.Messaging.Responses.BookOrderResponses
{
    public class GetAllBooksByOrderIdResponse:ServiceResponseBase
    {
        public List<BookVM> Books { get; set; }
    }
}
