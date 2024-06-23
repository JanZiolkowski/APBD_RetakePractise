using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PractiseScratch.Entities;

namespace PractiseScratch.DbContext.Configurations;

public class ActorMovieConfiguration : IEntityTypeConfiguration<ActorMovie>
{
    public void Configure(EntityTypeBuilder<ActorMovie> builder)
    {
        builder.ToTable("Actor_Movie");
        builder.HasKey(x => new { x.IdMovie, x.IdActor });

        builder.HasOne(x => x.Actor)
            .WithMany(x => x.ActorMovies)
            .HasForeignKey(x => x.IdActor);
        
        builder.HasOne(x => x.Movie)
            .WithMany(x => x.ActorMovies)
            .HasForeignKey(x => x.IdMovie);
    }
}