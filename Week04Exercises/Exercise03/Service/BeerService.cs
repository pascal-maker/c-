using System;
using System.Collections.Generic;

using System.Globalization;

using System.IO;


using System.Linq;
using beer.Exceptions;

using beer.Models;
using beer.Repositories;

namespace beer.Services
{
    public class BeerService
    {
        private readonly  BeerRepository _repo;

        public BeerService(BeerRepository repo)
        {
            _repo = repo;
        }

        public List<Beer> GetAllBeers()
        {
            return _repo.GetAllBeers();
        }
    }
}
