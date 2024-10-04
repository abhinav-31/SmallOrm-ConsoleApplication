using POCO;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Transactions;
using Utils;
namespace DAL
{
    public class UserDAL
    {
        private SqlConnection connection;

        public UserDAL()
        {
            this.connection = Util.getconnection();

        }

        public string loginUser(string email, string password)
        {
            SqlCommand cmd = new SqlCommand("SELECT a.name FROM users u JOIN Account a ON u.userid = a.userid WHERE u.email = @email AND u.password = @password", connection);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                return "Welcome " + reader.GetString(0) + "!!!!!!!!";
            }
            return "Invalid Credentials";

        }

        public void registerUser(string email, string password)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO users(email,password) values(@email,@password)", connection);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            connection.Open();
            int rowsaffected = cmd.ExecuteNonQuery();
            Console.WriteLine("Data inserted !!!!!");
        }

        public List<User> displayUsers()
        {
            SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM users"), connection);
            connection.Open();
            List<User> users = new List<User>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                User user = new User { Email = reader.GetString(1), Userid = reader.GetInt32(0) };
                users.Add(user);
            }
            return users;
        }
        public void deleteUser(string email)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM users WHERE email = @email", connection);
            cmd.Parameters.AddWithValue("@email", email);
            connection.Open();
            int rowsaffected = cmd.ExecuteNonQuery();
            Console.WriteLine("Data deleted !!!!!");
        }

        public int SearchUser(string email)
        {
            SqlCommand cmd = new SqlCommand("SELECT userid FROM users WHERE email = @email", connection);
            cmd.Parameters.AddWithValue("@email", email);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            User user = null;
            while (reader.Read())
            {
                user = new User { Userid = reader.GetInt32(0) };
                return user.Userid;
            }
            return 0;
        }
    }
}
