using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ISession = NHibernate.ISession;

namespace Backend.Framework
{
    public static class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static string DatabaseFile = "/Database/rateMe_filled.db3";

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();

                return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.UsingFile(DatabaseFile).ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())
                    .Conventions.Add(FluentNHibernate.Conventions.Helpers.DefaultLazy.Never()))
                .BuildSessionFactory();
        }
    }
}