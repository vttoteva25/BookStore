using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
