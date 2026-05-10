# ASP.NETCoreR2DotNetIsmailiaD09

# 🏢 CompanySystem  
### 🔷 ASP.NET Core MVC – 3-Layer Architecture (Repository + Unit Of Work) (.NET 9)

---

## 📌 Project Overview

**CompanySystem** is a structured ASP.NET Core MVC application built using a professional multi-layered architecture.

The goal of this project is to demonstrate:

- ✅ Clean 3-Layer Architecture
- ✅ Repository Pattern
- ✅ Generic Repository
- ✅ Unit of Work Pattern
- ✅ Dependency Injection (DI)
- ✅ Separation of Concerns (SoC)
- ✅ ViewModel Pattern
- ✅ Entity Framework Core
- ✅ Fluent API Configuration
- ✅ Data Seeding
- ✅ Audit Logging

This architecture is scalable and suitable for enterprise-level business systems.

---

# 🏗 Architecture Overview

```
CompanySystem
│
├── CompanySystem.PL    → Presentation Layer
├── CompanySystem.BLL   → Business Logic Layer
└── CompanySystem.DAL   → Data Access Layer
```

---

# 🔁 Application Flow

```
Client Request
      ↓
Controller (PL)
      ↓
Manager (BLL)
      ↓
UnitOfWork (DAL)
      ↓
Repository (DAL)
      ↓
DbContext (EF Core)
      ↓
SQL Server
```

Each layer has a clear and strict responsibility.

---

# 🧩 Layers Explained

---

## 1️⃣ Presentation Layer – `CompanySystem.PL`

### Contains:
- Controllers
- Razor Views

### Responsibilities:
- Handle HTTP Requests
- Perform Model Validation
- Call Business Layer
- Return Views

### Important Rules:
- ❌ No direct DbContext usage
- ❌ No business logic
- ❌ No database queries

Controllers depend ONLY on BLL interfaces.

Example:

```csharp
private readonly IDepartmentManager _departmentManager;
```

---

## 2️⃣ Business Logic Layer – `CompanySystem.BLL`

### Contains:
- Managers
- ViewModels
- Mapping Logic (Domain ↔ ViewModel)

### Responsibilities:
- Business rules implementation
- Data transformation
- Transaction control through UnitOfWork
- Keep Controllers thin

### Why Managers?

Managers act as an abstraction over data access.  
They protect the Presentation Layer from database details.

Example:

```csharp
public IEnumerable<DepartmentReadVM> GetDepartments()
{
    return _unitOfWork.DepartmentRepository
        .GetAll()
        .Select(d => new DepartmentReadVM
        {
            Id = d.Id,
            Name = d.Name
        });
}
```

---

## 3️⃣ Data Access Layer – `CompanySystem.DAL`

### Contains:
- Entities (Domain Models)
- DbContext
- Generic Repository
- Specific Repositories
- UnitOfWork
- Entity Configurations
- Seeding
- Audit Logic

### Responsibilities:
- Communicate with database
- Execute queries
- Track changes
- Save data

---

# 🛠 Design Patterns Used

---

## ✅ Repository Pattern

Abstracts database logic from business logic.

### Interfaces:

- `IGenericRepository<T>`
- `IEmployeeRepository`
- `IDepartmentRepository`

This prevents direct DbContext usage outside DAL.

---

## ✅ Generic Repository

Prevents duplicated CRUD code.

### Implemented Methods:

- `GetAll()`
- `GetById(int id)`
- `Add(T entity)`
- `Delete(T entity)`

Reusable across all entities.

---

## ✅ Unit Of Work Pattern

Coordinates multiple repositories using a single DbContext instance.

```csharp
public interface IUnitOfWork
{
    IEmployeeRepository EmployeeRepository { get; }
    IDepartmentRepository DepartmentRepository { get; }
    void Save();
}
```

### Benefits:

- Single transaction boundary
- Centralized SaveChanges()
- Cleaner architecture
- Better scalability

---

## ✅ Dependency Injection

Services are registered using extension methods.

### DAL Registration

```csharp
services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

services.AddScoped<IEmployeeRepository, EmployeeRepository>();
services.AddScoped<IDepartmentRepository, DepartmentRepository>();
services.AddScoped<IUnitOfWork, UnitOfWork>();
```

### BLL Registration

```csharp
services.AddScoped<IDepartmentManager, DepartmentManager>();
services.AddScoped<IEmployeeManager, EmployeeManager>();
```

This ensures loose coupling and testability.

---

# 🗄 Database Layer

## Database Provider
- SQL Server

## ORM
- Entity Framework Core

---

## 📦 Entities

### Department

| Property | Type |
|----------|------|
| Id | int |
| Name | string |
| CreatedAt | DateTime |
| UpdatedAt | DateTime? |

Relationship:
- One Department → Many Employees

---

### Employee

| Property | Type |
|----------|------|
| Id | int |
| Name | string |
| Age | int |
| Salary | decimal(8,2) |
| DepartmentId | int |
| CreatedAt | DateTime |
| UpdatedAt | DateTime? |

Relationship:
- Many Employees → One Department

---

# 🔎 Audit Logging

Audit logic implemented inside `AppDbContext`.

```csharp
foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
{
    if (entry.State == EntityState.Added)
        entry.Entity.CreatedAt = DateTime.UtcNow;

    if (entry.State == EntityState.Modified)
        entry.Entity.UpdatedAt = DateTime.UtcNow;
}
```

All auditable entities implement:

```csharp
public interface IAuditableEntity
{
    DateTime CreatedAt { get; set; }
    DateTime? UpdatedAt { get; set; }
}
```

---

# 🌱 Data Seeding

Seeded inside `OnModelCreating()`:

- Default Departments
- Default Employees

Useful for:
- Development
- Testing
- Demonstration

---

# 📌 Features

## Department Module

- View All Departments
- View Department Details
- Create Department
- Edit Department
- Delete Department

## Employee Module

- View All Employees
- View Employee Details
- Create Employee
- Assign Employee to Department

---

# 🚀 How To Run

### 1️⃣ Configure Connection String

Inside `appsettings.json`:

```json
"ConnectionStrings": {
  "CompanySystem": "Server=.;Database=CompanySystemDB;Trusted_Connection=True;"
}
```

---

### 2️⃣ Apply Migrations

```
Add-Migration InitialCreate
Update-Database
```

---

### 3️⃣ Run Application

```
dotnet run
```

or press **F5** in Visual Studio.

---

# 🧠 Architectural Principles Applied

- Separation of Concerns
- Dependency Inversion Principle
- Single Responsibility Principle
- DRY Principle
- Layered Architecture
- Loose Coupling
- Clean Code Structure

---

# 🧪 Testing Strategy (Future)

- Mock IUnitOfWork
- Test Managers independently
- Use InMemory Database for integration tests

---

# 🏆 Project Level Assessment

This project demonstrates:

- Solid understanding of ASP.NET Core
- Clean architecture thinking
- Proper pattern usage
- Enterprise-ready structure

Suitable for:
- Mid-Level Developer Portfolio
- Real-world Business Systems
- Scalable Web Applications

---

# 👨‍💻 Author

Mohamed Hatem  
Software Engineer

---