using AutomatedTellerMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutomatedTellerMachine.Services
{
    public class CheckingAccountService
    {
        private ApplicationDbContext db;

        public CheckingAccountService(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }
            public void CreateCheckingAccount(string fristName, string lastName, 
                string userId, decimal InitialBalance)
        {
            
            var accountNumber = (123456 + db.CheckingAccounts.Count()).ToString
                ().PadLeft(10, '0');
            var CheckingAccount = new CheckingAccount { FirstName = fristName, LastName = lastName, AccountNumber = accountNumber,
                Balance = InitialBalance,
                ApplicationUserId = userId
            };
            db.CheckingAccounts.Add(CheckingAccount);
            db.SaveChanges();
        }
    }
}