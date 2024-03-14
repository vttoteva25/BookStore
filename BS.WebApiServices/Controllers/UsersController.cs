using BS.ApplicationServices.Interfaces;
using BS.ApplicationServices.Messaging.Responses.CustomerResponse;
using BS.ApplicationServices.Messaging;
using Microsoft.AspNetCore.Mvc;
using BS.ApplicationServices.ViewModels;
using BS.ApplicationServices.Implementations;
using BS.ApplicationServices.Messaging.Requests.CustomerRequests;
using Microsoft.AspNetCore.Authorization;
/// <summary>
/// Customers controller.
/// </summary>
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
    /// <param name="service">Customer service.</param>
    public UsersController(IUserService service, IJWTAuthenticationsManager authenticationManager)
    {
        _service = service;
        _authenticationManager = authenticationManager;
    }

    [HttpPost("authenticate")]
    public async Task<IActionResult> AuthenticateAsync(AuthenticateRequest request) =>Ok(await _service.Authenticate(request)); 
   

    /// <summary>
    /// Get customers list.
    /// </summary>
    /// <returns>Return list of all customers.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(GetAllCustomersResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCustomers() => Ok(await _service.GetCustomersAsync(new()));

    /// <summary>
    /// Get customer by first and last name.
    /// </summary>
    /// <param name="firstName">Customer first name.</param>
    /// <param name="lastName">Customer last name.</param>
    /// <returns>Single customer filter by first and last name</returns>
    [BS.WebApiServices.Helpers.Authorize]
    [HttpGet("search/{firstName}&&{lastName}")]
    [ProducesResponseType(typeof(GetCustomerByNameResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get([FromRoute] string firstName, [FromRoute] string lastName) => Ok(await _service.GetCustomerByNameAsync(new(firstName, lastName)));

    /// <summary>
    /// Save customer.
    /// </summary>
    /// <returns>Return null if not success.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(CreateCustomerResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateCustomer([FromBody] RegisterUserVM model) => Ok(await _service.SaveAsync(new(model)));

    /// <summary>
    /// Update customer.
    /// </summary>
    /// <returns>Return null if not success.</returns>
    [HttpPut("update/{id}")]
    [ProducesResponseType(typeof(UpdateCustomerResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateCustomer([FromRoute] Guid id, [FromBody] UserVM model) => Ok(await _service.UpdateAsync(new(id, model)));

    /// <summary>
    /// Delete customer.
    /// </summary>
    /// <returns>Return null if not success.</returns>
    [HttpPut("delete/{id}")]
    [ProducesResponseType(typeof(DeleteCustomerResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteCustomer([FromRoute] Guid id) => Ok(await _service.DeleteAsync(new(id)));
}