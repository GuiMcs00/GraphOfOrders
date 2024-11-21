#

## User Cases

## Explaining the Solution

The solution is structured into multiple projects, each with distinct responsibilities, adhering to principles of separation of concerns and low coupling. This structure facilitates maintenance, testing, and scalability of the application.

## Lib

- **Framework**: netstandard2.0
- **Responsibilities**:
  - **Domain Entities**: The `Lib` project contains the domain entities which represent the data structure of the application.
  - **Shared Logic**: Any shared business logic or shared constants are located here.
- **Characteristics**:
  - **Reusability**: Designed for maximum reusability, can be referenced by various other projects.
  - **Decoupling**: Entities are persistence-agnostic, with no knowledge of database specifics.
- **Decoupling Method**: The project is kept free of data access or business logic code, promoting a clean separation between data structures and application logic.

## Repo

- **Framework**: net8.0
- **Responsibilities**:
  - **Data Access Logic**: Implements data retrieval and persistence mechanisms.
  - **DbContext**: Houses the Entity Framework DbContext class and configurations.
- **Characteristics**:
  - **Encapsulation**: Encapsulates data access code, providing a clear API for data operations to the rest of the application.
- **Decoupling Method**: References the `Lib` project for entities but does not dictate or presume application logic, aiding in a clear separation of concerns.

## Service

- **Framework**: net8.0
- **Responsibilities**:
  - **Business Logic**: Contains core business logic and rules of the application.
  - **Coordination**: Coordinates data retrieval and transformations, acting as a mediator between the data layer and the presentation layer.
- **Characteristics**:
  - **Centralization**: Acts as a centralized point for business rule enforcement.
- **Decoupling Method**: While it references both `Lib` and `Repo` projects, it does not depend on specific data access implementations or presentation layer concerns, maintaining a clean architectural boundary.

## Api

- **Framework**: net8.0
- **Responsibilities**:
  - **Request Handling**: Manages HTTP request and response cycle, serving as the application’s entry point.
  - **DTO Mapping**: Transforms domain entities to Data Transfer Objects (DTOs) for client consumption.
- **Characteristics**:
  - **Thin Layer**: The Api layer is kept as thin as possible, delegating business logic to the `Service` layer.
- **Decoupling Method**: Depends on the `Service` layer for business operations but remains agnostic to data access details, focusing solely on client interaction and data presentation.

## Test

- **Framework**: net8.0
- **Responsibilities**:
  - **Unit Testing**: Hosts unit tests for various components of the application.
  - **Integration Testing**: (if applicable) Contains tests that check the interaction between components.
- **Characteristics**:
  - **Validation**: Ensures the integrity and correctness of code in other projects through systematic testing.
- **Decoupling Method**: While tests are written to validate the functionality in `Lib`, `Repo`, `Service`, and `Api` projects, they are kept separate to ensure that test code does not interfere with application code.

## Using the Solution

### Setup

dotnet tool install --global dotnet-ef

### build and run postgresql container

```bash
docker run --name database -e POSTGRES_USER=user -e POSTGRES_PASSWORD=changeme -e POSTGRES_DB=graphdb -p 5432:5432 -v graphdbdata:/var/lib/postgresql/data:delegated -d postgres:alpine
```

### Creating migrations

```bash
dotnet ef migrations add CustomerAdded --project GraphOfOrders.Repo -s GraphOfOrders.Api --context OrdersContext --verbose
```

### running migrations

```bash
dotnet ef database update MigrationName -p GraphOfOrders.Repo -s GraphOfOrders.Api -c OrdersContext --verbose
```

#### Deleting migrations scripts
> [!CAUTION]
> To remove, remember to update the database with the last valid migration

```bash
dotnet ef migrations remove -p GraphOfOrders.Repo -s GraphOfOrders.Api -c OrdersContext --verbose
```

### Do you want to roll back the migrations applied because you messed up?
#### First of all. Undo changes to database

- Rolling back last one
```bash
dotnet ef database update ValidMigration --project GraphOfOrders.Repo -s GraphOfOrders.Api --context YourContext -v
```
- Rolling back every thing to specific db context
```bash
dotnet ef database update '0' --project GraphOfOrders.Repo -s GraphOfOrders.Api --context YourContext -v
```
#### Removing migration script

- Delete the last created migration script
```bash
dotnet ef migrations remove --project GraphOfOrders.Repo -s GraphOfOrders.Api --context AccountingContext -v 
```
> Keep running the above command until you reach desired migration script   

## Implementing new features

### Add new packages to projects

```bash
dotnet add GraphOfOrders.Service/GraphOfOrders.Service.csproj package Microsoft.Extensions.DependencyInjection
```

