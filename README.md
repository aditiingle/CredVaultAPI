# CredVaultAPI

CredVault is a credential management API that allows users to store, retrieve, and manage their login credentials for websites they access using a RESTful service.

This is an ASP.NET Core Web API project that demonstrates key backend development concepts such as **Dependency Injection**, **DTO–Domain Model Mapping**, **Entity Framework Core Migrations**, **Asynchronous Programming**, and the **Repository Pattern** — with SQL Server as the database.

---

## Tech Stack ✨

- **Framework:** ASP.NET Core Web API (.NET 8.0)
- **Database:** SQL Server
- **ORM:** Entity Framework Core
- **IDE:** Visual Studio 
- **Language:** C#

---

## Project Structure 🏗️

### 1. Initial Commit: Domain Model
- Created base Web API project using Visual Studio.
- Added `User` and `Credential` domain model classes.

### 2. Database Connection & Migration
- Added SQL Server connection string in `appsettings.json`.
- Registered `CredVaultDbContext` in `Program.cs` using Dependency Injection.
- Ran `Add-Migration` and `Update-Database` to create database schema.



