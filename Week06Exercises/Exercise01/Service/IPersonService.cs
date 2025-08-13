using Exercise01.Models;

namespace Exercise01.Service
{
    public interface IPersonService
{
    void AddPerson(Person person);

    void UpdatePerson(Person person);
    void DeletePerson(int Id);

    void GetPersonById(int Id);
    List<Person> GetAllPersons();


}
}
