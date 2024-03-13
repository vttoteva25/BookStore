using BS.ApplicationServices.Interfaces;
using BS.ApplicationServices.Messaging.Requests.BookOrderRequests;
using BS.ApplicationServices.Messaging.Responses.AuthorResponses;
using BS.ApplicationServices.Messaging.Responses.BookOrderResponses;
using BS.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Implementations
{
    public class BookOrderService : IBookOrderService
    {
        private readonly ILogger<BookOrderService> _logger;
        private readonly BookStoreDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookOrderService"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="context">BookOrder database context.</param>
        public BookOrderService(ILogger<BookOrderService> logger, BookStoreDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<GetBookOrderByIdResponse> GetBookOrderByIdAsync(GetBookOrderByIdRequest request)
        {
            GetBookOrderByIdResponse response = new();

            var bookOrder = await _context.BooksOrders.SingleOrDefaultAsync(x => x.BookOrderId == request.BookOrderId);
            if (bookOrder is null)
            {
                _logger.LogInformation("BookOrder is not found with id: {bookOrderId}", request.BookOrderId);
                response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                return response;
            }

            response.BookOrder = new()
            {
                BookOrderId = bookOrder.OrderId,
                BookId = bookOrder.BookId,
                OrderId = bookOrder.OrderId
            };

            return response;
        }

        public async Task<GetAllOrdersByBookIdResponse> GetOrdersByBookIdAsync(GetAllOrdersByBookIdRequest request)
        {
            GetAllOrdersByBookIdResponse response = new();

            var bookOrders = await _context.BooksOrders.Select(x => x).Where(x => x.BookId == request.BookId).ToListAsync();
            if (bookOrders is null)
            {
                _logger.LogInformation("There are no orders for this book id: {BookId}", request.BookId);
                response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                return response;
            }
            foreach (var bookOrder in bookOrders)
            {
                var order = await _context.Orders.FirstAsync(x => x.OrderId == bookOrder.OrderId);
                if(order != null)
                {
                    response.Orders.Add(new()
                    {
                        OrderId = order.OrderId,
                        CustomerId = order.CustomerId,
                        OrderDate = order.OrderDate,
                        TotalAmount = order.TotalAmount,
                        PaymentMethod = order.PaymentMethod,
                        DeliveryAddress = order.DeliveryAddress,
                        DeliveryStatus = order.DeliveryStatus,
                        IsApproved = order.IsApproved,
                        IsDelivered = order.IsDelivered
                    });
                }
            }

            return response;
        }

        public async Task<GetAllBooksByOrderIdResponse> GetBooksByOrderIdAsync(GetAllBooksByOrderIdRequest request)
        {
            GetAllBooksByOrderIdResponse response = new();

            var bookOrders = await _context.BooksOrders.Select(x => x).Where(x => x.OrderId == request.OrderId).ToListAsync();
            if (bookOrders is null)
            {
                _logger.LogInformation("There are no books for this order id: {OrderID}", request.OrderId);
                response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                return response;
            }
            foreach (var bookOrder in bookOrders)
            {
                var book = await _context.Books.FirstAsync(x => x.BookId == bookOrder.BookId);
                if (book != null)
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
            }

            return response;
        }

        public async Task<GetAllBookOrdersResponse> GetBookOrdersAsync(GetAllBookOrdersRequest request)
        {
            GetAllBookOrdersResponse response = new() { BookOrders = new() };

            var bookOrders = await _context.BooksOrders.ToListAsync();
            if (bookOrders is null)
            {
                return response;
            }
            foreach (var bookOrder in bookOrders)
            {
                response.BookOrders.Add(new()
                {
                    BookOrderId = bookOrder.OrderId,
                    BookId = bookOrder.BookId,
                    OrderId = bookOrder.OrderId
                });
            }

            return response;
        }

        public async Task<CreateBookOrderResponse> SaveAsync(CreateBookOrderRequest request)
        {
            CreateBookOrderResponse response = new();

            try
            {
                await _context.BooksOrders.AddAsync(new()
                {
                    BookOrderId = request.BookOrder.BookOrderId,
                    BookId = request.BookOrder.BookId,
                    OrderId = request.BookOrder.OrderId
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BookOrder is not save.");
                response.StatusCode = Messaging.BusinessStatusCodeEnum.InternalServerError;
                return response;
            }

            return response;
        }

        public async Task<UpdateBookOrderResponse> UpdateAsync(UpdateBookOrderRequest request)
        {
            UpdateBookOrderResponse response = new();

            try
            {
                var bookOrder = await _context.BooksOrders.SingleOrDefaultAsync(x => x.BookOrderId == request.BookOrderId);
                if (bookOrder is null)
                {
                    _logger.LogInformation("BookOrder is not found with id: {BookOrderId}", request.BookOrderId);
                    response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                    return response;
                }
                _context.Entry(bookOrder).CurrentValues.SetValues(request.BookOrder);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BookOrder is not updated.");
                response.StatusCode = Messaging.BusinessStatusCodeEnum.InternalServerError;
                return response;
            }
            return response;
        }
        public async Task<DeleteBookOrderResponse> DeleteAsync(DeleteBookOrderRequest request)
        {
            DeleteBookOrderResponse response = new();

            try
            {
                var bookOrder = await _context.BooksOrders.SingleOrDefaultAsync(x => x.BookOrderId == request.BookOrderId);
                if (bookOrder is null)
                {
                    _logger.LogInformation("BookOrder is not found with id: {BookOrderId}", request.BookOrderId);
                    response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                    return response;
                }
                _context.BooksOrders.Remove(bookOrder);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BookOrder is not deleted.");
                response.StatusCode = Messaging.BusinessStatusCodeEnum.InternalServerError;
                return response;
            }
            return response;
        }

    }
}
