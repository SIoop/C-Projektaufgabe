using FluentNHibernate.Mapping;
using Models;

namespace Backend.Mapping
{
    public class UserMap : BaseMap<User>
    {
        public UserMap()
        {
            Table("Users");

            Map(x => x.Firstname).Length(50).Nullable();
            Map(x => x.Lastname).Length(50).Not.Nullable();
            Map(x => x.Username).Length(20).Unique().Not.Nullable();
            Map(x => x.Password).Length(60).Not.Nullable();
            Map(x => x.IsAdmin).Not.Nullable();
        }
    }
}