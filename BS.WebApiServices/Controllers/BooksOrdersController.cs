using BS.ApplicationServices.Interfaces;
using BS.ApplicationServices.Messaging.Responses.UserRoleResponses;
using BS.ApplicationServices.Messaging;
using BS.ApplicationServices.ViewModels;
using BS.WebApiServices.Helpers;
using Microsoft.AspNetCore.Mvc;
using BS.ApplicationServices.Messaging.Responses.BookOrderResponses;

namespace BS.WebApiServices.Controllers
{
    /// <summary>
    /// Books-Orders controller.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BooksOrdersController : Controller
    {
        private readonly IBookOrderService _service;
        /// <summary>
        /// Initializes a new instance of the <see cref="BooksOrdersController"/> class.
        /// </summary>
        /// <param name="service">Book-Order service.</param>
        public BooksOrdersController(IBookOrderService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get Book-Order list.
        /// </summary>
        /// <returns>Return list of all Book-Order.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(GetAllBookOrdersResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBooksOrders() => Ok(await _service.GetBookOrdersAsync(new()));

        /// <summary>
        /// Get list of books by order id.
        /// </summary>
        /// <param name="id">Order id.</param>
        /// <returns>List of books filter by order id</returns>
        [HttpGet("getbooks/{id}")]
        [ProducesResponseType(typeof(GetAllBooksByOrderIdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllBooksByOrderIdAsync([FromRoute] Guid id) => Ok(await _service.GetBooksByOrderIdAsync(new(id)));

        /// <summary>
        /// Get list of orders by book id.
        /// </summary>
        /// <param name="id">Book id.</param>
        /// <returns>List of orders filter by book id</returns>
        [HttpGet("getorders/{id}")]
        [ProducesResponseType(typeof(GetAllOrdersByBookIdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllOrdersByBookIdAsync([FromRoute] Guid id) => Ok(await _service.GetOrdersByBookIdAsync(new(id)));

        /// <summary>
        /// Save Book-Order.
        /// </summary>
        /// <returns>Return null if not success.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreateBookOrderResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateBookOrder([FromBody] BookOrderVM model) => Ok(await _service.SaveAsync(new(model)));

        /// <summary>
        /// Update Book-Order.
        /// </summary>
        /// <param name="bookId">Book id.</param>
        /// <param name="orderId">Order id.</param>
        /// <returns>Return null if not success.</returns>
        [HttpPut("update/{bookId}&&{orderId}")]
        [ProducesResponseType(typeof(UpdateBookOrderResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateBookOrder([FromRoute] Guid bookId, [FromRoute] Guid orderId, [FromBody] BookOrderVM model) => Ok(await _service.UpdateAsync(new(bookId, orderId, model)));

        /// <summary>
        /// Delete Book-Order.
        /// </summary>
        /// <returns>Return null if not success.</returns>
        [HttpDelete("delete")]
        [ProducesResponseType(typeof(DeleteBookOrderResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteBookOrder([FromBody] BookOrderVM model) => Ok(await _service.DeleteAsync(new(model)));
    }
}
