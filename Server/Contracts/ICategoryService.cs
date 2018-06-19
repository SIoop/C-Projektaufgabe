using System.Collections.Generic;
using System.ServiceModel;
using Models;

namespace Server.Contracts
{
    [ServiceContract]
    public interface ICategoryService
    {
        [OperationContract]
        List<Category> GetAll();

        [OperationContract]
        Category Get(int id);

        [OperationContract]
        bool Delete(Category category);

        [OperationContract]
        bool SaveOrUpdate(Category category);

    }
}