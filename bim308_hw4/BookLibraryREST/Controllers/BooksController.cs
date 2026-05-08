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
            return book is null ? NotFound(new { message = "Book was not found." }) : Ok(book);
        }

        [HttpPost]
        public ActionResult<Book> CreateBook([FromBody] Book book)
        {
            var result = _libraryService.CreateBook(book);
            if (!result.IsSuccess)
            {
                return ToErrorResult(result);
            }

            return CreatedAtAction(nameof(GetBook), new { id = result.Value!.BookID }, result.Value);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            var result = _libraryService.UpdateBook(id, book);
            return result.IsSuccess ? NoContent() : ToErrorResult(result);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBook(int id)
        {
            var result = _libraryService.DeleteBook(id);
            return result.IsSuccess ? NoContent() : ToErrorResult(result);
        }

        private ActionResult ToErrorResult(ServiceResult result)
        {
            var response = new { message = result.Message };
            return result.Error == ServiceError.NotFound ? NotFound(response) : BadRequest(response);
        }
    }
}
