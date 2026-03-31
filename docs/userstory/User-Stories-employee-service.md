Excellent — là tu passes en **mode produit + qualité (niveau CTO / équipe pro)** 🔥
On va structurer :

1. ✅ **User Stories réalistes (SaaS paie)**
2. 🧪 **Plan de tests unitaires**
3. 🔁 **Approche TDD concrète en .NET**

---

# 🧠 1. User Stories du `employee-service`

👉 Ton service doit répondre à des besoins métier RH.

---

## 🔷 🎯 EPIC : Gestion des employés

---

## ✅ US1 — Créer un employé

**En tant que** RH
**Je veux** créer un employé
**Afin de** gérer sa paie

### Critères d’acceptation :

* prénom obligatoire
* email unique
* salaire > 0

---

## ✅ US2 — Voir la liste des employés

**En tant que** RH
**Je veux** voir tous les employés
**Afin de** gérer l’effectif

---

## ✅ US3 — Voir un employé

* par ID
* retourner 404 si inexistant

---

## ✅ US4 — Modifier un employé

* modifier salaire
* modifier infos personnelles

---

## ✅ US5 — Désactiver un employé

👉 important pour paie

* soft delete (`IsActive = false`)
* ne plus apparaître dans payroll

---

## ✅ US6 — Rechercher un employé

* par nom
* par email

---

## 🔥 BONUS (niveau SaaS)

* multi-entreprise (`company_id`)
* pagination
* audit logs

---

# 🧪 2. Plan de tests unitaires

👉 On teste **la logique métier**, pas le controller.

---

## 🔷 Ce qu’on teste :

| Fonction       | Test                 |
| -------------- | -------------------- |
| CreateEmployee | valide / invalide    |
| Email unique   | doublon refusé       |
| Salary         | > 0                  |
| Update         | modifie bien         |
| Delete         | désactive            |
| Get            | retourne bon employé |

---

# 🧱 3. Structure TDD

👉 Ajouter un projet test :

```bash
dotnet new xunit -n EmployeeService.Tests
dotnet add EmployeeService.Tests reference employee-service
```

---

# 🔁 4. Approche TDD (cycle)

👉 Toujours :

```text
RED → GREEN → REFACTOR
```

1. ❌ écrire test (échoue)
2. ✅ écrire code minimum
3. 🔧 améliorer

---

# 🧪 5. Exemple concret (TDD)

## 🔴 Étape 1 — Test (CreateEmployee)

```csharp
using Xunit;

public class EmployeeServiceTests
{
    [Fact]
    public void Should_Create_Employee_When_Data_Is_Valid()
    {
        var service = new EmployeeService();

        var employee = service.Create(
            "Seydou",
            "Mane",
            "test@mail.com",
            500000
        );

        Assert.NotNull(employee);
        Assert.Equal("Seydou", employee.FirstName);
    }
}
```

👉 Ce test va échouer ❌

---

## 🟢 Étape 2 — Implémentation

```csharp
public class EmployeeService
{
    public Employee Create(string firstName, string lastName, string email, decimal salary)
    {
        return new Employee
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            BaseSalary = salary
        };
    }
}
```

👉 Test passe ✅

---

## 🔴 Test validation salaire

```csharp
[Fact]
public void Should_Throw_When_Salary_Is_Zero()
{
    var service = new EmployeeService();

    Assert.Throws<ArgumentException>(() =>
        service.Create("A", "B", "test@mail.com", 0)
    );
}
```

---

## 🟢 Implémentation

```csharp
if (salary <= 0)
    throw new ArgumentException("Salary must be greater than zero");
```

---

# 🔥 6. Test email unique (important)

👉 Simuler repository :

```csharp
[Fact]
public void Should_Throw_When_Email_Already_Exists()
{
    var repo = new FakeEmployeeRepository();
    var service = new EmployeeService(repo);

    repo.Add(new Employee { Email = "test@mail.com" });

    Assert.Throws<Exception>(() =>
        service.Create("A", "B", "test@mail.com", 1000)
    );
}
```

---

# 🧱 7. Fake Repository (mock simple)

```csharp
public class FakeEmployeeRepository
{
    private readonly List<Employee> _employees = new();

    public void Add(Employee employee)
    {
        _employees.Add(employee);
    }

    public bool Exists(string email)
    {
        return _employees.Any(e => e.Email == email);
    }
}
```

---

# 🧠 8. Bonnes pratiques TDD

👉 Toujours :

✔ tester logique métier (pas controller)
✔ tests rapides
✔ indépendants
✔ lisibles

---

# 🔥 9. Outils recommandés

* xUnit (tests)
* FluentAssertions (plus lisible)
* Moq (mock avancé)

---

# 💡 10. Exemple FluentAssertions

```csharp
employee.FirstName.Should().Be("Seydou");
```

---

# 🚀 11. Résultat attendu

Avec TDD :

✅ moins de bugs
✅ code propre
✅ refactor facile
✅ qualité production

---

# 🔥 Conclusion CTO

👉 Le `employee-service` doit être :

* piloté par les **User Stories**
* sécurisé par **tests unitaires**
* construit avec **TDD**

---

# 🚀 Prochaine étape

👉 On peut maintenant :

1️⃣ 🔥 Ajouter FluentValidation (validation pro)
2️⃣ 🔐 Ajouter Auth (JWT + roles RH)
3️⃣ 🧪 Implémenter tests complets
4️⃣ 💰 Connecter au Payroll Service

---
