using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Teachers")]
public class Teacher
{
    public Teacher()
    {
        Disciplines = new List<Discipline>();
    }

    public int ID { get; set; }
    [Required]
    public string FullName { get; set; }

    public int ChairID { get; set; }
    public virtual Chair Chair { get; set; }

    public virtual ICollection<Discipline> Disciplines { get; private set; }
}