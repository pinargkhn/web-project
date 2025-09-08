# 🚌 Bus Booking System

A **web-based bus booking platform** built with **ASP.NET Web Forms**, **C#**, and **MySQL**, designed to streamline bus reservation processes for both customers and administrators. The system provides a user-friendly interface for searching and booking bus trips, while offering robust management tools for administrators and bus companies.

---

## 📖 Table of Contents
- [Project Overview](#project-overview)
- [Features](#features)
- [Technologies](#technologies)
- [System Requirements](#system-requirements)
- [System Design](#system-design)
  - [UML Diagrams](#uml-diagrams)
  - [ER Diagram & Relational Schema](#er-diagram--relational-schema)
  - [Normalization](#normalization)
- [Implementation](#implementation)
  - [User Interface](#user-interface)
  - [Session Handling](#session-handling)
  - [Database Implementation](#database-implementation)
- [Database Schema](#database-schema)
- [Example Queries](#example-queries)
- [Setup Instructions](#setup-instructions)
- [Future Improvements](#future-improvements)
- [Contributors](#contributors)
- [License](#license)

---

## 🚀 Project Overview
Managing bus reservations manually is often **inefficient and error-prone**. This project delivers a **digital solution** that simplifies booking processes, improves management efficiency, and enhances user experience.

The platform provides:
- **Customers** with the ability to search, book, and manage trips.
- **Administrators** with tools to manage buses, companies, and reservations.
- **Developers** with database-level control via an admin dashboard.

---

## ✨ Features

### Customer
- Register and log in securely
- Search buses by **departure** and **arrival** location
- Make and cancel bookings
- View past trips

### Administrator
- Add, update, or delete buses
- Manage reservations
- Manage bus companies
- Access developer dashboard for database tables

### Security
- **Session-based authentication**
- **Role-based access control** (Admin / Customer)
- Passwords stored securely (hashing recommended)
- Protection against SQL Injection via parameterized queries

---

## 🧰 Technologies

- **Frontend**: HTML5, CSS3, JavaScript, Bootstrap  
- **Backend**: ASP.NET Web Forms (C#)  
- **Database**: MySQL  
- **Tools**: Visual Studio, MySQL Workbench, Trello, UML diagrams, Coolors (UI planning)

---

## 🖥️ System Requirements

- Visual Studio (with ASP.NET Web Forms support)  
- MySQL Server + MySQL Workbench  
- .NET Framework (4.x)  

---

## 🛠️ System Design

### UML Diagrams
- **Use Case Diagram** – defines interactions between users and the system  
- **Class Diagram** – represents core entities (`Users`, `Buses`, `Bookings`, `Companies`)

### ER Diagram & Relational Schema
- **Entities**: Users, Buses, Bookings, Companies  
- **Relationships**:
  - A company owns multiple buses
  - A user can make multiple bookings
  - A booking is associated with one bus and one user

### Normalization
- **1NF**: Atomic values only  
- **2NF**: All non-key attributes fully dependent on PK  
- **3NF**: No transitive dependencies  

---

## 💻 Implementation

### User Interface
- **Home Page**: login for users/admins  
- **Register Page**: create account  
- **Login Page**: session-based authentication  
- **Bus Search**: displays available buses based on filters  
- **Past Trips**: shows booking history & cancellations  
- **Manage Buses**: CRUD operations for buses  
- **Admin Dashboard**: developer/admin access to DB tables  

### Session Handling
- Session variables store login state  
- Session cleared on logout  

### Database Implementation
- **Schema creation** with MySQL  
- **Indexes** on `UserID`, `BusID`, and frequently queried columns  
- **Stored Procedures** for booking workflows and reports  
- **Triggers** for automatic logging of booking updates  

---

## 🗄️ Database Schema

**Users**
- `UserID` (PK)  
- `Username`  
- `PasswordHash`  
- `Email`  
- `CompanyID` (FK → Companies)  
- `IsAdmin`  
- `IsDeveloper`

**Companies**
- `CompanyID` (PK)  
- `CompanyName`

**Buses**
- `BusID` (PK)  
- `BusName`  
- `DepartureLocation`  
- `ArrivalLocation`  
- `DepartureTime`  
- `SeatsAvailable`  
- `CompanyID` (FK → Companies)

**Bookings**
- `BookingID` (PK)  
- `CustomerID` (FK → Users)  
- `BusID` (FK → Buses)  
- `BookingDate`  
- `Status` (`CONFIRMED`, `CANCELLED`, etc.)

---

## 📝 Example Queries

**Fetch all buses**
```sql
SELECT * FROM Buses;
