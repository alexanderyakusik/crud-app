using System.Collections.Generic;
using System.Runtime.Serialization;

[DataContract]
public class Discipline : BasicEntity
{
    public Discipline()
    {
        Teachers = new List<Teacher>();
    }

    [DataMember]
    public virtual List<Teacher> Teachers { get; set; }
}