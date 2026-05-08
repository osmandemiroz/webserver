using BookLibraryREST.Models;

namespace BookLibraryREST.Repositories
{
    public interface ILibraryRepository
    {
        IReadOnlyCollection<Author> GetAuthors();
        Author? GetAuthor(int id);
        Author AddAuthor(Author author);
        bool UpdateAuthor(Author author);
        bool DeleteAuthor(int id);
        bool AuthorExists(int id);

        IReadOnlyCollection<Book> GetBooks();
        Book? GetBook(int id);
        Book AddBook(Book book);
        bool UpdateBook(Book book);
        bool DeleteBook(int id);
        bool BookExists(int id);

        IReadOnlyCollection<User> GetUsers();
        User? GetUser(int id);
        User AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int id);
        bool UserExists(int id);

        bool RentBook(int userId, int bookId);
        bool ReturnBook(int userId, int bookId);
    }
}
