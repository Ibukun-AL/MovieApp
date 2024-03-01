using System.Net.Http;
using System.Threading.Tasks;

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

        var response = await _httpClient.GetFromJsonAsync<Movie>(url);
        return response;
    }

    public async Task<Movie> GetMovieDetailsAsync(string imdbId)
    {
        var apiKey = "17b6e338"; // Replace with your actual API key
        var url = $"https://www.omdbapi.com/?apikey={apiKey}&i={imdbId}";

        var response = await _httpClient.GetFromJsonAsync<Movie>(url);
        return response;
    }
}

public class Movie
{
    public string? Title { get; set; }
    public string? Year { get; set; }

    public string? Director{ get; set; }

    public string? ImdbID{ get; set; }
    public string? Plot{ get; set; }

    // Add other properties as needed
}
