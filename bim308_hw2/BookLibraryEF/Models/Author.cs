namespace BookLibraryEF.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorInfo { get; set; } = string.Empty;

        // Navigation Property: One Author -> Many Books
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
