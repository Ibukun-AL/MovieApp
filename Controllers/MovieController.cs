using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Microsoft.Extensions.Logging;

namespace MovieApp3.Controllers;

[ApiController]
[Route("[controller]")]

public class MovieController : ControllerBase
{
    private readonly OmdbApiService _omdbApiService;
     private readonly ILogger<MovieController> _logger;
 
 public MovieController(OmdbApiService omdbApiService, ILogger<MovieController> logger)
    {
        _omdbApiService = omdbApiService;
        _logger = logger;
    }
[HttpGet]
 [HttpGet("{title}")]
    public async Task<IActionResult> GetMovie(string title)
    {
        var movie = await _omdbApiService.GetMovieAsync(title);
        _logger.LogInformation("Received movie data: {@Movie}", movie.ImdbID);
        return Ok(movie);
    }

     [HttpGet("{title}/{imdbId}")]
    public async Task<IActionResult> GetMovieDetails(string imdbId)
    {
        var movieDetails = await _omdbApiService.GetMovieDetailsAsync(imdbId);
        _logger.LogInformation("Received movie details: {@MovieDetails}", movieDetails.ImdbID);
        return Ok(movieDetails);
    }
 }
