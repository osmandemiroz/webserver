namespace BookLibraryEF.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Navigation Property: Many Users <-> Many Books
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
