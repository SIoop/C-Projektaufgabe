using System.Collections.Generic;
using Models;
using Server.Framework;

namespace Server.Managers
{
    public class PersistenceManager<T> where T : class, BaseModel
    {
        public IRepository<T> Repository = new Repository<T>();

        public T Get(int id)
        {
            var all = Repository.GetAll();
            return all.Find(x => x.Id.Equals(id));
        }

        public bool Delete(T t)
        {
            var all = Repository.GetAll();
            var find = all.Find(x => x.Equals(t));
            if (find == null) return false;
            Repository.Delete(find);
            return true;
        }

        public bool SaveOrUpdate(T t)
        {
            Repository.SaveOrUpdate(t);
            return true;
        }

        public List<T> GetAll()
        {
            var t = Repository.GetAll();
            return t;
        }
    }
}