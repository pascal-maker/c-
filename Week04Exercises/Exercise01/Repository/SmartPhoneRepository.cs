using System.Globalization;
using System.IO;
using CsvHelper;
using Ct.Ai.Models;
using Ct.Ai.Repositories;

namespace Ct.Ai.Repositories
{
    public class SmartPhoneRepository
    {
        private readonly string _filePath = "Data/smartphones.csv";
        // Create a Smartphone object from the parts
        public List<Smartphone> GetSmartphones()
        {
            var lines = File.ReadAllLines(_filePath);
            var smartphones = new List<Smartphone>();

            foreach (var line in lines.Skip(1))
            {
                var parts = line.Split(',');
                smartphones.Add(new Smartphone
                {
                    Id = int.Parse(parts[0]),
                    Brand = parts[1],
                    Type = parts[2],
                    ReleaseYear = int.Parse(parts[3]),
                    StartPrice = decimal.Parse(parts[4], CultureInfo.InvariantCulture),
                    OperatingSystem = parts[5]
                });
            }

            return smartphones;
        }

        //This method is responsible for adding one new smartphone to your CSV file.

        public void AddSmartphone(Smartphone phone)

        {
            using var writer = File.AppendText(_filePath);
            writer.WriteLine($"{phone.Id},{phone.Brand},{phone.Type},{phone.ReleaseYear},{phone.StartPrice},{phone.OperatingSystem}");
        }
        
        //this methpd looks throught the list foe all smartphones and returns one with a matching id for null ifnone is found GETsartPhones loads allphones rom csv firstorDefaults.Id--id) finds the first march or returns null the ? in smarthone means its okay if nothing is found
        public Smartphone? GetSmartphoneById(int id)
        {
            return GetSmartphones().FirstOrDefault(s => s.Id == id);
        }
    }
}