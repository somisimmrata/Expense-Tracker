# 💸 Expense Tracker - ASP.NET MVC

A web application that allows users to register, login, track their daily expenses, and visualize their financial data through an intuitive dashboard.

---

## 📸 Features

- 🔐 User Registration & Login
- 🧾 Add, Edit & Delete Expenses
- 📊 Dashboard with Monthly Stats (Bar Chart)
- 🚫 Authentication Guard (only logged-in users can add expenses)
- 🎨 Stylish UI with support for image/video backgrounds

---

## 🛠️ Technologies Used

- ASP.NET MVC (C#)
- Entity Framework (Code-First)
- SQL Server
- Razor Views
- HTML, CSS, JavaScript
- Chart.js

---

## 🚀 How to Set Up and Run

### 1. Clone the repository

git clone https://github.com/somisimmrata/ExpenseTracker.git
cd ExpenseTracker

2. Open in Visual Studio
Open ExpenseTracker.sln in Visual Studio

Restore NuGet packages (Visual Studio usually does this automatically)

3. Set up the Database
Update your connection string in Web.config:

xml
Copy
Edit
<connectionStrings>
  <add name="ExpenseDbContext" 
       connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=ExpenseTrackerDB;Integrated Security=True" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
Run the app — EF will create the DB automatically via Code-First.

4. Run the Application
Press Ctrl + F5 or click Start Without Debugging

Register a new user and start tracking expenses

📦 Project Structure
pgsql
Copy
Edit
/Controllers      → C# Controllers for Account, Expense, Home
/Models           → EF Models (User, Expense)
/Views            → Razor Views (Register, Login, Dashboard, etc.)
/Content          → CSS, images, video
/ExpenseTracker.sln → Solution file
/Web.config       → Configuration
📚 Dependencies
Chart.js (CDN via layout)

EntityFramework

ASP.NET MVC (System.Web.Mvc)

.NET Framework 4.x

💡 Tip
To block non-logged-in users from adding expenses, [Authorize] is used in ExpenseController.cs.

👨‍💻 Author
 By Somi Simmrata
