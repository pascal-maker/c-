namespace smartphones.models;

public class SmartPhone 
{
    public int Id {get;set;}

    public string  Brand {get;set;}

    public string Type {get;set;}

    public int ReleaseYear {get;set;}

     public int StartPrice {get;set;}

    public string  OperatingSystem {get;set;}

    public SmartPhone () {}

    public SmartPhone(int id,string brand , string type, int releaseyear,int startprice,string operatingsystem)
    {
        Id = id;
        Brand = brand;
        Type = type;
        ReleaseYear  = releaseyear;
        StartPrice   = startprice;
        OperatingSystem = operatingsystem;



    }


    public   override string ToString()
    {
        return $" The smartphone has an id: {Id},Brand:{Brand}, Type: {Type},ReleaseYear:{ReleaseYear},StartPrice:{StartPrice},OperatingSytem:{OperatingSystem}";
    }
    
















}