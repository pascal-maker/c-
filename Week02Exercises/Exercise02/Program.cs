using Pascale.Models;
Addresse a1  = new Addresse("gerard willemotlaan", 24, 9030);
Addresse a2 = new Addresse("youranus", 69, 666);
List<string>  EmailAdresses  = new List<string> { "pascal-musa@hotmail.com", "joseph-musa@hotmail.com" };
List<string> PhoneNumbers = new List<string> { "05737474757", "95857573747", "9487575754785" };
Person p1 = new Person("musabyimana", "pascal", 23, new List<Addresse> { a1 }, EmailAdresses, PhoneNumbers);
Person p2 = new Person("musabyimana", "rilw", 83, new List<Addresse> { a2, a1 }, EmailAdresses, PhoneNumbers);

p1.Introduce();
p2.Introduce();



