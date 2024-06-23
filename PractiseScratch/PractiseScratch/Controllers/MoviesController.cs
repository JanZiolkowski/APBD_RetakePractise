using Microsoft.AspNetCore.Mvc;
using PractiseScratch.Exceptions;
using PractiseScratch.Services;
using PractiseScratch.Services.Interfaces;

namespace PractiseScratch.Controllers;

[Route("api/movies")]
[ApiController]
public class MoviesController : ControllerBase
{
    private IMoviesService _moviesService;

    public MoviesController(IMoviesService moviesService)
    {
        _moviesService = moviesService;
    }
    [HttpGet]
    public async Task<IActionResult> RetrieveMovies([FromQuery] string? ageRating, [FromQuery] DateTime releaseDate)
    {
        try
        {
            var movies = await _moviesService.GetMoviesAsync(ageRating,releaseDate);
            return Ok(movies);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            //todo:Return
            return BadRequest(e.Message);
        }

    }
}