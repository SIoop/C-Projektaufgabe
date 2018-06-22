namespace Models
{
    public class RatedItem
    {
        public string Name { get; set; }
        public double AvgRating { get; set; }
        public int Ratings { get; set; }

        protected bool Equals(RatedItem other)
        {
            return string.Equals(Name, other.Name) && AvgRating.Equals(other.AvgRating) && Ratings == other.Ratings;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RatedItem) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ AvgRating.GetHashCode();
                hashCode = (hashCode * 397) ^ Ratings;
                return hashCode;
            }
        }
    }
}