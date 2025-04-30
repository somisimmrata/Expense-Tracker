using System;
using System.Collections.Generic;
using ExpenseTracker.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseTracker.Controllers
{
    [Authorize]
    public class ExpenseController : Controller
    {
        private ExpenseDbContext db = new ExpenseDbContext();

        // GET: Expense/AddExpense
        public ActionResult Create()
        {
            return View();
        }

        // POST: Expense/AddExpense
        [HttpPost]
        public ActionResult Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                // You should add UserId here from Session or Authentication system.
                //expense.UserId = 1; // temporary hardcoded, later dynamic
                //expense.Date = System.DateTime.Now;

                expense.UserId = 1; // Hardcoded for now
                expense.Date = DateTime.Now; // Set date to current


                db.Expenses.Add(expense);
                db.SaveChanges();
                return RedirectToAction("Dashboard", "Home");
            }
            return View(expense);
        }
        //        public ActionResult ExpenseList()
        //        {
        //            var expenses = db.Expenses.ToList();
        //            return View(expenses);
        //}



        // GET: Expense/Edit/5
        public ActionResult Edit(int id)
        {
            var expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // POST: Expense/Edit/5
        [HttpPost]
        public ActionResult Edit(Expense expense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expense).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Dashboard", "Home");
            }
            return View(expense);
        }

        // GET: Expense/Delete/5
        public ActionResult Delete(int id)
        {
            var expense = db.Expenses.Find(id);
            if (expense != null)
            {
                db.Expenses.Remove(expense);
                db.SaveChanges();
            }
            return RedirectToAction("Dashboard", "Home");
        }
    }
}
