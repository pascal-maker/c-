using CTAndAI.CarReservationSystem.Models;
using CTAndAI.CarReservationSystem.Repositories;
namespace CTAndAI.CarReservationSystem.Repositories;

public interface IReservationRepository
{

    void Add(Reservations reservation);

    public List<Reservations> ShowCurrentReservations();

    public decimal TotalCostOfReservation(int duration, decimal cost);

    void UpdateReservation(int reservationid, string customername);
    void ExportReservations();






    
}




    
