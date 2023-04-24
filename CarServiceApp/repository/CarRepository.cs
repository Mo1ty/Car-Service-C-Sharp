using CarServiceApp.EFCore;
using CarServiceApp.EFCore.Context;
using CarServiceApp.repository.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp.repository
{
    internal class CarRepository : GenericRepository<Car>
    {
        private CarServiceContext context = ContextConfiguration.Context;

        public Car addCar(Car car)
        {
            throw new NotImplementedException();
        }

        public bool existsById(Guid Id)
        {
            List<Car> cars = (from c in context.Cars
                                       where c.Id == Id
                                       select c).ToList();
            return cars.Count != 0 ? true : false;
        }

        public Car findById(Guid Id)
        {
            List<Car> cars = (from c in context.Cars
                                       where c.Id == Id
                                       select c).ToList();
            if (cars.Count == 1)
                return cars[0];
            else if (cars.Count > 1)
                throw new Exception("Multiple cars with this ID found in the database!");
            return null;
        }
    }
}
