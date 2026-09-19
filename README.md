# Microsserviço de Catálogo e Autenticação

Microsserviço RESTful desenvolvido com ASP.NET Core 10 e MariaDB, projetado com arquitetura desacoplada e independente.

O projeto aplica boas práticas de desenvolvimento back-end, utilizando Entity Framework Core para persistência de dados, DTOs para separar a camada de domínio da API e autenticação JWT para proteger os endpoints.

## Stack Tecnológica

- **Backend:** C# / ASP.NET Core 10
- **ORM:** Entity Framework Core 9 + Pomelo.EntityFrameworkCore.MySql
- **Banco de Dados:** MariaDB
- **Segurança e Identidade:** JWT + Bearer + BCrypt 
- **Documentação de Rotas:** Scalar

## Como Rodar Localmente

1. **Clone o repositório e acesse a pasta:**
   ```bash
   git clone https://github.com/ucgfilho/microservice-cs.git
   cd microservice-cs
   ```

2. **Pré-requisitos:**
   - [.NET 10 SDK](https://dotnet.microsoft.com/)
   - [MariaDB](https://mariadb.org/)
   - EF Core:
     ```bash
     dotnet tool install --global dotnet-ef
     ```

3. **Configuração do Banco de Dados:**
   - Atualize as credenciais no arquivo `appsettings.json` com o usuário e senha do seu banco de dados local:
     ```json
     "DefaultConnection": "Server=localhost;Port=3306;Database=produtos_db;Uid=root;Pwd=sua_senha;"
     ```

4. **Aplicar Migrations:**
   ```bash
   dotnet ef database update
   ```

5. **Executar o Microsserviço:**
   ```bash
   dotnet watch
   ```

6. **Acessar a Documentação:**
   - Abra no navegador: `http://localhost:5096/scalar/v1`
