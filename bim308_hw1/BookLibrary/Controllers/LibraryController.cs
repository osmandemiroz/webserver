using Microsoft.AspNetCore.Mvc;
using BookLibrary.Models;

namespace BookLibrary.Controllers
{
    public class LibraryController : Controller
    {
        public IActionResult Index()
        {
            var books = new List<Book>
            {
                new Book
                {
                    BookID = 1,
                    Title = "The Great Gatsby",
                    Director = "F. Scott Fitzgerald",
                    Stars = new string[] { "★", "★", "★", "★", "★" },
                    ReleaseYear = 1925,
                    ImageUrl = "https://m.media-amazon.com/images/I/71FTb9X6wsL._SY466_.jpg",
                    Price = 12.99
                },
                new Book
                {
                    BookID = 2,
                    Title = "To Kill a Mockingbird",
                    Director = "Harper Lee",
                    Stars = new string[] { "★", "★", "★", "★", "★" },
                    ReleaseYear = 1960,
                    ImageUrl = "https://m.media-amazon.com/images/I/81gepf1eMqL._SY466_.jpg",
                    Price = 14.99
                },
                new Book
                {
                    BookID = 3,
                    Title = "1984",
                    Director = "George Orwell",
                    Stars = new string[] { "★", "★", "★", "★", "☆" },
                    ReleaseYear = 1949,
                    ImageUrl = "https://m.media-amazon.com/images/I/71kxa1-0mfL._SY466_.jpg",
                    Price = 13.99
                },
                new Book
                {
                    BookID = 4,
                    Title = "Pride and Prejudice",
                    Director = "Jane Austen",
                    Stars = new string[] { "★", "★", "★", "★", "★" },
                    ReleaseYear = 1813,
                    ImageUrl = "https://m.media-amazon.com/images/I/71Q1tPupKjL._SY466_.jpg",
                    Price = 11.99
                },
                new Book
                {
                    BookID = 5,
                    Title = "The Catcher in the Rye",
                    Director = "J.D. Salinger",
                    Stars = new string[] { "★", "★", "★", "★", "☆" },
                    ReleaseYear = 1951,
                    ImageUrl = "https://m.media-amazon.com/images/I/8125BDk3l9L._SY466_.jpg",
                    Price = 10.99
                },
                new Book
                {
                    BookID = 6,
                    Title = "Nutuk",
                    Director = "Mustafa Kemal Atatürk",
                    Stars = new string[] { "★", "★", "★", "★", "★" },
                    ReleaseYear = 1927,
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR8VkBKk4MXwH0UL8xRRt7mlVVo7XLv94ofiw&s",
                    Price = 19.39
                }
            };

            return View(books);
        }
    }
}
