# 🚀 PayFlow SaaS

Scalable Payroll Microservices Platform inspired by Stripe & PayFit.

## 🏗️ Architecture

- Microservices architecture
- Event-driven (future Kafka integration)
- Clean Architecture + DDD
- .NET / Rust / Node.js
- PostgreSQL

## 📦 Services

- API Gateway
- Auth Service
- Employee Service
- Payroll Service
- Tax Engine (Rust)
- Payment Service
- Billing Service
- Notification Service
- Reporting Service

## ⚙️ Getting Started

```bash
docker-compose up --build

2. Workflow Git propre
main        → production
develop     → intégration
feature/*   → développement
hotfix/*    → correction urgente
release/*   → release

/PayflowSaaS
  ├── /src
  │    ├── Payflow.Domain (C# - Interfaces)
  │    ├── Payflow.Application (C# - Use Cases)
  │    ├── Payflow.Infrastructure (C# - DB & Wrappers)
  │    └── Payflow.Api (C# - Controllers)
  ├── /native
  │    ├── /Payflow_engine (Rust - Calculs)
  │    └── /pdf_generator (C++ - Documents)
  └── /web
       ├── /admin-react (Dashboard)
       └── /employee-vue (Mobile Portal)
