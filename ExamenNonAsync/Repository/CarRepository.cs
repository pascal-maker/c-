using CTANDAI.CarReservationSystem.Models; // To use the Car model
using MySql.Data.MySqlClient;               // For MySQL database connections and commands

namespace CTANDAI.CarReservationSystem.NonAsync.Repositories
{
    // Repository class for interacting with the Cars table in the database
    public class CarRepository : ICarRepository
    {
        // Holds the connection string used to connect to MySQL
        private readonly string _connectionString;

        // Constructor - connection string is passed in (dependency injection)
        public CarRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Get ALL cars from the database
        public List<Car> GetAllCars()
        {
            var cars = new List<Car>(); // List to hold the result

            // Create and open a database connection
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                // SQL SELECT query
                var command = new MySqlCommand("SELECT * FROM Cars", connection);

                // ExecuteReader() → Executes a query that returns rows (SELECT)
                // It returns a MySqlDataReader that allows you to read row by row
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read()) // Move through each row
                    {
                        // Map each row to a Car object
                        cars.Add(new Car
                        {
                            Id = reader.GetInt32("Id"),
                            Brand = reader.GetString("Brand"),
                            Model = reader.GetString("Model"),
                            Year = reader.GetInt32("Year"),
                            PricePerDay = reader.GetDecimal("PricePerDay"),
                            Electric = reader.GetBoolean("Electric"),
                            LicensePlate = reader.GetString("LicensePlate")
                        });
                    }
                }
            }

            return cars;
        }

        // Get only cars where Electric = true
        public List<Car> GetElectricCars()
        {
            var cars = new List<Car>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var command = new MySqlCommand("SELECT * FROM Cars WHERE Electric = true", connection);

                // ExecuteReader() is used because we want to retrieve multiple rows from SELECT
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cars.Add(new Car
                        {
                            Id = reader.GetInt32("Id"),
                            Brand = reader.GetString("Brand"),
                            Model = reader.GetString("Model"),
                            Year = reader.GetInt32("Year"),
                            PricePerDay = reader.GetDecimal("PricePerDay"),
                            Electric = reader.GetBoolean("Electric"),
                            LicensePlate = reader.GetString("LicensePlate")
                        });
                    }
                }
            }

            return cars;
        }

        // Get a single car by its ID
        public Car GetCarById(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var command = new MySqlCommand("SELECT * FROM Cars WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id); // Prevent SQL injection

                // ExecuteReader() is used again because we expect a SELECT result
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read()) // If a row exists
                    {
                        return new Car
                        {
                            Id = reader.GetInt32("Id"),
                            Brand = reader.GetString("Brand"),
                            Model = reader.GetString("Model"),
                            Year = reader.GetInt32("Year"),
                            PricePerDay = reader.GetDecimal("PricePerDay"),
                            Electric = reader.GetBoolean("Electric"),
                            LicensePlate = reader.GetString("LicensePlate")
                        };
                    }
                }
            }

            // Return null if no match found
            return null;
        }

        // Import cars from an API list into the database (insert or update)
        public void ImportCarsFromApi(List<Car> cars)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                foreach (var car in cars)
                {
                    // First check if this car already exists
                    var checkCommand = new MySqlCommand("SELECT COUNT(*) FROM Cars WHERE Id = @Id", connection);
                    checkCommand.Parameters.AddWithValue("@Id", car.Id);

                    // ExecuteScalar() → Executes a query and returns the first column of the first row
                    // Here, it's used to get the count of rows that match the given Id
                    var exists = Convert.ToInt32(checkCommand.ExecuteScalar()) > 0;

                    if (exists)
                    {
                        // Update existing car
                        var updateCommand = new MySqlCommand(@"
                            UPDATE Cars 
                            SET Brand = @Brand, Model = @Model, Year = @Year, 
                                PricePerDay = @PricePerDay, Electric = @Electric, LicensePlate = @LicensePlate 
                            WHERE Id = @Id", connection);

                        updateCommand.Parameters.AddWithValue("@Id", car.Id);
                        updateCommand.Parameters.AddWithValue("@Brand", car.Brand);
                        updateCommand.Parameters.AddWithValue("@Model", car.Model);
                        updateCommand.Parameters.AddWithValue("@Year", car.Year);
                        updateCommand.Parameters.AddWithValue("@PricePerDay", car.PricePerDay);
                        updateCommand.Parameters.AddWithValue("@Electric", car.Electric);
                        updateCommand.Parameters.AddWithValue("@LicensePlate", car.LicensePlate);

                        // ExecuteNonQuery() → Used for commands that change data but don’t return rows
                        // Returns the number of affected rows
                        updateCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        // Insert a new car
                        var insertCommand = new MySqlCommand(@"
                            INSERT INTO Cars (Id, Brand, Model, Year, PricePerDay, Electric, LicensePlate) 
                            VALUES (@Id, @Brand, @Model, @Year, @PricePerDay, @Electric, @LicensePlate)", connection);

                        insertCommand.Parameters.AddWithValue("@Id", car.Id);
                        insertCommand.Parameters.AddWithValue("@Brand", car.Brand);
                        insertCommand.Parameters.AddWithValue("@Model", car.Model);
                        insertCommand.Parameters.AddWithValue("@Year", car.Year);
                        insertCommand.Parameters.AddWithValue("@PricePerDay", car.PricePerDay);
                        insertCommand.Parameters.AddWithValue("@Electric", car.Electric);
                        insertCommand.Parameters.AddWithValue("@LicensePlate", car.LicensePlate);

                        // ExecuteNonQuery() is used here because INSERT does not return result rows
                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
// If the reservation does not exist, notify the user