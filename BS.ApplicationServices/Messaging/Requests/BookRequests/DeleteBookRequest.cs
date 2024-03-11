using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.BookRequests
{
    public class DeleteBookRequest
    {
        public Guid BookId { get; set;}

        public DeleteBookRequest( Guid bookId) 
        {
            BookId = bookId;
        }  
    }
}
