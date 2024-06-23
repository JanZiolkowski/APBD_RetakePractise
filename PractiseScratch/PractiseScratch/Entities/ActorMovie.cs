using System.ComponentModel.DataAnnotations;

namespace PractiseScratch.Entities;

public class ActorMovie
{
    public int IdMovie { get; set; }
    public int IdActor { get; set; }
    [MaxLength(50)]
    public string CharacterName { get; set; }
    
    public virtual Actor Actor { get; set; }
    public virtual Movie Movie { get; set; }
}