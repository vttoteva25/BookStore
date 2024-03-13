using BS.ApplicationServices.Messaging.Requests.BookOrderRequests;
using BS.ApplicationServices.Messaging.Requests.BookRequests;
using BS.ApplicationServices.Messaging.Responses.BookOrderResponses;
using BS.ApplicationServices.Messaging.Responses.BookResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Interfaces
{
    public interface IBookOrderService
    {
        /// <summary>
        /// Get list with BookOrders.
        /// </summary>
        /// <param name="request">Get BookOrder request object.</param>
        /// <returns>Return list with BookOrder.</returns>
        Task<GetAllBookOrdersResponse> GetBookOrdersAsync(GetAllBookOrdersRequest request);

        /// <summary>
        /// Get BookOrder by id.
        /// </summary>
        /// <param name="request">Get BookOrder by request object.</param>
        /// <returns>Return single BookOrder by id.</returns>
        Task<GetBookOrderByIdResponse> GetBookOrderByIdAsync(GetBookOrderByIdRequest request);

        /// <summary>
        /// Get orders by book id.
        /// </summary>
        /// <param name="request">Get orders request object.</param>
        /// <returns>Return list of orders by book id.</returns>
        Task<GetAllOrdersByBookIdResponse> GetOrdersByBookIdAsync(GetAllOrdersByBookIdRequest request);

        /// <summary>
        /// Get books by order id.
        /// </summary>
        /// <param name="request">Get books request object.</param>
        /// <returns>Return list of books by order id.</returns>
        Task<GetAllBooksByOrderIdResponse> GetBooksByOrderIdAsync(GetAllBooksByOrderIdRequest request);

        /// <summary>
        /// Create BookOrder.
        /// </summary>
        /// <param name="request">Create BookOrder request object.</param>
        /// <returns>Return 200 ok.</returns>
        Task<CreateBookOrderResponse> SaveAsync(CreateBookOrderRequest request);

        /// <summary>
        /// Update BookOrder.
        /// </summary>
        /// <param name="request">Update BookOrder request object.</param>
        /// <returns>Return the updated BookOrder.</returns>
        Task<UpdateBookOrderResponse> UpdateAsync(UpdateBookOrderRequest request);

        /// <summary>
        /// Delete BookOrder.
        /// </summary>
        /// <param name="request">Delete BookOrder request object.</param>
        /// <returns>Return 200 ok.</returns>
        Task<DeleteBookOrderResponse> DeleteAsync(DeleteBookOrderRequest request);
    }
}
