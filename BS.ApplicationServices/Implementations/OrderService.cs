using BS.ApplicationServices.Interfaces;
using BS.ApplicationServices.Messaging.Requests.OrderRequests;
using BS.ApplicationServices.Messaging.Responses.BookResponses;
using BS.ApplicationServices.Messaging.Responses.OrderResponses;
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
    public class OrderService : IOrderService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly BookStoreDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderService"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="context">Order database context.</param>
        public OrderService(ILogger<OrderService> logger, BookStoreDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<GetOrderByIdResponse> GetOrderByIdAsync(GetOrderByIdRequest request)
        {
            GetOrderByIdResponse response = new();

            var order = await _context.Orders.SingleOrDefaultAsync(x => x.OrderId == request.OrderId);
            if (order is null)
            {
                _logger.LogInformation("Order is not found with id: {OrderId}", request.OrderId);
                response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                return response;
            }

            response.Order = new()
            {
                OrderId = order.OrderId,
                UserId = order.UserId,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                PaymentMethod = order.PaymentMethod,
                DeliveryAddress = order.DeliveryAddress,
                DeliveryStatus = order.DeliveryStatus,
                IsApproved  = order.IsApproved,
                IsDelivered  = order.IsDelivered
            };

            return response;
        }

        public async Task<GetAllOrdersResponse> GetOrdersAsync(GetAllOrdersResponse request)
        {
            GetAllOrdersResponse response = new() { Orders = new() };

            var orders = await _context.Orders.ToListAsync();
            if (orders is null)
            {
                return response;
            }
            foreach (var order in orders)
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

            return response;
        }

        public async Task<CreateOrderResponse> SaveAsync(CreateOrderRequest request)
        {
            CreateOrderResponse response = new();

            try
            {
                await _context.Orders.AddAsync(new()
                {
                    OrderId = request.Order.OrderId,
                    UserId = request.Order.UserId,
                    OrderDate = request.Order.OrderDate,
                    TotalAmount = request.Order.TotalAmount,
                    PaymentMethod = request.Order.PaymentMethod,
                    DeliveryAddress = request.Order.DeliveryAddress,
                    DeliveryStatus = request.Order.DeliveryStatus,
                    IsApproved = request.Order.IsApproved,
                    IsDelivered = request.Order.IsDelivered
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Order is not save.");
                response.StatusCode = Messaging.BusinessStatusCodeEnum.InternalServerError;
                return response;
            }

            return response;
        }

        public async Task<UpdateOrderResponse> UpdateAsync(UpdateOrderRequest request)
        {
            UpdateOrderResponse response = new();

            try
            {
                var order = await _context.Orders.SingleOrDefaultAsync(x => x.OrderId == request.OrderId);
                if (order is null)
                {
                    _logger.LogInformation("Order is not found with id: {OrderId}", request.OrderId);
                    response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                    return response;
                }
                _context.Entry(order).CurrentValues.SetValues(request.Order);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Order is not updated.");
                response.StatusCode = Messaging.BusinessStatusCodeEnum.InternalServerError;
                return response;
            }
            return response;
        }

        public async Task<DeleteOrderResponse> DeleteAsync(DeleteOrderRequest request)
        {
            DeleteOrderResponse response = new();

            try
            {
                var order = await _context.Orders.SingleOrDefaultAsync(x => x.OrderId == request.OrderId);
                if (order is null)
                {
                    _logger.LogInformation("Order is not found with id: {OrderId}", request.OrderId);
                    response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                    return response;
                }
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Order is not deleted.");
                response.StatusCode = Messaging.BusinessStatusCodeEnum.InternalServerError;
                return response;
            }
            return response;
        }
    }
}
