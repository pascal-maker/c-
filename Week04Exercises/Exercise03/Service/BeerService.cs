// Import the System namespace for basic functionality
using System;
// Import the System.Collections.Generic namespace for List<T>
using System.Collections.Generic;
// Import the System.Globalization namespace for CultureInfo
using System.Globalization;
// Import the System.IO namespace for file operations
using System.IO;
// Import the System.Linq namespace for LINQ operations
using System.Linq;
// Import the custom exceptions namespace
using beer.Exceptions;
// Import the beer models namespace
using beer.Models;

// Import the beer repositories namespace
using beer.Repositories;

// Define the namespace for beer services
namespace beer.Services
{
    // Define the BeerService class to handle beer business logic
    public class BeerService
    {
        // Private field to store the beer repository dependency
        private readonly BeerRepository _repo;
        // Constructor to initialize the service with a repository
        public BeerService(BeerRepository repo)
        {
            // Assign the provided repository to the private field
            _repo = repo;
        }

        // Method to get all beers by delegating to the repository
        public List<Beer> GetAllBeers()
        {
            // Return all beers from the repository
            return _repo.GetAllBeers();
        }

        // Empty line for spacing

    }
}