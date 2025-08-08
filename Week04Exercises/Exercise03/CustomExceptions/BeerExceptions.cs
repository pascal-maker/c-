using System;
namespace Exercise03.Models
{
     public class BeerException : Exception
     {

      public string WrongFieldName { get; set; }
      public string WrongValue { get; set; }

       public BeerException(string message, string fieldname, string fieldvalue)
        :
        base(message)
        {
         WrongFieldName = fieldname;
         WrongValue = fieldvalue;
        }
    }
}



