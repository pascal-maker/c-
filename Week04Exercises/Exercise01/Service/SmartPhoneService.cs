using Ct.Ai.Models;
using Ct.Ai.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ct.Ai.Services
{
    public class SmartPhoneService
    {
        private readonly SmartPhoneRepository _repo; // Use Ct.Ai.Repositories.SmartPhoneRepository

        public SmartPhoneService(SmartPhoneRepository repo) // Correct type
        {
            _repo = repo;
        }
        // private readonly SmartphoneRepository _repo; stores fixed reference to the repository the service can call it later. the constuctor receives the repository from outside instead of creating it inside the service use all service methods call_repo to actually read/write data

        public List<Smartphone> GetAll() => _repo.GetSmartphones();

        public List<Smartphone> Search(string keyword)
        {
            return _repo.GetSmartphones()
                .Where(s => s.Brand.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                         || s.Type.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        //**Summary of the Smartphone Search Method**

        //The method searches for smartphones in a repository by **brand** or **type** using the following steps:
        //1. **Retrieve Data**: Calls `_repo.GetSmartphones()` to fetch all smartphones from a CSV file as a list of `Smartphone` objects.
        //2. **Filter Results**: Uses `.Where(...)` to filter the list, keeping only smartphones where the **brand** or **type** contains the search keyword (case-insensitive).
        //3. **Return List**: Converts the filtered results to a `List<Smartphone>` using `.ToList()` for easy use by the caller.

        //**Example**: Searching for `"iPhone"` returns all smartphones where the brand or type contains `"iPhone"` (ignoring case).


        public void Add(Smartphone phone)
        {
            var all = _repo.GetSmartphones();
            phone.Id = all.Max(p => p.Id) + 1;
            _repo.AddSmartphone(phone);
        }
    }
      

      //It gets all smartphones, determines the next available ID, assigns it to the new smartphone, and then saves it.
    
}