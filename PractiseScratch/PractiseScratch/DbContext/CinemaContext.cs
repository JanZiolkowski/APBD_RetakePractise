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
        AddData(modelBuilder);
    }

    private void AddData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>().HasData(
            new Actor()
            {
                IdActor = 1,
                Name = "John",
                Surname = "Miguells",
                Nickname = "Vigor"
            },
            new Actor()
            {
                IdActor = 2,
                Name = "Vera",
                Surname = "Bailla",
                Nickname = "Kiss"
            },
            new Actor()
            {
                IdActor = 3,
                Name = "Ala",
                Surname = "Piska",
                Nickname = "Vigra"
            }
        );
        modelBuilder.Entity<AgeRating>().HasData(
            new AgeRating()
            {
                IdAgeRating = 1,
                Name = "Underage"
            },
            new AgeRating()
            {
                IdAgeRating = 2,
                Name = "Age"
            }
        );
        modelBuilder.Entity<Movie>().HasData(
            new Movie()
            {
                IdMovie = 1,
                IdAgeRating = 1,
                Name = "James Bond",
                ReleaseDate = DateTime.Now.AddMonths(-3)
            },
            new Movie()
            {
                IdMovie = 2,
                IdAgeRating = 2,
                Name = "Query",
                ReleaseDate = DateTime.Now.AddMonths(-1)
            }
        );
        modelBuilder.Entity<ActorMovie>().HasData(
            new ActorMovie()
            {
                IdMovie = 1,
                IdActor = 1,
                CharacterName = "Bear"
            },
            new ActorMovie()
            {
                IdMovie = 1,
                IdActor = 2,
                CharacterName = "Herrassa"
            },
            new ActorMovie()
            {
                IdMovie = 2,
                IdActor = 2,
                CharacterName = "Jinxa"
            }
        );
    }
}