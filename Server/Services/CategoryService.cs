using System.Collections.Generic;
using Models;
using Server.Contracts;
using Server.Managers;

namespace Server.Services
{
    public class CategoryService : ICategoryService
    {
        public PersistenceManager<Category> Manager = new PersistenceManager<Category>();

        public List<Category> GetAll() => Manager.GetAll();

        public Category Get(int id) => Manager.Get(id);

        public bool Delete(Category category) => Manager.Delete(category);

        public bool SaveOrUpdate(Category category) => Manager.SaveOrUpdate(category);
    }
}