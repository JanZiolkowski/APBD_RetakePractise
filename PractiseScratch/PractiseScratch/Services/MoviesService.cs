using PractiseScratch.Dtos.Response;
using PractiseScratch.Exceptions;
using PractiseScratch.Repositories.Interfaces;
using PractiseScratch.Services.Interfaces;

namespace PractiseScratch.Services;

public class MoviesService : IMoviesService
{
    private IMoviesRepository _moviesRepository;

    public MoviesService(IMoviesRepository moviesRepository)
    {
        _moviesRepository = moviesRepository;
    }

    public async Task<ICollection<MovieDTO>> GetMoviesAsync(string? ageRating, DateTime? releaseDate)
    {
        //First I have to retrieve list of Movies from database:
        var movies = await _moviesRepository.GetMoviesWithIncludeAsync();
        if (movies.Count == 0)
        {
            throw new NotFoundException("No movie has been found in Database!");
        }
        
        ICollection<MovieDTO> newMovies = movies.Select(x => new MovieDTO()
        {
            Name = x.Name,
            AgeRating = x.AgeRating.Name,
            ReleaseDate = x.ReleaseDate,
            Actors = x.ActorMovies.Select(x => new ActorDTO()
            {
                Name = x.Actor.Name,
                Surname = x.Actor.Surname,
                Nickname = x.Actor.Nickname,
                CharacterName = x.CharacterName
            }).ToList()
        }).OrderByDescending(x => x.ReleaseDate).ToList();
        
        newMovies = FilterMovies(newMovies,ageRating,releaseDate);
        return newMovies;
    }

    private ICollection<MovieDTO> FilterMovies(ICollection<MovieDTO> movieDtos,string? ageRating, DateTime? releaseDate)
    {
        if (ageRating == null && releaseDate == null)
        {
            return movieDtos;
        }

        if (ageRating != null && releaseDate == null)
        {
            return movieDtos.Where(x => x.AgeRating.Equals(ageRating)).ToList();
        }

        if (ageRating == null && releaseDate != null)
        {
            return movieDtos.Where(x => x.ReleaseDate == releaseDate).ToList();
        }

        return movieDtos.Where(x => x.ReleaseDate == releaseDate && x.AgeRating.Equals(ageRating)).ToList();

    }

    public async Task DeleteMovieAsync(int idMovie)
    {
        throw new NotImplementedException();
    }
}