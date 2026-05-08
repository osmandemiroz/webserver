using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookLibraryREST.Models
{
    public class Book
    {
        [JsonPropertyName("bookID")]
        public int BookID { get; set; }

        [Required]
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [Range(1, 3000)]
        [JsonPropertyName("releaseYear")]
        public int ReleaseYear { get; set; }

        [Range(0, double.MaxValue)]
        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; } = string.Empty;

        [JsonPropertyName("authorID")]
        public int AuthorID { get; set; }
    }
}
