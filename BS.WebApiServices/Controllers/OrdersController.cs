using BS.ApplicationServices.Interfaces;
using BS.ApplicationServices.Messaging.Responses.OrderResponses;
using BS.ApplicationServices.Messaging;
using BS.ApplicationServices.ViewModels;
using Microsoft.AspNetCore.Mvc;
using BS.WebApiServices.Helpers;


/// <summary>
/// Orders controller.
/// </summary>
[Authorize]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class OrdersController : Controller
{
    private readonly IOrderService _service;
    /// <summary>
    /// Initializes a new instance of the <see cref="OrdersController"/> class.
    /// </summary>
    /// <param name="service">Order service.</param>
    public OrdersController(IOrderService service)
    {
        _service = service;
    }

    /// <summary>
    /// Get orders list.
    /// </summary>
    /// <returns>Return list of all orders.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(GetAllOrdersResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetOrders() => Ok(await _service.GetOrdersAsync(new()));

    /// <summary>
    /// Get order by id.
    /// </summary>
    /// <param name="id">Order id.</param>
    /// <returns>Single order filter by id</returns>
    [HttpGet("search/{id}")]
    [ProducesResponseType(typeof(GetOrderByIdResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get([FromRoute] Guid guid) => Ok(await _service.GetOrderByIdAsync(new(guid)));

    /// <summary>
    /// Save order.
    /// </summary>
    /// <returns>Return null if not success.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(CreateOrderResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateOrder([FromBody] OrderVM model) => Ok(await _service.SaveAsync(new(model)));

    /// <summary>
    /// Update order.
    /// </summary>
    /// <returns>Return null if not success.</returns>
    [HttpPut("update/{id}")]
    [ProducesResponseType(typeof(UpdateOrderResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateOrder([FromRoute] Guid id, [FromBody] OrderVM model) => Ok(await _service.UpdateAsync(new(id, model)));

    /// <summary>
    /// Delete order.
    /// </summary>
    /// <returns>Return null if not success.</returns>
    [HttpDelete("delete/{id}")]
    [ProducesResponseType(typeof(DeleteOrderResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteOrder([FromRoute] Guid id) => Ok(await _service.DeleteAsync(new(id)));
}