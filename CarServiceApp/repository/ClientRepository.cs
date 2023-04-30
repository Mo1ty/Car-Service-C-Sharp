using CarServiceApp.EFCore;
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
    internal class ClientRepository : GenericRepository<Client> {

        public string exportToCSV(string Path)
        {
            var csv = new StringBuilder();
            List<Client> clients = findAll<Client>();

            foreach (Client client in clients)
            {
                var newLine = $"{client.Id},{client.Name},{client.Surname},{client.Email},{client.BirthDate},{client.DriverLicense}," +
                    $"{client.AddressId}";
                csv.AppendLine(newLine);
            }
            string name = $"\\client.csv";
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
            if (!File.Exists(filepath + "\\client.csv"))
            {
                return;
            }
            using (var reader = new StreamReader(filepath + "\\client.csv"))
            {
                using (var csvReader = new CsvReader(reader, configuration))
                {
                    var clients = csvReader.GetRecords<Client>();
                    foreach (Client client in clients)
                    {
                        addEntity<Client>(client);
                    }
                }

            }
        }

    }
}
