using BS.ApplicationServices.Interfaces;
using BS.ApplicationServices.Messaging.Requests.BookRequests;
using BS.ApplicationServices.Messaging.Requests.CustomerRequests;
using BS.ApplicationServices.Messaging.Responses.AuthorResponses;
using BS.ApplicationServices.Messaging.Responses.BookResponses;
using BS.ApplicationServices.Messaging.Responses.CustomerResponse;
using BS.Data.Contexts;
using BS.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Implementations
{
    public class BookService : IBookService
    {
        private readonly ILogger<BookService> _logger;
        private readonly BookStoreDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookService"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="context">Book database context.</param>
        public BookService(ILogger<BookService> logger, BookStoreDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<GetBookByTitleResponse> GetBookByTitleAsync(GetBookByTitleRequest request)
        {
            GetBookByTitleResponse response = new();

            var book = await _context.Books.SingleOrDefaultAsync(x => x.Title == request.Title);
            if (book is null)
            {
                _logger.LogInformation("Book is not found with title: {title}", request.Title);
                response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                return response;
            }

            response.Book = new()
            {
                BookId = book.BookId,
                Title = book.Title,
                AuthorId = book.AuthorId,
                Genre = book.Genre,
                Price = book.Price,
                ISBN = book.ISBN,
                Language = book.Language,
                QuantityAvailable = book.QuantityAvailable,
                Available = book.Available,
                Description = book.Description
            };

            return response;
        }

        public async Task<GetAllBooksResponse> GetBooksAsync(GetAllBooksRequest request)
        {
            GetAllBooksResponse response = new() { Books = new() };

            var books = await _context.Books.ToListAsync();
            if (books is null)
            {
                return response;
            }
            foreach (var book in books)
            {
                response.Books.Add(new()
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    AuthorId = book.AuthorId,
                    Genre = book.Genre,
                    Price = book.Price,
                    ISBN = book.ISBN,
                    Language = book.Language,
                    QuantityAvailable = book.QuantityAvailable,
                    Available = book.Available,
                    Description = book.Description
                });
            }

            return response;
        }

        public async Task<CreateBookResponse> SaveAsync(CreateBookRequest request)
        {
            CreateBookResponse response = new();

            try
            {
                await _context.Books.AddAsync(new()
                {
                    BookId = request.Book.BookId,
                    Title = request.Book.Title,
                    AuthorId = request.Book.AuthorId,
                    Genre = request.Book.Genre,
                    Price = request.Book.Price,
                    ISBN = request.Book.ISBN,
                    Language = request.Book.Language,
                    QuantityAvailable = request.Book.QuantityAvailable,
                    Available = request.Book.Available,
                    Description = request.Book.Description
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Book is not save.");
                response.StatusCode = Messaging.BusinessStatusCodeEnum.InternalServerError;
                return response;
            }

            return response;
        }

        public async Task<UpdateBookResponse> UpdateAsync(UpdateBookRequest request)
        {
            UpdateBookResponse response = new();

            try
            {
                var book = await _context.Books.SingleOrDefaultAsync(x => x.BookId == request.BookId);
                if (book is null)
                {
                    _logger.LogInformation("Book is not found with id: {BookId}", request.BookId);
                    response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                    return response;
                }
                _context.Entry(book).CurrentValues.SetValues(request.Book);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Book is not updated.");
                response.StatusCode = Messaging.BusinessStatusCodeEnum.InternalServerError;
                return response;
            }
            return response;
        }

        public async Task<DeleteBookResponse> DeleteAsync(DeleteBookRequest request)
        {
            DeleteBookResponse response = new();

            try
            {
                var book = await _context.Books.SingleOrDefaultAsync(x => x.BookId == request.BookId);
                if (book is null)
                {
                    _logger.LogInformation("Book is not found with id: {BookId}", request.BookId);
                    response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                    return response;
                }
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Book is not deleted.");
                response.StatusCode = Messaging.BusinessStatusCodeEnum.InternalServerError;
                return response;
            }
            return response;
        }
    }
}
