using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class Rating : BaseModel
    {
        [DataMember]
        public int  Id { get; set; }
        [DataMember]
        public int Score { get; set; }
        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public int Version { get; set; }
        [DataMember]
        public User User { get; set; }
        [DataMember]
        public Item Item { get; set; }
    }
}