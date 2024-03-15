using BS.ApplicationServices.Interfaces;
using BS.ApplicationServices.Messaging.Requests.UserRequests;
using BS.ApplicationServices.Messaging.Responses.UserResponse;
using BS.ApplicationServices.Messaging.Responses.UserResponses;
using BS.Data.Contexts;
using BS.Data.Helpers;
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
        /// <param name="context">User database context.</param>
        public UserService(ILogger<UserService> logger, BookStoreDbContext context,
            IJWTAuthenticationsManager jwtAuthenticationsManager)
        {
            _logger = logger;
            _context = context;
            _jwtAuthenticationsManager = jwtAuthenticationsManager;
        }        

        public async Task<GetUserByNameResponse> GetUserByNameAsync(GetUserByNameRequest request)
        {
            GetUserByNameResponse response = new();

            var user = await _context.Users.SingleOrDefaultAsync(x => x.FirstName == request.FirstName && x.LastName == request.LastName);
            if (user is null)
            {
                _logger.LogInformation("User is not found with first and last name: {firstName} {lastname}", request.FirstName, request.LastName);
                response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                return response;
            }

            response.User = new ()
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                Phone = user.PhoneNumber,
                RegistrationDate = DateTime.Now,
                OrdersCount = user.OrdersCount,
                HasOrders = user.HasOrders
            };

            return response;
        }

        public async Task<GetAllUsersResponse> GetUsersAsync(GetAllUsersRequest request)
        {
            GetAllUsersResponse response = new() { Users = new() };

            var users = await _context.Users.ToListAsync();
            if (users is null)
            {
                return response;
            }
            foreach (var user in users)
            {
                response.Users.Add(new()
                {
                    UserId = user.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Address = user.Address,
                    Phone = user.PhoneNumber,
                    RegistrationDate = DateTime.Now,
                    OrdersCount = user.OrdersCount,
                    HasOrders = user.HasOrders
                });
            }

            return response;
        }

        public async Task<CreateUserResponse> SaveAsync(CreateUserRequest request)
        {
            CreateUserResponse response = new();

            try
            {
                await _context.Users.AddAsync(new()
                {
                    UserId = Guid.NewGuid(),
                    Username = request.User.Username,
                    Password = Hasher.Hash(request.User.Password),
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

        public async Task<UpdateUserResponse> UpdateAsync(UpdateUserRequest request)
        {
            UpdateUserResponse response = new();

            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(x => x.UserId == request.UserId);
                if (user is null)
                {
                    _logger.LogInformation("User is not found with id: {UserId}", request.UserId);
                    response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                    return response;
                }
                _context.Entry(user).CurrentValues.SetValues(request.User);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User is not updated.");
                response.StatusCode = Messaging.BusinessStatusCodeEnum.InternalServerError;
                return response;
            }
            return response;
        }

        public async Task<DeleteUserResponse> DeleteAsync(DeleteUserRequest request)
        {
            DeleteUserResponse response = new();

            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(x => x.UserId == request.UserId);
                if (user is null)
                {
                    _logger.LogInformation("User is not found with id: {UserId}", request.UserId);
                    response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                    return response;
                }
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User is not deleted.");
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
                var user = _context.Users.SingleOrDefault(x => x.Username == request.Username && x.Password == Hasher.Hash(request.Password));

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
                _logger.LogError(ex, "User is not deleted.");
                response.StatusCode = Messaging.BusinessStatusCodeEnum.InternalServerError;
                return response;
            }

            return response;
        }

        public async Task<GetUserByIdResponse> GetUserByIdAsync(GetUserByIdRequest request)
        {

            GetUserByIdResponse response = new();

            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserId == request.UserId);
            if (user is null)
            {
                _logger.LogInformation("User with id: '{request.UserId}' is not found", request.UserId);
                response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                return response;
            }

            response.User = new()
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.Username,
                Address = user.Address,
                Phone = user.PhoneNumber,
                RegistrationDate = DateTime.Now,
                OrdersCount = user.OrdersCount,
                HasOrders = user.HasOrders
            };

            return response;
        }
    }
}
