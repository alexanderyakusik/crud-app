using System.Collections.Generic;

public class Teacher : BasicEntity
{
    public Teacher()
    {
        Disciplines = new List<Discipline>();
    }

    public int ChairID { get; set; }
    public virtual Chair Chair { get; set; }

    public virtual List<Discipline> Disciplines { get; set; }
}