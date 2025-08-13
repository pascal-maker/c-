namespace CTANDAI.CarReservationSystem.Service
{
    using CTANDAI.CarReservationSystem.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICarReservationService
    {
        void AddReservation(string CustomerName, int duration, bool ElectricRequired, int CarId);
        //add reservation we need different paramters for it
        List<CarReservation> GetAllReservations();
        // we need to get all reservations
        CarReservation GetReservationById(int id);
        // we need to get reservation by id
        void UpdateReservation(int id, string CustomerName, int duration, bool ElectricRequired, int CarId);
        // we need to update reservation by id
        decimal GetTotalCost();
        // we need to get total cost of all reservations
    }
}