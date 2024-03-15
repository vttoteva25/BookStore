using BS.ApplicationServices.Interfaces;
using BS.ApplicationServices.Messaging.Requests.RolesRequests;
using BS.ApplicationServices.Messaging.Responses.BookResponses;
using BS.ApplicationServices.Messaging.Responses.RolesResponses;
using BS.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly ILogger<RoleService> _logger;
        private readonly BookStoreDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleService"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="context">Book database context.</param>
        public RoleService(ILogger<RoleService> logger, BookStoreDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<GetRoleByNameResponse> GetRoleByNameAsync(GetRoleByNameRequest request)
        {
            GetRoleByNameResponse response = new();

            var role = await _context.Roles.SingleOrDefaultAsync(x => x.RoleName == request.RoleName);
            if (role is null)
            {
                _logger.LogInformation("Role is not found with name: {name}", request.RoleName);
                response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                return response;
            }

            response.Role = new()
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
                RoleDescription = role.RoleDescription
            };

            return response;
        }

        public async Task<GetAllRolesResponse> GetRolesAsync(GetAllRolesRequest request)
        {
            GetAllRolesResponse response = new() { Roles = new() };

            var roles = await _context.Roles.ToListAsync();
            if (roles is null)
            {
                return response;
            }
            foreach (var role in roles)
            {
                response.Roles.Add(new()
                {
                    RoleId = role.RoleId,
                    RoleName = role.RoleName,
                    RoleDescription = role.RoleDescription
                });
            }

            return response;
        }

        public async Task<CreateRoleResponse> SaveAsync(CreateRoleRequest request)
        {
            CreateRoleResponse response = new();

            try
            {
                await _context.Roles.AddAsync(new()
                {
                    RoleId = request.Role.RoleId,
                    RoleName = request.Role.RoleName,
                    RoleDescription = request.Role.RoleDescription
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Role was not saved.");
                response.StatusCode = Messaging.BusinessStatusCodeEnum.InternalServerError;
                return response;
            }

            return response;
        }

        public async Task<UpdateRoleResponse> UpdateAsync(UpdateRoleRequest request)
        {
            UpdateRoleResponse response = new();

            try
            {
                var role = await _context.Roles.SingleOrDefaultAsync(x => x.RoleId == request.RoleId);
                if (role is null)
                {
                    _logger.LogInformation("Role was not found with id: {RoleId}", request.RoleId);
                    response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                    return response;
                }
                _context.Entry(role).CurrentValues.SetValues(request.Role);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Role was not updated.");
                response.StatusCode = Messaging.BusinessStatusCodeEnum.InternalServerError;
                return response;
            }
            return response;
        }

        public async Task<DeleteRoleResponse> DeleteAsync(DeleteRoleRequest request)
        {
            DeleteRoleResponse response = new();

            try
            {
                var role = await _context.Roles.SingleOrDefaultAsync(x => x.RoleId == request.RoleId);
                if (role is null)
                {
                    _logger.LogInformation("Role was not found with id: {RoleId}", request.RoleId);
                    response.StatusCode = Messaging.BusinessStatusCodeEnum.MissingObject;
                    return response;
                }
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Role was not deleted.");
                response.StatusCode = Messaging.BusinessStatusCodeEnum.InternalServerError;
                return response;
            }
            return response;
        }

    }
}
