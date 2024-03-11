using BS.ApplicationServices.Messaging.Requests.BookRequests;
using BS.ApplicationServices.Messaging.Requests.CustomerRequests;
using BS.ApplicationServices.Messaging.Responses.BookResponses;
using BS.ApplicationServices.Messaging.Responses.CustomerResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Interfaces
{
    public interface IBookService
    {
        /// <summary>
        /// Get list with books.
        /// </summary>
        /// <param name="request">Get book request object.</param>
        /// <returns>Return list with books.</returns>
        Task<GetAllBooksResponse> GetBooksAsync(GetAllBooksRequest request);

        /// <summary>
        /// Get book by title.
        /// </summary>
        /// <param name="request">Get book by request object.</param>
        /// <returns>Return single book by title.</returns>
        Task<GetBookByTitleResponse> GetBookByTitleAsync(GetBookByTitleRequest request);

        /// <summary>
        /// Create book.
        /// </summary>
        /// <param name="request">Create book request object.</param>
        /// <returns>Return 200 ok.</returns>
        Task<CreateBookResponse> SaveAsync(CreateBookRequest request);

        /// <summary>
        /// Update book.
        /// </summary>
        /// <param name="request">Update book request object.</param>
        /// <returns>Return the updated book.</returns>
        Task<UpdateBookResponse> UpdateAsync(UpdateBookRequest request);

        /// <summary>
        /// Delete book.
        /// </summary>
        /// <param name="request">Delete book request object.</param>
        /// <returns>Return 200 ok.</returns>
        Task<DeleteBookResponse> DeleteAsync(DeleteBookRequest request);
    }
}
