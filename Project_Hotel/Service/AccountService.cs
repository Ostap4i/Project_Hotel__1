using Project_Hotel.Entity;
using Project_Hotel.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Hotel.Service
{
    internal class AccountService
    {
        string connectionString = "ostapserver.database.windows.net,1433;" +
     "Initial Catalog=Testdb;Persist Security Info=False;User ID=CloudSA713bc2aa;Password=ITstep123;" +
     "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" +
     "Pooling=true; Max Pool Size=10; Min Pool Size=2";

        //string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DB1_connectionString"].ConnectionString.ToString();

        private AccountRepository accountRepository = new AccountRepository();
        public List<Account> getAllAccounts()
        {
            List<Account> accounts = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    accounts = accountRepository.getAllAccounts(connection);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return accounts;
        }


        // Get Account by ID
        public Account getAccountById(int id)
        {
            Account account = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    account = accountRepository.getAccountById(connection, id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return account;
        }


        // Create new Account
        public int createNewAccount(string email, string name, string password)
        {
            int id = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    accountRepository.createNewAccount(connection, name, email, password);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return id;
        }


        // Update Account
        public void updateAccount(int id, string email, string name, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Account account = accountRepository.getAccountById(connection, id);
                    if (account != null)
                    {
                        accountRepository.updateAccount(connection, id, name, email, password);
                    }
                    else
                    {
                        throw new Exception("\t\tThis account not exist\n\n");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        // Delete Account
        public void deleteAccount(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Account account = accountRepository.getAccountById(connection, id);
                if (account != null)
                {
                    accountRepository.deleteAccount(connection, id);
                }
                else
                {
                    throw new Exception("\t\tThis account not exist\n\n");
                }
            }
        }


        // Login into Account
        public Account login(string name, string password)
        {
            Account account;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                account = accountRepository.login(connection, name, password);
            }
            return account;
        }
    }
}
    

