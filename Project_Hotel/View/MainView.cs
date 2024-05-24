using Project_Hotel.Controller;
using Project_Hotel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Project_Hotel.View
{
    class MainView
    {
        private AccountController accountController = new AccountController();


        public void initialInterface()
        {
            /* Base initial interface(Menu) */

            Console.WriteLine("\t1 - Show all Accounts");
            Console.WriteLine("\t2 - Get Account by ID");
            Console.WriteLine("\t3 - Get Account statistics");
            Console.WriteLine("\t4 - Create new Account");
            Console.WriteLine("\t5 - Update Account by ID");
            Console.WriteLine("\t6 - Delete Account by ID");

            int choice;
            do
            {
                Console.Write("\n\n\tEnter the number: ");
                choice = Int32.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    showAllAccounts();
                }
                else if (choice == 2)
                {
                    getAccountById();
                }
                else if (choice == 3)
                {

                }
                else if (choice == 4)
                {
                    createNewAccount();
                }
                else if (choice == 5)
                {
                    updateAccount();
                }
                else if (choice == 6)
                {
                    deleteAccount();
                }

            } while (choice != 0);
        }

        public void showAllAccounts()
        {
            List<Account> accounts = accountController.getAllAccounts();

            accounts.ForEach(account => Console.WriteLine(
                $"  {account.Id,-3} {account.Name,-10} {account.Email.ToLower(),-20} {account.Password}"));
        }

        public void getAccountById()
        {
            int id;
            Console.Write("\tEnter ID to find Account: ");
            id = Int32.Parse(Console.ReadLine());
            Account account = accountController.getAccountById(id);
            Console.WriteLine($"  Account name: {account.Name} \n" +
                $"  Account email: {account.Email} \n" +
                $"  Account password {account.Password}");
        }

        public void createNewAccount()
        {
            string email = "nothing@gmail.com";
            string name = "Undefined";
            string password = "0000";

            Console.Write("Enter email: ");
            email = Console.ReadLine();

            Console.Write("Enter name: ");
            name = Console.ReadLine();

            Console.Write("Enter password: ");
            password = Console.ReadLine();

            accountController.createNewAccount(email, name, password);
        }

        public void updateAccount()
        {
            int id;
            string email = "nothing@gmail.com";
            string name = "Undefined";
            string password = "0000";

            Console.Write("Enter ID to update Account: ");
            id = Int32.Parse(Console.ReadLine());

            Console.Write("Enter email: ");
            email = Console.ReadLine();

            Console.Write("Enter name: ");
            name = Console.ReadLine();

            Console.Write("Enter password: ");
            password = Console.ReadLine();


            accountController.updateAccount(id, email, name, password);
        }

        public void deleteAccount()
        {
            int id;

            Console.Write("Enter ID to delete Account: ");
            id = Int32.Parse(Console.ReadLine());

            accountController.deleteAccount(id);
        }


    }
}

    
