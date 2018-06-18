
using FluentNHibernate.Mapping;
using Models;

namespace Backend.Mapping
{
    public class CategoryMap : BaseMap<Category>
    {
        public CategoryMap()
        {
            Table("Categories");

            Map(x => x.Name).Length(20).Not.Nullable();
        }
    }
}