using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Responses.BookResponses
{
    public class GetBookByTitleResponse:ServiceResponseBase
    {
        public BookVM? Book { get; set; }

    }
}
