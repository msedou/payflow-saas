payroll-service/
│
├── Domain/
│   ├── Entities/
│   └── ValueObjects/
│
├── Application/
│   ├── Services/
│   ├── DTOs/
│   └── Interfaces/
│
├── Infrastructure/
│   └── Persistence/
│
├── API/
│   └── Controllers/


mkdir -p Domain/Entities
mkdir -p Domain/ValueObjects

mkdir -p Application/Services
mkdir -p Application/DTOs
mkdir -p Application/Interfaces

mkdir -p Infrastructure/Persistence
mkdir -p Infrastructure/Repository

mkdir -p API/Controllers

touch Domain/Entities/Payroll.cs
touch Domain/ValueObjects/SalaryBreakdown.cs

touch Application/Services/PayrollService.cs
touch Application/DTOs/RunPayrollDto.cs
touch Application/Interfaces/IPayrollService.cs

touch Infrastructure/Persistence/PayrollDbContext.cs

touch API/Controllers/PayrollController.cs

dotnet new sln -n PayrollService

dotnet new webapi -n PayrollService.API

dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Design

