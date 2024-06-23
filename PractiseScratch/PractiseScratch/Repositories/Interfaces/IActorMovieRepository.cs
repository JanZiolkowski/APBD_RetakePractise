using Microsoft.EntityFrameworkCore.Storage;
using PractiseScratch.Dtos.Request;

namespace PractiseScratch.Repositories.Interfaces;

public interface IActorMovieRepository
{
    public Task<IDbContextTransaction> BeginTransactionAsync();

    public Task AssignActor(MapDTO mapDto,int idActor);

    public Task<bool> CheckIfThereIsAssignment(int idActor);
}