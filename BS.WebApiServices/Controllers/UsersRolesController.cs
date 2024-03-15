using BS.ApplicationServices.Interfaces;
using BS.ApplicationServices.Messaging;
using BS.ApplicationServices.Messaging.Responses.UserRoleResponses;
using BS.ApplicationServices.ViewModels;
using BS.WebApiServices.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace BS.WebApiServices.Controllers
{
    /// <summary>
    /// Users-Roles controller.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsersRolesController : Controller
    {
        private readonly IUserRoleService _service;
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersRolesController"/> class.
        /// </summary>
        /// <param name="service">User-Role service.</param>
        public UsersRolesController(IUserRoleService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get User-Role list.
        /// </summary>
        /// <returns>Return list of all User-Role.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(GetAllUserRolesResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsersRoles() => Ok(await _service.GetUserRoleAsync(new()));

        /// <summary>
        /// Get list of users by role id.
        /// </summary>
        /// <param name="id">Role id.</param>
        /// <returns>List of users filter by role id</returns>
        [HttpGet("getusers/{id}")]
        [ProducesResponseType(typeof(GetAllUsersByRoleIdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllUsersByRoleIdAsync([FromRoute] Guid id) => Ok(await _service.GetAllUsersByRoleIdAsync(new(id)));

        /// <summary>
        /// Get list of roles by user id.
        /// </summary>
        /// <param name="id">User id.</param>
        /// <returns>List of roles filter by user id</returns>
        [HttpGet("getroles/{id}")]
        [ProducesResponseType(typeof(GetAllRolesByUserIdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllRolesByUserIdAsync([FromRoute] Guid id) => Ok(await _service.GetAllRolesByUserIdAsync(new(id)));

        /// <summary>
        /// Save User-Role.
        /// </summary>
        /// <returns>Return null if not success.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreateUserRoleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUserRole([FromBody] UserRoleVM model) => Ok(await _service.SaveAsync(new(model)));

        /// <summary>
        /// Update User-Role.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="roleId">Role id.</param>
        /// <returns>Return null if not success.</returns>
        [HttpPut("update/{userId}&&{roleId}")]
        [ProducesResponseType(typeof(UpdateUserRoleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUserRole([FromRoute] Guid userId,[FromRoute] Guid roleId, [FromBody] UserRoleVM model) => Ok(await _service.UpdateAsync(new(userId,roleId, model)));

        /// <summary>
        /// Delete User-Role.
        /// </summary>
        /// <returns>Return null if not success.</returns>
        [HttpDelete("delete")]
        [ProducesResponseType(typeof(DeleteUserRoleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUserRole([FromBody] UserRoleVM model) => Ok(await _service.DeleteAsync(new(model)));
    }
}
