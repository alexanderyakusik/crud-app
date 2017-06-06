using System.Collections.Generic;
using System.Runtime.Serialization;

[DataContract]
public class Teacher : BasicEntity
{
    public Teacher()
    {
        Disciplines = new List<Discipline>();
    }

    [DataMember]
    public int? ChairID { get; set; }
    [DataMember]
    public virtual Chair Chair { get; set; }

    [DataMember]
    public virtual List<Discipline> Disciplines { get; set; }
}