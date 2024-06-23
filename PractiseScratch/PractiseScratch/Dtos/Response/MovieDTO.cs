namespace PractiseScratch.Dtos.Response;

public class MovieDTO
{
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string AgeRating { get; set; }
    
    public ICollection<ActorDTO> Actors { get; set; }
    
}