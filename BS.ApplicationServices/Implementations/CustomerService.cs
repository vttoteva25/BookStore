using BS.ApplicationServices.Interfaces;
using BS.ApplicationServices.Messaging.Requests.CustomerRequests;
using BS.ApplicationServices.Messaging.Responses.CustomerResponse;
using BS.Data.Contexts;
using BS.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BS.ApplicationServices.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly BookStoreDbContext _context;
        private readonly UserManager<Customer> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerService"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="context">Customer database context.</param>
        public CustomerService(ILogger<CustomerService> logger, BookStoreDbContext context,
            UserManager<Customer> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public async Task<GetCustomerByNameResponse> GetCustomerByNameAsync(GetCustomerByNameRequest request)
        {
            GetCustomerByNameResponse response = new();

            var customer = await _context.Customers.SingleOrDefaultAsync(x => x.FirstName == request.FirstName && x.LastName == request.LastName);
            if (customer is null)
            {
                _logger.LogInformation("Customer is not found with first and last name: {firstName} {lastname}", request.FirstName, request.LastName);
                response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                return response;
            }

            response.Customer = new()
            {
                CustomerId = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Address = customer.Address,
                Phone = customer.Phone,
                RegistrationDate = DateTime.Now,
                OrdersCount = customer.OrdersCount,
                hasOrders = customer.HasOrders
            };

            return response;
        }

        public async Task<GetAllCustomersResponse> GetCustomersAsync(GetAllCustomersRequest request)
        {
            GetAllCustomersResponse response = new() { Customers = new() };

            var customers = await _context.Customers.ToListAsync();
            if (customers is null)
            {
                return response;
            }
            foreach (var customer in customers)
            {
                response.Customers.Add(new()
                {
                    CustomerId = customer.CustomerId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    Address = customer.Address,
                    Phone = customer.Phone,
                    RegistrationDate = DateTime.Now,
                    OrdersCount = customer.OrdersCount,
                    hasOrders = customer.hasOrders
                });
            }

            return response;
        }

        public async Task<CreateCustomerResponse> SaveAsync(CreateCustomerRequest request)
        {
            CreateCustomerResponse response = new();

            try
            {
                await _context.Customers.AddAsync(new()
                {
                    CustomerId = request.Customer.CustomerId,
                    FirstName = request.Customer.FirstName,
                    LastName = request.Customer.LastName,
                    Email = request.Customer.Email,
                    Address = request.Customer.Address,
                    Phone = request.Customer.Phone,
                    RegistrationDate = DateTime.Now,
                    OrdersCount = request.Customer.OrdersCount,
                    hasOrders = request.Customer.hasOrders
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Customer is not save.");
                response.StatusCode = Messaging.BusinessStatusCodeEnum.InternalServerError;
                return response;
            }

            return response;
        }

        public async Task<UpdateCustomerResponse> UpdateAsync(UpdateCustomerRequest request)
        {
            UpdateCustomerResponse response = new();

            try
            {
                var customer = await _context.Customers.SingleOrDefaultAsync(x => x.CustomerId == request.CustomerId);
                if (customer is null)
                {
                    _logger.LogInformation("Customer is not found with id: {CustomerId}", request.CustomerId);
                    response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                    return response;
                }
                _context.Entry(customer).CurrentValues.SetValues(request.Customer);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Customer is not updated.");
                response.StatusCode = Messaging.BusinessStatusCodeEnum.InternalServerError;
                return response;
            }
            return response;
        }

        public async Task<DeleteCustomerResponse> DeleteAsync(DeleteCustomerRequest request)
        {
            DeleteCustomerResponse response = new();

            try
            {
                var customer = await _context.Customers.SingleOrDefaultAsync(x => x.CustomerId == request.CustomerId);
                if (customer is null)
                {
                    _logger.LogInformation("Customer is not found with id: {CustomerId}", request.CustomerId);
                    response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                    return response;
                }
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Customer is not deleted.");
                response.StatusCode = Messaging.BusinessStatusCodeEnum.InternalServerError;
                return response;
            }
            return response;
        }
    }
}
