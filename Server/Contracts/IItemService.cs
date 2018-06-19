using System.Collections.Generic;
using System.ServiceModel;
using Models;

namespace Server.Contracts
{
    [ServiceContract]
    public interface IItemService
    {
        [OperationContract]
        List<Item> GetAll();

        [OperationContract]
        bool Delete(Item item);

        [OperationContract]
        bool SaveOrUpdate(Item item);

    }
}