using AutomatedTellerMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutomatedTellerMachine.Services
{
    public class CheckingAccountService
    {
        private IApplicationDbContext db;

        public CheckingAccountService(IApplicationDbContext dbContext)
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

        public void UpdateBalance(int checkingAccountId)
        {
            var checkingAccount = db.CheckingAccounts.Where(c => c.Id ==
            checkingAccountId).First();
            checkingAccount.Balance = db.Transactions.Where(c => c.CheckingAccountId ==
            checkingAccountId).Sum(c =>c.Amount);
            db.SaveChanges();
        }
    }
}