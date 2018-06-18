using System.Collections.Generic;
using System.ServiceModel;
using Models;

namespace Server.Services
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        User GetUser(int id);

        [OperationContract]
        List<User> GetAllUsers();

        [OperationContract]
        bool AddOrUpdateUser(User user);

        [OperationContract]
        bool DeleteUser(User user);
    }
}
