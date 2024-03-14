using BS.ApplicationServices.Messaging.Requests.AuthorRequests;
using BS.ApplicationServices.Messaging.Requests.CustomerRequests;
using BS.ApplicationServices.Messaging.Responses.CustomerResponse;
using BS.ApplicationServices.Messaging.Responses.CustomerResponses;

namespace BS.ApplicationServices.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
        Task<GetUserByIdResponse> GetUserById(GetUserByIdRequest request);

        /// <summary>
        /// Get list with customers.
        /// </summary>
        /// <param name="request">Get customer request object.</param>
        /// <returns>Return list with customers.</returns>
        Task<GetAllCustomersResponse> GetCustomersAsync(GetAllCustomersRequest request);

        /// <summary>
        /// Get customer by name.
        /// </summary>
        /// <param name="request">Get customer by request object.</param>
        /// <returns>Return single customer by name.</returns>
        Task<GetCustomerByNameResponse> GetCustomerByNameAsync(GetCustomerByNameRequest request);

        /// <summary>
        /// Create customer.
        /// </summary>
        /// <param name="request">Create customer request object.</param>
        /// <returns>Return 200 ok.</returns>
        Task<CreateCustomerResponse> SaveAsync(CreateCustomerRequest request);

        /// <summary>
        /// Update customer.
        /// </summary>
        /// <param name="request">Update customer request object.</param>
        /// <returns>Return the updated customer.</returns>
        Task<UpdateCustomerResponse> UpdateAsync(UpdateCustomerRequest request);

        /// <summary>
        /// Delete customer.
        /// </summary>
        /// <param name="request">Delete customer request object.</param>
        /// <returns>Return 200 ok.</returns>
        Task<DeleteCustomerResponse> DeleteAsync(DeleteCustomerRequest request);
    }
}
