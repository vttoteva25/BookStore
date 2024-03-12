using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Responses.AuthorResponses
{
    public class GetAllAuthorsResponse : ServiceResponseBase
    {
        public List<AuthorVM> Authors { get; set; }
    }
}
