using PractiseScratch.Dtos.Request;

namespace PractiseScratch.Services.Interfaces;

public interface IActorService
{
    Task AssignActorToMovie(MapDTO mapDto);
}