employee-service/
│
├── Domain/
│   ├── Entities/
│   └── Enums/
│
├── Application/
│   ├── DTOs/
│   ├── Interfaces/
│   └── Services/
│
├── Infrastructure/
│   ├── Persistence/
│   └── Repositories/
│
├── API/
│   ├── Controllers/
│   └── Config/
│
└── Program.cs

mkdir -p Domain/Entities
mkdir -p Application/DTOs
mkdir -p Infrastructure/Persistence
mkdir -p API/Controllers

dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Design