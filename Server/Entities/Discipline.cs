using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Disciplines")]
public class Discipline
{
    public Discipline()
    {
        Teachers = new List<Teacher>();
    }

    public int ID { get; set; }
    [Required]
    public string Name { get; set; }

    public virtual ICollection<Teacher> Teachers { get; private set; }
}