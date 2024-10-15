# 🎟️ Ticket Management API

A simple web application for managing tickets using .NET 8 and SQLite. This project implements CRUD functionality with sorting and filtering.

## 🚀 Getting Started I'm Mouad Amzil :)

Follow these steps to set up the backend on your machine.

### Prerequisites

Make sure you have the following installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022 or later](https://visualstudio.microsoft.com/downloads/) (with ASP.NET and web development workload)
- [SQLite](https://www.sqlite.org/download.html) (optional, if not using built-in SQLite)

### 📥 Clone the Repository

Open your terminal and clone the repository:

```bash
git clone https://github.com/MouadAmzil/ticket-management-api.git
```
###  📁 Navigate to the Project Directory

```bash
cd ticket-management-api
```
### 🔧 Restore Dependencies
Run the following command to restore the required packages:

```bash
dotnet restore
```
### ⚙️ Update the Database Connection
Open Program.cs.

Ensure the database connection string is set to use SQLite:
```bash
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=tickets.db"));
```
### 🛠️ Create the Database
Run the following commands to create the initial migration and update the database:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```
### 🏃‍♂️ Run the Application
Start the API with:
```bash
dotnet run
```
The API will be running at http://localhost:5000 (or https://localhost:5001 if you choose to use HTTPS).

### 🌐 API Documentation
You can view the API documentation by navigating to https://localhost:5001/swagger in your web browser.

🤝 Contributing

# AMZIL Was Here 😄 
