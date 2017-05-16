using System.Collections.Generic;

public class Faculty : BasicEntity
{
    public Faculty()
    {
        Chairs = new List<Chair>();
    }

    public string Name { get; set; }

    public virtual ICollection<Chair> Chairs { get; set; }
}