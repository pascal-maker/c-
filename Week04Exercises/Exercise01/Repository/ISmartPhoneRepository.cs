using smartphones.models;

namespace smartphones.repositories;

public interface ISmartPhoneRepository
{
    List<SmartPhone> GetSmartPhones();

    void AddSmartPhone(SmartPhone smartphone);
    //we retoruenren niks daarmee void

    SmartPhone? GetSmartPhoneById(int id);

    SmartPhone? GetSmartPhoneByBrand(string brand);

    SmartPhone? GetSmartPhoneByType(string type);





}
