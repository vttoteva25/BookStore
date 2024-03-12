using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
