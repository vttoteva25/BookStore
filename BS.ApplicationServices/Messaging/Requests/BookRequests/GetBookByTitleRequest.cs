using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.BookRequests
{
    public class GetBookByTitleRequest
    {
        public string Title { get; set; }

        public GetBookByTitleRequest(string title)
        {
            Title = title;
        }
    }
}
