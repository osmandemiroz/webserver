using BookLibraryREST.Models;
using BookLibraryREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryREST.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public UsersController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_libraryService.GetUsers());
        }

        [HttpGet("{id:int}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _libraryService.GetUser(id);
            return user is null ? NotFound(new { statusCode = 404, message = "User was not found." }) : Ok(new { statusCode = 200, data = user });
        }

        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] User user)
        {
            var result = _libraryService.CreateUser(user);
            if (!result.IsSuccess)
            {
                return ToErrorResult(result);
            }

            return CreatedAtAction(nameof(GetUser), new { id = result.Value!.UserID }, new { statusCode = 201, data = result.Value });
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            var result = _libraryService.UpdateUser(id, user);
            return result.IsSuccess ? Ok(new { statusCode = 200, message = "User updated successfully." }) : ToErrorResult(result);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            var result = _libraryService.DeleteUser(id);
            return result.IsSuccess ? Ok(new { statusCode = 200, message = "User deleted successfully." }) : ToErrorResult(result);
        }

        [HttpPost("{userId:int}/rent/{bookId:int}")]
        public ActionResult<User> RentBook(int userId, int bookId)
        {
            var result = _libraryService.RentBook(userId, bookId);
            if (!result.IsSuccess)
            {
                return ToErrorResult(result);
            }

            return Ok(new { statusCode = 200, message = "Book rented successfully.", data = result.Value });
        }

        [HttpPost("{userId:int}/return/{bookId:int}")]
        public ActionResult<User> ReturnBook(int userId, int bookId)
        {
            var result = _libraryService.ReturnBook(userId, bookId);
            if (!result.IsSuccess)
            {
                return ToErrorResult(result);
            }

            return Ok(new { statusCode = 200, message = "Book returned successfully.", data = result.Value });
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
