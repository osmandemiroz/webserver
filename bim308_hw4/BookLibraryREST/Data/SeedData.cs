using BookLibraryREST.Models;
using System.Text.Json;

namespace BookLibraryREST.Data
{
    public static class SeedData
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public static List<Author> CreateAuthors()
        {
            try
            {
                var json = _httpClient.GetStringAsync("https://raw.githubusercontent.com/emindk/JSON_Files/main/authors.json").Result;
                return JsonSerializer.Deserialize<List<Author>>(json, _jsonOptions) ?? new List<Author>();
            }
            catch
            {
                return new List<Author>();
            }
        }

        public static List<Book> CreateBooks()
        {
            try
            {
                var json = _httpClient.GetStringAsync("https://raw.githubusercontent.com/emindk/JSON_Files/main/books.json").Result;
                return JsonSerializer.Deserialize<List<Book>>(json, _jsonOptions) ?? new List<Book>();
            }
            catch
            {
                return new List<Book>();
            }
        }

        public static List<User> CreateUsers()
        {
            try
            {
                var json = _httpClient.GetStringAsync("https://raw.githubusercontent.com/emindk/JSON_Files/main/users.json").Result;
                return JsonSerializer.Deserialize<List<User>>(json, _jsonOptions) ?? new List<User>();
            }
            catch
            {
                return new List<User>();
            }
        }
    }
}
