using BookLibraryREST.Models;
using BookLibraryREST.Repositories;

namespace BookLibraryREST.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository _repository;

        public LibraryService(ILibraryRepository repository)
        {
            _repository = repository;
        }

        public IReadOnlyCollection<Author> GetAuthors()
        {
            return _repository.GetAuthors();
        }

        public Author? GetAuthor(int id)
        {
            return _repository.GetAuthor(id);
        }

        public ServiceResult<Author> CreateAuthor(Author author)
        {
            if (author.AuthorID > 0 && _repository.AuthorExists(author.AuthorID))
            {
                return ServiceResult<Author>.BadRequest("An author with this ID already exists.");
            }

            TrimAuthor(author);
            return ServiceResult<Author>.Success(_repository.AddAuthor(author));
        }

        public ServiceResult UpdateAuthor(int id, Author author)
        {
            if (!IsMatchingId(id, author.AuthorID))
            {
                return ServiceResult.BadRequest("The route ID and authorID value do not match.");
            }

            if (!_repository.AuthorExists(id))
            {
                return ServiceResult.NotFound("Author was not found.");
            }

            author.AuthorID = id;
            TrimAuthor(author);
            _repository.UpdateAuthor(author);
            return ServiceResult.Success();
        }

        public ServiceResult DeleteAuthor(int id)
        {
            if (!_repository.AuthorExists(id))
            {
                return ServiceResult.NotFound("Author was not found.");
            }

            if (_repository.GetBooks().Any(b => b.AuthorID == id))
            {
                return ServiceResult.BadRequest("Author cannot be deleted while books reference it.");
            }

            _repository.DeleteAuthor(id);
            return ServiceResult.Success();
        }

        public IReadOnlyCollection<Book> GetBooks()
        {
            return _repository.GetBooks();
        }

        public Book? GetBook(int id)
        {
            return _repository.GetBook(id);
        }

        public ServiceResult<Book> CreateBook(Book book)
        {
            if (book.BookID > 0 && _repository.BookExists(book.BookID))
            {
                return ServiceResult<Book>.BadRequest("A book with this ID already exists.");
            }

            if (!_repository.AuthorExists(book.AuthorID))
            {
                return ServiceResult<Book>.BadRequest("The selected author does not exist.");
            }

            TrimBook(book);
            return ServiceResult<Book>.Success(_repository.AddBook(book));
        }

        public ServiceResult UpdateBook(int id, Book book)
        {
            if (!IsMatchingId(id, book.BookID))
            {
                return ServiceResult.BadRequest("The route ID and bookID value do not match.");
            }

            if (!_repository.BookExists(id))
            {
                return ServiceResult.NotFound("Book was not found.");
            }

            if (!_repository.AuthorExists(book.AuthorID))
            {
                return ServiceResult.BadRequest("The selected author does not exist.");
            }

            book.BookID = id;
            TrimBook(book);
            _repository.UpdateBook(book);
            return ServiceResult.Success();
        }

        public ServiceResult DeleteBook(int id)
        {
            if (!_repository.BookExists(id))
            {
                return ServiceResult.NotFound("Book was not found.");
            }

            _repository.DeleteBook(id);
            return ServiceResult.Success();
        }

        public IReadOnlyCollection<User> GetUsers()
        {
            return _repository.GetUsers();
        }

        public User? GetUser(int id)
        {
            return _repository.GetUser(id);
        }

        public ServiceResult<User> CreateUser(User user)
        {
            user.RentedBookIDs ??= new List<int>();

            if (user.UserID > 0 && _repository.UserExists(user.UserID))
            {
                return ServiceResult<User>.BadRequest("A user with this ID already exists.");
            }

            var invalidBookId = user.RentedBookIDs.FirstOrDefault(bookId => !_repository.BookExists(bookId));
            if (user.RentedBookIDs.Any(bookId => !_repository.BookExists(bookId)))
            {
                return ServiceResult<User>.BadRequest($"Book ID {invalidBookId} does not exist.");
            }

            TrimUser(user);
            return ServiceResult<User>.Success(_repository.AddUser(user));
        }

        public ServiceResult UpdateUser(int id, User user)
        {
            user.RentedBookIDs ??= new List<int>();

            if (!IsMatchingId(id, user.UserID))
            {
                return ServiceResult.BadRequest("The route ID and userID value do not match.");
            }

            if (!_repository.UserExists(id))
            {
                return ServiceResult.NotFound("User was not found.");
            }

            var invalidBookId = user.RentedBookIDs.FirstOrDefault(bookId => !_repository.BookExists(bookId));
            if (user.RentedBookIDs.Any(bookId => !_repository.BookExists(bookId)))
            {
                return ServiceResult.BadRequest($"Book ID {invalidBookId} does not exist.");
            }

            user.UserID = id;
            TrimUser(user);
            _repository.UpdateUser(user);
            return ServiceResult.Success();
        }

        public ServiceResult DeleteUser(int id)
        {
            if (!_repository.UserExists(id))
            {
                return ServiceResult.NotFound("User was not found.");
            }

            _repository.DeleteUser(id);
            return ServiceResult.Success();
        }

        public ServiceResult<User> RentBook(int userId, int bookId)
        {
            var user = _repository.GetUser(userId);
            if (user is null)
            {
                return ServiceResult<User>.NotFound("User was not found.");
            }

            if (!_repository.BookExists(bookId))
            {
                return ServiceResult<User>.NotFound("Book was not found.");
            }

            if (user.RentedBookIDs.Contains(bookId))
            {
                return ServiceResult<User>.BadRequest("The user has already rented this book.");
            }

            _repository.RentBook(userId, bookId);
            return ServiceResult<User>.Success(_repository.GetUser(userId)!);
        }

        public ServiceResult<User> ReturnBook(int userId, int bookId)
        {
            var user = _repository.GetUser(userId);
            if (user is null)
            {
                return ServiceResult<User>.NotFound("User was not found.");
            }

            if (!_repository.BookExists(bookId))
            {
                return ServiceResult<User>.NotFound("Book was not found.");
            }

            if (!user.RentedBookIDs.Contains(bookId))
            {
                return ServiceResult<User>.BadRequest("The user has not rented this book.");
            }

            _repository.ReturnBook(userId, bookId);
            return ServiceResult<User>.Success(_repository.GetUser(userId)!);
        }

        private static bool IsMatchingId(int routeId, int bodyId)
        {
            return bodyId == 0 || routeId == bodyId;
        }

        private static void TrimAuthor(Author author)
        {
            author.AuthorName = author.AuthorName.Trim();
            author.AuthorInfo = author.AuthorInfo.Trim();
        }

        private static void TrimBook(Book book)
        {
            book.Title = book.Title.Trim();
            book.ImageUrl = book.ImageUrl.Trim();
        }

        private static void TrimUser(User user)
        {
            user.Name = user.Name.Trim();
            user.Email = user.Email.Trim();
        }
    }
}
