using System;
namespace Ct.Ai.Models

{
    public class Multiple
    {
        private string name;
        private string lastname;
        private int age;

        private List<Address> addresses = new List<Address>();

        private List<string> emailaddresses = new List<string>();


        private List<string> phonenumbers = new List<string>();



        public Multiple(string name)
        {
            this.name = name;
        }
        public Multiple(string name, string lastname)
        {
            this.name = name;
            this.lastname = lastname;
        }

        public Multiple(string name, string lastname, int age)
        {

            this.name = name;
            this.lastname = lastname;
            this.age = age;
        }


        public Multiple(string name, string lastname, int age, List<Address> addresses)
        {

            this.name = name;
            this.lastname = lastname;
            this.age = age;
            this.addresses = addresses;
        }


        public Multiple(string name, string lastname, int age, List<Address> addresses, List<string> emailaddresses)
        {

            this.name = name;
            this.lastname = lastname;
            this.age = age;
            this.addresses = addresses;
            this.emailaddresses = emailaddresses;
        }

        public Multiple(string name, string lastname, int age, List<Address> addresses, List<string> emailaddresses, List<string> phonenumbers)
        {

            this.name = name;
            this.lastname = lastname;
            this.age = age;
            this.addresses = addresses;
            this.emailaddresses = emailaddresses;
            this.phonenumbers = phonenumbers;
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }


        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("Age must be between 0 and 120");
                }
                age = value;
            }
        }








        public List<Address> Addresses
        {
            get { return addresses; }
            set { addresses = value; }
        }
        public List<string> EmailAddresses
        {
            get { return emailaddresses; }
            set { emailaddresses = value; }
        }
        public List<string> PhoneNumbers
        {
            get { return phonenumbers; }
            set { phonenumbers = value; }
        }




        public void Introduce()
        {
            Console.WriteLine($"Hello ,my  name is {Name} {LastName} And I am {Age} years old.");
            Console.WriteLine("Addresses:" + string.Join("|", Addresses));
            Console.WriteLine("emails:" + string.Join(",", EmailAddresses));
            Console.WriteLine("Phone Numbers:" + string.Join(",", PhoneNumbers));



        }

        public override string ToString()
        {
            return $"{Name} {LastName} --Age: {Age}" +
            $"{string.Join("|", Addresses)} --" +
            $"{string.Join(",", EmailAddresses)} --" +
            $"{string.Join(",", PhoneNumbers)}";


        }
        


        



        
    }
}