namespace Pascale.Models;

public class Addresse
{
    public string StreetName { get; set; }

    public int StreetNumber { get; set; }

    public int PostalCode { get; set; }


    public Addresse(string streetname, int streetnumber, int postalcode)
    {
        StreetName = streetname;
        StreetNumber = streetnumber;
        PostalCode = postalcode;

    }


    public override string ToString()
    {
        return $" {StreetName},{StreetNumber},{PostalCode}";
    }
}
