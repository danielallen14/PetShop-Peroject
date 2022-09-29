using PetShop.Data.Contexts;
using PetShop.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PetShopDataContext _context;
        public CategoryRepository(PetShopDataContext petsopContext)
        {
            _context = petsopContext;
        }
        public Category Add(Category entity)
        {
            _context.Categories.Add(entity);
            _context.SaveChanges();
            return entity;
        }
        public Category Get(int? id)
        {
            var category = _context.Categories.FirstOrDefault(category => category.CategoryId == id);
            return category;
        }

        public Category Delete(int id)
        {
            var category = Get(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                return category;
            }
            else return null;
            _context.SaveChanges();
        }


        public IQueryable<Category> GetAll()
        {
            return _context.Categories;
        }

       
    }
}
