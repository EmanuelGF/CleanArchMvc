# CleanArchMvc
Creating a full project using clean architecture.

This is an example project about the implementation of Clean Architecture using many design patterns and best practices. 

The project will feature an ASP .Net Core MVC UI project that will allow the management of products and categories.
It will feature the domain models Product and Category and their respective atributes.
The models Product and category will have a relatioship one-to-many.

### Data Persistance is achieved using the following:
- SQL Server;
- Entity Framework Core using Code first aproach; 
- Microsoft.EntityFameworkCore.SqlServer;
- Microsoft.EntityFramworkCore.Tools (Migrations)
- Repository Pattern (used to decouple the Data layer)

### Project Structure (Multilayered using Dependency Injection)
- CleanArchMvc.Domain : Domain Model, Business Rules, Interfaces.
- CleanArchMvc.Application : Application domain rules, mapping, services, DTO's.
- CleanArchMvc.Infra.Data : EF Core, Context, Confs, Migrations, Repository.
- CleanArchMvc.Infra.IoC : Dependency Injection, Service registry, life time.
- CleanArchMvc.WebUI : MVC, Controllers, Views, Filters, ViewModels.

### Dependencies
- CleanArchMvc.Domain --> No dependency.
- CleanArchMvc.Application --> Domain.
- CleanArchMvc.Infra.Data --> Domain.
- CleanArchMvc.Infra.IoC --> Domain, Application, Infra.Data.
- CleanArchMvc.WebUI --> Infra.IoC.

### Layers 
- Domain Layer -> CleanArchMvc.Domain (Entities, interfaces)
- Application Layer -> CleanArchMvc.Application (Services, Interfaces, DTO's, Mappings)
- Infrastructure Layer -> CleanArchMvc.Infra.Data (Repositories, Context, Migrations), CleanArchMvc.Infra.IoC (Dependency Injection) 
- Presentation Layer -> CleanArchMvc.WebUI (Controllers, Views, ViewModels, Filters, Componentes...)

### D.I
- The layers are decoupled using infrastructures/constructor injection and the dependency injection container (Microsoft.Extensions.DependencyInjection).
- To call the product and category services the infrastructures are used to inject the proper service objects in the calling class constructor, this is achieved via
the DI container.

### Domain
- Responsible for representing business information and rules.

### Infrastructure
This is the outermost layer of the application and is responsible for dealing with the infrastructure necessities. It provides the repository interfaces and it is the
only one that knows about the database and how it works.

### Application 
- Where the business rules are defined.
- Responsible for mappings and communication between the UI and Persistance.
...
