using BS.ApplicationServices.Interfaces;
using BS.ApplicationServices.Messaging.Requests.BookOrderRequests.GetAllOrdersByBookId;
using BS.ApplicationServices.Messaging.Requests.UserRoleRequests.CreateUserRole;
using BS.ApplicationServices.Messaging.Requests.UserRoleRequests.CreateUserRoleRequestValidator;
using BS.ApplicationServices.Messaging.Requests.UserRoleRequests.DeleteUserRole;
using BS.ApplicationServices.Messaging.Requests.UserRoleRequests.GetAllRolesByUserId;
using BS.ApplicationServices.Messaging.Requests.UserRoleRequests.GetAllUserRoles;
using BS.ApplicationServices.Messaging.Requests.UserRoleRequests.GetAllUsersByRoleId;
using BS.ApplicationServices.Messaging.Requests.UserRoleRequests.UpdateUserRole;
using BS.ApplicationServices.Messaging.Responses.BookOrderResponses;
using BS.ApplicationServices.Messaging.Responses.UserRoleResponses;
using BS.Data.Contexts;
using BS.Data.Entities;
using BS.Data.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BS.ApplicationServices.Implementations
{
    public class UserRoleService : IUserRoleService
    {
        private readonly ILogger<UserRoleService> _logger;
        private readonly BookStoreDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRoleService#"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="context">Book database context.</param>
        public UserRoleService(ILogger<UserRoleService> logger, BookStoreDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<GetAllRolesByUserIdResponse> GetAllRolesByUserIdAsync(GetAllRolesByUserIdRequest request)
        {
            var validator = new GetAllRolesByUserIdRequestValidator();
            var validRes = validator.Validate(request);
            if (!validRes.IsValid)
            {
                throw new ValidationException("GetRolesByUserId", string.Join("/n", validRes.Errors));
            }
            GetAllRolesByUserIdResponse response = new();

            var userRoles = await _context.UsersRoles.Select(x => x).Where(x => x.UserId == request.UserId).ToListAsync();
            if (userRoles is null)
            {
                _logger.LogInformation("There are no roles for this user id: {UserId}", request.UserId);
                response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                return response;
            }
            foreach (var userRole in userRoles)
            {
                var role = await _context.Roles.FirstAsync(x => x.RoleId == userRole.RoleId);
                if (role != null)
                {
                    response.Roles.Add(new()
                    {
                        RoleId = role.RoleId,
                        RoleName = role.RoleName,
                        RoleDescription = role.RoleDescription
                    });
                }
            }

            return response;
        }

        public async Task<GetAllUsersByRoleIdResponse> GetAllUsersByRoleIdAsync(GetAllUsersByRoleIdRequest request)
        {
            var validator = new GetAllUsersByRoleIdRequestValidator();
            var validRes = validator.Validate(request);
            if (!validRes.IsValid)
            {
                throw new ValidationException("GetUsersByRoleId", string.Join("/n", validRes.Errors));
            }
            GetAllUsersByRoleIdResponse response = new();

            var userRoles = await _context.UsersRoles.Select(x => x).Where(x => x.RoleId == request.RoleId).ToListAsync();
            if (userRoles is null)
            {
                _logger.LogInformation("There are no users for this role id: {RoleId}", request.RoleId);
                response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                return response;
            }
            foreach (var userRole in userRoles)
            {
                var user = await _context.Users.FirstAsync(x => x.UserId == userRole.UserId);
                if (user != null)
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
            }

            return response;
        }

        public async Task<GetAllUserRolesResponse> GetUserRoleAsync(GetAllUserRolesRequest request)
        {
            GetAllUserRolesResponse response = new() { UserRoles = new() };

            var userRoles = await _context.UsersRoles.ToListAsync();
            if (userRoles is null)
            {
                return response;
            }
            foreach (var userRole in userRoles)
            {
                response.UserRoles.Add(new()
                {
                    UserId = userRole.UserId,
                    RoleId = userRole.RoleId
                });
            }

            return response;
        }

        public async Task<CreateUserRoleResponse> SaveAsync(CreateUserRoleRequest request)
        {
            var validator = new CreateUserRoleRequestValidator();
            var validRes = validator.Validate(request);
            if (!validRes.IsValid)
            {
                throw new ValidationException("CreateUserRole", string.Join("/n", validRes.Errors));
            }

            CreateUserRoleResponse response = new();

            try
            {
                await _context.UsersRoles.AddAsync(new()
                {
                    UserId = request.UserRole.UserId,
                    RoleId = request.UserRole.RoleId
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User-Role was not saved.");
                response.StatusCode = Messaging.BusinessStatusCodeEnum.InternalServerError;
                return response;
            }

            return response;
        }

        public async Task<UpdateUserRoleResponse> UpdateAsync(UpdateUserRoleRequest request)
        {
            var validator = new UpdateUserRoleRequestValidator();
            var validRes = validator.Validate(request);
            if (!validRes.IsValid)
            {
                throw new ValidationException("UpdateUserRole", string.Join("/n", validRes.Errors));
            }

            UpdateUserRoleResponse response = new();

            try
            {
                var userRole = await _context.UsersRoles.SingleOrDefaultAsync(x => x.UserId == request.UserId && x.RoleId == request.RoleId);
                if (userRole is null)
                {
                    _logger.LogInformation("User-Role was not found.");
                    response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                    return response;
                }
                _context.Entry(userRole).CurrentValues.SetValues(request.UserRole);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User-Role was not updated.");
                response.StatusCode = Messaging.BusinessStatusCodeEnum.InternalServerError;
                return response;
            }
            return response;
        }

        public async Task<DeleteUserRoleResponse> DeleteAsync(DeleteUserRoleRequest request)
        {
            var validator = new DeleteUserRoleRequestValidator();
            var validRes = validator.Validate(request);
            if (!validRes.IsValid)
            {
                throw new ValidationException("DeleteUserRole", string.Join("/n", validRes.Errors));
            }

            DeleteUserRoleResponse response = new();

            try
            {
                var userRole = await _context.UsersRoles.SingleOrDefaultAsync(x => x.UserId == request.UserRole.UserId && x.RoleId == request.UserRole.RoleId);
                if (userRole is null)
                {
                    _logger.LogInformation("User-Role was not found.");
                    response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                    return response;
                }
                _context.UsersRoles.Remove(userRole);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User-Role was not deleted.");
                response.StatusCode = Messaging.BusinessStatusCodeEnum.InternalServerError;
                return response;
            }

            return response;
        }

    }
}
