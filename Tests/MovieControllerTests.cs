using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MovieApp3.Controllers;
using System.Threading.Tasks;
using Xunit;

namespace MovieApp3.Tests
{
    public class MovieControllerTests
    {
        private readonly Mock<OmdbApiService> _mockOmdbApiService;
        private readonly Mock<ILogger<MovieController>> _mockLogger;

        public MovieControllerTests()
        {
            _mockOmdbApiService = new Mock<OmdbApiService>();
            _mockLogger = new Mock<ILogger<MovieController>>();
        }

        [Fact]
        public async Task GetMovie_ShouldReturnOk_WhenMovieFound()
        {
            // Arrange
            var expectedTitle = "The Shawshank Redemption";
            var expectedMovie = new Movie { Title = expectedTitle };
            _mockOmdbApiService.Setup(service => service.GetMovieAsync(expectedTitle))
                .Returns(Task.FromResult(expectedMovie));

            var controller = new MovieController(_mockOmdbApiService.Object, _mockLogger.Object);

            // Act
            var result = await controller.GetMovie(expectedTitle);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(expectedMovie, okResult.Value);
            _mockOmdbApiService.Verify(service => service.GetMovieAsync(expectedTitle), Times.Once);
        }

        [Fact]
        public async Task GetMovie_ShouldReturnNotFound_WhenMovieNotFound()
        {
            // Arrange
            var expectedTitle = "Non-existent Movie";
            _mockOmdbApiService.Setup(service => service.GetMovieAsync(expectedTitle))
                .Returns(Task.FromResult<Movie>(null));

            var controller = new MovieController(_mockOmdbApiService.Object, _mockLogger.Object);

            // Act
            var result = await controller.GetMovie(expectedTitle);

            // Assert
            Assert.IsType<NotFoundResult>(result);
            _mockOmdbApiService.Verify(service => service.GetMovieAsync(expectedTitle), Times.Once);
        }

        [Fact]
        public async Task GetMovieDetails_ShouldReturnOk_WhenDetailsFound()
        {
            // Arrange
            var expectedImdbId = "tt0111161";
            var expectedDetails = new Movie { Title = "The Shawshank Redemption" };
            _mockOmdbApiService.Setup(service => service.GetMovieDetailsAsync(expectedImdbId))
                .Returns(Task.FromResult(expectedDetails));

            var controller = new MovieController(_mockOmdbApiService.Object, _mockLogger.Object);

            // Act
            var result = await controller.GetMovieDetails(expectedImdbId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(expectedDetails, okResult.Value);
            _mockOmdbApiService.Verify(service => service.GetMovieDetailsAsync(expectedImdbId), Times.Once);
        }

        [Fact]
        public async Task GetMovieDetails_ShouldReturnNotFound_WhenDetailsNotFound()
        {
            // Arrange
            var expectedImdbId = "InvalidImdbId";
            _mockOmdbApiService.Setup(service => service.GetMovieDetailsAsync(expectedImdbId))
                .Returns(Task.FromResult<Movie>(null));

            var controller = new MovieController(_mockOmdbApiService.Object, _mockLogger.Object);

            // Act
            var result = await controller.GetMovieDetails(expectedImdbId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
            _mockOmdbApiService.Verify(service => service.GetMovieDetailsAsync(expectedImdbId), Times.Once);
        }
    }
}
