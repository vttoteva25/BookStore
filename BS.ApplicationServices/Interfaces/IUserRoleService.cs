using BS.ApplicationServices.Messaging.Requests.BookOrderRequests;
using BS.ApplicationServices.Messaging.Requests.UserRoleRequests.CreateUserRoleRequestValidator;
using BS.ApplicationServices.Messaging.Requests.UserRoleRequests.DeleteUserRole;
using BS.ApplicationServices.Messaging.Requests.UserRoleRequests.GetAllRolesByUserId;
using BS.ApplicationServices.Messaging.Requests.UserRoleRequests.GetAllUserRoles;
using BS.ApplicationServices.Messaging.Requests.UserRoleRequests.GetAllUsersByRoleId;
using BS.ApplicationServices.Messaging.Requests.UserRoleRequests.UpdateUserRole;
using BS.ApplicationServices.Messaging.Responses.BookOrderResponses;
using BS.ApplicationServices.Messaging.Responses.UserRoleResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Interfaces
{
    public interface IUserRoleService
    {
        /// <summary>
        /// Get list with User-Role.
        /// </summary>
        /// <param name="request">Get User-Role request object.</param>
        /// <returns>Return list with User-Role.</returns>
        Task<GetAllUserRolesResponse> GetUserRoleAsync(GetAllUserRolesRequest request);

        /// <summary>
        /// Get users by role id.
        /// </summary>
        /// <param name="request">Get users request object.</param>
        /// <returns>Return list of users by role id.</returns>
        Task<GetAllUsersByRoleIdResponse> GetAllUsersByRoleIdAsync(GetAllUsersByRoleIdRequest request);

        /// <summary>
        /// Get roles by user id.
        /// </summary>
        /// <param name="request">Get roles request object.</param>
        /// <returns>Return list of roles by user id.</returns>
        Task<GetAllRolesByUserIdResponse> GetAllRolesByUserIdAsync(GetAllRolesByUserIdRequest request);

        /// <summary>
        /// Create User-Role.
        /// </summary>
        /// <param name="request">Create User-Role request object.</param>
        /// <returns>Return 200 ok.</returns>
        Task<CreateUserRoleResponse> SaveAsync(CreateUserRoleRequest request);

        /// <summary>
        /// Update User-Role.
        /// </summary>
        /// <param name="request">Update User-Role request object.</param>
        /// <returns>Return the updated User-Role.</returns>
        Task<UpdateUserRoleResponse> UpdateAsync(UpdateUserRoleRequest request);

        /// <summary>
        /// Delete User-Role.
        /// </summary>
        /// <param name="request">Delete User-Role request object.</param>
        /// <returns>Return 200 ok.</returns>
        Task<DeleteUserRoleResponse> DeleteAsync(DeleteUserRoleRequest request);
    }
}
