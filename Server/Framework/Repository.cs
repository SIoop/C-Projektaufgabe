using System;
using System.Collections.Generic;
using System.IO;

namespace Server.Framework
{
    public class Repository<T> where T : class
    {
        public Repository(string databaseFile)
        {
            NHibernateHelper.DatabaseFile = databaseFile;
        }

        public Repository()
        {
            var path = Path.GetDirectoryName(Path.GetDirectoryName(
                Path.GetDirectoryName(
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)));
            var localPath = new Uri(path ?? throw new InvalidOperationException()).LocalPath;
            NHibernateHelper.DatabaseFile = Path.Combine(localPath, @"Database\", "rateMe.db3");
        }

        public List<T> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var returnList = session.CreateCriteria<T>().List<T>();
                return returnList as List<T>;
            }
        }

        public void Delete(T entity)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(entity);
                    transaction.Commit();
                }
            }
        }

        public void SaveOrUpdate(T entity)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(entity);
                    transaction.Commit();
                }
            }
        }
    }
}