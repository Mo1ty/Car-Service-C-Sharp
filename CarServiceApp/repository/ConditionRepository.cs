using CarServiceApp.EFCore;
using CarServiceApp.repository.common;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp.repository
{
    internal class ConditionRepository : GenericRepository<Condition>{

        public string exportToCSV(string Path)
        {
            var csv = new StringBuilder();
            List<Condition> conditions = findAll<Condition>();

            foreach (Condition condition in conditions)
            {
                var newLine = $"{condition.Id},{condition.ConditionState},{condition.Description}";
                csv.AppendLine(newLine);
            }
            string name = $"\\condition.csv";
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
            if (!File.Exists(filepath + "\\condition.csv"))
            {
                return;
            }
            using (var reader = new StreamReader(filepath + "\\condition.csv"))
            {
                using (var csvReader = new CsvReader(reader, configuration))
                {
                    var conditions = csvReader.GetRecords<Condition>();
                    foreach (Condition condition in conditions)
                    {
                        addEntity<Condition>(condition);
                    }
                }
                
            }
        }

    }
}
