using System.Collections.Generic;
using Models;
using Server.Contracts;
using Server.Managers;

namespace Server.Services
{
    public class RatingService : IRatingService
    {
        private readonly PersistenceManager<Rating> _manager = new PersistenceManager<Rating>();

        public bool DeleteRating(Rating rating) => _manager.Delete(rating);

        public bool AddRating(Rating rating) => _manager.SaveOrUpdate(rating);
    }
}