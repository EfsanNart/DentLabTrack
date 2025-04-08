# 🦷 Dental Laboratory Management System

Welcome to the **Dental Laboratory Management System** — a secure, scalable and modular backend application designed to streamline dental lab workflows. This project showcases key enterprise-level practices in .NET development, including multi-layered architecture, authentication & authorization, advanced data handling, and clean code design.

---

## 🛠️ Technologies & Tools

- ASP.NET Core Web API
- Entity Framework Core (Code First)
- ASP.NET Core Identity
- JWT (JSON Web Token)
- Repository & Unit of Work Pattern
- Data Protection API
- Middleware & Action Filters
- FluentValidation
- SQL Server

---

## 🧱 Architecture

This project follows a **3-layered architecture**:

1. **Data Layer**
   - Entity Models
   - `DbContext`
   - Generic Repository
   - Soft Delete logic
2. **Service Layer**
   - Business Logic
   - DTOs (Data Transfer Objects)
   - Transactional operations
   - Unit of Work
3. **Web Layer**
   - RESTful Controllers
   - JWT Authentication & Role-based Authorization
   - Fluent Validation
   - Custom Middleware & Global Exception Handling

---

## 🔐 Authentication & Authorization

- Implemented **JWT-based Authentication**
- Users are authenticated using **ASP.NET Core Identity**
- Role-based **Authorization** is enforced at the Controller level
- Secure password management with **Data Protection API**

---

## 🔁 Many-to-Many Relationship

This system features a well-designed many-to-many relationship between **Orders** and **Technicians**.  
🧑‍🔧 An order can be assigned to multiple technicians, and each technician can work on multiple orders.

To ensure consistency, **transactional handling** is used when adding orders and assigning technicians — either all operations succeed, or none do.

---

## 🧹 Soft Delete

Instead of permanently removing data, a **Soft Delete** mechanism is applied.  
This enhances safety and allows data recovery or administrative review when needed.

---

## ✅ Model Validation

All incoming data is validated using **FluentValidation** to ensure clean and consistent data input.

---

## 🔄 Dependency Injection

All services and repositories are injected using the built-in **Dependency Injection** mechanism for better testability and flexibility.

---

## ⚙️ Custom Middleware & Filters

- Custom Middleware for **global exception handling** and request logging
- **Action Filters** for centralized model validation and cross-cutting concerns

---

## 🔧 RESTful API Endpoints

### 🔐 Auth
- `POST /api/Auth/Register` – Register a new user  
- `POST /api/Auth/Login` – User login  
- `GET /api/Auth/Me` – Get current authenticated user info

### 🧑‍⚕️ Doctors
- `POST /api/Doctors` – Add a new doctor  
- `GET /api/Doctors` – Get all doctors  
- `GET /api/Doctors/{id}` – Get doctor by ID  
- `PUT /api/Doctors/{id}` – Update doctor by ID  
- `DELETE /api/Doctors/{id}` – Delete doctor by ID

### 🔬 LabTechnicians
- `POST /api/LabTechnicians` – Add a new lab technician  
- `GET /api/LabTechnicians` – Get all lab technicians  
- `GET /api/LabTechnicians/{id}` – Get lab technician by ID  
- `PUT /api/LabTechnicians/{id}` – Update lab technician by ID  
- `DELETE /api/LabTechnicians/{id}` – Delete lab technician by ID

### 📆 Orders
- `GET /api/Orders/{id}` – Get order by ID  
- `DELETE /api/Orders/{id}` – Delete order by ID  
- `GET /api/Orders/lab-technician` – Get orders by lab technician  
- `GET /api/Orders` – Get all orders  
- `POST /api/Orders` – Create a new order  
- `POST /api/Orders/{doctorId}/orders` – Create an order for a specific doctor  
- `PATCH /api/Orders/{orderId}/order-status` – Update order status

### 🧝 Patients
- `POST /api/Patients` – Add a new patient  
- `GET /api/Patients` – Get all patients  
- `GET /api/Patients/{id}` – Get patient by ID  
- `PUT /api/Patients/{id}` – Update patient by ID  
- `DELETE /api/Patients/{id}` – Delete patient by ID

### ⚙️ Settings
- `PATCH /api/Settings` – Update application settings

---

## 📆 Sample Features

- 👨‍⚕️ Add an order and assign multiple technicians with one request
- 🔐 Role-based access: Only authorized users can perform critical actions
- 🔄 Transaction-safe database operations
- 🛡️ Secured authentication system
- 🔍 Flexible, testable, and maintainable codebase

---

## 📈 Future Improvements

- Add Unit Tests and Integration Tests
- Create Admin Panel using Blazor or React
- Integrate Real-time Notifications with SignalR

---

## 👨‍💻 About the Developer

This project was developed as part of a backend developer assessment.  
It aims to demonstrate real-world software development practices using ASP.NET Core technologies.

Feel free to explore, contribute, or reach out for collaboration!

---

