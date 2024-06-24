namespace PractiseScratch.Dtos.Response;

public class Actor2DTO 
{
    public int IdActor { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? Nickname { get; set; }
    public ICollection<Movie2DTO> Movies { get; set; }
}