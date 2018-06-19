using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Models;
using Server.Contracts;
using Server.Framework;
using Server.Managers;

namespace Server.Services
{
    public class UserService : IUserService
    {
        private PersistenceManager<User> manager = new PersistenceManager<User>();

        public User GetUser(int id) => manager.Get(id);

        public List<User> GetAllUsers() => manager.GetAll();

        public bool AddOrUpdateUser(User user) => manager.SaveOrUpdate(user);

        public bool DeleteUser(User user) => manager.Delete(user);

        public User LoginUser(string username, string password)
        {
            var users = manager.GetAll();
            var result = users.Find(u => u.Username == username);
            if (result == null) return result;
            else
            {
                if (BCrypt.Net.BCrypt.Verify(password, result.Password))
                {
                    return result;
                }
                else return null;
            }
        }
    }
}
