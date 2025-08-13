using Exercise03.Models;
using Exercise03.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise03.Services
{
    public class BeerService
    {
        private readonly BeerRepository _repo; 

        public BeerService(BeerRepository repo) 
        {
            _repo = repo;
        }
        // private readonly SmartphoneRepository _repo; stores fixed reference to the repository the service can call it later. the constuctor receives the repository from outside instead of creating it inside the service use all service methods call_repo to actually read/write data

         public List<Beer> GetAllBeers()
        {
            // Eventueel extra logica, maar hier volstaat:
            return _repo.GetAllBeers();
        }

        

        

      
    }
      

    
}