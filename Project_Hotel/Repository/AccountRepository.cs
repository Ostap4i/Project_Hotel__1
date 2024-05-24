using Project_Hotel.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Hotel.Repository
{
    internal class AccountRepository
    {
        public List<Account> getAllAccounts(SqlConnection connection)
        {
            //Account account = new Account(1, "Dimon", "dimonch1k@gmail.com", "1234");

            List<Account> accounts = new List<Account>();
            //accounts.Add(account);
            //return accounts;

            string query = "SELECT * FROM Accounts";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string name = Convert.ToString(reader["name"]);
                        string email = Convert.ToString(reader["email"]);
                        string password = Convert.ToString(reader["password"]);

                        Account account = new Account(id, name, email, password);
                        accounts.Add(account);
                    }
                }
            }
            return accounts;
        }
        public Account getAccountById(SqlConnection connection, int id)
        {
            Account account = null;
            string query = "SELECT * FROM Accounts WHERE id = @id";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = Convert.ToString(reader["name"]);
                        string email = Convert.ToString(reader["email"]);
                        string password = Convert.ToString(reader["password"]);

                        account = new Account(id, name, email, password);
                    }
                }
            }
            return account;
        }

        public Account login(SqlConnection connection, string name, string password)
        {
            Account account = null;
            string query = "SELECT * FROM Accounts WHERE name = @name AND password = @password";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = name;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = password;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string email = Convert.ToString(reader["email"]);

                        account = new Account(id, name, email, password);
                    }
                }
            }
            return account;
        }



        public void createNewAccount(SqlConnection connection, string name, string email, string password)
        {
            string query = $"INSERT INTO Accounts (name, email, password) output INSERTED.id " +
                $"VALUES (@name, @email, @password)";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = name;
                cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = email;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = password;
                int id = (int)cmd.ExecuteScalar();
                Console.WriteLine("Inserted row with ID: " + id);
            }
        }

        public void updateAccount(SqlConnection connection, int id, string name, string email, string password)
        {
            string query = $"UPDATE Accounts " +
                $"SET name = @name, email= @email, password = @password " +
                $"WHERE id = @id";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = name;
                cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = email;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = password;
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                cmd.ExecuteNonQuery();
                Console.WriteLine($"Account with ID {id} was successfully updated.");
            }
        }

        public void deleteAccount(SqlConnection connection, int id)
        {
            string query = $"DELETE FROM Accounts " +
                $"WHERE id = @id";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                cmd.ExecuteNonQuery();
                Console.WriteLine($"Account with ID {id} was successfully deleted.");
            }
        }

    }
}
