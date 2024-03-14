using Azure.Core;
using BS.ApplicationServices.Interfaces;
using BS.ApplicationServices.Messaging.Requests.CustomerRequests;
using BS.ApplicationServices.Messaging.Responses.CustomerResponse;
using BS.ApplicationServices.Messaging.Responses.CustomerResponses;
using BS.Data.Contexts;
using BS.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BS.ApplicationServices.Implementations
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly BookStoreDbContext _context;
        private readonly IJWTAuthenticationsManager _jwtAuthenticationsManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="context">Customer database context.</param>
        public UserService(ILogger<UserService> logger, BookStoreDbContext context,
            IJWTAuthenticationsManager jwtAuthenticationsManager)
        {
            _logger = logger;
            _context = context;
            _jwtAuthenticationsManager = jwtAuthenticationsManager;
        }        

        public async Task<GetCustomerByNameResponse> GetCustomerByNameAsync(GetCustomerByNameRequest request)
        {
            GetCustomerByNameResponse response = new();

            var customer = await _context.Users.SingleOrDefaultAsync(x => x.FirstName == request.FirstName && x.LastName == request.LastName);
            if (customer is null)
            {
                _logger.LogInformation("Customer is not found with first and last name: {firstName} {lastname}", request.FirstName, request.LastName);
                response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                return response;
            }

            response.User = new ()
            {
                UserId = customer.UserId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Address = customer.Address,
                Phone = customer.PhoneNumber,
                RegistrationDate = DateTime.Now,
                OrdersCount = customer.OrdersCount,
                HasOrders = customer.HasOrders
            };

            return response;
        }

        public async Task<GetAllCustomersResponse> GetCustomersAsync(GetAllCustomersRequest request)
        {
            GetAllCustomersResponse response = new() { Users = new() };

            var customers = await _context.Users.ToListAsync();
            if (customers is null)
            {
                return response;
            }
            foreach (var customer in customers)
            {
                response.Users.Add(new()
                {
                    UserId = customer.UserId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    Address = customer.Address,
                    Phone = customer.PhoneNumber,
                    RegistrationDate = DateTime.Now,
                    OrdersCount = customer.OrdersCount,
                    HasOrders = customer.HasOrders
                });
            }

            return response;
        }

        public async Task<CreateCustomerResponse> SaveAsync(CreateCustomerRequest request)
        {
            CreateCustomerResponse response = new();

            try
            {
                await _context.Users.AddAsync(new()
                {
                    UserId = Guid.NewGuid(),
                    Username = request.User.Username,
                    Password = request.User.Password,
                    FirstName = request.User.FirstName,
                    LastName = request.User.LastName,
                    Email = request.User.Email,
                    Address = request.User.Address,
                    PhoneNumber = request.User.Phone,
                    RegistrationDate = DateTime.Now
                });

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User is not save.");
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
                var customer = await _context.Users.SingleOrDefaultAsync(x => x.UserId == request.UserId);
                if (customer is null)
                {
                    _logger.LogInformation("Customer is not found with id: {CustomerId}", request.UserId);
                    response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                    return response;
                }
                _context.Entry(customer).CurrentValues.SetValues(request.User);
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
                var customer = await _context.Users.SingleOrDefaultAsync(x => x.UserId == request.UserId);
                if (customer is null)
                {
                    _logger.LogInformation("Customer is not found with id: {CustomerId}", request.UserId);
                    response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                    return response;
                }
                _context.Users.Remove(customer);
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

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
        {
            AuthenticateResponse response = new();
            try
            {
                var user = _context.Users.SingleOrDefault(x => x.Username == request.Username && x.Password == request.Password);

                // return null if user not found
                if (user == null)
                { 
                    response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                    return response;
                }

                // authentication successful so generate jwt token
                response.Token =  _jwtAuthenticationsManager.GenerateJwtToken(user);
                response.Id = user.UserId;
                response.FirstName = user.FirstName;
                response.LastName = user.LastName;
                response.Username = user.Username;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Customer is not deleted.");
                response.StatusCode = Messaging.BusinessStatusCodeEnum.InternalServerError;
                return response;
            }

            return response;
        }

        public async Task<GetUserByIdResponse> GetUserById(GetUserByIdRequest request)
        {

            GetUserByIdResponse response = new();

            var customer = await _context.Users.SingleOrDefaultAsync(x => x.UserId == request.UserId);
            if (customer is null)
            {
                _logger.LogInformation("Customer with id: '{request.UserId}' is not found", request.UserId);
                response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                return response;
            }

            response.User = new()
            {
                UserId = customer.UserId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Address = customer.Address,
                Phone = customer.PhoneNumber,
                RegistrationDate = DateTime.Now,
                OrdersCount = customer.OrdersCount,
                HasOrders = customer.HasOrders
            };

            return response;
        }
    }
}
