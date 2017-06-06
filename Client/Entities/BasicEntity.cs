using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

[DataContract]
public class BasicEntity
{
    [DataMember]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ID { get; set; }
    [DataMember]
    public string Name { get; set; }
}