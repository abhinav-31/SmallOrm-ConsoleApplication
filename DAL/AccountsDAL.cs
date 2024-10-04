
using Utils;
using POCO;
using System.Security.Principal;
using System.Data.SqlClient;

namespace DAL
{
    public class AccountsDAL
    {
        private SqlConnection connection;

        public AccountsDAL()
        {
            this.connection = Util.getconnection();
        }

        public void registerAccount(long accNumber, string name, string email, long phone, double balance, int userid)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Account(accNumber,name,email,phone,balance,userid) VALUES(@accNumber,@name,@email,@phone,@balance,@userid)", connection);
            cmd.Parameters.AddWithValue("@accNumber", accNumber);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@balance", balance);
            cmd.Parameters.AddWithValue("@userid", userid);
            connection.Open();
            int rowsaffected = cmd.ExecuteNonQuery();
            connection.Close();
        }

        public List<Account> displayAccount(string email)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Account where email = @email", connection);
            cmd.Parameters.AddWithValue("@email", email);
            connection.Open();
            List<Account> users = new List<Account>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Account acc = new Account
                {
                    AccNumber = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Email = reader.GetString(2),
                    Phone = reader.GetString(3),
                    Balance = reader.GetDouble(4)
                };
                users.Add(acc);
            }
            connection.Close();
            return users;
        }

        public List<Account> displayAccounts()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Account", connection);
            connection.Open();
            List<Account> users = new List<Account>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Account acc = new Account
                {
                    AccNumber = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Email = reader.GetString(2),
                    Phone = reader.GetString(3),
                    Balance = reader.GetDouble(4)
                };
                users.Add(acc);
            }
            connection.Close();
            return users;
        }


        public void Deposit(int accNumber, double amount)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Account SET balance = balance + @amount WHERE accNumber = @accNumber", connection);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@accNumber", accNumber);
            connection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            connection.Close();

            if (rowsAffected > 0)
            {
                Console.WriteLine("Deposit successful.");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public bool Withdraw(int accNumber, double amount)
        {
            SqlCommand getBalanceCmd = new SqlCommand("SELECT balance FROM Account WHERE accNumber = @accNumber", connection);
            getBalanceCmd.Parameters.AddWithValue("@accNumber", accNumber);
            connection.Open();
            double currentBalance = (double)getBalanceCmd.ExecuteScalar();
            connection.Close();

            if (currentBalance >= amount)
            {
                SqlCommand cmd = new SqlCommand("UPDATE Account SET balance = balance - @amount WHERE accNumber = @accNumber", connection);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@accNumber", accNumber);
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                connection.Close();

                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Account not found.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
                return false;
            }
        }


    }
}
