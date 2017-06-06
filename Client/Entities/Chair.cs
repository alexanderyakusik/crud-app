using System.Collections.Generic;
using System.Runtime.Serialization;

[DataContract]
public class Chair : BasicEntity
{
    public Chair()
    {
        Teachers = new List<Teacher>();
    }
    
    [DataMember]
    public int? FacultyID { get; set; }
    [DataMember]
    public virtual Faculty Faculty { get; set; }

    [DataMember]
    public virtual List<Teacher> Teachers { get; set; }
}