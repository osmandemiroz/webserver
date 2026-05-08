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
            return author is null ? NotFound(new { message = "Author was not found." }) : Ok(author);
        }

        [HttpPost]
        public ActionResult<Author> CreateAuthor([FromBody] Author author)
        {
            var result = _libraryService.CreateAuthor(author);
            if (!result.IsSuccess)
            {
                return ToErrorResult(result);
            }

            return CreatedAtAction(nameof(GetAuthor), new { id = result.Value!.AuthorID }, result.Value);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateAuthor(int id, [FromBody] Author author)
        {
            var result = _libraryService.UpdateAuthor(id, author);
            return result.IsSuccess ? NoContent() : ToErrorResult(result);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteAuthor(int id)
        {
            var result = _libraryService.DeleteAuthor(id);
            return result.IsSuccess ? NoContent() : ToErrorResult(result);
        }

        private ActionResult ToErrorResult(ServiceResult result)
        {
            var response = new { message = result.Message };
            return result.Error == ServiceError.NotFound ? NotFound(response) : BadRequest(response);
        }
    }
}
