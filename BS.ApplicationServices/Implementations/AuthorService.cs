using BS.ApplicationServices.Interfaces;
using BS.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BS.ApplicationServices.Messaging.Responses.AuthorResponses;
using BS.ApplicationServices.Messaging.Requests.AuthorRequests.CreateAuthor;
using BS.ApplicationServices.Messaging.Requests.AuthorRequests.DeleteAuthor;
using BS.ApplicationServices.Messaging.Requests.AuthorRequests.GetAllAuthors;
using BS.ApplicationServices.Messaging.Requests.AuthorRequests.UpdateAuthor;
using BS.ApplicationServices.Messaging.Requests.AuthorRequests.GetAuthorByName;
using BS.Data.Exceptions;
using BS.ApplicationServices.ViewModels;

namespace BS.ApplicationServices.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly ILogger<AuthorService> _logger;
        private readonly BookStoreDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorService"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="context">Author database context.</param>
        public AuthorService(ILogger<AuthorService> logger, BookStoreDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<GetAllAuthorsResponse> GetAuthorsAsync(GetAllAuthorsRequest request)
        {
            GetAllAuthorsResponse response = new() { Authors = new() };

            var authors = await _context.Authors.ToListAsync();
            if (authors is null)
            {
                return response;
            }
            foreach (var author in authors)
            {
                response.Authors.Add(new()
                {
                    AuthorId = author.AuthorId,
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    Email = author.Email,
                    CareerStartingDate = author.CareerStartingDate,
                    IsActiveNow = author.IsActiveNow,
                    WrittenBooksCount = author.WrittenBooksCount,
                    Description = author.Description
                });
            }

            return response;
        }

        public async Task<GetAuthortByNameResponse> GetAuthorByNameAsync(GetAuthorByNameRequest request)
        {
            var validator = new GetAuthorByNameRequestValidator();
            var validRes = validator.Validate(request);
            if (!validRes.IsValid)
            {
                throw new ValidationException("GetAuthor", string.Join("/n", validRes.Errors));
            }

            GetAuthortByNameResponse response = new();

            var authors = await _context.Authors.Where(x => x.FirstName == request.FirstName && 
                            (string.IsNullOrEmpty(x.LastName) ? true : x.LastName == request.LastName)).ToListAsync();

            if (!(authors?.Any() ?? false))
            {
                _logger.LogInformation("Author is not found with first and last name: {firstName} {lastname}", request.FirstName, request.LastName);
                response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                return response;
            }

            response.Authors = authors.Select(author 
                => new AuthorVM()
            {
                AuthorId = author.AuthorId,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Email = author.Email,
                CareerStartingDate = author.CareerStartingDate,
                WrittenBooksCount = author.WrittenBooksCount,
                IsActiveNow = author.IsActiveNow,
                Description = author.Description
            })
                .ToList();

            return response;
        }

        public async Task<CreateAuthorResponse> SaveAsync(CreateAuthorRequest request)
        {
            var validator = new CreateAuthorRequestValidator();
            var validRes = validator.Validate(request);
            if (!validRes.IsValid)
            {
                throw new ValidationException("CreateAuthor", string.Join("/n", validRes.Errors));
            }
            CreateAuthorResponse response = new();

            try
            {
                await _context.Authors.AddAsync(new()
                {
                    AuthorId = Guid.NewGuid(),
                    FirstName = request.Author.FirstName,
                    LastName = request.Author.LastName,
                    Email = request.Author.Email,
                    CareerStartingDate = request.Author.CareerStartingDate,
                    WrittenBooksCount = request.Author.WrittenBooksCount,
                    IsActiveNow = request.Author.IsActiveNow,
                    Description = request.Author.Description
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Author is not save.");
                response.StatusCode = Messaging.BusinessStatusCodeEnum.InternalServerError;
                return response;
            }

            return response;
        }

        public async Task<UpdateAuthorResponse> UpdateAsync(UpdateAuthorRequest request)
        {
            var validator = new UpdateAuthorRequestValidator();
            var validRes = validator.Validate(request);
            if (!validRes.IsValid)
            {
                throw new ValidationException("UpdateAuthor", string.Join("/n", validRes.Errors));
            }

            UpdateAuthorResponse response = new();

            try
            {
                var author = await _context.Authors.SingleOrDefaultAsync(x => x.AuthorId == request.AuthorId);
                if (author is null)
                {
                    _logger.LogInformation("Author is not found with id: {AuthorId}", request.AuthorId);
                    response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                    return response;
                }
                _context.Entry(author).CurrentValues.SetValues(request.Author);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Author is not updated.");
                response.StatusCode = Messaging.BusinessStatusCodeEnum.InternalServerError;
                return response;
            }
            return response;
        }

        public async Task<DeleteAuthorResponse> DeleteAsync(DeleteAuthorRequest request)
        {
            var validator = new DeleteAuthorRequestValidator();
            var validRes = validator.Validate(request);
            if (!validRes.IsValid)
            {
                throw new ValidationException("GetAuthor", string.Join("/n", validRes.Errors));
            }

            DeleteAuthorResponse response = new();

            try
            {
                var author = await _context.Authors.SingleOrDefaultAsync(x => x.AuthorId == request.AuthorId);
                if (author is null)
                {
                    _logger.LogInformation("Author is not found with id: {AuthorId}", request.AuthorId);
                    response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                    return response;
                }
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Author is not deleted.");
                response.StatusCode = Messaging.BusinessStatusCodeEnum.InternalServerError;
                return response;
            }
            return response;
        }
    }
}
