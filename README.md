### 🌦️ Weather Forecast API with SQL Database

A modern .NET Web API for managing and retrieving weather data, backed by a SQL Server database and designed for cloud deployment on Azure.

#### 📌 Overview

This project is a RESTful Web API built using .NET (Minimal APIs) that provides endpoints to manage and retrieve weather-related data. It integrates with a SQL Server database using Entity Framework Core (Code-First approach).

The application is designed with simplicity and scalability in mind and can be easily deployed to cloud environments such as Azure.

#### 🚀 Features
* RESTful API for weather data
* SQL Server database integration
* Minimal API architecture (lightweight & fast)
* Entity Framework Core (Code-First + Migrations)
* Azure deployment support (App Service + Azure SQL)
* Configurable environment-based settings

#### 🏗️ Architecture
`` Client → API Endpoints → Services → EF Core → SQL Database ``

#### 🔐 Key Components
* **Minimal API** – Lightweight HTTP endpoints
* **Entity Framework Core** – ORM for database interaction
* **SQL Server** – Relational database
* **Azure App Service** – API hosting
* **Azure SQL Database** – Cloud database backend

#### 🛠️ Technologies Used
* .NET 10 (ASP.NET Core Web API)
* Entity Framework Core
* SQL Server
* Azure App Service
* Azure SQL Database

#### 📂 Project Structure
* **Program.cs** – Entry point (Minimal API configuration)
* **Models/** – Contains domain models/entities
* **Data/** – Includes DbContext and database configuration
* **Migrations/** – EF Core migration files
* **appsettings.json** – Configuration file (connection strings, environment settings)
* **\*.sln** – Solution file for Visual Studio


---

## ⚙️ Getting Started

### Prerequisites

* .NET SDK (v9 or later)
* SQL Server (LocalDB or full instance)
* Visual Studio / VS Code

---

### 🔧 Installation

1. Clone the repository:

```bash
git clone https://github.com/hansamaligamage/Weather-API.git
cd Weather-API
```
2. Restore dependencies:
```bash
dotnet restore
```
3. Update database connection string in ``` appsettings.json ```

4. Apply migrations:
```bash
dotnet ef database update
```
5. Run the project:
```bash
dotnet run
```
### 🔌 API Endpoints
| Method | Endpoint      | Description            |
| ------ | ------------- | ---------------------- |
| GET    | /weather      | Get all weather data   |
| GET    | /weather/{id} | Get weather by ID      |
| POST   | /weather      | Add new weather record |
| PUT    | /weather/{id} | Update weather record  |
| DELETE | /weather/{id} | Delete weather record  |

### ☁️ Deployment to Azure

This project can be deployed using:

* Azure App Service – Hosts the API
* Azure SQL Database – Stores application data

Deployment can be done directly from Visual Studio or CLI.

### 🔐 Database Authentication Setup (Azure SQL)

When deploying the API to Azure App Service and migrating a local SQL Server database to Azure SQL Database, the default authentication method is:

#### 👉 Microsoft Entra (Azure AD) authentication

However, for many applications—especially when running Entity Framework Core migrations—it is often easier to use:

#### 👉 SQL Server authentication (username & password)

### 🧾 Steps to Configure SQL Authentication
* Go to the Azure Portal
* Navigate to your Azure SQL Database
* Open the Query Editor
* Log in using an admin account

### ➕ Create a SQL User
Run the following command:
```SQL
CREATE USER weatherapp_user WITH PASSWORD = '<Your Password>';
```

### 🔑 Grant Required Permissions
To enable migrations and full database access:
```SQL
ALTER ROLE db_datareader ADD MEMBER weatherapp_user;
ALTER ROLE db_datawriter ADD MEMBER weatherapp_user;
ALTER ROLE db_ddladmin ADD MEMBER weatherapp_user;
```
### ⚙️ Update Connection String
Update your ``` appsettings.json ``` :
```JSON
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your-server.database.windows.net;Database=your-db;User Id=weatherapp_user;Password=<Your Password>;TrustServerCertificate=True;"
  }
}
```

### ✅ Result
* API uses SQL authentication instead of Entra ID
* EF Core migrations run successfully
* Full CRUD access is enabled

### 🔐 Configuration
Main configuration file:
``` appsettings.json ```

### 📈 Future Improvements
* Add authentication (JWT / Identity)
* Implement caching (Redis)
* Add Swagger enhancements
* Integrate external weather APIs
* Add logging & monitoring
