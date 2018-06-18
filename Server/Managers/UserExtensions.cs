using System.Collections.Generic;
using System.Linq;
using Backend.Framework;
using Models;

namespace Server.Managers
{
    public static class UserExtensions
    {
        public static User FindUser(this int i)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<User>().First();
            }
        }

        public static bool SaveOrUpdate(this User user)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var result = session.Query<User>().First(u => u == user);
                session.SaveOrUpdate(user);
                return result != null;
            }
        }

        public static bool Delete(this User user)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var result = session.Query<User>().First(u => u == user);
                session.SaveOrUpdate(user);
                return result != null;
            }
        }

        public static List<User> GetAllUsers()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<User>().ToList();
            }
        }
    }
}