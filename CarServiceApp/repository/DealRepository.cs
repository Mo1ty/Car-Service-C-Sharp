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
    internal class DealRepository : GenericRepository<Deal>{

        public string exportToCSV(string Path)
        {
            var csv = new StringBuilder();
            List<Deal> deals = findAll<Deal>();

            foreach (Deal deal in deals)
            {
                var newLine = $"{deal.Id},{deal.ClientId},{deal.CarId},{deal.DealDateTime},{deal.PaymentAccount},{deal.PaymentCode}";
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
            if (!File.Exists(filepath + "\\deal.csv"))
            {
                return;
            }
            using (var reader = new StreamReader(filepath + "\\deal.csv"))
            {
                using (var csvReader = new CsvReader(reader, configuration))
                {
                    var deals = csvReader.GetRecords<Deal>();
                    foreach (Deal deal in deals)
                    {
                        addEntity<Deal>(deal);
                    }
                }

            }
        }

    }
}
