using Microsoft.EntityFrameworkCore;
using BookLibraryEF.Models;

namespace BookLibraryEF.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One-to-Many: Author -> Books
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorID);

            // Many-to-Many: Users <-> Books
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Users)
                .WithMany(u => u.Books)
                .UsingEntity(j => j.ToTable("BookUser"));

            // Seed Authors
            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorID = 1, AuthorName = "F. Scott Fitzgerald", AuthorInfo = "American novelist, widely regarded as one of the greatest writers of the 20th century." },
                new Author { AuthorID = 2, AuthorName = "Harper Lee", AuthorInfo = "American novelist best known for her Pulitzer Prize-winning novel." },
                new Author { AuthorID = 3, AuthorName = "George Orwell", AuthorInfo = "English novelist and essayist, known for his sharp criticism of political oppression." },
                new Author { AuthorID = 4, AuthorName = "Jane Austen", AuthorInfo = "English novelist known for her commentary on the British landed gentry." },
                new Author { AuthorID = 5, AuthorName = "J.D. Salinger", AuthorInfo = "American writer known for his widely-read novel about teenage angst." },
                new Author { AuthorID = 6, AuthorName = "Mustafa Kemal Ataturk", AuthorInfo = "Founder of the Republic of Turkey and its first President." }
            );

            // Seed Books
            modelBuilder.Entity<Book>().HasData(
                new Book { BookID = 1, Title = "The Great Gatsby", ReleaseYear = 1925, Price = 12.99, ImageUrl = "https://m.media-amazon.com/images/I/71FTb9X6wsL._SY466_.jpg", AuthorID = 1 },
                new Book { BookID = 2, Title = "To Kill a Mockingbird", ReleaseYear = 1960, Price = 14.99, ImageUrl = "https://m.media-amazon.com/images/I/81gepf1eMqL._SY466_.jpg", AuthorID = 2 },
                new Book { BookID = 3, Title = "1984", ReleaseYear = 1949, Price = 13.99, ImageUrl = "https://m.media-amazon.com/images/I/71kxa1-0mfL._SY466_.jpg", AuthorID = 3 },
                new Book { BookID = 4, Title = "Pride and Prejudice", ReleaseYear = 1813, Price = 11.99, ImageUrl = "https://m.media-amazon.com/images/I/71Q1tPupKjL._SY466_.jpg", AuthorID = 4 },
                new Book { BookID = 5, Title = "The Catcher in the Rye", ReleaseYear = 1951, Price = 10.99, ImageUrl = "https://m.media-amazon.com/images/I/8125BDk3l9L._SY466_.jpg", AuthorID = 5 },
                new Book { BookID = 6, Title = "Nutuk", ReleaseYear = 1927, Price = 19.39, ImageUrl = "https://m.media-amazon.com/images/I/51KMDtNclHL._SY466_.jpg", AuthorID = 6 }
            );

            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User { UserID = 1, Name = "Ali Yilmaz", Email = "ali.yilmaz@example.com" },
                new User { UserID = 2, Name = "Ayse Demir", Email = "ayse.demir@example.com" }
            );
        }
    }
}
