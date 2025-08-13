using CTANDAI.CarReservationSystem.Repositories; // For ICarRepository interface
using Newtonsoft.Json;                           // For JSON deserialization
using CTANDAI.CarReservationSystem.Models;       // For Car model
using CTANDAI.CarReservationSystem;              // For Constants (API URL)

namespace CTANDAI.CarReservationSystem.Services
{
    // Service layer for managing cars
    // Handles importing cars from the API and applying any business logic
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository; // Repository for DB operations
        private readonly HttpClient _httpClient;        // HTTP client for API calls

        // Constructor - inject repository and create HttpClient
        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
            _httpClient = new HttpClient();
        }

        // Import cars from external API and save them to the database
        public async Task<List<Car>> ImportCarsFromApiAsync()
        {
            try
            {
                // Make HTTP GET request to the Cars API
                var response = await _httpClient.GetAsync(Constants.CarsApiUrl);

                // Throw an exception if the HTTP status is not 2xx
                response.EnsureSuccessStatusCode();
                
                // Read the API response content as a string
                var jsonContent = await response.Content.ReadAsStringAsync();

                // Deserialize JSON into a List<Car> object
                var cars = JsonConvert.DeserializeObject<List<Car>>(jsonContent);
                
                // If the API returned cars, save them to the database
                if (cars != null)
                {
                    _carRepository.ImportCarsFromApi(cars); // Persist cars using the repository
                    return cars; // Return the list to the caller
                }
                
                // If no cars returned, return an empty list
                return new List<Car>();
            }
            catch (Exception ex)
            {
                // If any error occurs, log it and return empty list
                Console.WriteLine($"Error importing cars from API: {ex.Message}");
                return new List<Car>();
            }
        }

        // Get all cars from the repository
        public List<Car> GetAllCars()
        {
            return _carRepository.GetAllCars();
        }

        // Get only electric cars
        public List<Car> GetElectricCars()
        {
            return _carRepository.GetElectricCars();
        }

        // Get a car by its ID
        public Car GetCarById(int id)
        {
            return _carRepository.GetCarById(id);
        }
    }
}
