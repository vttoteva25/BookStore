using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.UserRoleRequests.GetAllUsersByRoleId
{
    public class GetAllUsersByRoleIdRequest
    {
        public Guid RoleId { get; set; }

        public GetAllUsersByRoleIdRequest(Guid roleId)
        {
            RoleId = roleId;
        }
    }
}
