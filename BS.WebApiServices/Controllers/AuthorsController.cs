using BS.ApplicationServices.Interfaces;
using BS.ApplicationServices.Messaging;
using BS.ApplicationServices.Messaging.Responses.AuthorResponses;
using BS.ApplicationServices.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BS.WebApiServices.Controllers
{
    /// <summary>
    /// Authors controller.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _service;
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorsController"/> class.
        /// </summary>
        /// <param name="service">Author service.</param>
        public AuthorsController(IAuthorService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get authors list.
        /// </summary>
        /// <returns>Return list of all authors.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(GetAllAuthorsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAuthors() => Ok(await _service.GetAuthorsAsync(new()));

        /// <summary>
        /// Get author by first and last name.
        /// </summary>
        /// <param name="firstName">Author first name.</param>
        /// <param name="lastName">Author last name.</param>
        /// <returns>Single movie filter by first and last name</returns>
        [HttpGet("search/{firstName}&&{lastName}")]
        [ProducesResponseType(typeof(GetAuthortByNameResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute] string firstName, [FromRoute] string lastName) => Ok(await _service.GetAuthorByNameAsync(new(firstName, lastName)));

        /// <summary>
        /// Save movie.
        /// </summary>
        /// <returns>Return null if not success.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreateAuthorResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorVM model) => Ok(await _service.SaveAsync(new(model)));

        /// <summary>
        /// Update author.
        /// </summary>
        /// <returns>Return null if not success.</returns>
        [HttpPut("update/{id}")]
        [ProducesResponseType(typeof(UpdateAuthorResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAuthor([FromRoute] Guid id,[FromBody] AuthorVM model) => Ok(await _service.UpdateAsync(new(id,model)));

        /// <summary>
        /// Delete author.
        /// </summary>
        /// <returns>Return null if not success.</returns>
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(typeof(DeleteAuthorResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAuthor([FromRoute] Guid id) => Ok(await _service.DeleteAsync(new(id)));
    }
}
