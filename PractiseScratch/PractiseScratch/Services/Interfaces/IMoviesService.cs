using PractiseScratch.Dtos.Response;

namespace PractiseScratch.Services.Interfaces;

public interface IMoviesService
{
    Task<ICollection<MovieDTO>> GetMoviesAsync(string? ageRating, DateTime? releaseDate);
}