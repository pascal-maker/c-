using MySql.Data.MySqlClient;
using System.Globalization;
using CTAndAI.CarReservationSystem.Models;
using CTAndAI.CarReservationSystem.Repositories;
namespace CTAndAI.CarReservationSystem.Repositories;

public interface Reservation : IReservationRepository
{

    private const string _connectionString = "server=localhost;database=advancedsoftwarenegineering;user=root;password=9370;SslMode=None;AllowPublicKeyRetrieval=True";


    public void Add(Reservations reservation)
    {
        MySqlConnection connection = new MySqlConnection(_connectionString);
        connection.Open();

        MySqlCommand cmd = new MySqlCommand("INSERT INTO Reservations( ReservationId ,RoomId,CustomerName,Duration ,Cost ");
        cmd.Parameters.AddWithValue("@ReservationId", reservation.ReservationId);
        cmd.Parameters.AddWithValue("@RoomId", reservation.RoomId);
        cmd.Parameters.AddWithValue("@CustomerName", reservation.CustomerName);
        cmd.Parameters.AddWithValue("@Duration", reservation.Duration);
        cmd.Parameters.AddWithValue("@Cost", reservation.Cost);
        cmd.ExecuteNonQuery();
        connection.Close();
    }

    public List<Reservations> ShowCurrentReservations()
    {
        List<Reservations> reservation = new List<Reservations>();
        try
        {
            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM Reservations", connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                reservation.Add(new Reservations
                {
                    ReservationId = reader.GetInt32("ReservationId"),
                    RoomId = reader.GetInt32("RoomId"),
                    CustomerName = reader.GetString("Age"),
                    Duration = reader.GetInt32("Duration"),
                    Cost = reader.GetDecimal("`Cost")
                });
            }
            connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return reservation;
    }
        
            
        
        
            









}







    


