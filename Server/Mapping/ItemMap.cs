using Models;

namespace Backend.Mapping
{
    public class ItemMap : BaseMap<Item>
    {
        public ItemMap()
        {
            Table("Items");

            Map(x => x.Name).Length(100).Not.Nullable();

            References(x => x.Category).Column("CatgoryId").Not.Nullable().Cascade.All();
        }
    }
}