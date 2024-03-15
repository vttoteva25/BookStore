using BS.ApplicationServices.Messaging.Requests.AuthorRequests;
using BS.ApplicationServices.Messaging.Requests.AuthorRequests.CreateAuthor;
using BS.ApplicationServices.Messaging.Responses.AuthorResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Interfaces
{
    public interface IAuthorService
    {
        /// <summary>
        /// Get list with authors.
        /// </summary>
        /// <param name="request">Get author request object.</param>
        /// <returns>Return filter list with authors.</returns>
        Task<GetAllAuthorsResponse> GetAuthorsAsync(GetAllAuthorsRequest request);

        /// <summary>
        /// Get author by title.
        /// </summary>
        /// <param name="request">Get title by request object.</param>
        /// <returns>Return single author by title.</returns>
        Task<GetAuthortByNameResponse> GetAuthorByNameAsync(GetAuthortByNameRequest request);

        /// <summary>
        /// Create author.
        /// </summary>
        /// <param name="request">Create author request object.</param>
        /// <returns>Return 200 ok.</returns>
        Task<CreateAuthorResponse> SaveAsync(CreateAuthorRequest request);

        /// <summary>
        /// Update author.
        /// </summary>
        /// <param name="request">Update author request object.</param>
        /// <returns>Return 200 ok.</returns>
        Task<UpdateAuthorResponse> UpdateAsync(UpdateAuthorRequest request);

        /// <summary>
        /// Delete author.
        /// </summary>
        /// <param name="request">Delete author request object.</param>
        /// <returns>Return 200 ok.</returns>
        Task<DeleteAuthorResponse> DeleteAsync(DeleteAuthorRequest request);
    }
}
