using PractiseScratch.Dtos.Request;
using PractiseScratch.Entities;

namespace PractiseScratch.Repositories.Interfaces;

public interface IActorRepository
{
    Task<Actor?> GetActorAsync(int idActor);
    Task<int> CreateActorAsync(MapDTO mapDto);
}