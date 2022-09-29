using Microsoft.EntityFrameworkCore;
using PetShop.Data.Contexts;
using PetShop.Data.Model;
using System.Linq;

namespace PetShop.Client.Repositories
{
    public class AnimalRepository : IAnimalsRepository
    {
        private readonly PetShopDataContext _context;
        public AnimalRepository(PetShopDataContext petsopContext)
        {
            _context = petsopContext;
        }
        public Animal Add(Animal entity)
        {
            _context.Animals.Add(entity);
            _context.SaveChanges();
            return entity;
        }
        public Animal Get(int ?id)
        {
            var animal = _context.Animals.Include(a => a.Category).FirstOrDefault(animal => animal.AnimalId == id);
            return animal;
        }

        public Animal Delete(int id)
        {
            var animal = Get(id);
            if (animal != null)
            {
                _context.Animals.Remove(animal);
            }
            else return null;
            _context.SaveChanges();
            return animal;
        }


        public IQueryable<Animal> GetAll()
        {
            return _context.Animals;
        }

        public Animal GetByName(string name)
        {
            var animal = _context.Animals.FirstOrDefault(a => a.Name == name);
            if (animal == null)
            {
                return null;
            }
            return animal;
        }

        public ICollection<Animal> GetTop2Animals()
        {
            var Top2List = GetAll().OrderByDescending(a => a.Comments.Count).Take(2).ToList();
            //var Top2List = _context.Animals.FromSqlRaw("select top 2 AnimalID, count(AnimalID)'comments'from Comment group by AnimalID order by comments desc").ToList();
            return Top2List;

        }

        public Animal Update(Animal entity) //////****************
        {
            _context.Animals.Update(entity);
            _context.SaveChanges();
            return entity;
        }

    }
}
