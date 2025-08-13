using CTANDAI.CarReservationSystem.Models;

namespace CTANDAI.CarReservationSystem.Repositories
{
    public interface ICarRepository
    {
        List<Car> GetAllCars();
        List<Car> GetElectricCars();
        Car GetCarById(int id);
        void ImportCarsFromApi(List<Car> cars);

        //In the interface → It says every repository must be able to import a list of cars from an API.

//In the implementation → You actually write the database logic to save those cars.
    }
}