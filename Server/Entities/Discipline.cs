using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Disciplines")]
public class Discipline : BasicEntity
{
    public Discipline()
    {
        Teachers = new List<Teacher>();
    }

    [Required]
    public string Name { get; set; }

    public virtual ICollection<Teacher> Teachers { get; private set; }
}