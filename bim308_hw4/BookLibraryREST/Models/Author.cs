using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookLibraryREST.Models
{
    public class Author
    {
        [JsonPropertyName("authorID")]
        public int AuthorID { get; set; }

        [Required]
        [JsonPropertyName("authorName")]
        public string AuthorName { get; set; } = string.Empty;

        [Required]
        [JsonPropertyName("authorInfo")]
        public string AuthorInfo { get; set; } = string.Empty;
    }
}
