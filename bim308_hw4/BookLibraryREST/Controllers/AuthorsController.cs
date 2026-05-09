using BookLibraryREST.Models;
using BookLibraryREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryREST.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public AuthorsController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAuthors()
        {
            return Ok(_libraryService.GetAuthors());
        }

        [HttpGet("{id:int}")]
        public ActionResult<Author> GetAuthor(int id)
        {
            var author = _libraryService.GetAuthor(id);
            return author is null ? NotFound(new { statusCode = 404, message = "Author was not found." }) : Ok(new { statusCode = 200, data = author });
        }

        [HttpPost]
        public ActionResult<Author> CreateAuthor([FromBody] Author author)
        {
            var result = _libraryService.CreateAuthor(author);
            if (!result.IsSuccess)
            {
                return ToErrorResult(result);
            }

            return CreatedAtAction(nameof(GetAuthor), new { id = result.Value!.AuthorID }, new { statusCode = 201, data = result.Value });
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateAuthor(int id, [FromBody] Author author)
        {
            var result = _libraryService.UpdateAuthor(id, author);
            return result.IsSuccess ? Ok(new { statusCode = 200, message = "Author updated successfully." }) : ToErrorResult(result);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteAuthor(int id)
        {
            var result = _libraryService.DeleteAuthor(id);
            return result.IsSuccess ? Ok(new { statusCode = 200, message = "Author deleted successfully." }) : ToErrorResult(result);
        }

        private ActionResult ToErrorResult(ServiceResult result)
        {
            if (result.Error == ServiceError.NotFound)
            {
                return NotFound(new { statusCode = 404, message = result.Message });
            }
            return BadRequest(new { statusCode = 400, message = result.Message });
        }
    }
}
