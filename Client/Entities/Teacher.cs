using System.Collections.Generic;

public class Teacher : BasicEntity
{
    public Teacher()
    {
        Disciplines = new List<Discipline>();
    }

    public string FullName { get; set; }

    public int ChairID { get; set; }
    public virtual Chair Chair { get; set; }

    public virtual ICollection<Discipline> Disciplines { get; set; }
}