using BookLibraryREST.Data;
using BookLibraryREST.Models;

namespace BookLibraryREST.Repositories
{
    public class InMemoryLibraryRepository : ILibraryRepository
    {
        private readonly object _syncRoot = new object();
        private readonly List<Author> _authors = SeedData.CreateAuthors();
        private readonly List<Book> _books = SeedData.CreateBooks();
        private readonly List<User> _users = SeedData.CreateUsers();

        public IReadOnlyCollection<Author> GetAuthors()
        {
            lock (_syncRoot)
            {
                return _authors.Select(Clone).ToList();
            }
        }

        public Author? GetAuthor(int id)
        {
            lock (_syncRoot)
            {
                var author = _authors.FirstOrDefault(a => a.AuthorID == id);
                return author is null ? null : Clone(author);
            }
        }

        public Author AddAuthor(Author author)
        {
            lock (_syncRoot)
            {
                var created = Clone(author);
                created.AuthorID = created.AuthorID == 0 ? NextAuthorId() : created.AuthorID;
                _authors.Add(created);
                return Clone(created);
            }
        }

        public bool UpdateAuthor(Author author)
        {
            lock (_syncRoot)
            {
                var index = _authors.FindIndex(a => a.AuthorID == author.AuthorID);
                if (index < 0)
                {
                    return false;
                }

                _authors[index] = Clone(author);
                return true;
            }
        }

        public bool DeleteAuthor(int id)
        {
            lock (_syncRoot)
            {
                var author = _authors.FirstOrDefault(a => a.AuthorID == id);
                return author is not null && _authors.Remove(author);
            }
        }

        public bool AuthorExists(int id)
        {
            lock (_syncRoot)
            {
                return _authors.Any(a => a.AuthorID == id);
            }
        }

        public IReadOnlyCollection<Book> GetBooks()
        {
            lock (_syncRoot)
            {
                return _books.Select(Clone).ToList();
            }
        }

        public Book? GetBook(int id)
        {
            lock (_syncRoot)
            {
                var book = _books.FirstOrDefault(b => b.BookID == id);
                return book is null ? null : Clone(book);
            }
        }

        public Book AddBook(Book book)
        {
            lock (_syncRoot)
            {
                var created = Clone(book);
                created.BookID = created.BookID == 0 ? NextBookId() : created.BookID;
                _books.Add(created);
                return Clone(created);
            }
        }

        public bool UpdateBook(Book book)
        {
            lock (_syncRoot)
            {
                var index = _books.FindIndex(b => b.BookID == book.BookID);
                if (index < 0)
                {
                    return false;
                }

                _books[index] = Clone(book);
                return true;
            }
        }

        public bool DeleteBook(int id)
        {
            lock (_syncRoot)
            {
                var book = _books.FirstOrDefault(b => b.BookID == id);
                if (book is null)
                {
                    return false;
                }

                foreach (var user in _users)
                {
                    user.RentedBookIDs.Remove(id);
                }

                return _books.Remove(book);
            }
        }

        public bool BookExists(int id)
        {
            lock (_syncRoot)
            {
                return _books.Any(b => b.BookID == id);
            }
        }

        public IReadOnlyCollection<User> GetUsers()
        {
            lock (_syncRoot)
            {
                return _users.Select(Clone).ToList();
            }
        }

        public User? GetUser(int id)
        {
            lock (_syncRoot)
            {
                var user = _users.FirstOrDefault(u => u.UserID == id);
                return user is null ? null : Clone(user);
            }
        }

        public User AddUser(User user)
        {
            lock (_syncRoot)
            {
                var created = Clone(user);
                created.UserID = created.UserID == 0 ? NextUserId() : created.UserID;
                created.RentedBookIDs = created.RentedBookIDs.Distinct().ToList();
                _users.Add(created);
                return Clone(created);
            }
        }

        public bool UpdateUser(User user)
        {
            lock (_syncRoot)
            {
                var index = _users.FindIndex(u => u.UserID == user.UserID);
                if (index < 0)
                {
                    return false;
                }

                var updated = Clone(user);
                updated.RentedBookIDs = updated.RentedBookIDs.Distinct().ToList();
                _users[index] = updated;
                return true;
            }
        }

        public bool DeleteUser(int id)
        {
            lock (_syncRoot)
            {
                var user = _users.FirstOrDefault(u => u.UserID == id);
                return user is not null && _users.Remove(user);
            }
        }

        public bool UserExists(int id)
        {
            lock (_syncRoot)
            {
                return _users.Any(u => u.UserID == id);
            }
        }

        public bool RentBook(int userId, int bookId)
        {
            lock (_syncRoot)
            {
                var user = _users.FirstOrDefault(u => u.UserID == userId);
                if (user is null || user.RentedBookIDs.Contains(bookId))
                {
                    return false;
                }

                user.RentedBookIDs.Add(bookId);
                return true;
            }
        }

        public bool ReturnBook(int userId, int bookId)
        {
            lock (_syncRoot)
            {
                var user = _users.FirstOrDefault(u => u.UserID == userId);
                return user is not null && user.RentedBookIDs.Remove(bookId);
            }
        }

        private int NextAuthorId()
        {
            return _authors.Count == 0 ? 1 : _authors.Max(a => a.AuthorID) + 1;
        }

        private int NextBookId()
        {
            return _books.Count == 0 ? 1 : _books.Max(b => b.BookID) + 1;
        }

        private int NextUserId()
        {
            return _users.Count == 0 ? 1 : _users.Max(u => u.UserID) + 1;
        }

        private static Author Clone(Author author)
        {
            return new Author
            {
                AuthorID = author.AuthorID,
                AuthorName = author.AuthorName,
                AuthorInfo = author.AuthorInfo
            };
        }

        private static Book Clone(Book book)
        {
            return new Book
            {
                BookID = book.BookID,
                Title = book.Title,
                ReleaseYear = book.ReleaseYear,
                Price = book.Price,
                ImageUrl = book.ImageUrl,
                AuthorID = book.AuthorID
            };
        }

        private static User Clone(User user)
        {
            return new User
            {
                UserID = user.UserID,
                Name = user.Name,
                Email = user.Email,
                RentedBookIDs = user.RentedBookIDs.ToList()
            };
        }
    }
}
