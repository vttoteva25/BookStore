using BS.ApplicationServices.ViewModels;

namespace BS.ApplicationServices.Messaging.Requests.BookRequests
{
    public class CreateBookRequest
    {
        public BookVM? Book { get; set; }

        public CreateBookRequest(BookVM book) 
        { 
            Book = book;
        }  
    }
}
