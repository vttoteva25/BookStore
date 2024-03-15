using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.UserRoleRequests
{
    public class GetAllRolesByUserIdRequest
    {
        public Guid UserId { get; set; }

        public GetAllRolesByUserIdRequest(Guid userId)
        {
            UserId = userId;
        }
    }
}
