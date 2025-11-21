Global Solution — “O Futuro do Trabalho”

API RESTful construída em ASP.NET Core para gerenciar tarefas internas em um ambiente corporativo.
A solução permite que funcionários criem entregas (WorkItems), adicionem comentários, atualizem status, acompanhem progresso e trabalhem com versionamento de API.
Banco de dados SQLite + Entity Framework Core com Migrations.

📌 Funcionalidades

✔️ Criar tarefas (WorkItems)

✔️ Listar, atualizar e deletar tarefas

✔️ Adicionar comentários por entrega

✔️ Controle de status: Pending, InProgress, Review, Done

✔️ Banco de dados SQLite

✔️ Migrations automáticas

✔️ Versionamento de API: /api/v1

✔️ Documentação automática com Swagger

✔️ Boas práticas REST (status code correto + verbos HTTP)

## Arquitetura do Projeto
<img width="479" height="667" alt="image" src="https://github.com/user-attachments/assets/175a652d-dd0b-49e1-8dd4-5065ae939189" />

🛠 Tecnologias Utilizadas

ASP.NET Core 8

Entity Framework Core 8

SQLite

Swagger / OpenAPI

C#

EF Core Migrations

📁 Estrutura do Projeto
/Controllers
/Data
/Dtos
/Migrations
/Models
appsettings.json
Program.cs
futureofwork.db


Rotas da API
https://localhost:xxxx/api/v1

➕ Criar tarefa

POST /WorkItems

📄 Listar tarefas

GET /WorkItems]

🔄 Atualizar tarefa

PUT /WorkItems/{id}

❌ Deletar tarefa

DELETE /WorkItems/{id}

💬 Adicionar comentário

POST /WorkItems/{id}/comments

▶️ Como Rodar o Projeto Localmente

git clone https://github.com/SEU_USUARIO/SEU_REPOSITORIO.git
cd SEU_REPOSITORIO

2️⃣ Restaurar dependências
dotnet restore

3️⃣ Criar o banco via migrations
dotnet ef database update

4️⃣ Rodar a API
dotnet run

5️⃣ Abrir a documentação Swagger
https://localhost:xxxx/swagger

📌 Versionamento da API
/api/v1

📦 Banco de Dados

A aplicação utiliza:

SQLite (arquivo: futureofwork.db)

EF Core com Migrations

Criação automática do banco ao rodar o projeto

🎥 Vídeo





