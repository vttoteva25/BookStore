using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.AuthorRequests
{
    public class DeleteAuthorRequest
    {
        public Guid AuthorId { get; set; }

        public DeleteAuthorRequest(Guid authorId) 
        { 
            AuthorId = authorId;
        }

    }
}
