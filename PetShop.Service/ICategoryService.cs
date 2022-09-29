using PetShop.Client.Repositories;
using PetShop.Data.Model;

namespace PetShop.Service
{
    public interface ICategoryService : IRepository<Category>
    {
        IQueryable<Category> GetAllcategory();
    }
}
