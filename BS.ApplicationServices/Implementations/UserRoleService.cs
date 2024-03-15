using BS.ApplicationServices.Interfaces;
using BS.ApplicationServices.Messaging.Requests.UserRoleRequests;
using BS.ApplicationServices.Messaging.Responses.BookOrderResponses;
using BS.ApplicationServices.Messaging.Responses.UserRoleResponses;
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
