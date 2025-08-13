using MySql.Data.MySqlClient;
using Exercise01.Models;

namespace Exercise01.Repository
{
    public class PersonRepository : IPersonRepository
    {

        private const string _connectionString = "server=localhost;database=Exercise01;user=root;password=9370;SslMode=None;AllowPublicKeyRetrieval=True";

        public void AddPerson(Person person)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(_connectionString);
                connection.Open();
                MySqlCommand command = new MySqlCommand("INSERT INTO Persons (Id,Name, Age, Email) VALUES (@Id,@Name, @Age, @Email)", connection);
                command.Parameters.AddWithValue("@Id", person.Id);
                command.Parameters.AddWithValue("@Name", person.Name);
                command.Parameters.AddWithValue("@Age", person.Age);
                command.Parameters.AddWithValue("@Email", person.Email);
                command.ExecuteNonQuery();
                connection.Close();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void UpdatePerson(Person person)
        {
            using (MySqlConnection conn = CreateConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE Persons SET Name = @Name, Age = @Age, Email = @Email WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", person.Id);
                cmd.Parameters.AddWithValue("@Name", person.Name);
                cmd.Parameters.AddWithValue("@Age", person.Age);
                cmd.Parameters.AddWithValue("@Email", person.Email);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeletePerson(int Id)
        {
            using (MySqlConnection conn = CreateConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM Persons WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void GetPersonById(int Id)
        {
            using (MySqlConnection conn = CreateConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Persons WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", Id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Console.WriteLine($"Id: {reader.GetInt32("Id")}, Name: {reader.GetString("Name")}, Age: {reader.GetInt32("Age")}, Email: {reader.GetString("Email")}");
                }
                else
                {
                    Console.WriteLine("Person not found.");
                }
            }
        }

        public List<Person> GetAllPersons()
        {
            List<Person> people = new List<Person>();
            try
            {
                MySqlConnection connection = new MySqlConnection(_connectionString);
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM Persons", connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    people.Add(new Person
                    {
                        Id = reader.GetInt32("Id"),
                        Name = reader.GetString("Name"),
                        Age = reader.GetInt32("Age"),
                        Email = reader.GetString("Email")
                    });
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return people;
        }
        

        
        

        private MySqlConnection CreateConnection()
        {
            var connectionString = "server=localhost;database=Exercise01;user=root;password=9370;SslMode=None;AllowPublicKeyRetrieval=True";
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }

    }
}
