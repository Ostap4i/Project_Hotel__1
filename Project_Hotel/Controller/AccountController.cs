using Project_Hotel.Entity;
using Project_Hotel.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Hotel.Controller
{
    internal class AccountController
    {
        private AccountService accountService = new AccountService();

        public List<Account> getAllAccounts()
        {
            return accountService.getAllAccounts();
        }

        public int createNewAccount(string email, string name, string password)
        {
            return accountService.createNewAccount(email, name, password);
        }

        public Account getAccountById(int id)
        {
            return accountService.getAccountById(id);
        }

        public void updateAccount(int id, string email, string name, string password)
        {
            accountService.updateAccount(id, email, name, password);
        }

        public void deleteAccount(int id)
        {
            accountService.deleteAccount(id);
        }

        public Account login(string name, string password)
        {
            return accountService.login(name, password);
        }
    }
}

    

