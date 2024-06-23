using PractiseScratch.DbContext;
using PractiseScratch.Entities;

namespace PractiseScratch.Repositories.Interfaces;

public interface IMoviesRepository
{
    Task<ICollection<Movie>> GetMoviesWithIncludeAsync();
}