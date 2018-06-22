using System.Collections.Generic;
using System.Linq;
using Models;
using NHibernate.Util;
using Server.Contracts;
using Server.Managers;

namespace Server.Services
{
    public class ItemService : IItemService
    {
        private readonly PersistenceManager<Item> _manager = new PersistenceManager<Item>();
        private readonly PersistenceManager<Rating> _ratManager = new PersistenceManager<Rating>();


        public List<Item> GetAll() => _manager.GetAll();

        public bool Delete(Item item) => _manager.Delete(item);

        public bool SaveOrUpdate(Item item) => _manager.SaveOrUpdate(item);

        public List<RatedItem> GetRatedItemsByCategory(Category cat)
        {
            var catItems = cat.Items;

            var result = new List<RatedItem>();
            foreach (var item in catItems)
            {
                var scores = item.Ratings.Select(rating => rating.Score);
                var enumerable = scores as int[] ?? scores.ToArray();
                result.Add(new RatedItem()
                {
                    Name = item.Name,
                    AvgRating = !enumerable.Any() ? 0 : enumerable.Average(),
                    Ratings = item.Ratings.Count
                });
            }

            return result;
        }
    }
}