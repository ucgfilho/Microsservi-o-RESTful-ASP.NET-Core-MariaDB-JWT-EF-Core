# Microsserviço de Catálogo e Autenticação

Microsserviço RESTful desenvolvido em **C# / ASP.NET Core 10** e **MySQL / MariaDB**, estruturado seguindo os princípios de design de software **SOLID** e arquitetura em camadas.

O projeto conta com persistência assíncrona via Entity Framework Core, separação estrita de responsabilidades entre apresentação, regras de negócio e acesso a dados, autenticação via tokens JWT+Bearer e documentação interativa com Scalar.

---

## Arquitetura e Princípios SOLID

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

## Estrutura do Projeto

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

## Stack Tecnológica

* **Runtime & Framework:** C# / .NET 10 (ASP.NET Core Web API)
* **ORM:** Entity Framework Core 9 (Pomelo)
* **Banco de Dados:** MariaDB / MySQL
* **Autenticação & Segurança:** JWT e Bearer + BCrypt.Net
* **Documentação OpenAPI:** Scalar

---

## Como Rodar Localmente

### 1. Pré-requisitos
* [.NET 10 SDK](https://dotnet.microsoft.com/)
* [MariaDB](https://mariadb.org/) ou [MySQL](https://www.mysql.com/)
* Ferramenta de linha de comando do EF Core:
  ```bash
  dotnet tool install --global dotnet-ef
  ```

### 2. Configurar a Conexão
Atualize a string de conexão no arquivo `appsettings.json` com suas credenciais do banco:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Port=3306;Database=produtos_db;Uid=root;Pwd=sua_senha;"
}
```

### 3. Aplicar as Migrações
Execute a atualização do banco de dados para criar as tabelas necessárias:
```bash
dotnet ef database update
```

### 4. Executar o Projeto
Inicie a aplicação:
```bash
dotnet run
```
Ou com recarregamento automático durante o desenvolvimento:
```bash
dotnet watch
```

### 5. Acessar a Documentação
Com a aplicação em execução, acesse no navegador a documentação interativa da API via Scalar:
* `http://localhost:5096/scalar/v1` (ou na porta HTTPS indicada no terminal)
