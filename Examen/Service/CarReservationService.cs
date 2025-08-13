using CTANDAI.CarReservationSystem.Models;       // For Car and CarReservation models
using CTANDAI.CarReservationSystem.Repositories; // For repository interfaces
using CTANDAI.CarReservationSystem.Service;      // For ICarReservationService interface

namespace CTANDAI.CarReservationSystem.Services
{
    // Service layer for car reservations
    // Acts as a bridge between the UI/Controllers and the repositories
    // Handles business logic before calling the repository methods
    public class CarReservationService : ICarReservationService
    {
        // Repository for handling reservation data (CRUD in CarReservations table)
        private readonly ICarReservationRepository _reservationRepository;

        // Repository for handling car data (checking availability, getting details)
        private readonly ICarRepository _carRepository;

        // Constructor - receives repository implementations via dependency injection
        public CarReservationService(ICarReservationRepository reservationRepository, ICarRepository carRepository)
        {
            _reservationRepository = reservationRepository;
            _carRepository = carRepository;
        }

        // Add a reservation (checks if car exists and matches electric requirement)
        public void AddReservation(string customerName, int duration, bool ElectricRequired, int carId)
        {
            // Retrieve the car details from the repository
            var car = _carRepository.GetCarById(carId);
            if (car == null)
            {
                throw new ArgumentException("Car not found");
            }

            // If electric is required but the car is not electric → throw an error
            if (ElectricRequired && !car.Electric)
            {
                throw new ArgumentException("Electric car required but not available");
            }

            // Calculate total cost = price per day × number of days
            var cost = car.PricePerDay * duration;

            // Create a new reservation object
            var reservation = new CarReservation
            {
                CarId = carId,
                CustomerName = customerName,
                Duration = duration,
                Cost = cost,
                ElectricRequired = ElectricRequired
            };

            // Add the reservation to the database through the repository
            _reservationRepository.AddReservation(reservation);
        }

        // Get all reservations
        public List<CarReservation> GetAllReservations()
        {
            return _reservationRepository.GetAllReservations();
        }

        // Get a single reservation by its ID
        public CarReservation GetReservationById(int id)
        {
            return _reservationRepository.GetReservationById(id);
        }

        // Update an existing reservation (with car availability and electric checks)
        public void UpdateReservation(int id, string customerName, int duration, bool ElectricRequired, int carId)
        {
            // Get the car details first
            var car = _carRepository.GetCarById(carId);
            if (car == null)
            {
                throw new ArgumentException("Car not found");
            }

            // Check electric requirement
            if (ElectricRequired && !car.Electric)
            {
                throw new ArgumentException("Electric car required but not available");
            }

            // Calculate updated cost
            var cost = car.PricePerDay * duration;

            // Create an updated reservation object
            var reservation = new CarReservation
            {
                Id = id, // Keep the same ID
                CarId = carId,
                CustomerName = customerName,
                Duration = duration,
                Cost = cost,
                ElectricRequired = ElectricRequired
            };

            // Update the reservation in the database
            _reservationRepository.UpdateReservation(reservation);
        }

        // Get the total cost of all reservations (uses repository aggregate query)
        public decimal GetTotalCost()
        {
            return _reservationRepository.GetTotalCost();
        }

        // Export all reservations to a CSV file
        public void ExportReservationsToCsv(string filePath)
        {
            _reservationRepository.ExportToCsv(filePath);
        }
    }
}
