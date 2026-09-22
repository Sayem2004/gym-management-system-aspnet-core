# Gym Management System
A web-based Gym Management System built with **ASP.NET Core MVC, C#, Entity Framework Core, SQL Server, and N-Tier Architecture**.
## Features
### User
- User Registration
- User Login
- Session-based Authentication
- User Dashboard
- View Profile
- Edit Profile
- Delete Profile
- Logout
### Trainer
- Add Trainer
- View Trainer List
- Edit Trainer
- Delete Trainer
- Search Trainer
### Package
- Add Package
- View Package List
- Edit Package
- Delete Package
- Assign Package to Trainer
- Display Available Packages on User Dashboard
## Architecture
The project follows **N-Tier Architecture**:

```text
APP
 ├── Controllers
 └── Views

BLL
 ├── DTOs
 ├── Services
 ├── Validations
 └── MapperConfig

DAL
 ├── EF
 │   ├── DbContext
 │   └── Tables
 └── Repos
````

### Application Flow

```text
View
  ↓
Controller
  ↓
Service (BLL)
  ↓
Repository (DAL)
  ↓
Entity Framework Core
  ↓
SQL Server
```
## Database Relationships
```text
User    1 ──────── * Package
Trainer 1 ──────── * Package
Trainer 1 ──────── * Schedule
```
## Technologies Used
* C#
* ASP.NET Core MVC
* .NET 10
* Entity Framework Core
* SQL Server
* AutoMapper
* Bootstrap
* Razor Views
* Git & GitHub
## Design Patterns & Concepts
* N-Tier Architecture
* Repository Pattern
* Service Layer
* DTO Pattern
* AutoMapper
* CRUD Operations
* Entity Framework Core
* Session Authentication
* Database Relationships
* Form Validation
## Main Routes
### User
```text
/Auth/Registration
/Auth/Login
/Auth/Dashboard
/Auth/Profile
/Auth/EditProfile
/Auth/DeleteProfile
/Auth/Logout
```
### Trainer
```text
/Trainer/Index
/Trainer/Create
/Trainer/Edit/{id}
/Trainer/Delete/{id}
```
### Package
```text
/Package/Index
/Package/Create/{id}
/Package/Edit/{id}
/Package/Delete/{id}
```
## How to Run
1. Clone the repository:
```bash
git clone https://github.com/Sayem2004/gym-management-system-aspnet-core.git
```
2. Open the project in **Visual Studio**.
3. Configure the SQL Server connection string in:
```text
appsettings.json
```
4. Restore NuGet packages:
```bash
dotnet restore
```
5. Build the project:
```bash
dotnet build
```
6. Run the application:
```bash
dotnet run
```
## Git Branches
This project uses two branches:
```text
main
development
```
* **development** → Development and testing
* **main** → Stable version
Workflow:

```text
development
     ↓
Testing
     ↓
Pull Request
     ↓
main
```

## Author
**MD. AL-IMRAN SAYEM**
GitHub: [https://github.com/Sayem2004](https://github.com/Sayem2004)
Email: (mdalimransayem@gmail.com)

## Purpose
This project was developed as an academic and learning project to practice **ASP.NET Core MVC, N-Tier Architecture, Entity Framework Core, SQL Server, CRUD operations, authentication, DTOs, Repository Pattern, and Service Layer architecture**.


