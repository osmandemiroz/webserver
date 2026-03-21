namespace BookLibrary.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string[] Stars { get; set; }
        public int ReleaseYear { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
    }
}
