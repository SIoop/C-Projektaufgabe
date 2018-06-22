using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class Rating : BaseModel
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public int Score { get; set; }
        [DataMember] public string Comment { get; set; }
        [DataMember] public int Version { get; set; }
        [DataMember] public User User { get; set; }

        protected bool Equals(Rating other)
        {
            return Id == other.Id && Score == other.Score && string.Equals(Comment, other.Comment) &&
                   Equals(User, other.User);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Rating) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ Score;
                hashCode = (hashCode * 397) ^ (Comment != null ? Comment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Version;
                hashCode = (hashCode * 397) ^ (User != null ? User.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}