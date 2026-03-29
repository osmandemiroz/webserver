namespace BookLibraryEF.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

        // Foreign Key
        public int AuthorID { get; set; }

        // Navigation Properties
        public Author? Author { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
