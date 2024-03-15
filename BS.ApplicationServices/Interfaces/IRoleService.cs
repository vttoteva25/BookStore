using BS.ApplicationServices.Messaging.Requests.RolesRequests.CreateRole;
using BS.ApplicationServices.Messaging.Requests.RolesRequests.DeleteRole;
using BS.ApplicationServices.Messaging.Requests.RolesRequests.GetAllRoles;
using BS.ApplicationServices.Messaging.Requests.RolesRequests.GetRoleByName;
using BS.ApplicationServices.Messaging.Requests.RolesRequests.UpdateRole;
using BS.ApplicationServices.Messaging.Requests.UserRoleRequests;
using BS.ApplicationServices.Messaging.Responses.RolesResponses;
using BS.ApplicationServices.Messaging.Responses.UserRoleResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Interfaces
{
    public interface IRoleService
    {
        /// <summary>
        /// Get list with roles.
        /// </summary>
        /// <param name="request">Get role request object.</param>
        /// <returns>Return list with roles.</returns>
        Task<GetAllRolesResponse> GetRolesAsync(GetAllRolesRequest request);

        /// <summary>
        /// Get role by name.
        /// </summary>
        /// <param name="request">Get roles request object.</param>
        /// <returns>Return single role with this name.</returns>
        Task<GetRoleByNameResponse> GetRoleByNameAsync(GetRoleByNameRequest request);

        /// <summary>
        /// Create role.
        /// </summary>
        /// <param name="request">Create role request object.</param>
        /// <returns>Return 200 ok.</returns>
        Task<CreateRoleResponse> SaveAsync(CreateRoleRequest request);

        /// <summary>
        /// Update role.
        /// </summary>
        /// <param name="request">Update role request object.</param>
        /// <returns>Return the updated role.</returns>
        Task<UpdateRoleResponse> UpdateAsync(UpdateRoleRequest request);

        /// <summary>
        /// Delete role.
        /// </summary>
        /// <param name="request">Delete role request object.</param>
        /// <returns>Return 200 ok.</returns>
        Task<DeleteRoleResponse> DeleteAsync(DeleteRoleRequest request);
    }
}
