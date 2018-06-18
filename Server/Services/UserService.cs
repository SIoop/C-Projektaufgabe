using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Models;
using Server.Managers;

namespace Server.Services
{
    public class UserService : IUserService
    {
        public User GetUser(int id)
        {
            return id.FindUser();
        }

        public List<User> GetAllUsers()
        {
            return UserExtensions.GetAllUsers();
        }

        public bool AddOrUpdateUser(User user)
        {
            return user.SaveOrUpdate();
        }

        public bool DeleteUser(User user)
        {
            return user.Delete();
        }
    }
}
