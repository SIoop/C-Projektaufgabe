using Models;

namespace Backend.Mapping
{
    public class RatingMap : BaseMap<Rating>
    {
        public RatingMap()
        {
            Table("Ratings");

            Map(x => x.Comment).Length(100);
            Map(x => x.Score).Not.Nullable().Default("1");

            References(x => x.User).Column("UserId").Not.Nullable().Cascade.None();
        }
    }
}