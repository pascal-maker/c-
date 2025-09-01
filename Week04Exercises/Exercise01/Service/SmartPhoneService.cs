using smartphones.models;
using smartphones.repositories;

namespace smartphones.Services;

public class SmartPhoneService : ISmartPhoneService
{
    private readonly ISmartPhoneRepository _smartphoneRepository;

    public SmartPhoneService(ISmartPhoneRepository smartPhoneRepository)
    {
        _smartphoneRepository = smartPhoneRepository;
    }

    public List<SmartPhone> GetSmartPhones()
    {
        return _smartphoneRepository.GetSmartPhones();
    }

    public SmartPhone? GetSmartPhoneById(int id)
    {
        return _smartphoneRepository.GetSmartPhoneById(id);
    }

    public void AddSmartPhone(SmartPhone smartphone)
    {
        _smartphoneRepository.AddSmartPhone(smartphone);
    }

     public SmartPhone? GetSmartPhoneByBrand(string brand)
    {
        return _smartphoneRepository.GetSmartPhoneByBrand(brand);
    }


     public SmartPhone? GetSmartPhoneByType(string type)
    {
        return _smartphoneRepository.GetSmartPhoneByType(type);
    }







}