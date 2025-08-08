using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Exercise03.Models;

namespace Exercise03.Repositories
{
    public class BeerRepository
    {
        private readonly string _filePath;
        private static readonly CultureInfo Inv = CultureInfo.InvariantCulture;

        public BeerRepository(string filePath)
        {
            _filePath = filePath;
        }

        public List<Beer> GetAllBeers()
        {
            var beers = new List<Beer>();
            if (!File.Exists(_filePath)) return beers;

            // Read all lines, skip header
            var lines = File.ReadAllLines(_filePath).Skip(1);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                // CSV: Nr;Naam;Brouwerij;Kleur;alcohol
                var parts = line.Split(';');
                if (parts.Length < 5) continue;

                var name = parts[1].Trim();
                var brewery = parts[2].Trim();
                var color = parts[3].Trim();

                // Allow "6,5" or "6.5"
                var alcoholStr = parts[4].Trim().Replace(',', '.');
                if (!decimal.TryParse(alcoholStr, NumberStyles.Any, Inv, out var alcohol)) continue;

                try
                {
                    // Use validating constructor from Beer
                    beers.Add(new Beer(name, brewery, alcohol, color));
                }
                catch (BeerException ex)
                {
                    Console.WriteLine($"FOUT: {ex.Message} (Field: {ex.WrongFieldName}, Value: {ex.WrongValue})");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Onverwachte fout bij parsen bier: {ex.Message}");
                }
            }

            return beers;
        }
    }
}
