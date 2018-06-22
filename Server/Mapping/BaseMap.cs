using FluentNHibernate.Mapping;
using Models;
using NHibernate.Mapping.ByCode;

namespace Backend.Mapping
{
    public class BaseMap<T> : ClassMap<T> where T : BaseModel
    {
        public BaseMap()
        {
            Id(x => x.Id).GeneratedBy.Native();

            OptimisticLock.Version();
            Version(x => x.Version);
        }
    }
}