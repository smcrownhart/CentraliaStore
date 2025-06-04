********************************* CentraliaStore Configuration Information *********************************

Clone the CentraliaStore project from GitHub using Visual Studio.


Create a fork of the repository on GitHub:


Navigate to the CentraliaStore repo.


Click "Fork" (top-right).


Make sure you're based on the development branch.


⚠️ In Visual Studio, unclick "Clone only the master branch" so all branches are available.


In Visual Studio, create a new branch off of your fork (e.g., feature/my-update).


Right-click on the CentraliaStore project in Solution Explorer → Click "Manage User Secrets".


Paste the following JSON into the secrets.json file:


{
  "Accounts:AdminEmail": "admin@centraliastore.com",
  "Accounts:AdminPassword": "Admin123!",
  "Accounts:TestUserEmail": "test@centraliastore.com",
  "Accounts:TestUserPassword": "Test123!"
}


In the Package Manager Console, run:

Update-Database

Make your changes:


If changes involve the database (e.g., seed data), run the following in your manage package console or terminal


Add-Migration YourMigrationName
Update-Database


Push your changes to your fork on GitHub.


Create a Pull Request:


Base: development (main repo)


Compare: your branch (forked repo)


🎉 You're all set!



🔁 How to Make Future Changes to an Existing Fork
Create a new branch in your existing fork for each new change (don’t reuse old branches).


Repeat Steps 4–5 (reconfigure user secrets if needed).


Make your changes.


If changes affect the database, repeat:

Add-Migration YourMigrationName
Update-Database
 Then push and create a new pull request.




