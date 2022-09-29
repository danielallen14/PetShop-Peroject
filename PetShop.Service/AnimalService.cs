using PetShop.Client.Repositories;
using PetShop.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Service
{
    public class AnimalService : IAnimalService
    {
        public IAnimalsRepository MyAnimalRepository { get; }
        public AnimalService(IAnimalsRepository repository)
        {
            MyAnimalRepository = repository;
        }

        public Animal Add(Animal entity)
        {
            return MyAnimalRepository.Add(entity);
        }
        public Animal Get(int? id)
        {
            return MyAnimalRepository.Get(id);
        }
        public Animal Delete(int id)
        {
            return MyAnimalRepository.Delete(id);
        }
        public ICollection<Animal> GetTop2Animals()
        {
           return MyAnimalRepository.GetTop2Animals();
        }

        public Animal GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Animal> GetAll()
        {
            return MyAnimalRepository.GetAll();
        }
        
        public Animal Update(Animal animal)
        {
            return MyAnimalRepository.Update(animal);
        }
    }
}
