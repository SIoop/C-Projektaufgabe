using Models;

namespace Backend.Mapping
{
    public class RatingMap : BaseMap<Rating>
    {
        public RatingMap()
        {
            Table("Ratings");

            References(x => x.Item).Column("ItemId").Not.Nullable().Cascade.All();

            References(x => x.User).Column("UserId").Not.Nullable().Cascade.All();
        }
    }
}