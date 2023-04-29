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
    internal class DealRepository : GenericRepository<Deal>{

        public string exportToCSV()
        {
            var csv = new StringBuilder();
            List<Deal> deals = findAll<Deal>();

            foreach (Deal deal in deals)
            {
                var newLine = $"{deal.Id},{deal.ClientId},{deal.CarId},{deal.DealDateTime},{deal.PaymentAccount},{deal.PaymentCode}";
                csv.Append(newLine);
            }

            string filepath = "/car.csv";
            File.WriteAllText(filepath, csv.ToString());

            return filepath;
        }

    }
}
