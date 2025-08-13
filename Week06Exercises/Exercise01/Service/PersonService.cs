using Exercise01.Repository;
using Exercise01.Models;

namespace Exercise01.Service
{
    public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;


    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public void AddPerson(Person person)
    {
        _personRepository.AddPerson(person);
    }


    public void UpdatePerson(Person person)
    {
        _personRepository.UpdatePerson(person);
    }
    
    public void DeletePerson(int Id)
    {
        _personRepository.DeletePerson(Id);
    }
    

    public void GetPersonById(int Id)
    {
            _personRepository.GetPersonById(Id);
    }

    public List<Person> GetAllPersons()
    {
            return _personRepository.GetAllPersons();
    }




    

   
   



    






}
}
