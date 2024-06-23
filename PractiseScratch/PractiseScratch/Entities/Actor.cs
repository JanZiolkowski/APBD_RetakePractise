using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PractiseScratch.Entities;
[Table("Actor")]
public class Actor
{
    [Key]
    public int IdActor { get; set; }
    [MaxLength(30)]
    public string Name { get; set; }
    [MaxLength(30)]
    public string Surname { get; set; }
    [MaxLength(30)]
    public string? Nickname { get; set; }

    public virtual ICollection<ActorMovie> ActorMovies { get; set; }
}