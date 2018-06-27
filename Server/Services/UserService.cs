using System.Collections.Generic;
using Models;
using Server.Contracts;
using Server.Managers;

namespace Server.Services
{
    public class UserService : IUserService
    {
        public PersistenceManager<User> Manager = new PersistenceManager<User>();

        public User GetUser(int id) => Manager.Get(id);

        public List<User> GetAllUsers() => Manager.GetAll();

        public bool AddOrUpdateUser(User user)
        {
            user.Username = user.Username.ToLower();
            var foundUser = GetUser(user.Id);
            if (foundUser == null) user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            return Manager.SaveOrUpdate(user);
        }

        public bool DeleteUser(User user) => Manager.Delete(user);

        public User LoginUser(string username, string password)
        {
            var users = Manager.GetAll();
            var lowerUsername = username.ToLower();
            var result = users.Find(u => u.Username == lowerUsername);
            if (result == null) return null;
            return BCrypt.Net.BCrypt.Verify(password, result.Password) ? result : null;
        }
    }
}
