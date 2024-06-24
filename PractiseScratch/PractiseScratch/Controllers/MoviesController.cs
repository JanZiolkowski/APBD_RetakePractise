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
    public async Task<IActionResult> RetrieveMovies([FromQuery] string? ageRating, [FromQuery] DateTime? releaseDate)
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

    [HttpDelete("delete/{idMovie:int}")]
    public async Task<IActionResult> DeleteMovie(int idMovie)
    {
        try
        {
            await _moviesService.DeleteMovieAsync(idMovie);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return Conflict(e.Message);
        }
    }
    // [HttpPost("newMovie")]
    // public async Task<IActionResult> AddMovie()
    // {
    //     try
    //     {
    //         
    //     }
    //     catch (NotFoundException exception)
    //     {
    //         return NotFound(exception.Message);
    //     }
    //     catch (BadRequestException exception)
    //     {
    //         return BadRequest(exception.Message);
    //     }
    //     catch (Exception exception)
    //     {
    //         return Conflict(exception.Message);
    //     }
    // }

}