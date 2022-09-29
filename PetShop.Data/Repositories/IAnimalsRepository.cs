using PetShop.Data.Model;

namespace PetShop.Client.Repositories
{
    public interface IAnimalsRepository : IRepository<Animal>
    {
        Animal GetByName(string name);
        ICollection<Animal> GetTop2Animals();
        Animal Update(Animal animal);
    }
}
