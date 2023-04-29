using CarServiceApp.EFCore;
using CarServiceApp.repository.common;
using System;
using System.Collections.Generic;
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

    }
}
