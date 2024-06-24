using PractiseScratch.Dtos.Request;
using PractiseScratch.Dtos.Response;
using PractiseScratch.Entities;
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

    public async Task<ICollection<Actor2DTO>> GetListOfAllActors(string? name, string? surname)
    {
        ICollection<Actor> actors = await _actorRepository.GetActorsAsync();
        if (actors.Count == 0)
        {
            throw new NotFoundException("No actors has been found in the database!");
        }

        ICollection<Actor2DTO> unfilteredActors = actors.Select(x => new Actor2DTO()
        {
            IdActor = x.IdActor,
            Name = x.Name,
            Surname = x.Surname,
            Nickname = x.Nickname,
            Movies = x.ActorMovies.Select(x => new Movie2DTO()
            {
                NameOfMovie = x.Movie.Name,
                AgeRating = x.Movie.AgeRating.Name,
                Role = x.CharacterName
            }).ToList()
        }).OrderBy(x=>x.Name).ToList();

        if (name == null && surname == null)
        {
            return unfilteredActors;
        }
        
        if (name != null && surname == null)
        {
            return unfilteredActors.Where(x => x.Name.Equals(name) ).ToList();
        }
        if (name == null && surname != null)
        {
            return unfilteredActors.Where(x => x.Surname.Equals(surname)).ToList();
        }

        return unfilteredActors.Where(x => x.Name.Equals(name) && x.Surname.Equals(surname)).ToList();
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

    public async Task<int> AddActorAsync(NewActorDTO newActorDto)
    {
        if (newActorDto.Name.Length > 30)
        {
            throw new BadRequestException("The Name exceeds the limit of 30 characters!");
        }

        if (newActorDto.Surname.Length > 30)
        {
            throw new BadRequestException("The Surname exceeds the limit of 30 characters!");
        }
        if (newActorDto.NickName != null && newActorDto.NickName.Length > 30)
        {
            throw new BadRequestException("The Nickname exceeds the limit of 30 characters!");
        }
        

        return await _actorRepository.CreateActorAsync(newActorDto);
    }

    public async Task RemoveActorAsync(int idActor)
    {
        Actor? actor = await _actorRepository.GetActorAsync(idActor);
        
        if (actor == null)
        {
            throw new NotFoundException("No actor was found in database with such an id");
        }
        
        await _actorRepository.RemoveActorAsync(actor);
        
    }

    public async Task ChangeActor(int idActor, ActorUpdateDTO actorUpdateDto)
    {
        Actor? actor = await _actorRepository.GetActorAsync(idActor);
        
        if (actor == null)
        {
            throw new NotFoundException("No actor was found in database with such an id!");
        }
        
        await _actorRepository.ModifyActorAsync(actor,actorUpdateDto);
    }
}