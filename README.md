# 🌱 AgroSphere API

## 📋 Sobre o Projeto

A AgroSphere API foi desenvolvida como projeto da disciplina **Advanced Business Development with .NET** da FIAP.

O objetivo da solução é auxiliar no gerenciamento de fazendas e plantios, permitindo o cadastro, consulta, atualização e remoção de informações através de uma API REST desenvolvida com ASP.NET Core.

---

## 🚀 Tecnologias Utilizadas

* ASP.NET Core 8
* Entity Framework Core
* SQLite
* Swagger / OpenAPI
* C#
* Git e GitHub

---

## 🏗️ Arquitetura do Projeto

O projeto foi estruturado seguindo boas práticas de desenvolvimento em camadas:

```text
Controllers
│
├── Services
│
├── Repositories
│
├── DTOs
│
├── Entities
│
├── Data
│
└── Migrations
```

### Responsabilidades

* **Controllers:** recebem as requisições HTTP.
* **Services:** concentram as regras de negócio.
* **Repositories:** acesso aos dados.
* **DTOs:** transferência de dados entre camadas.
* **Entities:** representação das tabelas do banco.
* **Data:** configuração do Entity Framework.
* **Migrations:** versionamento do banco de dados.

---

## 🗄️ Modelo de Dados

### Fazenda

| Campo       | Tipo    |
| ----------- | ------- |
| Id          | Integer |
| Nome        | String  |
| Localizacao | String  |

### Plantio

| Campo         | Tipo     |
| ------------- | -------- |
| Id            | Integer  |
| NomeCultura   | String   |
| DataPlantio   | DateTime |
| AreaCultivada | Double   |
| FazendaId     | Integer  |

### Relacionamento

```text
Fazenda (1)
    │
    └─── (N) Plantio
```

Uma fazenda pode possuir vários plantios cadastrados.

---

## 🔄 Migrations

O banco de dados é criado utilizando Entity Framework Core Migrations.

Comandos utilizados:

```powershell
Add-Migration InitialCreate
Update-Database
```

---

## 📡 Endpoints Disponíveis

### Fazendas

| Método | Endpoint           |
| ------ | ------------------ |
| GET    | /api/Fazendas      |
| GET    | /api/Fazendas/{id} |
| POST   | /api/Fazendas      |
| PUT    | /api/Fazendas/{id} |
| DELETE | /api/Fazendas/{id} |

### Plantios

| Método | Endpoint           |
| ------ | ------------------ |
| GET    | /api/Plantios      |
| GET    | /api/Plantios/{id} |
| POST   | /api/Plantios      |
| PUT    | /api/Plantios/{id} |
| DELETE | /api/Plantios/{id} |

---

## 🧪 Exemplos de Teste

### Criar Fazenda

POST /api/Fazendas

```json
{
  "nome": "Fazenda Marte Alpha",
  "localizacao": "São Paulo - Brasil"
}
```

### Criar Plantio

POST /api/Plantios

```json
{
  "nomeCultura": "Batata Espacial",
  "dataPlantio": "2026-06-08T00:00:00",
  "areaCultivada": 120.5,
  "fazendaId": 1
}
```

---

## 📖 Swagger

Após executar o projeto:

```text
https://localhost:7205/swagger
```

A documentação interativa da API estará disponível através do Swagger/OpenAPI.

---

## ▶️ Como Executar

1. Clonar o repositório

```bash
git clone <URL_DO_REPOSITORIO>
```

2. Restaurar dependências

```bash
dotnet restore
```

3. Aplicar migrations

```bash
Update-Database
```

4. Executar o projeto

```bash
dotnet run
```

---

## 👨‍🎓 Projeto Acadêmico

Projeto desenvolvido para a disciplina **Advanced Business Development with .NET** da FIAP, aplicando conceitos de:

* API REST
* Entity Framework Core
* Persistência de Dados
* Relacionamentos entre entidades
* Migrations
* Swagger/OpenAPI
* Arquitetura em Camadas
