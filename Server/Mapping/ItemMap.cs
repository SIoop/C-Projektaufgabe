using Backend.Mapping;
using Models;

namespace Server.Mapping
{
    public class ItemMap : BaseMap<Item>
    {
        public ItemMap()
        {
            Table("Items");

            Map(x => x.Name).Length(100).Not.Nullable();

            HasMany(x => x.Ratings).KeyColumn("ItemId").Cascade.All().Inverse();
        }
    }
}