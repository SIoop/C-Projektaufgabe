using System.Collections.Generic;
using Models;
using Server.Framework;

namespace Server.Managers
{
    public class PersistenceManager<T> where T : class, BaseModel
    {
        private readonly Repository<T> _repository = new Repository<T>();

        public T Get(int id)
        {
            var all = _repository.GetAll();
            return all.Find(x => x.Id.Equals(id));
        }

        public bool Delete(T t)
        {
            var all = _repository.GetAll();
            var find = all.Find(x => x.Equals(t));
            if (find == null) return false;
            _repository.Delete(find);
            return true;
        }

        public bool SaveOrUpdate(T t)
        {
            _repository.SaveOrUpdate(t);
            return true;
        }

        public List<T> GetAll()
        {
            var t = _repository.GetAll();
            return t;
        }
    }
}