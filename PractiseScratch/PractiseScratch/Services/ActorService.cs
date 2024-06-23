using PractiseScratch.Dtos.Request;
using PractiseScratch.Repositories.Interfaces;
using PractiseScratch.Services.Interfaces;

namespace PractiseScratch.Services;

public class ActorService : IActorService
{
    private IActorMovieRepository _actorMovieRepository;
    private IMoviesRepository _moviesRepository;
    private IActorRepository _actorRepository;

    public ActorService(IActorMovieRepository actorMovieRepository, IMoviesRepository moviesRepository, IActorRepository actorRepository)
    {
        _actorMovieRepository = actorMovieRepository;
        _moviesRepository = moviesRepository;
        _actorRepository = actorRepository;
    }

    public async Task AssignActorToMovie(MapDTO mapDto)
    {
        //CHECK FOR THE ID MOVIE IN DATABASE
    }
}