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

🧱 10. Use Case global (vue UML simplifiée)
Employé
 ├── Consulter profil
 ├── Modifier profil
 ├── Consulter bulletins
 │     └── Télécharger PDF
 ├── Voir détail paie
 ├── Gérer compte bancaire
 ├── Se connecter
 └── Recevoir notifications
 | Use Case         | Endpoint               |
| ---------------- | ---------------------- |
| Consulter profil | GET /me                |
| Modifier profil  | PUT /me                |
| Bulletins        | GET /me/payslips       |
| PDF              | GET /payslips/{id}/pdf |
| Banque           | PUT /me/bank           |
| Login            | POST /auth/login       |
