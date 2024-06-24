using PractiseScratch.Dtos.Request;
using PractiseScratch.Entities;

namespace PractiseScratch.Repositories.Interfaces;

public interface IActorRepository
{
    Task<Actor?> GetActorAsync(int idActor);
    Task<ICollection<Actor>> GetActorsAsync();
    Task<int> CreateActorAsync(MapDTO mapDto);
    Task<int> CreateActorAsync(NewActorDTO newActorDto);
    Task RemoveActorAsync(Actor actor);
    Task RemoveActorAsync(int idActor);

    Task ModifyActorAsync(Actor actor, ActorUpdateDTO actorUpdateDto);
    
}