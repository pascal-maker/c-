using CTANDAI.CarReservationSystem.Models;

namespace CTANDAI.CarReservationSystem.NonAsync.Services
{
    public interface ICarService
    {
        List<Car> ImportCarsFromApi();
        // In the interface → It says every service must be able to import a list of cars from an API (synchronous version).
        List<Car> GetAllCars();
        // In the implementation → You actually write the business logic to import those cars.
        List<Car> GetElectricCars();
        // Get only electric cars
        Car GetCarById(int id);
        // Get car by ID
    }
}
