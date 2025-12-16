using Microsoft.Data.SqlClient;
namespace mvc_project.Services
{
    public class UserService
    {
        public void GetUser(string username)
        {
            var connectionString =
                "Server=localhost;Database=TestDb;Trusted_Connection=True;";

            // ❌ SQL Injection vulnerability
            string query = "SELECT * FROM Users WHERE Username = '" + username + "'";

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand(query, connection);

            connection.Open();
            command.ExecuteReader();
        }
    }

}