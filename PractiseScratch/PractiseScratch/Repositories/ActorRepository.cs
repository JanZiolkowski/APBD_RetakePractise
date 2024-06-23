using Microsoft.EntityFrameworkCore;
using PractiseScratch.DbContext;
using PractiseScratch.Dtos.Request;
using PractiseScratch.Entities;
using PractiseScratch.Repositories.Interfaces;

namespace PractiseScratch.Repositories;

public class ActorRepository : IActorRepository
{
    private CinemaContext _cinemaContext;

    public ActorRepository(CinemaContext cinemaContext)
    {
        _cinemaContext = cinemaContext;
    }
    public async Task<Actor?> GetActorAsync(int idActor)
    {
        return await _cinemaContext.Actors.FirstOrDefaultAsync(x => x.IdActor == idActor);
    }

    public async Task<int> CreateActorAsync(MapDTO mapDto)
    {
        Actor actor = new Actor()
        {
            Name = mapDto.Name,
            Surname = mapDto.Surname,
            Nickname = mapDto.NickName
        };

        await _cinemaContext.Actors.AddAsync(actor);
        await _cinemaContext.SaveChangesAsync();

        return actor.IdActor;
    }
}