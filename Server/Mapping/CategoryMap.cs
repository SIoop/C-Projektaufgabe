using Backend.Mapping;
using Models;

namespace Server.Mapping
{
    public class CategoryMap : BaseMap<Category>
    {
        public CategoryMap()
        {
            Table("Categories");

            Map(x => x.Name).Length(20).Not.Nullable();

            HasMany(x => x.Items).KeyColumn("CategoryId").Cascade.All().Inverse();
        }
    }
}