using System.ComponentModel.DataAnnotations;

namespace PractiseScratch.Entities;

public class Movie
{
    public int IdMovie { get; set; }
    public int IdAgeRating { get; set; }
    [MaxLength(30)]
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    
    public virtual AgeRating AgeRating { get; set; }
    public virtual ICollection<ActorMovie> ActorMovies { get; set; }
}