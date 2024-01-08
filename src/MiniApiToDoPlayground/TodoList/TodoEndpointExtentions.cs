using MiniApiToDoPlayground.TodoList.CompleteTodo;
using MiniApiToDoPlayground.TodoList.CreateTodo;
using MiniApiToDoPlayground.TodoList.ListTodos;
using MiniApiToDoPlayground.TodoList.UpdateTodo;

namespace MiniApiToDoPlayground.TodoList;

internal static class TodoEndpointExtentions
{
    public static void AddTodoListServices(this IServiceCollection services)
    {
        services.AddScoped<IListTodosHandler, ListTodosHandler>();
        services.AddScoped<ICreateTodoHandler, CreateTodoHandler>();
        services.AddScoped<IUpdateTodoHandler, UpdateTodoHandler>();
        services.AddScoped<ICompleteTodoHandler, CompleteTodoHandler>();
    }

    public static void MapTodoListEndpoints(this WebApplication app)
    {
        var apiGroup = app.MapGroup("/api/todos");

        apiGroup.MapGet("/", (IListTodosHandler handler) => handler.GetAll());
        apiGroup.MapGet("/completed", (IListTodosHandler handler) => handler.GetAllComplete());
        apiGroup.MapGet("/{id}", (IListTodosHandler handler, int id) => handler.GetById(id));

        apiGroup.MapPost("/", (ICreateTodoHandler handler, CreateTodoRequest request) => handler.CreateNewTodo(request));

        apiGroup.MapPut("/{id}", (IUpdateTodoHandler handler, int id, UpdateTodoRequest request) => handler.UpdateTodo(id, request));
        apiGroup.MapPut("/{id}/complete", (ICompleteTodoHandler handler, int id) => handler.CompleteTodo(id));
    }
}
