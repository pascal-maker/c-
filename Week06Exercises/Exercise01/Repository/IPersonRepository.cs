using Exercise01.Models;

namespace Exercise01.Repository
{

    public interface IPersonRepository
    {
        void AddPerson(Person person);

        void UpdatePerson(Person person);
        void DeletePerson(int Id);



        void GetPersonById(int Id);
        List<Person> GetAllPersons();


    }

}

