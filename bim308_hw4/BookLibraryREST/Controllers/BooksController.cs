using BookLibraryREST.Models;
using BookLibraryREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryREST.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public BooksController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return Ok(_libraryService.GetBooks());
        }

        [HttpGet("{id:int}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = _libraryService.GetBook(id);
            return book is null ? NotFound(new { statusCode = 404, message = "Book was not found." }) : Ok(new { statusCode = 200, data = book });
        }

        [HttpPost]
        public ActionResult<Book> CreateBook([FromBody] Book book)
        {
            var result = _libraryService.CreateBook(book);
            if (!result.IsSuccess)
            {
                return ToErrorResult(result);
            }

            return CreatedAtAction(nameof(GetBook), new { id = result.Value!.BookID }, new { statusCode = 201, data = result.Value });
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            var result = _libraryService.UpdateBook(id, book);
            return result.IsSuccess ? Ok(new { statusCode = 200, message = "Book updated successfully." }) : ToErrorResult(result);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBook(int id)
        {
            var result = _libraryService.DeleteBook(id);
            return result.IsSuccess ? Ok(new { statusCode = 200, message = "Book deleted successfully." }) : ToErrorResult(result);
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
