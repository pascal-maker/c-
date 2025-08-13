using MySql.Data.MySqlClient;      // For connecting to and executing SQL commands in MySQL
using CsvHelper;                   // For writing data to CSV
using System.Globalization;        // Needed for CSV culture formatting
using CTANDAI.CarReservationSystem.Models; // For the CarReservation model

namespace CTANDAI.CarReservationSystem.NonAsync.Repositories
{
    // Repository for performing CRUD operations on the CarReservations table
    public class CarReservationRepository : ICarReservationRepository
    {
        private readonly string _connectionString; // Connection string to the MySQL DB

        // Constructor - receives the connection string via dependency injection
        public CarReservationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Get all reservations from the CarReservations table
        public List<CarReservation> GetAllReservations()
        {
            var reservations = new List<CarReservation>();

            // Create a new MySQL connection object using the stored connection string
            // This only creates the object; the actual connection is made when .Open() is called
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open(); // Establishes the actual connection to the DB

                // Prepare a SQL query to select all reservations
                var command = new MySqlCommand("SELECT * FROM CarReservations", connection);

                // ExecuteReader() → Runs the SELECT query and returns a MySqlDataReader
                // The reader is used to read each row of the result set
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read()) // Move to the next row
                    {
                        reservations.Add(new CarReservation
                        {
                            Id = reader.GetInt32("Id"),
                            CarId = reader.GetInt32("CarId"),
                            CustomerName = reader.GetString("CustomerName"),
                            Duration = reader.GetInt32("Duration"),
                            Cost = reader.GetDecimal("Cost"),
                            ElectricRequired = reader.GetBoolean("ElectricRequired")
                        });
                    }
                }
            }

            return reservations; // Return the list of reservations
        }

        // Get a single reservation by its ID
        public CarReservation GetReservationById(int id)
        {
            using (var connection = new MySqlConnection(_connectionString)) // Creates connection object
            {
                connection.Open(); // Opens actual DB connection

                var command = new MySqlCommand("SELECT * FROM CarReservations WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader()) // Executes SELECT and reads rows
                {
                    if (reader.Read()) // If a matching row is found
                    {
                        return new CarReservation
                        {
                            Id = reader.GetInt32("Id"),
                            CarId = reader.GetInt32("CarId"),
                            CustomerName = reader.GetString("CustomerName"),
                            Duration = reader.GetInt32("Duration"),
                            Cost = reader.GetDecimal("Cost"),
                            ElectricRequired = reader.GetBoolean("ElectricRequired")
                        };
                    }
                }
            }

            return null;
        }

        // Add a new reservation to the database
        public void AddReservation(CarReservation reservation)
        {
            using (var connection = new MySqlConnection(_connectionString)) // Create connection object
            {
                connection.Open(); // Open DB connection

                var command = new MySqlCommand(
                    "INSERT INTO CarReservations (CarId, CustomerName, Duration, Cost, ElectricRequired) " +
                    "VALUES (@CarId, @CustomerName, @Duration, @Cost, @ElectricRequired)", connection);

                command.Parameters.AddWithValue("@CarId", reservation.CarId);
                command.Parameters.AddWithValue("@CustomerName", reservation.CustomerName);
                command.Parameters.AddWithValue("@Duration", reservation.Duration);
                command.Parameters.AddWithValue("@Cost", reservation.Cost);
                command.Parameters.AddWithValue("@ElectricRequired", reservation.ElectricRequired);

                // ExecuteNonQuery() → Used for INSERT/UPDATE/DELETE (no result set, only affected rows count)
                command.ExecuteNonQuery();
            }
        }

        // Update an existing reservation
        public void UpdateReservation(CarReservation reservation)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var command = new MySqlCommand(
                    "UPDATE CarReservations " +
                    "SET CarId = @CarId, CustomerName = @CustomerName, Duration = @Duration, " +
                    "Cost = @Cost, ElectricRequired = @ElectricRequired " +
                    "WHERE Id = @Id", connection);

                command.Parameters.AddWithValue("@Id", reservation.Id);
                command.Parameters.AddWithValue("@CarId", reservation.CarId);
                command.Parameters.AddWithValue("@CustomerName", reservation.CustomerName);
                command.Parameters.AddWithValue("@Duration", reservation.Duration);
                command.Parameters.AddWithValue("@Cost", reservation.Cost);
                command.Parameters.AddWithValue("@ElectricRequired", reservation.ElectricRequired);

                command.ExecuteNonQuery(); // Runs the UPDATE
            }
        }

        // Calculate the total cost of all reservations
        public decimal GetTotalCost()
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var command = new MySqlCommand(
                "SELECT COALESCE(SUM(Cost), 0) FROM CarReservations", connection);

            // ExecuteScalar() → Executes the query and returns a single value (first column, first row)
            return Convert.ToDecimal(command.ExecuteScalar());
        }

        // Export all reservations to a CSV file
        public void ExportToCsv(string filePath)
        {
            var reservations = GetAllReservations();

            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(reservations); // CsvHelper writes all rows + header
            }
        }
    }
}
