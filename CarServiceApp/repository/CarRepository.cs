using CarServiceApp.EFCore;
using CarServiceApp.EFCore.Context;
using CarServiceApp.repository.common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp.repository
{
    internal class CarRepository : GenericRepository<Car> {

        public string exportToCSV()
        {
            var csv = new StringBuilder();
            List<Car> cars = findAll<Car>();

            foreach (Car car in cars)
            {
                var newLine = $"{car.Id},{car.Brand},{car.Model},{car.IdentificationNumber},{car.CarNumber},{car.ProductionTime}," +
                    $"{car.TestDriveable},{car.ConditionId}";
                csv.Append(newLine);
            }

            string filepath = "/car.csv";
            File.WriteAllText(filepath, csv.ToString());

            return filepath;
        }
    }
}
