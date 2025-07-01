✅ Step-by-Step: Run ASP.NET Core EF Project from GitHub on Another Device
📦 1. Prerequisites (Install First)
Ensure the target device has the following installed:

✅ Visual Studio 2022 or 2022+
✔ Install the ASP.NET and web development workload.

✅ .NET SDK (6, 7, or 8 — match your project)

✅ SQL Server Express or LocalDB (installed by default with VS)

✅ Git

🧬 2. Clone the Project from GitHub
Open Command Prompt or Git Bash, then run:

bash
Copy
Edit
git clone https://github.com/levi245/Employee.git
cd your-repo-name
Or use GitHub Desktop to clone it.

🧷 3. Open in Visual Studio
Launch Visual Studio

Open the solution file:

File → Open → Project/Solution

Select the .sln file in the cloned folder.

🔗 4. Set Connection String
Check appsettings.json for the connection string:

json
Copy
Edit
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=YourDbName;Trusted_Connection=True;"
}
If you’re using SQL Server Express or another instance, update it accordingly.

Example for SQL Server Express:

json
Copy
Edit
"DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=YourDbName;Trusted_Connection=True;"
🔧 5. Apply Migrations (Create the Database)
In Visual Studio:

Open Tools → NuGet Package Manager → Package Manager Console

Run:

powershell
Copy
Edit
Update-Database
This uses DbContext to create the database schema based on your models.

▶️ 6. Run the App
Press F5 or click the green "Start" button in Visual Studio

App will open in your browser, typically at:
