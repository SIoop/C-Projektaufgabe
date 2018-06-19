using System.Collections.Generic;
using Models;
using Server.Contracts;
using Server.Managers;

namespace Server.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly PersistenceManager<Category> _manager = new PersistenceManager<Category>();

        public List<Category> GetAll() => _manager.GetAll();

        public Category Get(int id) => _manager.Get(id);

        public bool Delete(Category category) => _manager.Delete(category);

        public bool SaveOrUpdate(Category category) => _manager.SaveOrUpdate(category);
    }
}