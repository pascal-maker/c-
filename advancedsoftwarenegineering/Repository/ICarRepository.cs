namespace CTAndAI.CarReservationSystem.Repositories
{
    public interface ICarRepository
    {
        List<Car> GetAllCars();
        List<Car> GetElectricCars();
        Car GetCarById(int id);
        void AddCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(int id);
        void ImportCarsFromApi(List<Car> cars);
    }
} 