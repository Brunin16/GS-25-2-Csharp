# Global Solution 2025 – API .NET

Este projeto é uma API REST desenvolvida em C# (.NET 8) para o gerenciamento de Usuários, Trilhas, Competências e Matrículas.  
A API implementa operações CRUD e um relacionamento N:N entre Trilhas e Competências.

---

## Diagrama da Arquitetura

Models  
   ↓  
Data (DbContext)  
   ↓  
Oracle Database  
   ↓  
Business (Services)  
   ↓  
API (Controllers REST)

---

## Tecnologias Utilizadas

- .NET 8 — Web API
- C#
- Entity Framework Core
- Oracle Database
- Swagger/OpenAPI

---

## Endpoints Principais

### Usuários
- POST /api/v1/usuarios  
- GET /api/v1/usuarios  
- GET /api/v1/usuarios/{id}  
- PUT /api/v1/usuarios/{id}  
- DELETE /api/v1/usuarios/{id}  

### Trilhas
- POST /api/v1/trilhas  
- GET /api/v1/trilhas  
- GET /api/v1/trilhas/{id}  
- PUT /api/v1/trilhas/{id}  
- DELETE /api/v1/trilhas/{id}  

### Competências
- POST /api/v1/competencias  
- GET /api/v1/competencias  
- GET /api/v1/competencias/{id}  
- PUT /api/v1/competencias/{id}  
- DELETE /api/v1/competencias/{id}  

### Relacionamento N:N (Trilha ↔ Competência)
- POST /api/v1/trilhas/{trilhaId}/competencias/{competenciaId}  
- GET /api/v1/trilhas/{trilhaId}/competencias  
- DELETE /api/v1/trilhas/{trilhaId}/competencias/{competenciaId}  

### Matrículas
- POST /api/v1/matriculas  
- GET /api/v1/matriculas  
- GET /api/v1/matriculas/{id}  
- GET /api/v1/matriculas/usuario/{usuarioId}  
- GET /api/v1/matriculas/trilha/{trilhaId}  
- PATCH /api/v1/matriculas/{id}/status  
- DELETE /api/v1/matriculas/{id}  

---

## Como Executar

1. Configure o arquivo `appsettings.json` com a connection string do Oracle.
2. Aplique as migrations (se necessário):
   dotnet ef database update
3. Rode o projeto:
   dotnet run
4. Acesse o Swagger:
   http://localhost:5056/swagger

---

## Membro

- Bruno Caputo - RM558303

---
## Link para o video
- [Video](https://youtu.be/5ArztDPPAwA)
