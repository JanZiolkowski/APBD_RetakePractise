using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PractiseScratch.Entities;

namespace PractiseScratch.DbContext.Configurations;

public class MoviesConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies");

        builder.HasKey(x => x.IdMovie);

        builder.HasOne(x => x.AgeRating)
            .WithMany(x => x.Movies)
            .HasForeignKey(x => x.IdAgeRating);

    }
}