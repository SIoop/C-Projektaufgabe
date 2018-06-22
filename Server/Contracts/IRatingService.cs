using System.Collections.Generic;
using System.ServiceModel;
using Models;

namespace Server.Contracts
{
    [ServiceContract]
    public interface IRatingService
    {
        [OperationContract]
        bool DeleteRating(Rating rating);

        [OperationContract]
        bool AddRating(Rating rating);
    }
}