
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ExpenseTracker.Models;

namespace ExpenseTracker.Controllers
{
    public class HomeController : Controller
    {
        private ExpenseDbContext db = new ExpenseDbContext();

        // ✅ Home Page
        public ActionResult Index()
        {
            return View();
        }

        // ✅ Dashboard Page
        public ActionResult Dashboard()
        {
            // Get expenses for the hardcoded user
            var expenses = db.Expenses.Where(e => e.UserId == 1).ToList();

            // Total expenses
            ViewBag.TotalExpense = expenses.Sum(e => e.Amount);

            // Recent expenses
            ViewBag.RecentExpenses = expenses.OrderByDescending(e => e.Date).Take(5).ToList();

            // ✅ Pie Chart: Expense breakdown by category
            var categoryData = expenses
                .GroupBy(e => e.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    Total = g.Sum(e => e.Amount)
                }).ToList();

            ViewBag.CategoryLabels = Newtonsoft.Json.JsonConvert.SerializeObject(categoryData.Select(c => c.Category));
            ViewBag.CategoryTotals = Newtonsoft.Json.JsonConvert.SerializeObject(categoryData.Select(c => c.Total));

            // ✅ Bar Chart: Expense totals by month
            var monthlyData = expenses
                .GroupBy(e => e.Date.ToString("MMM yyyy")) // Example: "Apr 2025"
                .Select(g => new
                {
                    Month = g.Key,
                    Total = g.Sum(e => e.Amount)
                })
                .OrderBy(x => x.Month).ToList();

            ViewBag.MonthLabels = Newtonsoft.Json.JsonConvert.SerializeObject(monthlyData.Select(m => m.Month));
            ViewBag.MonthTotals = Newtonsoft.Json.JsonConvert.SerializeObject(monthlyData.Select(m => m.Total));

            return View();
        }
    }
}
