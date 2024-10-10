# Product Project 

The Product Project App is a powerful Windows application designed to streamline product management for businesses. Built with C# and the .NET framework, this desktop application provides a comprehensive solution for managing products.

## Table of Contents

1. [Prerequisites](#prerequisites)
2. [Installation](#installation)
3. [Configuration](#configuration)
4. [Database Migrations](#database-migrations)
5. [Running the Application](#running-the-application)
6. [Usage](#usage)
8. [Testing](#testing)

## Prerequisites

Before you begin, ensure you have the following installed on your machine:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio 2022 or Visual Studio Code](https://visualstudio.microsoft.com/vs/)

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/AleksaDjorovic21/ProductProject.git
   cd ProductProject
   ```

2. Restore the packages for C# .Net:
   ```bash
   dotnet restore
   ```

3. If you are using Visual Studio Code or Visual Studio 2022, open the solution file (`ProductProject.sln`).

## Configuration

1. **Database Connection:**
   - Open `appsettings.json` in `Products.Api` and set up the database connection:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=<YOUR_SQLSERVER_HOST>;Database=ProductProjectDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
   }
   ```
   - Ensure that the connection string matches your SQL Server configuration.

## Database Migrations 

To apply the database migrations and create the necessary tables, follow these steps:

1. Open your terminal and navigate to the `src/Products.Infrastructure` directory.

2. Run the following command:
   ```bash
   dotnet ef migrations add InitialCreate
   ```

   ```bash
   dotnet ef database update
   ```

This command will create the database and apply all the migrations defined in your application.

## Running the Application

To run the C# .Net part of the application, open your terminal and navigate to the `src/Products.Api` directory.
Than execute the following command in your terminal:
```bash
dotnet build
```

```bash
dotnet run
```

## Usage

1. **Access the Application:**
   - Open your web browser and navigate to `http://localhost:5233`. 

2. **Product Management:**
   - You can create, edit, and delete products.
   - Also you can create categories. 

## Testing

To run the C# .Net tests, open your terminal and navigate to the `tests` directory.
Than execute the following command in your terminal:

```bash
dotnet test
```

