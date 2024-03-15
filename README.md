# Basic Playground app for Todo list API using Minimal APIs

Nothing special here ... basic Todo list API using dotnet minimal apis.

The API uses Request-Response handlers for handling API responses. The API uses `MapGroup` to map grouped requests and separates out each request into the corresponding handler.

The API uses SQLite as the backing database with EF Core. There is an EF Core migration to generate the necessary table.


Endpoints - [use](src/MiniApiToDoPlayground/MiniApiToDoPlayground.http) for testing:

All Todo Items
> GET /api/todos/

All completed Todos:
> GET /api/todos/completed

Todo Item Id
> GET /api/todos/1

Create Todo
> POST /api/todos/

Update Todo
> PUT /api/todos/1

Complete Todo
> PUT /api/todos/1/complete

