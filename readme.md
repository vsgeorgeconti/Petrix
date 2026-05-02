# 🐾 Petrix

> **A lightweight, full-stack SaaS platform for pet shops and grooming services.**

[![C#](https://img.shields.io/badge/C%23-70%25-239120?style=flat-square&logo=csharp)](https://github.com/vsgeorgeconti/Petrix)
[![TypeScript](https://img.shields.io/badge/TypeScript-22%25-3178C6?style=flat-square&logo=typescript)](https://github.com/vsgeorgeconti/Petrix)
[![.NET MAUI](https://img.shields.io/badge/.NET%20MAUI-5%25-512BD4?style=flat-square&logo=dotnet)](https://github.com/vsgeorgeconti/Petrix)
[![XAML](https://img.shields.io/badge/XAML-3%25-0C54C2?style=flat-square&logo=microsoft)](https://github.com/vsgeorgeconti/Petrix)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=flat-square)](LICENSE)

---

## 💎 About

**Petrix** is a streamlined version of a pet business management system, built to prove out the core architecture before scaling. It covers the essentials: client management, scheduling, and service tracking — all wrapped in a clean full-stack setup ready for containerized deployment.

---

## 🏗️ Architecture

```
Frontend  → Angular (TypeScript + SCSS)
Backend   → ASP.NET Core (C#)
App  →  .Net MAUI
Database  → PostgreSQL
Deploy    → Docker + Docker Compose
```

The backend follows **Clean Architecture**:

```
Petrix.Api              → Controllers, middleware, entry point
Petrix.Application      → Use cases, DTOs, service interfaces
Petrix.Domain           → Entities, domain rules
Petrix.Infrastructure   → Repositories, database, EF Core
```

---

## ⚙️ Tech Stack

| Layer | Technology |
|---|---|
| Backend | ASP.NET Core (.NET 10), Entity Framework Core, JWT |
| Frontend | Angular, TypeScript, SCSS |
| Mobile | .Net MAUI |
| Database | PostgreSQL |
| DevOps | Docker, Docker Compose |

---

## 🚀 Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Node.js 18+](https://nodejs.org/)
- [Docker](https://www.docker.com/) (includes PostgreSQL via compose)

### Run with Docker

```bash
git clone https://github.com/vsgeorgeconti/Petrix.git
cd Petrix
docker-compose up --build
```

The API will be available at `http://localhost:5000`.

### Run locally

**Backend:**
```bash
cd Petrix.Api
dotnet restore
dotnet run
```

**Frontend:**
```bash
cd petrix-web
npm install
npm start
```

---

## 🔐 Authentication

- JWT Bearer Token
- Role-based access control

```
POST /api/v1/auth
```

---

## 📁 Project Structure

```
Petrix/
├── src/            
├────── Petrix.Api/             # ASP.NET Core API
├────── Petrix.Application/     # Use cases and interfaces
├────── Petrix.Domain/          # Domain entities
├────── Petrix.Infrastructure/  # EF Core, repositories
├────── petrix-web/             # Angular frontend
├────── Petrix.App/             # .net MAUI Mobile App
├── dockerfile
└── docker-compose.yaml
```

---

## 📜 License

MIT

---

## 💬 Contact

Developed by **George Lucas** — [github.com/vsgeorgeconti](https://github.com/vsgeorgeconti)
