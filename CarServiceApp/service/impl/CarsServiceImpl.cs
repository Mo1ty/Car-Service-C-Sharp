using CarServiceApp.EFCore;
using CarServiceApp.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp.service.impl
{
    internal class CarsServiceImpl : CarsService
    {
        CarRepository carRepository = new CarRepository();
        ConditionRepository conditionRepository = new ConditionRepository();

        public void addCar(Car car)
        {
            try
            {
                if (!conditionRepository.existsById<Condition>(car.ConditionId))
                    throw new ArgumentException("Attempt to add a car failed due to non-existent condition identifier!");
            }
            catch { throw; }
            carRepository.addEntity<Car>(car);
        }

        public List<Car> findAll()
        {
            return carRepository.findAll<Car>();
        }

        public Car findById(Guid Id)
        {
            return carRepository.findById<Car>(Id);
        }

        public string exportCSV(string Path)
        {
            return carRepository.exportToCSV(Path);
        }
    }
}
