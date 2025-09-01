using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using beer.Exceptions;
using beer.Models;

namespace beer.Repositories
{
    /// <summary>
    /// BeerRepository - Implementeert data toegang voor Beer objecten
    /// Leest bier data uit een CSV bestand en converteert naar Beer objecten
    /// Volgt het Repository Pattern voor scheiding van data toegang en business logic
    /// </summary>
    public class BeerRepository
    {
        /// <summary>
        /// Pad naar het CSV bestand met bier data
        /// </summary>
        private readonly string _filePath;

        /// <summary>
        /// CultureInfo.InvariantCulture voor consistente decimal parsing
        /// Zorgt ervoor dat decimalen correct worden geparsed ongeacht de locale instellingen
        /// </summary>
        private static readonly CultureInfo inv = CultureInfo.InvariantCulture;//omdecimalen te kunnen lezen

        /// <summary>
        /// Constructor die het pad naar het CSV bestand initialiseert
        /// </summary>
        /// <param name="filePath">Pad naar het CSV bestand</param>
        public BeerRepository(string filePath)
        {
            _filePath = filePath;
        }

        /// <summary>
        /// Haalt alle bieren op uit het CSV bestand
        /// Leest het bestand regel voor regel, parst elke regel naar een Beer object
        /// Handelt fouten af door ze te loggen en door te gaan met de volgende regel
        /// </summary>
        /// <returns>Lijst van alle succesvol geparsede Beer objecten</returns>
        public List<Beer> GetAllBeers()
        {
            // Maak een lege lijst voor de bieren
            var beers = new List<Beer>();

            // Controleer of het bestand bestaat, anders return lege lijst
            if(!File.Exists(_filePath)) return beers;

            // Lees alle regels uit het bestand en sla de header over (Skip(1))
            var lines = File.ReadAllLines(_filePath).Skip(1);

            // Loop door alle regels in het bestand
            foreach (var line in lines)
            {
                // Sla lege regels over
                if(string.IsNullOrWhiteSpace(line)) continue;

                // Split de regel op puntkomma's om de verschillende velden te krijgen
                var parts = line.Split(';');

                // Controleer of er genoeg velden zijn (minimaal 5)
                if(parts.Length < 5) continue;

                // Haal de verschillende velden op en trim whitespace
                var name = parts[1].Trim();
                var brewery = parts[2].Trim();
                var color = parts[3].Trim();
                
                // Converteer komma naar punt voor decimal parsing
                var alcoholStr = parts[4].Trim().Replace(',','.');//omdecimalpartsnaarkomma om te zetten

                // Probeer het alcohol percentage te parsen naar double
                if(!double.TryParse(alcoholStr, NumberStyles.Any, inv, out var alcohol)) continue;

                // Probeer een nieuw Beer object te maken en voeg toe aan de lijst
                try
                {
                    beers.Add(new Beer(name, brewery, alcohol, color));
                }
                // Vang BeerException op (validatie fouten)
                catch (BeerException ex)
                {
                    Console.WriteLine($"Fout: {ex.Message} (Field: {ex.WrongFieldName}) (Value: {ex.WrongValue})");
                }
                // Vang alle andere onverwachte fouten op
                catch (Exception ex)
                {
                    Console.WriteLine($"Onverwachte fout bij het parsen bier: {ex.Message}");
                }
            }

            // Return de lijst met alle succesvol geparsede bieren
            return beers;
        }
    }
}