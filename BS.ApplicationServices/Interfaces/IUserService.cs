using BS.ApplicationServices.Messaging.Requests.AuthorRequests;
using BS.ApplicationServices.Messaging.Requests.UserRequests;
using BS.ApplicationServices.Messaging.Responses.UserResponse;
using BS.ApplicationServices.Messaging.Responses.UserResponses;

namespace BS.ApplicationServices.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Authenticate user by given parameters username and passwords.
        /// </summary>
        /// <param name="request">Get user request object.</param>
        /// <returns>Return JWT token and user data.</returns>
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);

        /// <summary>
        /// Get user by id.
        /// </summary>
        /// <param name="request">Get user by id request object.</param>
        /// <returns>Return single user by id.</returns>
        Task<GetUserByIdResponse> GetUserByIdAsync(GetUserByIdRequest request);

        /// <summary>
        /// Get list with users.
        /// </summary>
        /// <param name="request">Get user request object.</param>
        /// <returns>Return list with users.</returns>
        Task<GetAllUsersResponse> GetUsersAsync(GetAllUsersRequest request);

        /// <summary>
        /// Get user by name.
        /// </summary>
        /// <param name="request">Get user by request object.</param>
        /// <returns>Return single user by name.</returns>
        Task<GetUserByNameResponse> GetUserByNameAsync(GetUserByNameRequest request);

        /// <summary>
        /// Create user.
        /// </summary>
        /// <param name="request">Create user request object.</param>
        /// <returns>Return 200 ok.</returns>
        Task<CreateUserResponse> SaveAsync(CreateUserRequest request);

        /// <summary>
        /// Update user.
        /// </summary>
        /// <param name="request">Update user request object.</param>
        /// <returns>Return the updated user.</returns>
        Task<UpdateUserResponse> UpdateAsync(UpdateUserRequest request);

        /// <summary>
        /// Delete user.
        /// </summary>
        /// <param name="request">Delete user request object.</param>
        /// <returns>Return 200 ok.</returns>
        Task<DeleteUserResponse> DeleteAsync(DeleteUserRequest request);
    }
}
