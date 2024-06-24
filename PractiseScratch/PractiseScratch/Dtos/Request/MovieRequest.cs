namespace PractiseScratch.Dtos.Request;

public class MovieRequest
{
    public string MovieName { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string AgeRating { get; set; }
    public ICollection<ActorRequest> Actors { get; set; }
}