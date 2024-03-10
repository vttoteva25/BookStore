using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.AuthorRequests
{
    public class CreateAuthorRequest
    {
        public AuthorVM Author { get; set; }

        public CreateAuthorRequest(AuthorVM author)
        {
            Author = author;
        }
    }
}
