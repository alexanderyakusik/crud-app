using System.Collections.Generic;

public class Chair : BasicEntity
{
    public Chair()
    {
        Teachers = new List<Teacher>();
    }

    public string Name { get; set; }
    
    public int FacultyID { get; set; }
    public virtual Faculty Faculty { get; set; }

    public virtual ICollection<Teacher> Teachers { get; set; }
}