using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class Category : BaseModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Version { get; set; }
    }
}