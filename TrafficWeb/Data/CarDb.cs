using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrafficWeb.Model;

namespace TrafficWeb.Data
{
    public interface ICarDb
    {
        IEnumerable<Car> GetAll();
        Car Get(int id);
        Car Add(Car newCar);
        Car Update(int id, Car updatedCar);
    }


    public class InMemoryCarDb : ICarDb
    {
        List<Car> cars = new List<Car>()
        {
            new Car { Id = 1, Year = 2008, Manufacturer = "Ford"},
            new Car { Id = 2, Year = 2018, Manufacturer = "Chevy"},
            new Car { Id = 3, Year = 2010, Manufacturer = "Tesla"}
        };


        public Car Add(Car newCar)
        {
            newCar.Id = cars.Max(c => c.Id) + 1;
            cars.Add(newCar);
            return newCar;
        }

        public Car Get(int id)
        {
            return cars.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Car> GetAll()
        {
            return cars;
        }

        public Car Update(int id, Car updatedCar)
        {
            var existingCar = cars.SingleOrDefault(c => c.Id == id);
            if(existingCar != null)
            {
                existingCar.Manufacturer = updatedCar.Manufacturer;
                existingCar.Year = updatedCar.Year;
            }
            return existingCar;
        }
    }
}
