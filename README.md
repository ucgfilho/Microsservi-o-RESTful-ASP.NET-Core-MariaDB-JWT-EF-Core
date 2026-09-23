# Microsserviço de Catálogo e Autenticação

Microsserviço RESTful desenvolvido em **C# / ASP.NET Core 10** e **MySQL / MariaDB**, estruturado seguindo os princípios de design de software **SOLID** e arquitetura em camadas.

O projeto conta com persistência assíncrona via Entity Framework Core, separação estrita de responsabilidades entre apresentação, regras de negócio e acesso a dados, autenticação via tokens JWT+Bearer e documentação interativa com Scalar.

---

## Arquitetura

A arquitetura do projeto foi estruturada em camadas desacopladas por meio de interfaces e injeção de dependência:

```
[   Cliente    ]
       ↓
[  Controllers ]     → Camada de Apresentação (recebe requisição HTTP, valida ModelState, devolve status code)
       ↓
[   Services   ]     → Regras de Negócio e Orquestração (validações, hashing, tokens, auditoria)
       ↓
[ Repositories ]     → Camada de Persistência (comunicação direta com o banco de dados via EF Core)
       ↓
[ AppDbContext ]     → Banco de Dados MariaDB
```

---

## Estrutura do projeto

```
projetoAPI/
├── Controllers/              # Apresentação HTTP
│   ├── AuthController.cs
│   ├── CategoriesController.cs
│   └── ProductsController.cs
├── DTOs/                     # Objetos de Transferência de Dados e Configurações Tipadas
│   ├── AuthResult.cs
│   ├── JwtSettings.cs
│   ├── LoginDTO.cs
│   └── RegisterDTO.cs
├── Data/                     # Contexto do Entity Framework Core
│   └── AppDbContext.cs
├── Migrations/               # Histórico de migrações do banco de dados
├── Models/                   # Entidades de Domínio
│   ├── Category.cs
│   ├── Product.cs
│   └── User.cs
├── Repositories/             # Acesso a dados com EF Core assíncrono
│   ├── CategoryRepository.cs
│   ├── ProductRepository.cs
│   ├── UserRepository.cs
│   └── Interfaces/           # Contratos dos repositórios
│       ├── ICategoryRepository.cs
│       ├── IProductRepository.cs
│       └── IUserRepository.cs
├── Services/                 # Lógica de negócio e orquestração
│   ├── AuthService.cs
│   ├── BcryptPasswordHasher.cs
│   ├── CategoryService.cs
│   ├── ProductService.cs
│   ├── TokenService.cs
│   └── Interfaces/           # Contratos dos serviços
│       ├── IAuthService.cs
│       ├── ICategoryService.cs
│       ├── IPasswordHasher.cs
│       ├── IProductService.cs
│       └── ITokenService.cs
├── Program.cs                # Composition Root e configuração de middlewares
├── appsettings.json          # Configurações de ambiente e conexão
└── projetoAPI.csproj         # Dependências e metadados do projeto
```

---

## Stack

* **Runtime & Framework:** C# / .NET 10 (ASP.NET Core Web API)
* **ORM:** Entity Framework Core 9 (Pomelo)
* **Banco de Dados:** MariaDB / MySQL
* **Autenticação & Segurança:** JWT e Bearer + BCrypt.Net
* **Documentação OpenAPI:** Scalar

---

## Como configurar

### 1. Pré-requisitos
* [Docker](https://www.docker.com/)

### 2. Configurar o Ambiente
Copie o arquivo de exemplo para criar o seu arquivo de variáveis de ambiente:
```bash
cp .env.example .env
```
*(Nota: O `.env` centraliza as senhas e as configurações. A chave JWT é gerada dinamicamente pelo sistema na inicialização).*

### 3. Executar o Projeto
Para iniciar a API e o Banco de Dados simultaneamente:
```bash
docker-compose up -d --build
```
> **Aviso:** As migrations do Entity Framework Core **são aplicadas automaticamente** assim que a API inicializa. Você não precisa criar as tabelas manualmente. O banco de dados fica acessível na porta `3307` e a API na porta `8080`.

### 4. Acessar a Documentação
Acesse através desse link:
**http://localhost:8080/scalar/v1**
