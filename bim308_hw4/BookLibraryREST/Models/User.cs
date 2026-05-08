using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookLibraryREST.Models
{
    public class User
    {
        [JsonPropertyName("userID")]
        public int UserID { get; set; }

        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [JsonPropertyName("rentedBookIDs")]
        public List<int> RentedBookIDs { get; set; } = new List<int>();
    }
}
