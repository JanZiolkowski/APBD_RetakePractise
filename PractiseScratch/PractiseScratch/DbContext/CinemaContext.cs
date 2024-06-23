using PractiseScratch.DbContext.Configurations;
using PractiseScratch.Entities;

namespace PractiseScratch.DbContext;
//Need to add this:
using Microsoft.EntityFrameworkCore;

public class CinemaContext : DbContext
{
    public DbSet<Actor> Actors{ get; set; }
    public DbSet<ActorMovie> ActorMovies{ get; set; }
    public DbSet<AgeRating> AgeRatings{ get; set; }
    public DbSet<Movie> Movies{ get; set; }

    protected CinemaContext()
    {
    }

    public CinemaContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new MoviesConfiguration());
        modelBuilder.ApplyConfiguration(new ActorMovieConfiguration());
        
    }
}