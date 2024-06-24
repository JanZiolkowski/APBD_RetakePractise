using PractiseScratch.DbContext;
using PractiseScratch.Entities;

namespace PractiseScratch.Repositories.Interfaces;

public interface IMoviesRepository
{
    Task<ICollection<Movie>> GetMoviesWithIncludeAsync();
    Task<Movie> GetMovieAsync(int idMovie);

    Task<bool> MovieExists(int idMovie);
    Task DeleteMovie(Movie movie);
    
}