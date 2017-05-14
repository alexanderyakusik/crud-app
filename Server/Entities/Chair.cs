using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Chairs")]
public class Chair : BasicEntity
{
    public Chair()
    {
        Teachers = new List<Teacher>();
    }

    [Required]
    public string Name { get; set; }

    public int FacultyID { get; set; }
    public virtual Faculty Faculty { get; set; }

    public virtual ICollection<Teacher> Teachers { get; private set; }
}