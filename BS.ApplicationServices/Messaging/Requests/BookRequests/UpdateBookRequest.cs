using BS.ApplicationServices.ViewModels;

namespace BS.ApplicationServices.Messaging.Requests.BookRequests
{
    public class UpdateBookRequest
    {
        public Guid BookId { get; set;}

        public BookVM Book { get; set; }

        public UpdateBookRequest(Guid bookId, BookVM book)
        {
            BookId = bookId;
            Book = book;
        }
    }
}
