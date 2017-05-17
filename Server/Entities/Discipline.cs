using System.Collections.Generic;

public class Discipline : BasicEntity
{
    public Discipline()
    {
        Teachers = new List<Teacher>();
    }

    public virtual List<Teacher> Teachers { get; set; }
}