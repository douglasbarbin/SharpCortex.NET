# SharpCortex.NET

SharpCortex.NET is a modern AI orchestration platform built with .NET 10, React, and Ollama for local LLM inference workloads.

The project is designed as a production-oriented infrastructure platform rather than a simple chatbot application, with emphasis on maintainability, observability, streaming inference, and clean architecture.

---

## Goals

- Local-first LLM orchestration
- ChatGPT-style conversational UI
- OpenAI-compatible API surface
- Streaming token responses
- Conversation persistence
- Production-grade observability
- Clean infrastructure boundaries
- Modern .NET and React architecture

---

## Tech Stack

### Backend

- ASP.NET Core (.NET 10)
- Minimal APIs
- PostgreSQL
- EF Core
- Serilog (might replace with NLog or something else, not sure yet)
- OpenTelemetry
- Polly
- Swagger / OpenAPI
- Server-Sent Events (SSE)

### Frontend

- React
- TypeScript
- Vite
- TailwindCSS
- React Router
- TanStack Query
- Zustand

### Inference

- Ollama
- ROCm-enabled AMD GPU infrastructure (CUDA for possible future scope)

---

## Architecture

```text
SharpCortex.NET/
│
├── backend/
│   ├── SharpCortex.Api/
│   ├── SharpCortex.Core/
│   ├── SharpCortex.Infrastructure/
│   └── SharpCortex.Contracts/
│
├── frontend/
│   └── sharpcortex-web/
│
├── docker/
├── docs/
├── scripts/
└── .github/
```

### Project Responsibilities

| Project | Responsibility |
|---|---|
| SharpCortex.Api | HTTP API surface, middleware, DI composition |
| SharpCortex.Core | Core orchestration logic and abstractions |
| SharpCortex.Infrastructure | Persistence, providers, external integrations |
| SharpCortex.Contracts | DTOs and shared contracts |

---

## Current Status

Initial infrastructure skeleton is in progress.

Implemented:
- Solution structure
- OpenAPI/Swagger
- Structured logging
- OpenTelemetry bootstrap
- PostgreSQL connectivity
- Health checks

Planned next:
- React frontend bootstrap
- Conversation persistence
- Streaming inference pipeline
- Ollama provider integration
- Chat interface

---

## Design Philosophy

SharpCortex.NET prioritizes:

- Simplicity over unnecessary abstraction
- Operational realism
- Async-first design
- Strong observability
- Clean dependency boundaries
- Extensibility without premature complexity

The project intentionally avoids premature adoption of:
- Microservices
- Kubernetes
- CQRS/MediatR-heavy architecture
- Distributed orchestration
- Plugin ecosystems
- Agent frameworks

---

## Development

### Backend

```bash
cd backend/SharpCortex.Api
dotnet run
```

### Frontend

```bash
cd frontend/sharpcortex-web
npm install
npm run dev
```

---

## Long-Term Vision

SharpCortex.NET is intended to evolve into a robust local AI infrastructure platform capable of orchestrating modern inference workloads while remaining operationally lightweight and developer-friendly.
