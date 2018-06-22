using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class Category : BaseModel
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public int Version { get; set; }
        [DataMember] public IList<Item> Items { get; set; }


        protected bool Equals(Category other)
        {
            return Id == other.Id && string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Category) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Version;
                return hashCode;
            }
        }
    }
}