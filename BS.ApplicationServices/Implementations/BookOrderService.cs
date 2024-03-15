using BS.ApplicationServices.Interfaces;
using BS.ApplicationServices.Messaging.Requests.BookOrderRequests.CreateBookOrder;
using BS.ApplicationServices.Messaging.Requests.BookOrderRequests.DeleteBookOrder;
using BS.ApplicationServices.Messaging.Requests.BookOrderRequests.GetAllBooksByOrderId;
using BS.ApplicationServices.Messaging.Requests.BookOrderRequests.GetAllBooksOrders;
using BS.ApplicationServices.Messaging.Requests.BookOrderRequests.GetAllOrdersByBookId;
using BS.ApplicationServices.Messaging.Requests.BookOrderRequests.UpdateBookOrder;
using BS.ApplicationServices.Messaging.Responses.BookOrderResponses;
using BS.Data.Contexts;
using BS.Data.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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

        public async Task<GetAllOrdersByBookIdResponse> GetOrdersByBookIdAsync(GetAllOrdersByBookIdRequest request)
        {
            var validator = new GetAllOrdersByBookIdRequestValidator();
            var validRes = validator.Validate(request);
            if (!validRes.IsValid)
            {
                throw new ValidationException("GetOrdersByBookId", string.Join("/n", validRes.Errors));
            }

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
                        UserId = order.UserId,
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
            var validator = new GetAllBooksByOrderIdRequestValidator();
            var validRes = validator.Validate(request);
            if (!validRes.IsValid)
            {
                throw new ValidationException("GetBooksByOrderIdAsync", string.Join("/n", validRes.Errors));
            }

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
                    BookId = bookOrder.BookId,
                    OrderId = bookOrder.OrderId
                });
            }

            return response;
        }

        public async Task<CreateBookOrderResponse> SaveAsync(CreateBookOrderRequest request)
        {
            var validator = new CreateBookOrderRequestValidator();
            var validRes = validator.Validate(request);
            if (!validRes.IsValid)
            {
                throw new ValidationException("CreateBookOrder", string.Join("/n", validRes.Errors));
            }

            CreateBookOrderResponse response = new();

            try
            {
                await _context.BooksOrders.AddAsync(new()
                {
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
            var validator = new UpdateBookOrderRequestValidator();
            var validRes = validator.Validate(request);
            if (!validRes.IsValid)
            {
                throw new ValidationException("UpdateBookOrder", string.Join("/n", validRes.Errors));
            }

            UpdateBookOrderResponse response = new();

            try
            {
                var bookOrder = await _context.BooksOrders.SingleOrDefaultAsync(x => x.BookId == request.BookId && x.OrderId == request.OrderId);
                if (bookOrder is null)
                {
                    _logger.LogInformation("Requested BookOrder is not found.");
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
            var validator = new DeleteBookOrderRequestValidator();
            var validRes = validator.Validate(request);
            if (!validRes.IsValid)
            {
                throw new ValidationException("DeleteBookOrder", string.Join("/n", validRes.Errors));
            }

            DeleteBookOrderResponse response = new();

            try
            {
                var bookOrder = await _context.BooksOrders.SingleOrDefaultAsync(x => x.BookId == request.BookOrder.BookId && x.OrderId == request.BookOrder.OrderId);
                if (bookOrder is null)
                {
                    _logger.LogInformation("Requested to BookOrder to delete is not found.");
                    response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                    return response;
                }
                _context.BooksOrders.Remove(bookOrder);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BookOrder was not deleted.");
                response.StatusCode = Messaging.BusinessStatusCodeEnum.InternalServerError;
                return response;
            }
            return response;
        }

    }
}
