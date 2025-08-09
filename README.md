# Employee Management System

## Overview
This project is a backend API built using **.NET 8**, demonstrating **Clean Architecture** principles and implementing the **Repository Pattern** along with the **Unit of Work** pattern using **Entity Framework Core**.   
The solution is divided into multiple layers: Domain, Infrastructure, Application, and WebAPI.  
The project includes features like employee and department management, filtering, sorting, and action logging.

---

## Folder Structure and Layers

- **RepositoryPattern.DomainLayer**  
  Contains domain entities, enums, and repository interfaces.

- **RepositoryPattern.InfrastructureLayer**  
  Contains Entity Framework Core DbContext, migrations, and repository implementations.

- **RepositoryPattern.ApplicationLayer**  
  Contains service interfaces, business logic implementations, DTOs, and AutoMapper profiles.

- **RepositoryPattern.WebAPI**  
  Contains the ASP.NET Core Web API project, controllers, middleware, and startup configuration.

---

## Features

### Employee Management
- Add, edit, delete, and retrieve employees.
- Employee fields include ID, Name, Email, Department, Hire Date, Status (Active/Suspended).
- Supports filtering by name, department, status, hire date range.
- Supports sorting by name or hire date (ascending/descending).

### Department Management
- Add and retrieve departments.
- Each employee is linked to a department.

### Logging
- Middleware logs all create, update, and delete operations on employees.
- Logs are stored in a `LogHistories` table with action type, entity name, entity ID, and timestamp.
- Separate endpoint available to retrieve logs.

---

## Setup Instructions

1. Clone the repository:

   ```bash
   git clone https://github.com/Muh-Fahad/EmployeeManagementSystem.git
