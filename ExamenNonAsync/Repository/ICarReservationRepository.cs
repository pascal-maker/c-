using CTANDAI.CarReservationSystem.Models;
    using System.Collections.Generic;
namespace CTANDAI.CarReservationSystem.NonAsync.Repositories
{
  

    public interface ICarReservationRepository
    {
        List<CarReservation> GetAllReservations();
        CarReservation GetReservationById(int id);
        void AddReservation(CarReservation reservation);
        void UpdateReservation(CarReservation reservation);

        decimal GetTotalCost();

        void ExportToCsv(string filePath);

    }
}