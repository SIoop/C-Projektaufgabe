using System.Collections.Generic;

namespace Server.Framework
{
    public interface IRepository<T> where T : class
    {
        void Delete(T entity);
        List<T> GetAll();
        void SaveOrUpdate(T entity);
    }
}