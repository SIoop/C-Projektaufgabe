using System.Collections.Generic;
using Models;
using Server.Contracts;
using Server.Managers;

namespace Server.Services
{
    public class RatingService : IRatingService
    {
        private PersistenceManager<Rating> _manager = new PersistenceManager<Rating>();


        public List<Rating> GetRatingsForItem(Item item)
        {
            var all = _manager.GetAll();
            var ratings = all.FindAll(r => r.Item.Id.Equals(item.Id));
            return ratings;
        }

        public bool DeleteRating(Rating rating) => _manager.Delete(rating);

        public bool AddRating(Rating rating) => _manager.SaveOrUpdate(rating);
    }
}