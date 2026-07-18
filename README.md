# SplitWise API

API REST para divisão de despesas em grupo — amigos criam grupos, lançam despesas compartilhadas, e o sistema calcula quem deve quanto a quem, sugerindo a forma mais simples de acertar as contas.

Projeto pessoal com foco em boas práticas de arquitetura e desenvolvimento back-end em .NET.

> **Status:** em desenvolvimento ativo. O núcleo (grupos) está funcional; as demais funcionalidades estão sendo implementadas de forma incremental (ver [Roadmap](#roadmap)).

---

## Tecnologias

- **.NET 8** — Web API
- **Entity Framework Core** (provider Pomelo para MySQL)
- **MySQL 8** — banco de dados
- **Docker & Docker Compose** — containerização da aplicação e do banco
- **Swagger / OpenAPI** — documentação interativa dos endpoints

## Arquitetura

O projeto segue os princípios de **Clean Architecture**, organizado em quatro camadas com as dependências apontando sempre para o domínio:

```
SplitWise.Domain          → entidades e regras de negócio (núcleo, sem dependências externas)
SplitWise.Application     → casos de uso e orquestração
SplitWise.Infrastructure  → persistência com EF Core (implementa contratos do domínio)
SplitWise.API             → controllers, injeção de dependência e configuração
```

A regra central: `Domain` não conhece nenhuma tecnologia externa. `Infrastructure` implementa as interfaces que o `Domain` define, o que mantém o núcleo testável e desacoplado do banco de dados.

Padrões aplicados: **Repository Pattern**, **injeção de dependência** e **DTOs** para separar o modelo de domínio do contrato da API.

## Como executar

Pré-requisitos: [Docker](https://www.docker.com/) e [Docker Compose](https://docs.docker.com/compose/).

1. Clone o repositório:
   ```bash
   git clone https://github.com/lucasborgss1/SplitWise.git
   cd SplitWise
   ```

2. Crie um arquivo `.env` na raiz (baseado no `.env.example`) com as credenciais do banco:
   ```bash
   cp .env.example .env
   ```
   Depois preencha os valores das senhas no `.env`.

3. Suba a aplicação e o banco:
   ```bash
   docker compose up --build
   ```

4. Acesse a documentação Swagger em `http://localhost:8080/swagger`.

### Executando apenas o banco (para rodar a API pela IDE)

Para desenvolver com a API rodando pela IDE (com debug) e o banco no Docker:

```bash
docker compose up splitwise.database
```

Nesse modo, a connection string da API aponta para `localhost` e é configurada via [User Secrets](https://learn.microsoft.com/aspnet/core/security/app-secrets) (não versionados).

## Endpoints

Documentação interativa completa disponível via Swagger. Atualmente implementados:

| Método | Rota | Descrição |
|--------|------|-----------|
| `POST` | `/api/grupos` | Cria um novo grupo |
| `GET`  | `/api/grupos/{id}` | Retorna um grupo pelo id |

## Roadmap

- [x] Estrutura base em Clean Architecture
- [x] CRUD de grupos (criação e consulta)
- [x] Containerização com Docker
- [ ] CRUD completo de grupos (edição, exclusão, listagem paginada)
- [ ] Autenticação e usuários (JWT + refresh token)
- [ ] Membros e lançamento de despesas
- [ ] Cálculo de saldos (quem deve a quem) + testes automatizados
- [ ] Algoritmo de simplificação de dívidas
- [ ] Refatoração para CQRS com MediatR
- [ ] CI/CD e deploy público

---

## Sobre

Projeto desenvolvido como estudo aprofundado de arquitetura e boas práticas em .NET.
