using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Chairs")]
public class Chair
{
    public Chair()
    {
        Teachers = new List<Teacher>();
    }

    public int ID { get; set; }
    [Required]
    public string Name { get; set; }

    public int FacultyID { get; set; }
    public virtual Faculty Faculty { get; set; }

    public virtual ICollection<Teacher> Teachers { get; private set; }
}