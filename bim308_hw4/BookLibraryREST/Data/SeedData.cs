using BookLibraryREST.Models;

namespace BookLibraryREST.Data
{
    public static class SeedData
    {
        public static List<Author> CreateAuthors()
        {
            return new List<Author>
            {
                new Author { AuthorID = 1, AuthorName = "George Orwell", AuthorInfo = "English novelist and essayist" },
                new Author { AuthorID = 2, AuthorName = "J.K. Rowling", AuthorInfo = "British author, Harry Potter series" },
                new Author { AuthorID = 3, AuthorName = "F. Scott Fitzgerald", AuthorInfo = "American novelist and short story writer" },
                new Author { AuthorID = 4, AuthorName = "Harper Lee", AuthorInfo = "American novelist known for To Kill a Mockingbird" },
                new Author { AuthorID = 5, AuthorName = "Jane Austen", AuthorInfo = "English novelist known for social commentary" }
            };
        }

        public static List<Book> CreateBooks()
        {
            return new List<Book>
            {
                new Book { BookID = 1, Title = "1984", ReleaseYear = 1949, Price = 120, ImageUrl = "https://m.media-amazon.com/images/I/71kxa1-0mfL._SY466_.jpg", AuthorID = 1 },
                new Book { BookID = 2, Title = "Animal Farm", ReleaseYear = 1945, Price = 90, ImageUrl = "https://m.media-amazon.com/images/I/91LUbAcpACL._SY466_.jpg", AuthorID = 1 },
                new Book { BookID = 3, Title = "Harry Potter and the Philosopher's Stone", ReleaseYear = 1997, Price = 150, ImageUrl = "https://m.media-amazon.com/images/I/81YOuOGFCJL._SY466_.jpg", AuthorID = 2 },
                new Book { BookID = 4, Title = "The Great Gatsby", ReleaseYear = 1925, Price = 110, ImageUrl = "https://m.media-amazon.com/images/I/71FTb9X6wsL._SY466_.jpg", AuthorID = 3 },
                new Book { BookID = 5, Title = "To Kill a Mockingbird", ReleaseYear = 1960, Price = 130, ImageUrl = "https://m.media-amazon.com/images/I/81gepf1eMqL._SY466_.jpg", AuthorID = 4 },
                new Book { BookID = 6, Title = "Pride and Prejudice", ReleaseYear = 1813, Price = 100, ImageUrl = "https://m.media-amazon.com/images/I/71Q1tPupKjL._SY466_.jpg", AuthorID = 5 }
            };
        }

        public static List<User> CreateUsers()
        {
            return new List<User>
            {
                new User { UserID = 1, Name = "Emin Demirkiran", Email = "emin@mail.com", RentedBookIDs = new List<int> { 1, 3, 5 } },
                new User { UserID = 2, Name = "Elif Sahin", Email = "elif@mail.com", RentedBookIDs = new List<int> { 2, 6 } },
                new User { UserID = 3, Name = "Ali Yilmaz", Email = "ali.yilmaz@example.com", RentedBookIDs = new List<int>() }
            };
        }
    }
}
