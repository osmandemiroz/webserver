using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookLibraryEF.Data;
using BookLibraryEF.Models;

namespace BookLibraryEF.Controllers
{
    public class LibraryController : Controller
    {
        private readonly LibraryContext _context;

        public LibraryController(LibraryContext context)
        {
            _context = context;
        }

        // GET: /Library
        public IActionResult Index()
        {
            var books = _context.Books.Include(b => b.Author).ToList();
            return View(books);
        }

        // GET: /Library/AddBook
        public IActionResult AddBook()
        {
            ViewBag.Authors = new SelectList(_context.Authors, "AuthorID", "AuthorName");
            return View();
        }

        // POST: /Library/AddBook
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Authors = new SelectList(_context.Authors, "AuthorID", "AuthorName", book.AuthorID);
            return View(book);
        }

        // GET: /Library/AddUser
        public IActionResult AddUser()
        {
            return View();
        }

        // POST: /Library/AddUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: /Library/RentBook
        public IActionResult RentBook()
        {
            ViewBag.Users = new SelectList(_context.Users, "UserID", "Name");
            ViewBag.Books = new SelectList(_context.Books, "BookID", "Title");
            return View();
        }

        // POST: /Library/RentBook
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RentBook(int userId, int bookId)
        {
            var user = _context.Users.Include(u => u.Books).FirstOrDefault(u => u.UserID == userId);
            var book = _context.Books.FirstOrDefault(b => b.BookID == bookId);

            if (user != null && book != null)
            {
                if (!user.Books.Any(b => b.BookID == bookId))
                {
                    user.Books.Add(book);
                    _context.SaveChanges();
                }
                ViewBag.Message = $"{user.Name} has successfully rented \"{book.Title}\"!";
            }
            else
            {
                ViewBag.Message = "Please select a valid user and book.";
            }

            ViewBag.Users = new SelectList(_context.Users, "UserID", "Name");
            ViewBag.Books = new SelectList(_context.Books, "BookID", "Title");
            return View();
        }
    }
}
