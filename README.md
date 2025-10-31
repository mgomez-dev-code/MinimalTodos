# MinimalTodos (.NET 9 + Minimal API)

![.NET](https://img.shields.io/badge/.NET-9-512BD4?logo=dotnet&logoColor=white)
![Language: C#](https://img.shields.io/badge/Language-C%23-239120?logo=csharp&logoColor=white)
![Tests: xUnit](https://img.shields.io/badge/Tests-xUnit-6aa84f)
![.NET CI](https://github.com/mgomez-dev-code/MinimalTodos/actions/workflows/dotnet.yml/badge.svg)
![License: MIT](https://img.shields.io/badge/License-MIT-green)

A small **Minimal API** built with **.NET 9** to manage a *Todo* list.
Demonstrates a clean architecture using Dependency Injection, validation, pagination, and unit testing with xUnit & Moq.
Designed to show how Minimal APIs simplify setup compared to traditional MVC Controllers, while keeping strong typing and testability.

## Features
- ⚡ CRUD endpoints (`GET`, `POST`, `PUT`, `PATCH`, `DELETE`)
- 🧠 In-memory repository with **Dependency Injection**
- 🔎 **Search filter** (`?search=`) and **pagination** (`pageIndex`, `pageSize`)
- 🧾 Validation: **Title required, 1–100 chars**
- 🧪 Unit tests with **xUnit** and **Moq**
- 💬 Proper HTTP responses (200, 201, 400, 404)
- 🚀 Swagger UI ready out of the box

## Project Structure
```text
MinimalTodos/
├─ MinimalTodos.sln
├─ MinimalTodos.API/
│  ├─ Domain/          # Models & DTOs
│  ├─ Endpoints/       # Minimal API routes
│  ├─ Extensions/      # App extensions (endpoint registration, DI helpers, etc.)
│  ├─ Repositories/    # ITodoRepository + InMemory repo
│  ├─ Validation/      # Custom validation
│  └─ Program.cs
└─ MinimalTodos.Tests/
   ├─ TodoRepositoryTests.cs
   └─ TodoNotifierTests.cs
```

## Getting Started

**1) Build & Test**
```bash
dotnet build
dotnet test
```

**2) Run the API**
```bash
dotnet run --project MinimalTodos.API
# Open https://localhost:7026/swagger
```
💡By default, the API runs on https://localhost:7026 (HTTPS) and http://localhost:5000 (HTTP).
Swagger UI will open automatically at /swagger, allowing you to explore and test all endpoints interactively.

## Example Endpoints
| Method | Endpoint | Description |
|-------:|----------|-------------|
| `GET`  | `/todos` | List todos (with search & pagination) |
| `GET`  | `/todos/{id}` | Get a single todo |
| `POST` | `/todos` | Create new todo |
| `PUT`  | `/todos/{id}` | Update todo |
| `PATCH`| `/todos/{id}/toggle` | Toggle IsDone |
| `DELETE`| `/todos/{id}` | Delete todo |

## License
This project is licensed under the **MIT License**.  
See `LICENSE` for details.
