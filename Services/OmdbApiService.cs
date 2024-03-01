using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

public class OmdbApiService
{
    private readonly HttpClient _httpClient;

    public OmdbApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Movie> GetMovieAsync(string title)
    {
        var apiKey = "17b6e338"; // Replace with your actual API key
        var url = $"https://www.omdbapi.com/?apikey={apiKey}&t={title}";

        var responseString = await _httpClient.GetStringAsync(url);
        var movie = JsonSerializer.Deserialize<Movie>(responseString);

        return movie;
    }

    public async Task<Movie> GetMovieDetailsAsync(string imdbId)
    {
        var apiKey = "17b6e338"; // Replace with your actual API key
        var url = $"https://www.omdbapi.com/?apikey={apiKey}&i={imdbId}";

        var responseString = await _httpClient.GetStringAsync(url);
        var movie = JsonSerializer.Deserialize<Movie>(responseString);

        return movie;
    }
}

public class Movie
{
    public string? Title { get; set; }
    public string? Year { get; set; }

    public string? imdbRating{ get; set; }

    public string? imdbID{ get; set; }
    public string? Plot{ get; set; }

    public string? Poster { get; set; }

    // Add other properties as needed
}
