using PractiseScratch.Dtos.Request;
using PractiseScratch.Dtos.Response;

namespace PractiseScratch.Services.Interfaces;

public interface IActorService
{
    Task AssignActorToMovie(MapDTO mapDto);
    Task<int> AddActorAsync(NewActorDTO newActorDto);
    Task RemoveActorAsync(int idActor);
    Task ChangeActor(int idActor, ActorUpdateDTO actorUpdateDto);
    Task<ICollection<Actor2DTO>> GetListOfAllActors(string? name, string? surname);
}