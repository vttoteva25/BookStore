using BS.ApplicationServices.Interfaces;
using BS.ApplicationServices.Messaging.Responses.UserResponse;
using BS.ApplicationServices.Messaging;
using Microsoft.AspNetCore.Mvc;
using BS.ApplicationServices.ViewModels;
using BS.WebApiServices.Helpers;
using BS.ApplicationServices.Messaging.Requests.UserRequests.AuthenticateUser;

/// <summary>
/// Users controller.
/// </summary>

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class UsersController : Controller
{
    private readonly IUserService _service;

    /// <summary>
    /// Initializes a new instance of the <see cref="UsersController"/> class.
    /// </summary>
    /// <param name="service">User service.</param>
    public UsersController(IUserService service)
    {
        _service = service;
    }

    /// <summary>
    /// Authenticate user by username and passwors.
    /// </summary>
    /// <returns>Return list of all users.</returns>
    [HttpPost("authenticate")]
    public async Task<IActionResult> AuthenticateAsync(AuthenticateUserRequest request) => Ok(await _service.Authenticate(request));


    /// <summary>
    /// Get all users list.
    /// </summary>
    /// <returns>Return list of all users.</returns>
    [Authorize]
    [HttpGet]
    [ProducesResponseType(typeof(GetAllUsersResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetUsers() => Ok(await _service.GetUsersAsync(new()));

    /// <summary>
    /// Get user by first and last name.
    /// </summary>
    /// <param name="firstName">User first name.</param>
    /// <param name="lastName">User last name.</param>
    /// <returns>Single user filter by first and last name</returns>
    [Authorize]
    [HttpGet("search/{firstName}&&{lastName}")]
    [ProducesResponseType(typeof(GetUserByNameResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get([FromRoute] string firstName, [FromRoute] string lastName) => Ok(await _service.GetUserByNameAsync(new(firstName, lastName)));

    /// <summary>
    /// Create user.
    /// </summary>
    /// <returns>Return null if not success.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(CreateUserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateUser([FromBody] RegisterUserVM model) => Ok(await _service.SaveAsync(new(model)));

    /// <summary>
    /// Update user data.
    /// </summary>
    /// <returns>Return null if not success.</returns>
    [Authorize]
    [HttpPut("update/{id}")]
    [ProducesResponseType(typeof(UpdateUserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UserVM model) => Ok(await _service.UpdateAsync(new(id, model)));

    /// <summary>
    /// Delete user.
    /// </summary>
    /// <returns>Return null if not success.</returns>
    [Authorize]
    [HttpDelete("delete/{id}")]
    [ProducesResponseType(typeof(DeleteUserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteUser([FromRoute] Guid id) => Ok(await _service.DeleteAsync(new(id)));
}