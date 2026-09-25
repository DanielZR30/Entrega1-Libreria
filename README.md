# 📚 Entrega 1 - Librería (Sistema de Catálogo de Biblioteca)

API REST desarrollada con **.NET 10**, implementando **Clean Architecture (CA)**, principios de **Domain-Driven Design (DDD)** y el patrón **CQRS** (Command Query Responsibility Segregation) para la consulta estructurada del catálogo de libros, autores y categorías.

---

## 📋 1. Contexto del Caso de Estudio

Una biblioteca desea desarrollar un sistema que permita consultar la información de los libros disponibles en su catálogo de forma organizada y centralizada.

### Alcance de la Versión 1.0 (Solo Consultas)
- **Solo Lectura:** Para esta primera versión **no** se requiere registrar, modificar ni eliminar información.
- **Objetivo principal:** Construir la infraestructura arquitectónica limpia y escalable necesaria para **consultar la información existente en el catálogo**.
- **Entidades de interés:**
  - 📖 **Libros**
  - ✍️ **Autores**
  - 🏷️ **Categorías**

---

## 🛠️ 2. Requisitos Técnicos y Arquitectura

| Requisito | Implementación |
| :--- | :--- |
| **Estilo Arquitectónico** | Clean Architecture (Capas concéntricas e independientes) |
| **Diseño del Dominio** | Domain-Driven Design (DDD) con entidades ricas y encapsuladas |
| **Patrón de Consultas** | CQRS con patrón Mediator (`SimpleMediator` desacoplado) |
| **Persistencia** | SQL Server mediante **Entity Framework Core (EF Core)** |
| **Estructura del Proyecto** | Estructura homologada a la plantilla de referencia **Inmoby** (`Microservices/Library/`) |
| **Herramientas de Migración** | Script `ef.cmd` integrado para gestión de migraciones |
| **Framework Base** | .NET 10 / C# |
| **Control de Versiones** | Git gestionado con flujo de trabajo por ramas de funcionalidad (**Feature Branches**) |
| **Documentación API** | OpenAPI / Swagger integrado |

---

## 🎯 3. Casos de Uso (Queries CQRS)

El sistema implementa tres casos de uso bajo el enfoque CQRS:

### 🔹 Query 1 – Consultar todos los libros (`GetAllBooksQuery`)
- **Propósito:** Retornar la lista completa de libros registrados en el catálogo.
- **Información retornada por libro:**
  - `Id` (Identificador único GUID v7)
  - `Título` (Title)
  - `ISBN` (International Standard Book Number)
  - `Año de publicación` (Publication Year)
  - `Autor` (Nombre y datos clave del autor)
  - `Categoría` (Nombre de la categoría)

### 🔹 Query 2 – Consultar un libro por ID (`GetBookByIdQuery`)
- **Propósito:** Retornar la información detallada de un libro específico a partir de su identificador.
- **Información retornada:**
  - Información relevante del libro (Id, Título, ISBN, Año, Sinopsis/Descripción).
  - Información detallada de su **Autor**.
  - Información detallada de su **Categoría**.

### 🔹 Query 3 – Consultar libros por categoría (`GetBooksByCategoryQuery`)
- **Propósito:** Filtrar y obtener todos los libros asociados a una categoría seleccionada (mediante su ID o identificador único).
- **Información retornada:**
  - Listado de libros pertenecientes a dicha categoría con información de autor y metadatos.

---

## 🏗️ 4. Estructura de la Solución (Clean Architecture - Estructura Inmoby)

```text
Entrega1-Libreria/
├── README.md                        # Documentación general de la Entrega 1
└── Microservices/
    └── Library/
        ├── Library.slnx             # Solución .NET 10
        ├── ef.cmd                   # Script auxiliar para Entity Framework Core
        │
        ├── Library.Domain/          # Núcleo: Entidades, Value Objects, Excepciones del Dominio
        │   ├── Entities/
        │   │   ├── Authors/         # Entidad Author
        │   │   ├── Categories/      # Entidad Category
        │   │   └── Books/           # Entidad Book (Agregado raíz con Id v7)
        │   └── Exceptions/          # DomainException
        │
        ├── Library.Application/     # Casos de uso CQRS, DTOs, Contratos y Mediador
        │   ├── Contracts/
        │   │   ├── Persistence/     # IUnitOfWork
        │   │   └── Repositories/    # IBooksRepository, IAuthorsRepository, ICategoriesRepository
        │   ├── UseCases/
        │   │   └── Books/
        │   │       └── Queries/
        │   │           ├── GetAllBooks/         # Query 1
        │   │           ├── GetBookById/         # Query 2
        │   │           ├── GetBooksByCategory/  # Query 3
        │   │           ├── BookListItemDTO.cs
        │   │           ├── BookDetailDTO.cs
        │   │           └── BookMapperExtensions.cs
        │   ├── Utilities/
        │   │   └── Mediator/        # IMediator, IRequest, IRequestHandler, SimpleMediator
        │   └── ApplicationServicesRegistry.cs
        │
        ├── Library.Persistence/     # EF Core, Contexto, Repositorios, Seeds
        │   ├── Configurations/      # Mapeos IEntityTypeConfiguration (Fluent API)
        │   ├── Repositories/        # Implementación de repositorios optimizados
        │   ├── Seeds/               # Seeders (Autores, Categorías, Libros iniciales)
        │   │   ├── DataBaseSeeder.cs
        │   │   ├── AuthorsSeeder.cs
        │   │   ├── CategoriesSeeder.cs
        │   │   └── BooksSeeder.cs
        │   ├── DataContext.cs       # DbContext
        │   └── PersistenceServicesRegistry.cs
        │
        ├── Library.Api/             # Controladores REST, OpenAPI, Configuración
        │   ├── Controllers/
        │   │   ├── BooksController.cs
        │   │   └── CategoriesController.cs
        │   ├── appsettings.json     # Cadena de conexión SQL Server
        │   └── Program.cs           # Pipeline HTTP y DataBaseSeeder
        │
        └── Library.Tests/           # Pruebas Unitarias Automatizadas
            ├── DomainEntityTests.cs # Pruebas de reglas de negocio DDD
            └── CqrsQueriesTests.cs  # Pruebas de las 3 Queries CQRS
```

---

## 🚀 5. Guía de Ejecución de la API

### Prerrequisitos
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Instancia de **SQL Server** o **LocalDB** activa.

### Ejecutar Pruebas
```bash
dotnet test Microservices/Library/Library.slnx
```

### Ejecutar la API
```bash
cd Microservices/Library/Library.Api
dotnet run
```
