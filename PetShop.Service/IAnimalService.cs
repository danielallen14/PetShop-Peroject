﻿using PetShop.Client.Repositories;
using PetShop.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Service
{
    public interface IAnimalService : IAnimalsRepository
    {
        Animal Update(Animal entity);
    }
}
