using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PractiseScratch.DbContext;
using PractiseScratch.Dtos.Request;
using PractiseScratch.Entities;
using PractiseScratch.Repositories.Interfaces;

namespace PractiseScratch.Repositories;

public class ActorMovieRepository : IActorMovieRepository
{
    private CinemaContext _cinemaContext;

    public ActorMovieRepository(CinemaContext cinemaContext)
    {
        _cinemaContext = cinemaContext;
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _cinemaContext.Database.BeginTransactionAsync();
    }

    public async Task AssignActor(MapDTO mapDto,int idActor)
    {
        ActorMovie actorMovie = new ActorMovie()
        {
            IdMovie = mapDto.IdMovie,
            IdActor = idActor,
            CharacterName = mapDto.CharacterName
        };
        await _cinemaContext.ActorMovies.AddAsync(actorMovie);
        await _cinemaContext.SaveChangesAsync();
    }

    public async Task<bool> CheckIfThereIsAssignment(int idActor)
    {
        var number = await _cinemaContext.ActorMovies.Where(x => x.IdActor == idActor).CountAsync();
        return number > 0;
    }

    public async Task DeleteAssigments(ICollection<ActorMovie> actorMovies)
    {
        foreach (var assignment in actorMovies)
        {
            _cinemaContext.Remove(assignment);
        }

        await _cinemaContext.SaveChangesAsync();
    }
}