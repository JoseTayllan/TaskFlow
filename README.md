# 📋 TaskFlow – Gerenciador de Tarefas (API + Console App) com ASP.NET Core 8 + EF Core

**TaskFlow** é um sistema completo para gerenciamento de tarefas, com duas formas de uso:

1. **API RESTful** desenvolvida em ASP.NET Core
2. **Aplicação Console** interativa usando o mesmo banco e lógica
3. **Biblioteca compartilhada (Core)** com todas as entidades, banco e regras de negócio

Projeto ideal para **portfólio profissional**, focado em boas práticas, estrutura limpa e separação de responsabilidades.

---

## ✅ Funcionalidades Comuns (API e Console)

- 📌 Criar nova tarefa
- 🗂️ Listar tarefas com status (concluída ou não)
- ✔️ Marcar tarefa como concluída
- 🗑️ Remover tarefa
- ✏️ Editar tarefa
- 📊 Gerar relatório de produtividade (console)
- 📡 Consumir via Swagger ou programaticamente

---

## 🧱 Estrutura de Pastas

```
TaskFlow/
├── TaskFlow.sln                  # Solução .NET
│
├── TaskFlow.Core/               # Núcleo compartilhado (camada de domínio)
│   ├── Models/                  # Entidades (ex: TaskItem.cs)
│   ├── Data/                    # EF Core (AppDbContext.cs)
│   ├── Services/                # Regras de negócio reutilizáveis (TaskService.cs)
│   └── TaskFlow.Core.csproj
│
├── TaskFlow.Api/                # API REST ASP.NET Core
│   ├── Controllers/             # Endpoints HTTP (TasksController.cs)
│   ├── Program.cs               # Configuração de middleware e rotas
│   ├── appsettings.json         # String de conexão SQLite
│   └── TaskFlow.Api.csproj
│
├── TaskFlow.App/                # Aplicação console interativa
│   ├── Program.cs               # Interface CLI com menus e serviços
│   └── TaskFlow.App.csproj
│
└── README.md                    # Este documento
```

---

## 🌐 Modo 1: Executar a API REST

### 1. Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- VS Code ou Visual Studio com extensão **C#** ou **C# Dev Kit**

### 2. Restaurar, compilar e aplicar migração

```bash
dotnet restore TaskFlow.sln
dotnet build TaskFlow.sln
dotnet ef migrations add Inicial --project TaskFlow.Core --startup-project TaskFlow.Api
dotnet ef database update --project TaskFlow.Core --startup-project TaskFlow.Api
```

### 3. Rodar a API

```bash
dotnet run --project TaskFlow.Api
```

Abra no navegador: [http://localhost:5165/swagger](http://localhost:5165/swagger)

---

## 💻 Modo 2: Executar o Console App

O console usa os mesmos modelos e banco da API.

### 1. Executar o aplicativo console

```bash
dotnet run --project TaskFlow.App
```

### 2. Interface disponível:

```
📋 TaskFlow - Gerenciador de Tarefas
1. Adicionar nova tarefa
2. Listar tarefas
3. Concluir tarefa
4. Remover tarefa
5. Editar tarefa
6. Ver relatório de produtividade
0. Sair
```

---

## 📦 Extensões recomendadas para VS Code

- ✅ C# (OmniSharp) – suporte à linguagem
- ✅ SQLite Viewer – visualizar `taskflow.db`
- ✅ REST Client – testar API diretamente no VS Code
- ✅ GitLens – controle de versão e autoria
- ✅ C# Dev Kit (opcional) – suporte avançado

---

## 🧠 Boas práticas aplicadas

- ✅ Projeto dividido em camadas (API, App e Core)
- ✅ Reaproveitamento de código entre API e Console
- ✅ Migrations e banco versionado com EF Core
- ✅ RESTful + Swagger
- ✅ SQLite leve e funcional

---

## 👨‍💻 Autor

**Thaydion** — Desenvolvedor com foco em boas práticas, arquitetura limpa e projetos de impacto profissional.

---

## 📄 Licença

MIT — livre para modificar, usar e compartilhar.
