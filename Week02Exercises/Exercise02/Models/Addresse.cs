namespace Pascale.Models
{
    public class Addresse
    {
        // Eigenschappen van een adres
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public int PostalCode { get; set; }

        // Constructor → maakt een nieuw adresobject aan
        public Addresse(string streetname, int streetnumber, int postalcode)
        {
            StreetName = streetname;
            StreetNumber = streetnumber;
            PostalCode = postalcode;
        }

        // ToString → bepaalt hoe een adres als tekst wordt weergegeven
        public override string ToString()
        {
            return $"{StreetName} {StreetNumber} {PostalCode}";
        }
    }
}
