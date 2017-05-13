using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Faculties")]
public class Faculty
{
    public Faculty()
    {
        Chairs = new List<Chair>();
    }

    public int ID { get; set; }
    [Required]
    public string Name { get; set; }

    public virtual ICollection<Chair> Chairs { get; private set; }
}