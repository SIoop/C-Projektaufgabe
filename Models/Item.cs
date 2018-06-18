using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class Item : BaseModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Version { get; set; }
        [DataMember]
        public Category Category { get; set; }
    }
}