using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PractiseScratch.Entities;
[Table("AgeRating")]
public class AgeRating
{
    [Key]
    public int IdAgeRating { get; set; }
    [MaxLength(30)]
    public string Name { get; set; }
    
    public virtual ICollection<Movie> Movies { get; set; }
}