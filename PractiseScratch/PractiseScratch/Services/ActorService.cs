using PractiseScratch.Dtos.Request;
using PractiseScratch.Exceptions;
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
        bool exists = await _moviesRepository.MovieExists(mapDto.IdMovie);
        if (!exists)
        {
            throw new NotFoundException("Movie with given ID has not been found in Database!");
        }

        using var transaction =await _actorMovieRepository.BeginTransactionAsync();
        try
        {
            int idActor = mapDto.IdActor;
            var actor = await _actorRepository.GetActorAsync(idActor);
            if (actor == null)
            {
                idActor = await _actorRepository.CreateActorAsync(mapDto);
            }

            if (await _actorMovieRepository.CheckIfThereIsAssignment(idActor))
            {
                throw new AssignmentException("There is already existingassignment for the Actor!");
            }
            else
            {
               await _actorMovieRepository.AssignActor(mapDto, idActor);
               await transaction.CommitAsync();
            }
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}