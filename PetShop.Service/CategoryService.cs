using PetShop.Data.Model;
using PetShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Service
{
    public class CategoryService : ICategoryService
    {
        public ICategoryRepository MyCategoryRepository { get; set; }
        public CategoryService(ICategoryRepository repository)
        {
            MyCategoryRepository = repository;
        }
        public Category Add(Category entity)
        {
            return MyCategoryRepository.Add(entity);
        }
        public Category Get(int? id)
        {
            return MyCategoryRepository.Get(id);
        }
        public Category Delete(int id)
        {
            return MyCategoryRepository.Delete(id);
        }

        public IQueryable<Category> GetAllcategory()
        {
            return MyCategoryRepository.GetAll();
        }

        public IQueryable<Category> GetAll()
        {
            throw new NotImplementedException();
        }
        


    }
}
