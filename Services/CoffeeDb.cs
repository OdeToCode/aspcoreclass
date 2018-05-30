﻿using aspcoreclass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspcoreclass.Services
{
    public interface ICoffeeDb
    {
        IEnumerable<Coffee> GetAll();
        Coffee Get(int id);
        Coffee Add(Coffee newCoffee);
        Coffee Update(Coffee updatedCoffee);
        void Delete(int id);
    }

    public class InMemoryCoffeeDb : ICoffeeDb
    {
        List<Coffee> coffees = new List<Coffee>
        {
            new Coffee { Id = 1, Name = "Scott", Type= CoffeeType.Espresso},
            new Coffee { Id = 2, Name = "Allen", Type= CoffeeType.Espresso},
            new Coffee { Id = 3, Name = "Michael", Type= CoffeeType.Latte},
            new Coffee { Id = 4, Name = "Kevin", Type= CoffeeType.Espresso},
        };

        public Coffee Add(Coffee newCoffee)
        {
            var id = coffees.Max(c => c.Id) + 1;
            newCoffee.Id = id;
            coffees.Add(newCoffee);
            return newCoffee;
        }

        public void Delete(int id)
        {
            var coffee = coffees.FirstOrDefault(c => c.Id == id);
            if(coffee != null)
            {
                coffees.Remove(coffee);
            }
        }

        public Coffee Get(int id)
        {
            return coffees.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Coffee> GetAll()
        {
            return coffees;
        }

        public Coffee Update(Coffee updatedCoffee)
        {
            var coffee = coffees.FirstOrDefault(c => c.Id == updatedCoffee.Id);
            if(coffee != null)
            {
                coffee.Name = updatedCoffee.Name;
                coffee.Type = updatedCoffee.Type;
            }
            return coffee;
        }
    }
}
