using System.Collections.Generic;
using System.ServiceModel;
using Models;

namespace Server.Contracts
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

        [OperationContract]
        User LoginUser(string username, string password);
    }
}
