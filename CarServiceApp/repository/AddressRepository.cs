using CarServiceApp.EFCore;
using CarServiceApp.EFCore.Context;
using CarServiceApp.repository.common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CarServiceApp.repository
{
    internal class AddressRepository : GenericRepository<Address> {
    
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
    
    }
}
