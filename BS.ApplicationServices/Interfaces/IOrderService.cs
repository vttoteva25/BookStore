using BS.ApplicationServices.Messaging.Requests.BookRequests;
using BS.ApplicationServices.Messaging.Requests.OrderRequests.CreateOrder;
using BS.ApplicationServices.Messaging.Requests.OrderRequests.DeleteOrder;
using BS.ApplicationServices.Messaging.Requests.OrderRequests.GetOrderById;
using BS.ApplicationServices.Messaging.Requests.OrderRequests.UpdateOrder;
using BS.ApplicationServices.Messaging.Responses.BookResponses;
using BS.ApplicationServices.Messaging.Responses.OrderResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Interfaces
{
    public interface IOrderService
    {
        /// <summary>
        /// Get list with orders.
        /// </summary>
        /// <param name="request">Get order request object.</param>
        /// <returns>Return list with orders.</returns>
        Task<GetAllOrdersResponse> GetOrdersAsync(GetAllOrdersResponse request);

        /// <summary>
        /// Get order by id.
        /// </summary>
        /// <param name="request">Get order by request object.</param>
        /// <returns>Return single order by id.</returns>
        Task<GetOrderByIdResponse> GetOrderByIdAsync(GetOrderByIdRequest request);

        /// <summary>
        /// Create order.
        /// </summary>
        /// <param name="request">Create order request object.</param>
        /// <returns>Return 200 ok.</returns>
        Task<CreateOrderResponse> SaveAsync(CreateOrderRequest request);

        /// <summary>
        /// Update order.
        /// </summary>
        /// <param name="request">Update order request object.</param>
        /// <returns>Return the updated order.</returns>
        Task<UpdateOrderResponse> UpdateAsync(UpdateOrderRequest request);

        /// <summary>
        /// Delete order.
        /// </summary>
        /// <param name="request">Delete order request object.</param>
        /// <returns>Return 200 ok.</returns>
        Task<DeleteOrderResponse> DeleteAsync(DeleteOrderRequest request);
    }
}
