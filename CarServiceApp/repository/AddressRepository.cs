using CarServiceApp.EFCore;
using CarServiceApp.EFCore.Context;
using CarServiceApp.repository.common;
using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CarServiceApp.repository
{
    internal class AddressRepository : GenericRepository<Address>
    {

        public string exportToCSV(string Path)
        {
            var csv = new StringBuilder();
            List<Address> addresses = findAll<Address>();

            foreach (Address address in addresses)
            {
                var newLine = $"{address.Id},{address.City},{address.Street},{address.HouseNumber},{address.PostalCode}";
                csv.AppendLine(newLine);
            }

            string name = $"\\address.csv";
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
            if (!File.Exists(filepath + "\\address.csv"))
            {
                return;
            }
            using (var reader = new StreamReader(filepath + "\\address.csv"))
            {
                using (var csvReader = new CsvReader(reader, configuration))
                {
                    var addresses = csvReader.GetRecords<Address>();
                    foreach (Address address in addresses)
                    {
                        addEntity<Address>(address);
                    }
                }

            }
        }

    }
}
