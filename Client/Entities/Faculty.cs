using System.Collections.Generic;
using System.Runtime.Serialization;

[DataContract]
public class Faculty : BasicEntity
{
    public Faculty()
    {
        Chairs = new List<Chair>();
    }

    [DataMember]
    public virtual List<Chair> Chairs { get; set; }
}