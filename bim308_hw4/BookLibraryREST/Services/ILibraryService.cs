using BookLibraryREST.Models;

namespace BookLibraryREST.Services
{
    public interface ILibraryService
    {
        IReadOnlyCollection<Author> GetAuthors();
        Author? GetAuthor(int id);
        ServiceResult<Author> CreateAuthor(Author author);
        ServiceResult UpdateAuthor(int id, Author author);
        ServiceResult DeleteAuthor(int id);

        IReadOnlyCollection<Book> GetBooks();
        Book? GetBook(int id);
        ServiceResult<Book> CreateBook(Book book);
        ServiceResult UpdateBook(int id, Book book);
        ServiceResult DeleteBook(int id);

        IReadOnlyCollection<User> GetUsers();
        User? GetUser(int id);
        ServiceResult<User> CreateUser(User user);
        ServiceResult UpdateUser(int id, User user);
        ServiceResult DeleteUser(int id);

        ServiceResult<User> RentBook(int userId, int bookId);
        ServiceResult<User> ReturnBook(int userId, int bookId);
    }
}
