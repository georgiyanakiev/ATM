using AutomatedTellerMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private IApplicationDbContext db;

        public TransactionController()
        {
            db = new IApplicationDbContext();
        }
        public TransactionController(IApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        // GET: Transaction/Deposti
        public ActionResult Deposit(int checkingAccountId)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Deposit(Transaction transaction)
        {   
            if (ModelState.IsValid)
            {

            
                db.Transactions.Add(transaction);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return View();
        }

    }
}
