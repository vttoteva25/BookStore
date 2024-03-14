using BS.ApplicationServices.Interfaces;
using BS.ApplicationServices.Messaging.Responses.BookResponses;
using BS.ApplicationServices.Messaging;
using BS.ApplicationServices.ViewModels;
using Microsoft.AspNetCore.Mvc;
using BS.WebApiServices.Helpers;

/// <summary>
/// Books controller.
/// </summary>
[Authorize]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class BooksController : Controller
{
    private readonly IBookService _service;
    /// <summary>
    /// Initializes a new instance of the <see cref="BooksController"/> class.
    /// </summary>
    /// <param name="service">Book service.</param>
    public BooksController(IBookService service)
    {
        _service = service;
    }

    /// <summary>
    /// Get books list.
    /// </summary>
    /// <returns>Return list of all books.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(GetAllBooksResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetBooks() => Ok(await _service.GetBooksAsync(new()));

    /// <summary>
    /// Get book by title.
    /// </summary>
    /// <param name="title">Book title.</param>
    /// <returns>Single book filter by title</returns>
    [HttpGet("search/{title}")]
    [ProducesResponseType(typeof(GetBookByTitleResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get([FromRoute] string title) => Ok(await _service.GetBookByTitleAsync(new(title)));

    /// <summary>
    /// Save book.
    /// </summary>
    /// <returns>Return null if not success.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(CreateBookResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateBook([FromBody] BookVM model) => Ok(await _service.SaveAsync(new(model)));

    /// <summary>
    /// Update book.
    /// </summary>
    /// <returns>Return null if not success.</returns>
    [HttpPut("update/{id}")]
    [ProducesResponseType(typeof(UpdateBookResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateBook([FromRoute] Guid id, [FromBody] BookVM model) => Ok(await _service.UpdateAsync(new(id, model)));

    /// <summary>
    /// Delete book.
    /// </summary>
    /// <returns>Return null if not success.</returns>
    [HttpDelete("delete/{id}")]
    [ProducesResponseType(typeof(DeleteBookResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteBook([FromRoute] Guid id) => Ok(await _service.DeleteAsync(new(id)));
}