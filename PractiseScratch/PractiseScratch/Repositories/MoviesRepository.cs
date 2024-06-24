using Microsoft.EntityFrameworkCore;
using PractiseScratch.DbContext;
using PractiseScratch.Entities;
using PractiseScratch.Repositories.Interfaces;

namespace PractiseScratch.Repositories;

public class MoviesRepository : IMoviesRepository
{
    private CinemaContext _cinemaContext;

    public MoviesRepository(CinemaContext cinemaContext)
    {
        _cinemaContext = cinemaContext;
    }

    public async Task<ICollection<Movie>> GetMoviesWithIncludeAsync()
    {
        return await _cinemaContext.Movies.Include(x=>x.AgeRating).Include(x => x.ActorMovies).ThenInclude(x => x.Actor).ToListAsync();
    }

    public async Task<bool> MovieExists(int idMovie)
    {
        var count = await _cinemaContext.Movies.Where(x => x.IdMovie == idMovie).CountAsync();
        if (count == 0)
        {
            return false;
        }

        return true;
    }

    public async Task<Movie?> GetMovieAsync(int idMovie)
    {
        return await _cinemaContext.Movies.Include(x=>x.ActorMovies).FirstOrDefaultAsync(x => x.IdMovie == idMovie);
    }

    public async Task DeleteMovie(Movie movie)
    {
        _cinemaContext.Remove(movie);
        await _cinemaContext.SaveChangesAsync();
    }
}