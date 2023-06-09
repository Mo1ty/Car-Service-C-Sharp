﻿using CarServiceApp.EFCore;
using CarServiceApp.EFCore.Context;
using CarServiceApp.repository.common;
using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp.repository
{
    internal class CarRepository : GenericRepository<Car> {

        public string exportToCSV(string Path)
        {
            var csv = new StringBuilder();
            List<Car> cars = findAll<Car>();

            foreach (Car car in cars)
            {
                var newLine = $"{car.Id},{car.Brand},{car.Model},{car.IdentificationNumber},{car.CarNumber},{car.ProductionTime}," +
                    $"{car.TestDriveable},{car.ConditionId}";
                csv.AppendLine(newLine);
            }

            string name = $"\\car.csv";
            string filepath = Path + name;
            File.WriteAllText(filepath, csv.ToString());

            return filepath;
        }

        public void importCSV(string filepath)
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                Encoding = Encoding.UTF8,
                Delimiter = ","
            };
            if (!File.Exists(filepath + "\\car.csv"))
            {
                return;
            }
            using (var reader = new StreamReader(filepath + "\\car.csv"))
            {
                using (var csvReader = new CsvReader(reader, configuration))
                {
                    var cars = csvReader.GetRecords<Car>();
                    foreach (Car car in cars)
                    {
                        addEntity<Car>(car);
                    }
                }

            }
        }
    }
}
