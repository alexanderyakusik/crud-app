using System.Collections.Generic;

public class Chair : BasicEntity
{
    public Chair()
    {
        Teachers = new List<Teacher>();
    }
    
    public int FacultyID { get; set; }
    public virtual Faculty Faculty { get; set; }

    public virtual List<Teacher> Teachers { get; set; }
}