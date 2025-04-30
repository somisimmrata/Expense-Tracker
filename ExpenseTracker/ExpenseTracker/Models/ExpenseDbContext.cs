using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExpenseTracker.Models
{
    public class ExpenseDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }


        public ExpenseDbContext() : base("DefaultConnection")
        {
            // This constructor connects to the connection string
        }
    }
}
