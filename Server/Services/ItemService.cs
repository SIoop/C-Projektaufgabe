using System.Collections.Generic;
using Models;
using Server.Contracts;
using Server.Managers;

namespace Server.Services
{
    public class ItemService : IItemService
    {
        private readonly PersistenceManager<Item> _manager = new PersistenceManager<Item>();


        public List<Item> GetAll() => _manager.GetAll();

        public bool Delete(Item item) => _manager.Delete(item);

        public bool SaveOrUpdate(Item item) => _manager.SaveOrUpdate(item);
    }
}