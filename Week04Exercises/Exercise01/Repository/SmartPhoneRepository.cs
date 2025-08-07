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

        public void AddSmartphone(Smartphone phone)

        {
            using var writer = File.AppendText(_filePath);
            writer.WriteLine($"{phone.Id},{phone.Brand},{phone.Type},{phone.ReleaseYear},{phone.StartPrice},{phone.OperatingSystem}");
        }

        public Smartphone? GetSmartphoneById(int id)
        {
            return GetSmartphones().FirstOrDefault(s => s.Id == id);
        }
    }
}