using BS.ApplicationServices.Interfaces;
using BS.ApplicationServices.Messaging.Responses.BookResponses;
using BS.ApplicationServices.Messaging;
using BS.ApplicationServices.ViewModels;
using BS.WebApiServices.Helpers;
using Microsoft.AspNetCore.Mvc;
using BS.ApplicationServices.Messaging.Responses.RolesResponses;

namespace BS.WebApiServices.Controllers
{
    /// <summary>
    /// Roles controller.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class RolesController : Controller
    {
        private readonly IRoleService _service;
        /// <summary>
        /// Initializes a new instance of the <see cref="RolesController"/> class.
        /// </summary>
        /// <param name="service">Role service.</param>
        public RolesController(IRoleService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get roles list.
        /// </summary>
        /// <returns>Return list of all roles.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(GetAllRolesResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRoles() => Ok(await _service.GetRolesAsync(new()));

        /// <summary>
        /// Get role by name.
        /// </summary>
        /// <param name="name">Role name.</param>
        /// <returns>Single role filter by name</returns>
        [HttpGet("search/{name}")]
        [ProducesResponseType(typeof(GetRoleByNameResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute] string name) => Ok(await _service.GetRoleByNameAsync(new(name)));

        /// <summary>
        /// Save role.
        /// </summary>
        /// <returns>Return null if not success.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreateRoleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateRole([FromBody] RoleVM model) => Ok(await _service.SaveAsync(new(model)));

        /// <summary>
        /// Update role.
        /// </summary>
        /// <returns>Return null if not success.</returns>
        [HttpPut("update/{id}")]
        [ProducesResponseType(typeof(UpdateRoleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateRole([FromRoute] Guid id, [FromBody] RoleVM model) => Ok(await _service.UpdateAsync(new(id, model)));

        /// <summary>
        /// Delete role.
        /// </summary>
        /// <returns>Return null if not success.</returns>
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(typeof(DeleteRoleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteRole([FromRoute] Guid id) => Ok(await _service.DeleteAsync(new(id)));
    }
}
