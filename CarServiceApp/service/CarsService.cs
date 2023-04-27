using CarServiceApp.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp.service
{
    internal interface CarsService
    {
        Car findById(Guid Id);
        List<Car> findAll();
        void addCar(Car car);
    }
}
