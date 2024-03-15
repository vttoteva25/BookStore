using BS.ApplicationServices.Interfaces;
using BS.ApplicationServices.Messaging.Requests.UserRequests.AuthenticateUser;
using BS.ApplicationServices.Messaging.Requests.UserRequests.CreateUser;
using BS.ApplicationServices.Messaging.Requests.UserRequests.DeleteUser;
using BS.ApplicationServices.Messaging.Requests.UserRequests.GetAllUsers;
using BS.ApplicationServices.Messaging.Requests.UserRequests.GetUserById;
using BS.ApplicationServices.Messaging.Requests.UserRequests.GetUserByName;
using BS.ApplicationServices.Messaging.Requests.UserRequests.UpdateUser;
using BS.ApplicationServices.Messaging.Responses.UserResponse;
using BS.ApplicationServices.Messaging.Responses.UserResponses;
using BS.ApplicationServices.ViewModels;
using BS.Data.Contexts;
using BS.Data.Exceptions;
using BS.Data.Helpers;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ValidationException = BS.Data.Exceptions.ValidationException;

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
            var validator = new GetUserByNameRequestValidator();
            var validRes = validator.Validate(request);
            if (!validRes.IsValid)
            {
                throw new ValidationException("GetUserByNames", string.Join("/n", validRes.Errors));
            }

            GetUserByNameResponse response = new();

            var users = await _context.Users.Where(x => x.FirstName == request.FirstName && x.LastName == request.LastName).ToListAsync();
            if (users is null)
            {
                _logger.LogInformation("User is not found with first and last name: {firstName} {lastname}", request.FirstName, request.LastName);
                response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                return response;
            }

            response.Users = users.Select(user => new UserVM()
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
            })
                .ToList();

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
            var validator = new CreateUserRequestValidator();
            var validRes = validator.Validate(request);
            if (!validRes.IsValid)
            {
                throw new ValidationException("CreateUser", string.Join("/n", validRes.Errors));
            }

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
            var validator = new UpdateUserRequestValidator();
            var validRes = validator.Validate(request);
            if (!validRes.IsValid)
            {
                throw new ValidationException("UpdateUser", string.Join("/n", validRes.Errors));
            }

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
            var validator = new DeleteUserRequestValidator();
            var validRes = validator.Validate(request);
            if (!validRes.IsValid)
            {
                throw new ValidationException("DeleteUser", string.Join("/n", validRes.Errors));
            }

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

        public async Task<AuthenticateResponse> Authenticate(AuthenticateUserRequest request)
        {
            AuthenticateResponse response = new();
            var validator = new AuthenticateUserRequestValidator();
            var validRes = validator.Validate(request);
            if (!validRes.IsValid)
            {
                throw new ValidationException("AuthenticateUser", string.Join("/n", validRes.Errors));
            }

            try
            {
                var user = _context.Users.SingleOrDefault(x => x.Username == request.Username && x.Password == Hasher.Hash(request.Password));

                if (user == null)
                { 
                    response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                    return response;
                }

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
            var validator = new GetUserByIdRequestValidator();
            var validRes = validator.Validate(request);
            if (!validRes.IsValid)
            {
                throw new ValidationException("GetUser", string.Join("/n", validRes.Errors));
            }

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
