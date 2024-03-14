using BS.ApplicationServices.Interfaces;
using BS.ApplicationServices.Messaging.Responses.UserResponse;
using BS.ApplicationServices.Messaging;
using Microsoft.AspNetCore.Mvc;
using BS.ApplicationServices.ViewModels;
using BS.ApplicationServices.Messaging.Requests.UserRequests;
using BS.WebApiServices.Helpers;


/// <summary>
/// Users controller.
/// </summary>
[Authorize]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class UsersController : Controller
{
    private readonly IUserService _service;
    private readonly IJWTAuthenticationsManager _authenticationManager;
    /// <summary>
    /// Initializes a new instance of the <see cref="UsersController"/> class.
    /// </summary>
    /// <param name="service">User service.</param>
    public UsersController(IUserService service, IJWTAuthenticationsManager authenticationManager)
    {
        _service = service;
        _authenticationManager = authenticationManager;
    }

    [HttpPost("authenticate")]
    public async Task<IActionResult> AuthenticateAsync(AuthenticateRequest request) =>Ok(await _service.Authenticate(request)); 
   

    /// <summary>
    /// Get users list.
    /// </summary>
    /// <returns>Return list of all users.</returns>
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
    /// Save user.
    /// </summary>
    /// <returns>Return null if not success.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(CreateUserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateUser([FromBody] RegisterUserVM model) => Ok(await _service.SaveAsync(new(model)));

    /// <summary>
    /// Update user.
    /// </summary>
    /// <returns>Return null if not success.</returns>
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
    [HttpDelete("delete/{id}")]
    [ProducesResponseType(typeof(DeleteUserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteUser([FromRoute] Guid id) => Ok(await _service.DeleteAsync(new(id)));
}