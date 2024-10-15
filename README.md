# 🎟️ Ticket Management API
 <img src="./Screenshot 2024-10-15 143245.png"/>

A simple web application for managing tickets using .NET 8 , Angular and SQLite. This project implements CRUD functionality with sorting and filtering.

# 🚀 Getting Started With Back-End

Follow these steps to set up the backend on your machine.

### Prerequisites

Make sure you have the following installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022 or later](https://visualstudio.microsoft.com/downloads/) (with ASP.NET and web development workload)
- [SQLite](https://www.sqlite.org/download.html) (optional, if not using built-in SQLite)

### 📥 Clone the Repository

Open your terminal and clone the repository:

```bash
https://github.com/MouadAmzil/Hahn.git
```
###  📁 Navigate to the Project Directory Backend

```bash
cd Hahn Task
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
The API will run at http://localhost:5000 (or https://localhost:5001 if you choose to use HTTPS).

### 🌐 API Documentation
You can view the API documentation by navigating to https://localhost:5001/swagger in your web browser.

# 🚀 Getting Started With Font-End
## Features
- View a list of tickets.
- Create, edit, and delete tickets.
- Search, filter, and sort tickets.
- Form validation (ensures required fields are filled).
- Uses CORS to allow communication between the frontend and backend.
- Responsive design using Bootstrap and PrimeNG for styling.

## Technologies
Frontend:
- Angular 18 (with standalone components)
- PrimeNG (for table and UI components)
- Bootstrap 5.3.3
- TypeScript
- RxJS
- HTTP Client for API communication

Follow the instructions below to set up both the Angular frontend and the .NET backend.

### Prerequisites

Make sure you have the following installed:

- Node.js (v18 or higher)
- Angular CLI

## Setup Angular
#### 1. Install Dependencies
Navigate to the frontend/ directory in your terminal and run the following command to install the dependencies:

```bash
npm install
```
#### 1. Development Server
Run the following command to start the Angular development server:
```bash
ng serve
```
The Angular application will run at http://localhost:4200 by default.


# AMZIL Was Here 🤝
