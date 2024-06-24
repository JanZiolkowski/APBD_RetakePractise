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
        return await _cinemaContext.Actors.Include(x=>x.ActorMovies).FirstOrDefaultAsync(x => x.IdActor == idActor);
    }

    public async Task<ICollection<Actor>> GetActorsAsync()
    {
        return await _cinemaContext.Actors.Include(x => x.ActorMovies).ThenInclude(x => x.Movie)
            .ThenInclude(x => x.AgeRating).ToListAsync();
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
    
    public async Task<int> CreateActorAsync(NewActorDTO newActorDto)
    {
        Actor actor = new Actor()
        {
            Name = newActorDto.Name,
            Surname = newActorDto.Surname,
            Nickname = newActorDto.NickName
        };

        await _cinemaContext.Actors.AddAsync(actor);
        await _cinemaContext.SaveChangesAsync();

        return actor.IdActor;
    }

    public async Task RemoveActorAsync(Actor actor)
    {
        _cinemaContext.Actors.Remove(actor);
        await _cinemaContext.SaveChangesAsync();
    }
    //It is not the best, because when we dont have idActor with id, i couldn't check in the business part easily
    public async Task RemoveActorAsync(int idActor)
    {
        Actor actor = new Actor()
        {
            IdActor = idActor
        };

        _cinemaContext.Attach(actor);
        var entry = _cinemaContext.Entry(actor);
        entry.State = EntityState.Deleted;

        await _cinemaContext.SaveChangesAsync();
    }

    public async Task ModifyActorAsync(Actor actor, ActorUpdateDTO actorUpdateDto)
    {

        if (actorUpdateDto.Name != null && !actorUpdateDto.Name.Equals(""))
        {
            actor.Name = actorUpdateDto.Name;
        }

        if (actorUpdateDto.Surname != null && !actorUpdateDto.Surname.Equals(""))
        {
            actor.Surname = actorUpdateDto.Surname;
        }

        if (actorUpdateDto.NickName != null && !actorUpdateDto.NickName.Equals(""))
        {
            actor.Nickname = actorUpdateDto.NickName;
        }

        await _cinemaContext.SaveChangesAsync();
    }
}